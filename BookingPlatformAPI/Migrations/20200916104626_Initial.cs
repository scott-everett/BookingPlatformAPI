using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace BookingPlatformAPI.Migrations
{
    public partial class Initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Accounts",
                columns: table => new
                {
                    AccountId = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserFullName = table.Column<string>(nullable: false),
                    EmailAddress = table.Column<string>(nullable: false),
                    PasswordHash = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Accounts", x => x.AccountId);
                });

            migrationBuilder.CreateTable(
                name: "Rooms",
                columns: table => new
                {
                    RoomId = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Title = table.Column<string>(nullable: false),
                    Description = table.Column<string>(nullable: false),
                    Address = table.Column<string>(nullable: false),
                    SummaryLocation = table.Column<string>(nullable: false),
                    Capacity = table.Column<int>(nullable: false),
                    Price = table.Column<decimal>(type: "decimal(10,2)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Rooms", x => x.RoomId);
                });

            migrationBuilder.CreateTable(
                name: "RoomBookings",
                columns: table => new
                {
                    RoomBookingId = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RoomId = table.Column<long>(nullable: false),
                    AccountId = table.Column<long>(nullable: false),
                    StartDate = table.Column<DateTime>(nullable: false),
                    EndDate = table.Column<DateTime>(nullable: false),
                    PersonCount = table.Column<int>(nullable: false),
                    CalculatedPrice = table.Column<decimal>(type: "decimal(10,2)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RoomBookings", x => x.RoomBookingId);
                    table.ForeignKey(
                        name: "FK_RoomBookings_Accounts_AccountId",
                        column: x => x.AccountId,
                        principalTable: "Accounts",
                        principalColumn: "AccountId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_RoomBookings_Rooms_RoomId",
                        column: x => x.RoomId,
                        principalTable: "Rooms",
                        principalColumn: "RoomId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "RoomImages",
                columns: table => new
                {
                    RoomImageId = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RoomId = table.Column<long>(nullable: false),
                    ImageDex = table.Column<int>(nullable: false),
                    Filename = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RoomImages", x => x.RoomImageId);
                    table.ForeignKey(
                        name: "FK_RoomImages_Rooms_RoomId",
                        column: x => x.RoomId,
                        principalTable: "Rooms",
                        principalColumn: "RoomId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Rooms",
                columns: new[] { "RoomId", "Address", "Capacity", "Description", "Price", "SummaryLocation", "Title" },
                values: new object[,]
                {
                    { 1L, "Hamilton Avenue, Surfers Paradise 4217, Gold Coast, Australia", 2, "Q1 Resort & Spa’s Skypoint Observation Deck rises 230 m above Surfers Paradise, with 360° views over the Gold Coast hinterland, Pacific Ocean and Byron Bay. Recreation options include the Q1 Spa, heated lap pool, 2 lagoon swimming pools and a private mini theatre.<br/><br/>The luxury Q1 Tower Gold Coast apartments each feature a kitchen, laundry facilities and a TV with cable channels. All accommodation features a spa bath as well as access to free on - site parking.Some also offer a balcony or panoramic ocean views.<br/><br/>As of May 2017, Q1 Resort and Spa Gold Coast now offers a Presidential Penthouse, taking up an entire level, 1020 square metres in size and boasting a unique swimming pool, 2 roof - top balconies, and floor - to - ceiling glass walls and windows that’s deliver unsurpassed views of the Pacific Ocean, Gold Coast and beyond. There is a Swedish sauna and a private theatre with luxurious lounges, a 75-inch wall-mounted 3D LCD Smart TV and surround-sound.<br/><br/>There are 4 restaurants on-site, namely Asami Teppanyaki, Skypoint Observation Deck - Bistro & Bar, Longboards Eatery & Bar and Osaka Kaiten Sushi.Limited Chinese speaking staff are available.<br/><br/>This is our guests' favourite part of Gold Coast, according to independent reviews.<br/><br/>Couples particularly like the location — they rated it 9.1 for a two-person trip.<br/><br/>We speak your language!", 220m, "Surfers Paradise, Gold Coast", "Q1 Resort & Spa" },
                    { 2L, "2 Cunningham Street, Sydney CBD, 2000 Sydney, Australia", 3, "APX World Square offers spacious apartments with a private balcony and full kitchen in the heart of Sydney CBD(Central Business District). APX World Square is a 5-minute walk from the shopping and entertainment of Chinatown and Darling Harbour.It is 10 minutes’ walk to Central Station, providing easy access to all Sydney’s attractions. <br/><br/>Each fully air-conditioned apartment at APX World Square features a private bathroom and laundry facilities.The large living and dining areas include a flat-screen TV. <br/><br/>The property offers a breakfast pack, comprised of cereal, milk, juice and muffin.", 144m, "Sydney CBD", "APX World Square" },
                    { 3L, "Port Douglas Road, 4877 Port Douglas, Australia", 4, "Just a 1 hour drive from international Cairns airport, Sheraton Grand Mirage Resort, Port Douglas boats a prime location as the only beachfront property to the Famous Four Mile Beach.Surrounded by 147 hectares of lush tropical gardens, the property features 2 hectares of sparkling saltwater lagoon pools, an 18 - hole golf course and 5 - star resort amenities. <br/><br/>The 5 - star rooms, suites and villas afford captivating views of the lagoon pools or tropical gardens and select rooms with private/swim out balconies.", 299m, "Port Douglas", "Sheraton Grand Mirage Resort, Port Douglas" },
                    { 4L, "Gin Gin Hotel 66 Mulgrave Street, 4671 Gin Gin, Australia", 2, "Gin Gin Budget Accommodation offers an onsite bar and a restaurant which is open 7 days for lunch and dinner.Free private parking and free WiFi is available on site. <br/><br/>Every room at this hotel is air conditioned and is fitted with a TV. The full serviced kitchenette includes complimentary continental style breakfast with tea and coffee making facilities.", 89m, "Gin Gin", "Gin Gin Budget Accommodation" },
                    { 5L, " 104 South Wharf Drive, Docklands, 3008 Melbourne, Australia", 4, "Boasting lake views, Waterfront Luxury Townhouse offers accommodation with a terrace and a balcony, around 2.2 km from Marvel Stadium. Guests may enjoy free WiFi. <br/><br/>The air conditioned apartment consists of 3 bedrooms, a living room, a fully equipped kitchen with a dishwasher and a coffee machine, and 1 bathroom with a hot tub.", 8436m, "Docklands, Melbourne", "Docklands Waterfront Luxury Villa" }
                });

            migrationBuilder.InsertData(
                table: "RoomImages",
                columns: new[] { "RoomImageId", "Filename", "ImageDex", "RoomId" },
                values: new object[,]
                {
                    { 1L, "72033222.jpg", 1, 1L },
                    { 16L, "206948065.jpg", 2, 5L },
                    { 15L, "166344973.jpg", 1, 5L },
                    { 14L, "263867987.jpg", 3, 4L },
                    { 13L, "263868037.jpg", 2, 4L },
                    { 12L, "75755370.jpg", 1, 4L },
                    { 11L, "263171495.jpg", 3, 3L },
                    { 10L, "263171492.jpg", 2, 3L },
                    { 9L, "239136494.jpg", 1, 3L },
                    { 8L, "138004914.jpg", 4, 2L },
                    { 7L, "138004893.jpg", 3, 2L },
                    { 6L, "233917557.jpg", 2, 2L },
                    { 5L, "262122035.jpg", 1, 2L },
                    { 4L, "97867168.jpg", 4, 1L },
                    { 3L, "129833711.jpg", 3, 1L },
                    { 2L, "242251694.jpg", 2, 1L },
                    { 17L, "204597424.jpg", 3, 5L },
                    { 18L, "206947684.jpg", 4, 5L }
                });

            migrationBuilder.CreateIndex(
                name: "IX_RoomBookings_AccountId",
                table: "RoomBookings",
                column: "AccountId");

            migrationBuilder.CreateIndex(
                name: "IX_RoomBookings_RoomId",
                table: "RoomBookings",
                column: "RoomId");

            migrationBuilder.CreateIndex(
                name: "IX_RoomImages_RoomId",
                table: "RoomImages",
                column: "RoomId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "RoomBookings");

            migrationBuilder.DropTable(
                name: "RoomImages");

            migrationBuilder.DropTable(
                name: "Accounts");

            migrationBuilder.DropTable(
                name: "Rooms");
        }
    }
}
