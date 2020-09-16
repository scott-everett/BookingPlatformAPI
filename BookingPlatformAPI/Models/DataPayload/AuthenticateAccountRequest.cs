using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BookingPlatformAPI.Models.DataPayload
{
    public class AuthenticateAccountRequest
    {
        public string EmailAddress { get; set; }
        public string Password { get; set; }
    }
}
