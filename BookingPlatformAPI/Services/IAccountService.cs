using BookingPlatformAPI.Models.DataPayload;
using System.Security.Claims;

namespace BookingPlatformAPI.Services
{
    public interface IAccountService
    {
        AuthenticateAccountResponse Authenticate(AuthenticateAccountRequest request);
        long? GetAccountIdFromClaimsPrincipal(ClaimsPrincipal claimsPrincipal);
        AuthenticateAccountResponse Register(RegisterAccountRequest request);
    }
}