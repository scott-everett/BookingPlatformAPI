using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace BookingPlatformAPI.Models
{
    public class Account
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public long AccountId { get; set; }

        [Required]
        public string UserFullName { get; set; }  // Normally expanded into first name, last name etc.

        [Required]
        public string EmailAddress { get; set; }

        [Required]
        public string PasswordHash { get; set; }

        // Other account details may be added here...

        // Navigation properties
        public virtual ICollection<RoomBooking> RoomBookings { get; set; }
    }
}
