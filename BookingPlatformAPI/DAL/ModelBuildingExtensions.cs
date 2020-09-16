using BookingPlatformAPI.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BookingPlatformAPI.DAL
{
    public static class ModelBuildingExtensions
    {
        public static void Seed(this ModelBuilder modelBuilder)
        {
            string newParagraph = "<br/><br/>";

            modelBuilder.Entity<Room>().HasData(
                new Room
                {
                    RoomId = 1,
                    Title = "Q1 Resort & Spa",
                    Description =
                        "Q1 Resort & Spa’s Skypoint Observation Deck rises 230 m above Surfers Paradise, " +
                        "with 360° views over the Gold Coast hinterland, Pacific Ocean and Byron Bay. Recreation options include the Q1 Spa, heated lap pool, 2 lagoon swimming pools and a private mini theatre." + 
                        newParagraph +
                        "The luxury Q1 Tower Gold Coast apartments each feature a kitchen, laundry facilities " +
                        "and a TV with cable channels. All accommodation features a spa bath as well as " +
                        "access to free on - site parking.Some also offer a balcony or panoramic ocean views." +
                        newParagraph +
                        "As of May 2017, Q1 Resort and Spa Gold Coast now offers a Presidential Penthouse, " +
                        "taking up an entire level, 1020 square metres in size and boasting a unique swimming pool, " +
                        "2 roof - top balconies, and floor - to - ceiling glass walls and windows that’s deliver unsurpassed views of the Pacific Ocean, " +
                        "Gold Coast and beyond. There is a Swedish sauna and a private theatre with luxurious lounges, " +
                        "a 75-inch wall-mounted 3D LCD Smart TV and surround-sound." +
                        newParagraph +
                        "There are 4 restaurants on-site, namely Asami Teppanyaki, Skypoint Observation Deck - Bistro & Bar, " +
                        "Longboards Eatery & Bar and Osaka Kaiten Sushi.Limited Chinese speaking staff are available." +
                        newParagraph +
                        "This is our guests' favourite part of Gold Coast, according to independent reviews." +
                        newParagraph +
                        "Couples particularly like the location — they rated it 9.1 for a two-person trip." +
                        newParagraph +
                        "We speak your language!",
                    Address = "Hamilton Avenue, Surfers Paradise 4217, Gold Coast, Australia",
                    SummaryLocation = "Surfers Paradise, Gold Coast",
                    Capacity = 2,
                    Price = 220M
                },

                new Room
                {
                    RoomId = 2,
                    Title = "APX World Square",
                    Description =
                    "APX World Square offers spacious apartments with a private balcony and full kitchen in the heart of Sydney CBD(Central Business District). " +
                    "APX World Square is a 5-minute walk from the shopping and entertainment of Chinatown and Darling Harbour.It is 10 minutes’ walk to Central Station, providing easy access to all Sydney’s attractions. " +
                    newParagraph +
                    "Each fully air-conditioned apartment at APX World Square features a private bathroom and laundry facilities.The large living and dining areas include a flat-screen TV. " +
                    newParagraph +
                    "The property offers a breakfast pack, comprised of cereal, milk, juice and muffin.",
                    Address = "2 Cunningham Street, Sydney CBD, 2000 Sydney, Australia",
                    SummaryLocation = "Sydney CBD",
                    Capacity = 3,
                    Price = 144M
                },

                new Room
                {
                    RoomId = 3,
                    Title = "Sheraton Grand Mirage Resort, Port Douglas",
                    Description =
                    "Just a 1 hour drive from international Cairns airport, " +
                    "Sheraton Grand Mirage Resort, " +
                    "Port Douglas boats a prime location as the only beachfront property to the Famous Four Mile Beach.Surrounded by 147 hectares of lush tropical gardens, " +
                    "the property features 2 hectares of sparkling saltwater lagoon pools, " +
                    "an 18 - hole golf course and 5 - star resort amenities. " +
                    newParagraph + 
                    "The 5 - star rooms, suites and villas afford captivating views of the lagoon pools or tropical gardens and select rooms with private/swim out balconies.",
                    Address = "Port Douglas Road, 4877 Port Douglas, Australia",
                    SummaryLocation = "Port Douglas",
                    Capacity = 4,
                    Price = 299M
                },

                new Room
                {
                    RoomId = 4,
                    Title = "Gin Gin Budget Accommodation",
                    Description =
                    @"Gin Gin Budget Accommodation offers an onsite bar and a restaurant which is open 7 days for lunch and dinner.Free private parking and free WiFi is available on site. " +
                    newParagraph + 
                    "Every room at this hotel is air conditioned and is fitted with a TV. " +
                    "The full serviced kitchenette includes complimentary continental style breakfast with tea and coffee making facilities.",
                    Address = "Gin Gin Hotel 66 Mulgrave Street, 4671 Gin Gin, Australia",
                    SummaryLocation = "Gin Gin",
                    Capacity = 2,
                    Price = 89M
                },
                new Room
                {
                    RoomId = 5,
                    Title = "Docklands Waterfront Luxury Villa",
                    Description =
                    @"Boasting lake views, Waterfront Luxury Townhouse offers accommodation with a terrace and a balcony, around 2.2 km from Marvel Stadium. Guests may enjoy free WiFi. " +
                    newParagraph + 
                    "The air conditioned apartment consists of 3 bedrooms, a living room, a fully equipped kitchen with a dishwasher and a coffee machine, and 1 bathroom with a hot tub.",
                    Address = " 104 South Wharf Drive, Docklands, 3008 Melbourne, Australia",
                    SummaryLocation = "Docklands, Melbourne",
                    Capacity = 4,
                    Price = 8436M
                }

            ); 

            modelBuilder.Entity<RoomImage>().HasData(
                new RoomImage { RoomImageId = 1, RoomId = 1, ImageDex = 1, Filename = "72033222.jpg" },
                new RoomImage { RoomImageId = 2, RoomId = 1, ImageDex = 2, Filename = "242251694.jpg" },
                new RoomImage { RoomImageId = 3, RoomId = 1, ImageDex = 3, Filename = "129833711.jpg" },
                new RoomImage { RoomImageId = 4, RoomId = 1, ImageDex = 4, Filename = "97867168.jpg" },
                new RoomImage { RoomImageId = 5, RoomId = 2, ImageDex = 1, Filename = "262122035.jpg" },
                new RoomImage { RoomImageId = 6, RoomId = 2, ImageDex = 2, Filename = "233917557.jpg" },
                new RoomImage { RoomImageId = 7, RoomId = 2, ImageDex = 3, Filename = "138004893.jpg" },
                new RoomImage { RoomImageId = 8, RoomId = 2, ImageDex = 4, Filename = "138004914.jpg" },
                new RoomImage { RoomImageId = 9, RoomId = 3, ImageDex = 1, Filename = "239136494.jpg" },
                new RoomImage { RoomImageId = 10, RoomId = 3, ImageDex = 2, Filename = "263171492.jpg" },
                new RoomImage { RoomImageId = 11, RoomId = 3, ImageDex = 3, Filename = "263171495.jpg" },
                new RoomImage { RoomImageId = 12, RoomId = 4, ImageDex = 1, Filename = "75755370.jpg" },
                new RoomImage { RoomImageId = 13, RoomId = 4, ImageDex = 2, Filename = "263868037.jpg" },
                new RoomImage { RoomImageId = 14, RoomId = 4, ImageDex = 3, Filename = "263867987.jpg" },
                new RoomImage { RoomImageId = 15, RoomId = 5, ImageDex = 1, Filename = "166344973.jpg" },
                new RoomImage { RoomImageId = 16, RoomId = 5, ImageDex = 2, Filename = "206948065.jpg" },
                new RoomImage { RoomImageId = 17, RoomId = 5, ImageDex = 3, Filename = "204597424.jpg" },
                new RoomImage { RoomImageId = 18, RoomId = 5, ImageDex = 4, Filename = "206947684.jpg" }
            );
        }
    }
}
