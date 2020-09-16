using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BookingPlatformAPI.Models.DataPayload
{
    public class AuthenticateAccountResponse
    {
        public long AccountId { get; set; }
        public string UserFullName { get; set; }  // Normally expanded into first name, last name etc.
        public string EmailAddress { get; set; }
        public string AccessToken { get; set; }
    }
}
