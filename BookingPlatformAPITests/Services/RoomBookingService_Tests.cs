using BookingPlatformAPI.DAL;
using BookingPlatformAPI.Models;
using BookingPlatformAPI.Services;
using Castle.Core.Logging;
using Microsoft.Data.Sqlite;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Moq;
using NUnit.Framework;
using NUnit.Framework.Internal;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BookingPlatformAPITests.Services
{
    class RoomBookingService_Tests
    {
        // Some test accounts
        private readonly List<Account> _testAccounts = new List<Account>
        {
            new Account { AccountId = 1, UserFullName = "Account1", EmailAddress = "a@a.com1", PasswordHash = "XXX" },
            new Account { AccountId = 2, UserFullName = "Account2", EmailAddress = "a@a.com1", PasswordHash = "XXX" },
            new Account { AccountId = 3, UserFullName = "Account3", EmailAddress = "a@a.com1", PasswordHash = "XXX" },
            new Account { AccountId = 4, UserFullName = "Account4", EmailAddress = "a@a.com1", PasswordHash = "XXX" },
        };

        // Some test rooms
        private readonly List<Room> _testRooms = new List<Room>
        {
            new Room { RoomId = 1, Title = "Room1", Description = "", Address = "", SummaryLocation = "", Capacity = 2, Price = 100 },
            new Room { RoomId = 2, Title = "Room2", Description = "", Address = "", SummaryLocation = "", Capacity = 4, Price = 150 },
            new Room { RoomId = 3, Title = "Room3", Description = "", Address = "", SummaryLocation = "", Capacity = 6, Price = 300 },
            new Room { RoomId = 4, Title = "Room4", Description = "", Address = "", SummaryLocation = "", Capacity = 2, Price = 700 },
        };

        [Test]
        public void Test_RoomBookingsForAccount()
        {
            // -- Arrange --
            var connection = new SqliteConnection("DataSource=:memory:");
            connection.Open();

            // We are using  TestDataContext to prevent database seeding
            var options = new DbContextOptionsBuilder<DataContext>().UseSqlite(connection).Options;

            var context = new TestDataContext(options);
            context.Database.EnsureCreated();

            // Add some test accounts
            context.Accounts.AddRange(_testAccounts);
            context.SaveChanges();

            // Add some test rooms
            context.Rooms.AddRange(_testRooms);
            context.SaveChanges();

            // Add some test bookings
            List<RoomBooking> testRoomBookings = new List<RoomBooking>
            {
                new RoomBooking { RoomBookingId = 1, AccountId = 1, RoomId = 2, StartDate = DateTime.MinValue, EndDate = DateTime.MinValue, PersonCount = 2, CalculatedPrice = 0 },
                new RoomBooking { RoomBookingId = 2, AccountId = 1, RoomId = 3, StartDate = DateTime.MinValue, EndDate = DateTime.MinValue, PersonCount = 2, CalculatedPrice = 0 },
                new RoomBooking { RoomBookingId = 3, AccountId = 1, RoomId = 4, StartDate = DateTime.MinValue, EndDate = DateTime.MinValue, PersonCount = 2, CalculatedPrice = 0 },
                new RoomBooking { RoomBookingId = 4, AccountId = 2, RoomId = 1, StartDate = DateTime.MinValue, EndDate = DateTime.MinValue, PersonCount = 2, CalculatedPrice = 0 },
                new RoomBooking { RoomBookingId = 5, AccountId = 2, RoomId = 4, StartDate = DateTime.MinValue, EndDate = DateTime.MinValue, PersonCount = 2, CalculatedPrice = 0 },
                new RoomBooking { RoomBookingId = 6, AccountId = 3, RoomId = 1, StartDate = DateTime.MinValue, EndDate = DateTime.MinValue, PersonCount = 2, CalculatedPrice = 0 },
            };

            context.RoomBookings.AddRange(testRoomBookings);
            context.SaveChanges();

            // Set up mocks ready to create the RoomBookingService
            var mockLogger = new Mock<ILogger<RoomBookingService>>();

            // If we need to mock any ILogger properties then do that here...

            // Create the RoomBookingService object for testing
            var roomBookingService = new RoomBookingService(mockLogger.Object, context);

            // -- Act --
            var result = roomBookingService.RoomBookingsForAccount(2).ToList();

            // -- Assert --
            Assert.IsTrue(result.Count() == 2, "Unexpected number of bookings returned!");
            CollectionAssert.AreEquivalent(new long[] { 4, 5 }, result.Select(b => b.RoomBookingId).OrderBy(b => b), "Unexpected booking details returned!");

            connection.Close();
        }
    }
}
