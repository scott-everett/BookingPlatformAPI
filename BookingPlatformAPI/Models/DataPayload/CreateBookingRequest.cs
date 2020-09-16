using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BookingPlatformAPI.Models.DataPayload
{
    public class CreateBookingRequest
    {
        public long RoomId { get; set; }
        public long AccountId { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public int PersonCount { get; set; }
    }
}
