using BookingPlatformAPI.Models;
using System.Collections.Generic;

namespace BookingPlatformAPI.Services
{
    public interface IRoomService
    {
        IEnumerable<RoomImage> RoomImagesForRoom(long roomId);
        IEnumerable<Room> Rooms();
    }
}