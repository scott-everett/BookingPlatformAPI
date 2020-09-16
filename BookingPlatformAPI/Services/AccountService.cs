using BC = BCrypt.Net.BCrypt;
using BookingPlatformAPI.Models;
using BookingPlatformAPI.Models.DataPayload;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BookingPlatformAPI.DAL;
using System.Net.Http;
using System.Security;
using Microsoft.IdentityModel.Tokens;
using System.Text;
using System.Security.Claims;
using System.IdentityModel.Tokens.Jwt;
using Microsoft.Extensions.Configuration;
using BookingPlatformAPI.Helpers;
using Microsoft.Extensions.Logging;

namespace BookingPlatformAPI.Services
{
    public class AccountService : IAccountService
    {
        private readonly ILogger _logger;
        private readonly DataContext _context;
        private readonly IConfiguration _config;

        public AccountService(ILogger<AccountService> logger, DataContext context, IConfiguration config)
        {
            _logger = logger;
            _context = context;
            _config = config;
        }

        public AuthenticateAccountResponse Register(RegisterAccountRequest request)
        {
            if (_context.Accounts.Any(x => x.EmailAddress == request.EmailAddress))
            {
                // There is already an account with given email address
                throw new AccountAlreadyExistsException();
            }

            // Create new account object from the request model
            var account = new Account()
            {
                UserFullName = request.UserFullName,
                EmailAddress = request.EmailAddress,
                PasswordHash = BC.HashPassword(request.Password)
            };

            // Save account
            _context.Accounts.Add(account);
            _context.SaveChanges();

            // Create a response that includes the access token
            var response = new AuthenticateAccountResponse
            {
                AccountId = account.AccountId,
                UserFullName = account.UserFullName,
                EmailAddress = account.EmailAddress,
                AccessToken = GenerateJsonWebToken(account)
            };

            return response;
        }

        public AuthenticateAccountResponse Authenticate(AuthenticateAccountRequest request)
        {
            // Get the account if it exists
            var account = _context.Accounts.SingleOrDefault(x => x.EmailAddress == request.EmailAddress);

            // Gernerate password hash and test.  Throw exception if email doesn't exists or password incorrect
            if (account == null || !BC.Verify(request.Password, account.PasswordHash))
                throw new AuthenticationFailedException();

            // Create a response that includes the access token
            var response = new AuthenticateAccountResponse
            {
                AccountId = account.AccountId,
                UserFullName = account.UserFullName,
                EmailAddress = account.EmailAddress,
                AccessToken = GenerateJsonWebToken(account)
            };

            return response;
        }

        // Gets the account id from the claims principal
        public long? GetAccountIdFromClaimsPrincipal(ClaimsPrincipal claimsPrincipal)
        {
            var accountIdString = claimsPrincipal?.FindFirst("Jti")?.Value;

            if (accountIdString == null && accountIdString.Length == 0)
                return null;

            return long.Parse(accountIdString);
        }

        private string GenerateJsonWebToken(Account account)
        {
            var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_config["Jwt:Key"]));
            var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);

            var claims = new[]
            {
                new Claim(JwtRegisteredClaimNames.Jti, account.AccountId.ToString()),
                new Claim(JwtRegisteredClaimNames.Sub, account.UserFullName),
                new Claim(JwtRegisteredClaimNames.Email, account.EmailAddress)
            };

            // Note - there is no refresh token and access token never expires!
            // Not good practice, but simplifies demo
            var token = new JwtSecurityToken(
                issuer: _config["Jwt:Issuer"],
                audience: _config["Jwt:Issuer"],
                claims: claims,
                expires: DateTime.MaxValue,
                signingCredentials: credentials);

            var encodetoken = new JwtSecurityTokenHandler().WriteToken(token);
            return encodetoken;
        }
    }
}
