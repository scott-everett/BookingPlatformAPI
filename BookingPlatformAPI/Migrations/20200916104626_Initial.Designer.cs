﻿// <auto-generated />
using System;
using BookingPlatformAPI.DAL;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace BookingPlatformAPI.Migrations
{
    [DbContext(typeof(DataContext))]
    [Migration("20200916104626_Initial")]
    partial class Initial
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "3.1.8")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("BookingPlatformAPI.Models.Account", b =>
                {
                    b.Property<long>("AccountId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("EmailAddress")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PasswordHash")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("UserFullName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("AccountId");

                    b.ToTable("Accounts");
                });

            modelBuilder.Entity("BookingPlatformAPI.Models.Room", b =>
                {
                    b.Property<long>("RoomId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Address")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Capacity")
                        .HasColumnType("int");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<decimal>("Price")
                        .HasColumnType("decimal(10,2)");

                    b.Property<string>("SummaryLocation")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("RoomId");

                    b.ToTable("Rooms");

                    b.HasData(
                        new
                        {
                            RoomId = 1L,
                            Address = "Hamilton Avenue, Surfers Paradise 4217, Gold Coast, Australia",
                            Capacity = 2,
                            Description = "Q1 Resort & Spa’s Skypoint Observation Deck rises 230 m above Surfers Paradise, with 360° views over the Gold Coast hinterland, Pacific Ocean and Byron Bay. Recreation options include the Q1 Spa, heated lap pool, 2 lagoon swimming pools and a private mini theatre.<br/><br/>The luxury Q1 Tower Gold Coast apartments each feature a kitchen, laundry facilities and a TV with cable channels. All accommodation features a spa bath as well as access to free on - site parking.Some also offer a balcony or panoramic ocean views.<br/><br/>As of May 2017, Q1 Resort and Spa Gold Coast now offers a Presidential Penthouse, taking up an entire level, 1020 square metres in size and boasting a unique swimming pool, 2 roof - top balconies, and floor - to - ceiling glass walls and windows that’s deliver unsurpassed views of the Pacific Ocean, Gold Coast and beyond. There is a Swedish sauna and a private theatre with luxurious lounges, a 75-inch wall-mounted 3D LCD Smart TV and surround-sound.<br/><br/>There are 4 restaurants on-site, namely Asami Teppanyaki, Skypoint Observation Deck - Bistro & Bar, Longboards Eatery & Bar and Osaka Kaiten Sushi.Limited Chinese speaking staff are available.<br/><br/>This is our guests' favourite part of Gold Coast, according to independent reviews.<br/><br/>Couples particularly like the location — they rated it 9.1 for a two-person trip.<br/><br/>We speak your language!",
                            Price = 220m,
                            SummaryLocation = "Surfers Paradise, Gold Coast",
                            Title = "Q1 Resort & Spa"
                        },
                        new
                        {
                            RoomId = 2L,
                            Address = "2 Cunningham Street, Sydney CBD, 2000 Sydney, Australia",
                            Capacity = 3,
                            Description = "APX World Square offers spacious apartments with a private balcony and full kitchen in the heart of Sydney CBD(Central Business District). APX World Square is a 5-minute walk from the shopping and entertainment of Chinatown and Darling Harbour.It is 10 minutes’ walk to Central Station, providing easy access to all Sydney’s attractions. <br/><br/>Each fully air-conditioned apartment at APX World Square features a private bathroom and laundry facilities.The large living and dining areas include a flat-screen TV. <br/><br/>The property offers a breakfast pack, comprised of cereal, milk, juice and muffin.",
                            Price = 144m,
                            SummaryLocation = "Sydney CBD",
                            Title = "APX World Square"
                        },
                        new
                        {
                            RoomId = 3L,
                            Address = "Port Douglas Road, 4877 Port Douglas, Australia",
                            Capacity = 4,
                            Description = "Just a 1 hour drive from international Cairns airport, Sheraton Grand Mirage Resort, Port Douglas boats a prime location as the only beachfront property to the Famous Four Mile Beach.Surrounded by 147 hectares of lush tropical gardens, the property features 2 hectares of sparkling saltwater lagoon pools, an 18 - hole golf course and 5 - star resort amenities. <br/><br/>The 5 - star rooms, suites and villas afford captivating views of the lagoon pools or tropical gardens and select rooms with private/swim out balconies.",
                            Price = 299m,
                            SummaryLocation = "Port Douglas",
                            Title = "Sheraton Grand Mirage Resort, Port Douglas"
                        },
                        new
                        {
                            RoomId = 4L,
                            Address = "Gin Gin Hotel 66 Mulgrave Street, 4671 Gin Gin, Australia",
                            Capacity = 2,
                            Description = "Gin Gin Budget Accommodation offers an onsite bar and a restaurant which is open 7 days for lunch and dinner.Free private parking and free WiFi is available on site. <br/><br/>Every room at this hotel is air conditioned and is fitted with a TV. The full serviced kitchenette includes complimentary continental style breakfast with tea and coffee making facilities.",
                            Price = 89m,
                            SummaryLocation = "Gin Gin",
                            Title = "Gin Gin Budget Accommodation"
                        },
                        new
                        {
                            RoomId = 5L,
                            Address = " 104 South Wharf Drive, Docklands, 3008 Melbourne, Australia",
                            Capacity = 4,
                            Description = "Boasting lake views, Waterfront Luxury Townhouse offers accommodation with a terrace and a balcony, around 2.2 km from Marvel Stadium. Guests may enjoy free WiFi. <br/><br/>The air conditioned apartment consists of 3 bedrooms, a living room, a fully equipped kitchen with a dishwasher and a coffee machine, and 1 bathroom with a hot tub.",
                            Price = 8436m,
                            SummaryLocation = "Docklands, Melbourne",
                            Title = "Docklands Waterfront Luxury Villa"
                        });
                });

            modelBuilder.Entity("BookingPlatformAPI.Models.RoomBooking", b =>
                {
                    b.Property<long>("RoomBookingId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<long>("AccountId")
                        .HasColumnType("bigint");

                    b.Property<decimal>("CalculatedPrice")
                        .HasColumnType("decimal(10,2)");

                    b.Property<DateTime>("EndDate")
                        .HasColumnType("datetime2");

                    b.Property<int>("PersonCount")
                        .HasColumnType("int");

                    b.Property<long>("RoomId")
                        .HasColumnType("bigint");

                    b.Property<DateTime>("StartDate")
                        .HasColumnType("datetime2");

                    b.HasKey("RoomBookingId");

                    b.HasIndex("AccountId");

                    b.HasIndex("RoomId");

                    b.ToTable("RoomBookings");
                });

            modelBuilder.Entity("BookingPlatformAPI.Models.RoomImage", b =>
                {
                    b.Property<long>("RoomImageId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Filename")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("ImageDex")
                        .HasColumnType("int");

                    b.Property<long>("RoomId")
                        .HasColumnType("bigint");

                    b.HasKey("RoomImageId");

                    b.HasIndex("RoomId");

                    b.ToTable("RoomImages");

                    b.HasData(
                        new
                        {
                            RoomImageId = 1L,
                            Filename = "72033222.jpg",
                            ImageDex = 1,
                            RoomId = 1L
                        },
                        new
                        {
                            RoomImageId = 2L,
                            Filename = "242251694.jpg",
                            ImageDex = 2,
                            RoomId = 1L
                        },
                        new
                        {
                            RoomImageId = 3L,
                            Filename = "129833711.jpg",
                            ImageDex = 3,
                            RoomId = 1L
                        },
                        new
                        {
                            RoomImageId = 4L,
                            Filename = "97867168.jpg",
                            ImageDex = 4,
                            RoomId = 1L
                        },
                        new
                        {
                            RoomImageId = 5L,
                            Filename = "262122035.jpg",
                            ImageDex = 1,
                            RoomId = 2L
                        },
                        new
                        {
                            RoomImageId = 6L,
                            Filename = "233917557.jpg",
                            ImageDex = 2,
                            RoomId = 2L
                        },
                        new
                        {
                            RoomImageId = 7L,
                            Filename = "138004893.jpg",
                            ImageDex = 3,
                            RoomId = 2L
                        },
                        new
                        {
                            RoomImageId = 8L,
                            Filename = "138004914.jpg",
                            ImageDex = 4,
                            RoomId = 2L
                        },
                        new
                        {
                            RoomImageId = 9L,
                            Filename = "239136494.jpg",
                            ImageDex = 1,
                            RoomId = 3L
                        },
                        new
                        {
                            RoomImageId = 10L,
                            Filename = "263171492.jpg",
                            ImageDex = 2,
                            RoomId = 3L
                        },
                        new
                        {
                            RoomImageId = 11L,
                            Filename = "263171495.jpg",
                            ImageDex = 3,
                            RoomId = 3L
                        },
                        new
                        {
                            RoomImageId = 12L,
                            Filename = "75755370.jpg",
                            ImageDex = 1,
                            RoomId = 4L
                        },
                        new
                        {
                            RoomImageId = 13L,
                            Filename = "263868037.jpg",
                            ImageDex = 2,
                            RoomId = 4L
                        },
                        new
                        {
                            RoomImageId = 14L,
                            Filename = "263867987.jpg",
                            ImageDex = 3,
                            RoomId = 4L
                        },
                        new
                        {
                            RoomImageId = 15L,
                            Filename = "166344973.jpg",
                            ImageDex = 1,
                            RoomId = 5L
                        },
                        new
                        {
                            RoomImageId = 16L,
                            Filename = "206948065.jpg",
                            ImageDex = 2,
                            RoomId = 5L
                        },
                        new
                        {
                            RoomImageId = 17L,
                            Filename = "204597424.jpg",
                            ImageDex = 3,
                            RoomId = 5L
                        },
                        new
                        {
                            RoomImageId = 18L,
                            Filename = "206947684.jpg",
                            ImageDex = 4,
                            RoomId = 5L
                        });
                });

            modelBuilder.Entity("BookingPlatformAPI.Models.RoomBooking", b =>
                {
                    b.HasOne("BookingPlatformAPI.Models.Account", null)
                        .WithMany("RoomBookings")
                        .HasForeignKey("AccountId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("BookingPlatformAPI.Models.Room", null)
                        .WithMany("RoomBookings")
                        .HasForeignKey("RoomId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("BookingPlatformAPI.Models.RoomImage", b =>
                {
                    b.HasOne("BookingPlatformAPI.Models.Room", null)
                        .WithMany("RoomImages")
                        .HasForeignKey("RoomId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });
#pragma warning restore 612, 618
        }
    }
}