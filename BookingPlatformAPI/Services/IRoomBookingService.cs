using BookingPlatformAPI.Models;
using BookingPlatformAPI.Models.DataPayload;
using System.Collections.Generic;

namespace BookingPlatformAPI.Services
{
    public interface IRoomBookingService
    {
        void CreateBooking(CreateBookingRequest request);
        IEnumerable<RoomBooking> RoomBookingsForAccount(long accountId);
    }
}