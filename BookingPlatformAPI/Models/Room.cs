using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace BookingPlatformAPI.Models
{
    public class Room
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public long RoomId { get; set; }

        [Required]
        public string Title { get; set; }

        [Required]
        public string Description { get; set; }

        [Required]
        public string Address { get; set; } // This would normally be expanded out into more fields...

        [Required]
        public string SummaryLocation { get; set; } // Location to be displayed on summary info

        [Required]
        public int Capacity { get; set; }

        [Column(TypeName = "decimal(10,2)")]
        public decimal Price { get; set; }


        // Navigation properties
        public virtual ICollection<RoomImage> RoomImages { get; set; }
        public virtual ICollection<RoomBooking> RoomBookings { get; set; }
    }
}
