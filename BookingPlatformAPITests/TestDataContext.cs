using BookingPlatformAPI.DAL;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace BookingPlatformAPITests
{
    class TestDataContext : DataContext
    {
        public TestDataContext(DbContextOptions<DataContext> options) : base(options) { }

        // We are overriding this so that database seeding is not used with this context
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
        }
    }
}
