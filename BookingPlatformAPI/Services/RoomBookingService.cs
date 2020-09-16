using BookingPlatformAPI.DAL;
using BookingPlatformAPI.Helpers;
using BookingPlatformAPI.Models;
using BookingPlatformAPI.Models.DataPayload;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BookingPlatformAPI.Services
{
    public class RoomBookingService : IRoomBookingService
    {
        private readonly ILogger _logger;
        private readonly DataContext _context;

        public RoomBookingService(ILogger<RoomBookingService> logger, DataContext context)
        {
            _logger = logger;
            _context = context;
        }

        // Creates a new booking
        public void CreateBooking(CreateBookingRequest request)
        {
            // Get the room  
            var room = _context.Rooms.Where(rb => rb.RoomId == request.RoomId).FirstOrDefault();

            // Was the room found?
            if (room == null)
                throw new NotFoundException();

            // Check to see if the room capacity is sufficient 
            if (request.PersonCount > room.Capacity || request.PersonCount < 1)
                throw new RoomCapacityInsufficentException();

            // Check to see if there are any conflicting bookings on the room
            if (_context.RoomBookings.Where(rb => rb.RoomId == request.RoomId &&
                rb.StartDate <= request.EndDate && rb.EndDate >= request.StartDate).ToList().Count > 0)
                throw new RoomNotAvailableException();

            // We are OK to insert the booking...
            var roomBooking = new RoomBooking
            {
                RoomId = request.RoomId,
                AccountId = request.AccountId,
                StartDate = request.StartDate,
                EndDate = request.EndDate,
                PersonCount = request.PersonCount,
                CalculatedPrice = CalculateBookingPrice(request.StartDate, request.EndDate, room.Price)
            };

            _context.RoomBookings.Add(roomBooking);
            _context.SaveChanges();
        }

        // Calculates the total booking price given the booking date range and price per day
        private decimal CalculateBookingPrice(DateTime startDate, DateTime endDate, decimal dailyRate)
        {
            return Math.Max((endDate - startDate).Days, 0) * dailyRate;
        }

        public IEnumerable<RoomBooking> RoomBookingsForAccount(long accountId)
        {
            return _context.RoomBookings.Where(rb => rb.AccountId == accountId).
                OrderBy(rb => rb.StartDate).ThenBy(rb => rb.EndDate);
        }
    }
}
