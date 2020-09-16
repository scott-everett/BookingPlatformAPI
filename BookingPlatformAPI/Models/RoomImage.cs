using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace BookingPlatformAPI.Models
{
    public class RoomImage
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public long RoomImageId { get; set; }

        [ForeignKey("Room")]
        public long RoomId { get; set; }

        [Required]
        public int ImageDex { get; set; }

        [Required]
        public string Filename { get; set; }
    }
}
