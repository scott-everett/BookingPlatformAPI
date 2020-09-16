using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Net;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Security;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using BookingPlatformAPI.Helpers;
using BookingPlatformAPI.Models;
using BookingPlatformAPI.Models.DataPayload;
using BookingPlatformAPI.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using Microsoft.IdentityModel.Tokens;

namespace BookingPlatformAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]/[action]")]
    public class AccountController : ControllerBase
    {
        private readonly ILogger _logger;
        private readonly IAccountService _accountService;

        public AccountController(ILogger<AccountController> logger, IAccountService accountService)
        {
            _logger = logger;
            _accountService = accountService;
        }

        [HttpPost]
        public ActionResult<AuthenticateAccountResponse> Login([FromBody]AuthenticateAccountRequest request)
        {
            // Authenticate the account
            try
            {
                var response = _accountService.Authenticate(request);
                _logger.LogInformation("(AccountId: {accountId}, EmailAddress: {emailAddress}) logged in successfully", response.AccountId, response.EmailAddress);

                return Ok(response);
            }
            catch (Exception e)
            {
                _logger.LogWarning(e, "Email address {emailAddress} login failed!", request.EmailAddress);

                // Default status code
                int httpStatusCode = (int)HttpStatusCode.InternalServerError;

                if (e is AuthenticationFailedException)
                {
                    // Status code if authentication failed
                    httpStatusCode = (int)HttpStatusCode.Unauthorized;
                }

                return StatusCode(httpStatusCode, e.GetType().Name);
            }
        }

        [HttpPost]
        public ActionResult<AuthenticateAccountResponse> Register([FromBody]RegisterAccountRequest request)
        {
            // Register the account
            try
            {
                var response = _accountService.Register(request);
                _logger.LogInformation("(AccountId: {accountId}, EmailAddress: {emailAddress}) registered successfully", response.AccountId, response.EmailAddress);
                return Ok(response);
            }
            catch (Exception e)
            {
                _logger.LogWarning(e, "Email address {emailAddress} registration failed!", request.EmailAddress);

                // Default status code
                int httpStatusCode = (int)HttpStatusCode.InternalServerError;

                if (e is AccountAlreadyExistsException)
                {
                    // Status code if account already exists
                    httpStatusCode = (int)HttpStatusCode.Conflict;
                }

                return StatusCode(httpStatusCode, e.GetType().Name);
            }
        }
    }
}
