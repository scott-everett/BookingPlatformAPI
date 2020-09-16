using BookingPlatformAPI.DAL;
using BookingPlatformAPI.Helpers;
using BookingPlatformAPI.Models;
using BookingPlatformAPI.Models.DataPayload;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BookingPlatformAPI.Services
{
    public class RoomService : IRoomService
    {
        private readonly ILogger _logger;
        private readonly DataContext _context;

        public RoomService(ILogger<RoomService> logger, DataContext context)
        {
            _logger = logger;
            _context = context;
        }

        public IEnumerable<Room> Rooms()
        {
            return _context.Rooms.Include(room => room.RoomImages);
        }

        public IEnumerable<RoomImage> RoomImagesForRoom(long roomId)
        {
            return _context.RoomImages.Where(ri => ri.RoomId == roomId);
        }
    }
}
