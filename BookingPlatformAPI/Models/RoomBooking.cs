using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace BookingPlatformAPI.Models
{
    public class RoomBooking
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public long RoomBookingId { get; set; }

        [ForeignKey("Room")]
        public long RoomId { get; set; }

        [ForeignKey("Account")]
        public long AccountId { get; set; }

        [Required]
        public DateTime StartDate { get; set; }

        [Required]
        public DateTime EndDate { get; set; }

        [Required]
        public int PersonCount { get; set; }

        [Required]
        [Column(TypeName = "decimal(10,2)")]
        public decimal CalculatedPrice { get; set; }
    }
}
