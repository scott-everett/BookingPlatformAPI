using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BookingPlatformAPI.Models.DataPayload
{
    public class RegisterAccountRequest
    {
        public string UserFullName { get; set; }  // Normally expanded into first name, last name etc.
        public string EmailAddress { get; set; }
        public string Password { get; set; }
    }
}
