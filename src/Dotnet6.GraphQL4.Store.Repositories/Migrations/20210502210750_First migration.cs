using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Dotnet6.GraphQL4.Store.Repositories.Migrations
{
    public partial class Firstmigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "ProductTypes",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Discriminator = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProductTypes", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Products",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(300)", maxLength: 300, nullable: true),
                    IntroduceAt = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Option = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PhotoUrl = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    Price = table.Column<decimal>(type: "decimal(10,2)", precision: 10, scale: 2, nullable: false),
                    ProductTypeId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    Rating = table.Column<int>(type: "int", nullable: false),
                    Stock = table.Column<int>(type: "int", nullable: false),
                    Discriminator = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: false),
                    BackpackType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    BootType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Size = table.Column<int>(type: "int", nullable: true),
                    AmountOfPerson = table.Column<int>(type: "int", nullable: true),
                    KayakType = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Products", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Products_ProductTypes_ProductTypeId",
                        column: x => x.ProductTypeId,
                        principalTable: "ProductTypes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Reviews",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Comment = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ProductId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Title = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Reviews", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Reviews_Products_ProductId",
                        column: x => x.ProductId,
                        principalTable: "Products",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "ProductTypes",
                columns: new[] { "Id", "Discriminator" },
                values: new object[] { new Guid("637d058e-069b-4df5-801c-208af77ff6b6"), "TypeOne" });

            migrationBuilder.InsertData(
                table: "ProductTypes",
                columns: new[] { "Id", "Discriminator" },
                values: new object[] { new Guid("d411d30d-0ccd-458c-8243-0fb9d5073dcd"), "TypeThree" });

            migrationBuilder.InsertData(
                table: "ProductTypes",
                columns: new[] { "Id", "Discriminator" },
                values: new object[] { new Guid("57e845ca-1e94-4ffa-8f73-9dc4e1274593"), "TypeTwo" });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "BackpackType", "Description", "Discriminator", "IntroduceAt", "Name", "Option", "PhotoUrl", "Price", "ProductTypeId", "Rating", "Stock" },
                values: new object[,]
                {
                    { new Guid("1f0094d2-f07d-499e-9af8-f0d9fca71e8d"), "Overnight", "Boston's most advanced compression wear technology increases muscle oxygenation, stabilizes active muscles", "Backpack", new DateTimeOffset(new DateTime(2021, 8, 19, 6, 36, 25, 685, DateTimeKind.Unspecified).AddTicks(7346), new TimeSpan(0, -3, 0, 0, 0)), "Refined Concrete Fish", "One", "https://picsum.photos/500/375/?image=110&blur", 478.42m, new Guid("637d058e-069b-4df5-801c-208af77ff6b6"), 4, 3616 },
                    { new Guid("5a0da657-2b0a-4db3-9cc6-df74efab41c0"), "Snowsports", "Carbonite web goalkeeper gloves are ergonomically designed to give easy fit", "Backpack", new DateTimeOffset(new DateTime(2021, 9, 22, 23, 41, 17, 581, DateTimeKind.Unspecified).AddTicks(475), new TimeSpan(0, -3, 0, 0, 0)), "Handmade Metal Keyboard", "Three", "https://picsum.photos/500/375/?image=694&blur", 45.09m, new Guid("57e845ca-1e94-4ffa-8f73-9dc4e1274593"), 3, 4464 },
                    { new Guid("2b02bdec-cb56-4bc4-a52c-d2fa5b04dba5"), "Snowsports", "Boston's most advanced compression wear technology increases muscle oxygenation, stabilizes active muscles", "Backpack", new DateTimeOffset(new DateTime(2022, 3, 17, 20, 22, 15, 232, DateTimeKind.Unspecified).AddTicks(6774), new TimeSpan(0, -3, 0, 0, 0)), "Handmade Fresh Tuna", "Two", "https://picsum.photos/500/375/?image=534&blur", 135.05m, new Guid("57e845ca-1e94-4ffa-8f73-9dc4e1274593"), 7, 3439 },
                    { new Guid("77809ee9-1cde-4487-9e77-fc419e6f0bae"), "Cycling", "New range of formal shirts are designed keeping you in mind. With fits and styling that will make you stand apart", "Backpack", new DateTimeOffset(new DateTime(2021, 10, 23, 9, 30, 13, 508, DateTimeKind.Unspecified).AddTicks(847), new TimeSpan(0, -3, 0, 0, 0)), "Intelligent Plastic Cheese", "One", "https://picsum.photos/500/375/?image=149&blur", 390.52m, new Guid("57e845ca-1e94-4ffa-8f73-9dc4e1274593"), 6, 2696 },
                    { new Guid("3b10cea2-7138-4937-ab79-7114edfcda96"), "Hiking", "The beautiful range of Apple Naturalé that has an exciting mix of natural ingredients. With the Goodness of 100% Natural Ingredients", "Backpack", new DateTimeOffset(new DateTime(2022, 2, 21, 19, 21, 50, 642, DateTimeKind.Unspecified).AddTicks(7884), new TimeSpan(0, -3, 0, 0, 0)), "Gorgeous Steel Salad", "Three", "https://picsum.photos/500/375/?image=221&blur", 465.38m, new Guid("d411d30d-0ccd-458c-8243-0fb9d5073dcd"), 5, 2009 },
                    { new Guid("e5e6ae11-7aab-4e3e-a9d6-cf74c95394ed"), "Climbing", "The Football Is Good For Training And Recreational Purposes", "Backpack", new DateTimeOffset(new DateTime(2021, 8, 27, 21, 35, 25, 266, DateTimeKind.Unspecified).AddTicks(4098), new TimeSpan(0, -3, 0, 0, 0)), "Generic Soft Hat", "One", "https://picsum.photos/500/375/?image=852&blur", 15.33m, new Guid("d411d30d-0ccd-458c-8243-0fb9d5073dcd"), 7, 2552 },
                    { new Guid("7c720012-fec9-42e0-9f0c-92a45ea192b1"), "Cycling", "The automobile layout consists of a front-engine design, with transaxle-type transmissions mounted at the rear of the engine and four wheel drive", "Backpack", new DateTimeOffset(new DateTime(2021, 12, 14, 17, 31, 42, 733, DateTimeKind.Unspecified).AddTicks(7192), new TimeSpan(0, -3, 0, 0, 0)), "Rustic Soft Pizza", "One", "https://picsum.photos/500/375/?image=556&blur", 481.66m, new Guid("637d058e-069b-4df5-801c-208af77ff6b6"), 10, 4786 },
                    { new Guid("71d5c4a2-8b60-4d78-b021-f80e2612faec"), "DayPack", "The Football Is Good For Training And Recreational Purposes", "Backpack", new DateTimeOffset(new DateTime(2021, 7, 27, 23, 47, 35, 505, DateTimeKind.Unspecified).AddTicks(4669), new TimeSpan(0, -3, 0, 0, 0)), "Refined Frozen Pants", "Two", "https://picsum.photos/500/375/?image=857&blur", 813.69m, new Guid("637d058e-069b-4df5-801c-208af77ff6b6"), 0, 1251 },
                    { new Guid("fdecd675-c6c5-4ec1-895c-2b40696278b1"), "Cycling", "The Apollotech B340 is an affordable wireless mouse with reliable connectivity, 12 months battery life and modern design", "Backpack", new DateTimeOffset(new DateTime(2022, 2, 10, 11, 1, 13, 684, DateTimeKind.Unspecified).AddTicks(9676), new TimeSpan(0, -3, 0, 0, 0)), "Ergonomic Wooden Mouse", "Three", "https://picsum.photos/500/375/?image=407&blur", 995.24m, new Guid("637d058e-069b-4df5-801c-208af77ff6b6"), 1, 4240 },
                    { new Guid("1c9ac255-e4f3-4732-ab59-cdf3f1b2adfa"), "Overnight", "The slim & simple Maple Gaming Keyboard from Dev Byte comes with a sleek body and 7- Color RGB LED Back-lighting for smart functionality", "Backpack", new DateTimeOffset(new DateTime(2021, 12, 2, 14, 50, 13, 919, DateTimeKind.Unspecified).AddTicks(8848), new TimeSpan(0, -3, 0, 0, 0)), "Awesome Fresh Bike", "Three", "https://picsum.photos/500/375/?image=441&blur", 18.41m, new Guid("637d058e-069b-4df5-801c-208af77ff6b6"), 6, 470 }
                });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "BootType", "Description", "Discriminator", "IntroduceAt", "Name", "Option", "PhotoUrl", "Price", "ProductTypeId", "Rating", "Size", "Stock" },
                values: new object[,]
                {
                    { new Guid("975f225e-6722-4b0f-b3aa-681b5ba04e28"), "Cowboy", "Andy shoes are designed to keeping in mind durability as well as trends, the most stylish range of shoes & sandals", "Boot", new DateTimeOffset(new DateTime(2022, 2, 10, 10, 38, 35, 490, DateTimeKind.Unspecified).AddTicks(4553), new TimeSpan(0, -3, 0, 0, 0)), "Rustic Metal Keyboard", "Two", "https://picsum.photos/500/375/?image=386&blur", 235.43m, new Guid("637d058e-069b-4df5-801c-208af77ff6b6"), 3, 23, 7 },
                    { new Guid("b438849a-06d1-40cd-9610-ddb4f5378a6b"), "Chelsea", "New range of formal shirts are designed keeping you in mind. With fits and styling that will make you stand apart", "Boot", new DateTimeOffset(new DateTime(2021, 11, 29, 3, 56, 29, 3, DateTimeKind.Unspecified).AddTicks(7672), new TimeSpan(0, -3, 0, 0, 0)), "Licensed Fresh Pizza", "Three", "https://picsum.photos/500/375/?image=349&blur", 914.05m, new Guid("637d058e-069b-4df5-801c-208af77ff6b6"), 5, 29, 2944 },
                    { new Guid("e387d182-295e-4f58-901b-3a6552949fd6"), "Drysuit", "The beautiful range of Apple Naturalé that has an exciting mix of natural ingredients. With the Goodness of 100% Natural Ingredients", "Boot", new DateTimeOffset(new DateTime(2022, 3, 14, 15, 40, 38, 510, DateTimeKind.Unspecified).AddTicks(1741), new TimeSpan(0, -3, 0, 0, 0)), "Rustic Cotton Sausages", "One", "https://picsum.photos/500/375/?image=662&blur", 389.76m, new Guid("d411d30d-0ccd-458c-8243-0fb9d5073dcd"), 4, 20, 709 },
                    { new Guid("dc0906dd-71bf-4fe1-90a0-209930bff579"), "Drysuit", "Ergonomic executive chair upholstered in bonded black leather and PVC padded seat and back for all-day comfort and support", "Boot", new DateTimeOffset(new DateTime(2021, 5, 7, 15, 19, 24, 788, DateTimeKind.Unspecified).AddTicks(3221), new TimeSpan(0, -3, 0, 0, 0)), "Gorgeous Fresh Hat", "One", "https://picsum.photos/500/375/?image=563&blur", 930.05m, new Guid("d411d30d-0ccd-458c-8243-0fb9d5073dcd"), 6, 22, 4309 },
                    { new Guid("e535d1ec-2820-46c5-8b7a-7186054569c3"), "Chelsea", "Carbonite web goalkeeper gloves are ergonomically designed to give easy fit", "Boot", new DateTimeOffset(new DateTime(2022, 2, 16, 3, 37, 36, 495, DateTimeKind.Unspecified).AddTicks(312), new TimeSpan(0, -3, 0, 0, 0)), "Awesome Metal Table", "One", "https://picsum.photos/500/375/?image=318&blur", 301.97m, new Guid("57e845ca-1e94-4ffa-8f73-9dc4e1274593"), 7, 26, 2454 },
                    { new Guid("6149432e-e0df-439c-90c1-a0c074c74626"), "Chelsea", "The beautiful range of Apple Naturalé that has an exciting mix of natural ingredients. With the Goodness of 100% Natural Ingredients", "Boot", new DateTimeOffset(new DateTime(2021, 9, 27, 23, 29, 8, 306, DateTimeKind.Unspecified).AddTicks(6549), new TimeSpan(0, -3, 0, 0, 0)), "Incredible Granite Cheese", "Three", "https://picsum.photos/500/375/?image=872&blur", 761.04m, new Guid("57e845ca-1e94-4ffa-8f73-9dc4e1274593"), 4, 20, 2583 },
                    { new Guid("d5377eff-4f5d-4fba-ad0e-59b2957350ba"), "Drysuit", "The slim & simple Maple Gaming Keyboard from Dev Byte comes with a sleek body and 7- Color RGB LED Back-lighting for smart functionality", "Boot", new DateTimeOffset(new DateTime(2021, 10, 16, 5, 26, 30, 558, DateTimeKind.Unspecified).AddTicks(4617), new TimeSpan(0, -3, 0, 0, 0)), "Fantastic Concrete Ball", "Three", "https://picsum.photos/500/375/?image=233&blur", 903.37m, new Guid("57e845ca-1e94-4ffa-8f73-9dc4e1274593"), 0, 26, 2436 },
                    { new Guid("8f5ade1b-6c0e-4efd-9de9-c500f4a757cd"), "Cowboy", "The beautiful range of Apple Naturalé that has an exciting mix of natural ingredients. With the Goodness of 100% Natural Ingredients", "Boot", new DateTimeOffset(new DateTime(2022, 3, 21, 7, 11, 44, 442, DateTimeKind.Unspecified).AddTicks(9294), new TimeSpan(0, -3, 0, 0, 0)), "Fantastic Rubber Bike", "Three", "https://picsum.photos/500/375/?image=915&blur", 677.49m, new Guid("57e845ca-1e94-4ffa-8f73-9dc4e1274593"), 5, 30, 294 },
                    { new Guid("8b1413ca-7cfb-4f3a-9360-722c53263bfa"), "Cowboy", "Boston's most advanced compression wear technology increases muscle oxygenation, stabilizes active muscles", "Boot", new DateTimeOffset(new DateTime(2021, 11, 27, 5, 58, 21, 977, DateTimeKind.Unspecified).AddTicks(3471), new TimeSpan(0, -3, 0, 0, 0)), "Gorgeous Cotton Cheese", "One", "https://picsum.photos/500/375/?image=1084&blur", 127.87m, new Guid("637d058e-069b-4df5-801c-208af77ff6b6"), 6, 23, 3944 },
                    { new Guid("e24d70a4-4d8d-4116-b18c-d685fd16b51f"), "Engineer", "The Apollotech B340 is an affordable wireless mouse with reliable connectivity, 12 months battery life and modern design", "Boot", new DateTimeOffset(new DateTime(2021, 7, 17, 22, 25, 22, 646, DateTimeKind.Unspecified).AddTicks(5758), new TimeSpan(0, -3, 0, 0, 0)), "Fantastic Granite Cheese", "Three", "https://picsum.photos/500/375/?image=677&blur", 580.79m, new Guid("57e845ca-1e94-4ffa-8f73-9dc4e1274593"), 7, 26, 3912 }
                });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "AmountOfPerson", "Description", "Discriminator", "IntroduceAt", "KayakType", "Name", "Option", "PhotoUrl", "Price", "ProductTypeId", "Rating", "Stock" },
                values: new object[,]
                {
                    { new Guid("8fb4b6c3-52dd-4041-91b0-945df91daf04"), 1, "The Football Is Good For Training And Recreational Purposes", "Kayak", new DateTimeOffset(new DateTime(2021, 9, 17, 16, 4, 53, 408, DateTimeKind.Unspecified).AddTicks(9094), new TimeSpan(0, -3, 0, 0, 0)), "Camping", "Practical Fresh Table", "Three", "https://picsum.photos/500/375/?image=972&blur", 491.57m, new Guid("57e845ca-1e94-4ffa-8f73-9dc4e1274593"), 1, 4022 },
                    { new Guid("dfd7c6cb-99de-434d-9ffd-c3f81a633d6d"), 2, "New ABC 13 9370, 13.3, 5th Gen CoreA5-8250U, 8GB RAM, 256GB SSD, power UHD Graphics, OS 10 Home, OS Office A & J 2016", "Kayak", new DateTimeOffset(new DateTime(2021, 11, 20, 6, 35, 28, 823, DateTimeKind.Unspecified).AddTicks(7052), new TimeSpan(0, -3, 0, 0, 0)), "Racing", "Generic Concrete Mouse", "Two", "https://picsum.photos/500/375/?image=908&blur", 117.70m, new Guid("57e845ca-1e94-4ffa-8f73-9dc4e1274593"), 1, 4904 },
                    { new Guid("1b946a7e-b43a-4434-8d0e-7eaab2d032b3"), 3, "The beautiful range of Apple Naturalé that has an exciting mix of natural ingredients. With the Goodness of 100% Natural Ingredients", "Kayak", new DateTimeOffset(new DateTime(2021, 7, 17, 22, 29, 57, 581, DateTimeKind.Unspecified).AddTicks(13), new TimeSpan(0, -3, 0, 0, 0)), "Racing", "Unbranded Concrete Mouse", "One", "https://picsum.photos/500/375/?image=978&blur", 324.40m, new Guid("d411d30d-0ccd-458c-8243-0fb9d5073dcd"), 5, 2956 },
                    { new Guid("8f0c19d5-ce5a-4ac8-a698-84a080ad33b0"), 2, "New ABC 13 9370, 13.3, 5th Gen CoreA5-8250U, 8GB RAM, 256GB SSD, power UHD Graphics, OS 10 Home, OS Office A & J 2016", "Kayak", new DateTimeOffset(new DateTime(2022, 2, 27, 8, 6, 9, 827, DateTimeKind.Unspecified).AddTicks(5518), new TimeSpan(0, -3, 0, 0, 0)), "Family", "Generic Plastic Bacon", "One", "https://picsum.photos/500/375/?image=539&blur", 68.84m, new Guid("d411d30d-0ccd-458c-8243-0fb9d5073dcd"), 7, 434 },
                    { new Guid("ba41753d-3f58-43c1-9657-4468da506538"), 2, "The beautiful range of Apple Naturalé that has an exciting mix of natural ingredients. With the Goodness of 100% Natural Ingredients", "Kayak", new DateTimeOffset(new DateTime(2021, 7, 18, 7, 21, 33, 812, DateTimeKind.Unspecified).AddTicks(3172), new TimeSpan(0, -3, 0, 0, 0)), "Family", "Handmade Rubber Tuna", "Three", "https://picsum.photos/500/375/?image=329&blur", 66.33m, new Guid("d411d30d-0ccd-458c-8243-0fb9d5073dcd"), 3, 4004 },
                    { new Guid("89b9fbaf-1a0d-4e71-8c21-a86d52d6ec76"), 2, "The Football Is Good For Training And Recreational Purposes", "Kayak", new DateTimeOffset(new DateTime(2021, 5, 4, 11, 42, 14, 605, DateTimeKind.Unspecified).AddTicks(2072), new TimeSpan(0, -3, 0, 0, 0)), "Camping", "Practical Soft Mouse", "Two", "https://picsum.photos/500/375/?image=102&blur", 636.00m, new Guid("57e845ca-1e94-4ffa-8f73-9dc4e1274593"), 4, 4335 },
                    { new Guid("abf8d8cc-b09f-43e9-be52-0b512aa71f1d"), 1, "New range of formal shirts are designed keeping you in mind. With fits and styling that will make you stand apart", "Kayak", new DateTimeOffset(new DateTime(2021, 7, 21, 10, 58, 22, 429, DateTimeKind.Unspecified).AddTicks(4172), new TimeSpan(0, -3, 0, 0, 0)), "Racing", "Fantastic Metal Towels", "One", "https://picsum.photos/500/375/?image=277&blur", 177.90m, new Guid("d411d30d-0ccd-458c-8243-0fb9d5073dcd"), 5, 4888 },
                    { new Guid("64cbbffb-4312-4679-bdea-eb98a7330d9e"), 1, "Andy shoes are designed to keeping in mind durability as well as trends, the most stylish range of shoes & sandals", "Kayak", new DateTimeOffset(new DateTime(2021, 8, 30, 5, 40, 11, 765, DateTimeKind.Unspecified).AddTicks(3851), new TimeSpan(0, -3, 0, 0, 0)), "Family", "Refined Concrete Bike", "Two", "https://picsum.photos/500/375/?image=861&blur", 139.21m, new Guid("637d058e-069b-4df5-801c-208af77ff6b6"), 0, 4810 },
                    { new Guid("35328f4f-d922-47b2-8312-1b9c73899019"), 2, "Carbonite web goalkeeper gloves are ergonomically designed to give easy fit", "Kayak", new DateTimeOffset(new DateTime(2022, 4, 7, 7, 33, 6, 515, DateTimeKind.Unspecified).AddTicks(3250), new TimeSpan(0, -3, 0, 0, 0)), "Fishing", "Ergonomic Metal Hat", "Two", "https://picsum.photos/500/375/?image=826&blur", 69.32m, new Guid("d411d30d-0ccd-458c-8243-0fb9d5073dcd"), 4, 4017 },
                    { new Guid("95a7f6c3-c9fd-4350-9e84-a4e7c01fbaf7"), 1, "The automobile layout consists of a front-engine design, with transaxle-type transmissions mounted at the rear of the engine and four wheel drive", "Kayak", new DateTimeOffset(new DateTime(2022, 4, 29, 1, 12, 18, 622, DateTimeKind.Unspecified).AddTicks(3443), new TimeSpan(0, -3, 0, 0, 0)), "Diving", "Awesome Granite Hat", "One", "https://picsum.photos/500/375/?image=1058&blur", 200.46m, new Guid("57e845ca-1e94-4ffa-8f73-9dc4e1274593"), 3, 747 }
                });

            migrationBuilder.InsertData(
                table: "Reviews",
                columns: new[] { "Id", "Comment", "ProductId", "Title" },
                values: new object[,]
                {
                    { new Guid("73cf0774-58f4-4490-abe2-f1a97c6d74c2"), "Eius fugiat non architecto at porro voluptas. Distinctio deleniti similique omnis eligendi rerum natus vitae. Dolorem facere et. Dolorem maiores et assumenda. Quibusdam repellendus sed quis ut eos quo molestiae modi aliquid. Modi aut omnis voluptatum et dolores corporis.\n\nEt eaque ut et amet voluptatem repudiandae culpa ut. Ullam qui assumenda illo magni tempore atque natus nisi. Temporibus consequuntur aliquid eveniet atque iste. Reiciendis voluptatum velit voluptatibus sapiente explicabo veniam nulla. Esse explicabo commodi est porro eos sit dicta molestiae quod.\n\nLaboriosam est nostrum. Mollitia dolorum enim et. Dolorem omnis quaerat. Repudiandae aut iusto voluptatem enim maxime nihil. Eius explicabo deleniti perferendis voluptas.", new Guid("64cbbffb-4312-4679-bdea-eb98a7330d9e"), "Vitae corrupti culpa." },
                    { new Guid("ff73782b-2017-41bc-8461-a77cfea4ac9c"), "Itaque voluptatem consectetur similique velit qui harum sed nihil. Et voluptatibus illum neque similique qui odit minima non. Fugit quisquam consequuntur similique minus.\n\nEst voluptatem similique dicta in libero. Officiis quod aperiam inventore sed voluptatem qui sed et. Nostrum totam ut qui reiciendis dolorem eius quod consequuntur. Quisquam inventore minus et itaque omnis.\n\nConsequatur explicabo ab at sit ipsam et aliquam unde. Neque quam commodi atque sapiente ea hic ullam consequatur eveniet. Dolorem aut eveniet nesciunt natus.", new Guid("abf8d8cc-b09f-43e9-be52-0b512aa71f1d"), "Quae beatae unde iste ea quod." },
                    { new Guid("1657b078-c145-4c26-9136-2c999c5d1eda"), "Accusamus rem suscipit. Sapiente reprehenderit maxime voluptatum sit. Saepe quam voluptas ipsa nostrum nulla. Accusantium neque laudantium dolores.\n\nDolorem ut repellendus. Quia ut aspernatur. Vitae excepturi quisquam rerum voluptatem tempore. At quia beatae. Rem et rerum ut et sunt omnis illo eveniet molestiae. Culpa asperiores beatae sapiente minima delectus ex delectus.\n\nDoloribus natus vitae. Eveniet voluptates assumenda praesentium. Voluptas eos nemo est laboriosam iure repellat laudantium excepturi blanditiis.", new Guid("1b946a7e-b43a-4434-8d0e-7eaab2d032b3"), "Ducimus incidunt voluptatem aliquid omnis consequuntur sunt." },
                    { new Guid("07146e83-6ef0-42e8-b0db-741a9b190c9e"), "Qui vitae deleniti est. Accusantium et et aspernatur assumenda perspiciatis animi culpa. Neque fugit rerum eius molestiae delectus rerum.\n\nIllo tenetur voluptatem eligendi magni eligendi. Quod atque deleniti vero ratione voluptatem qui ut exercitationem. Eos quasi iure autem ea accusamus.\n\nVoluptatem et rerum cupiditate voluptatem consequuntur in quidem. Aut dolorem inventore quo voluptates perferendis omnis et et. Repellat nam architecto fuga. Voluptas repudiandae necessitatibus dignissimos. Autem dolorem architecto. Aliquam et exercitationem nulla facere sequi quis eligendi.", new Guid("ba41753d-3f58-43c1-9657-4468da506538"), "Et quos atque provident aut fugiat perferendis consequatur et quia." },
                    { new Guid("6f9206a4-7308-43ba-94b3-a21eb8b752a8"), "Dolorem distinctio consequatur tempore unde dolores optio molestiae non. Dolor reiciendis non nemo dignissimos quam molestiae et. Atque eius odit mollitia sunt error praesentium aut velit soluta.\n\nFuga minima hic facilis architecto omnis numquam voluptatum quidem eius. Voluptatem amet illum omnis illo in dolores earum. Maiores consequatur molestiae animi. Nihil omnis et voluptatibus ut in tenetur a eum fuga.\n\nNobis nobis qui enim dolores omnis sed non a. Autem nihil molestiae eveniet assumenda quo veniam minus doloremque neque. Officia aut sint ipsa autem excepturi repudiandae ut. Explicabo nisi et repellat consequuntur est corrupti quae iste. Nemo incidunt officia amet omnis alias et. Rerum ipsa nesciunt sapiente facere ex quia sit ad.", new Guid("8f0c19d5-ce5a-4ac8-a698-84a080ad33b0"), "Ut beatae cupiditate dolores." },
                    { new Guid("13c1475a-c8b0-40ad-8216-211bb8e70b95"), "Et quod sed. Ut qui ut qui omnis. Eius qui possimus et nisi at. Architecto temporibus nisi impedit similique aliquam quia sit sunt.\n\nEa itaque eum quasi. Cum vel aut. Facilis tenetur provident. Omnis ullam commodi et numquam voluptates accusamus quibusdam. Omnis tempore rerum omnis. Molestiae soluta eum et perferendis commodi voluptatibus.\n\nNon qui et molestiae non sed culpa eos ut eos. Est quam repellat id. Velit ut architecto nam qui.", new Guid("35328f4f-d922-47b2-8312-1b9c73899019"), "Voluptas porro totam et." },
                    { new Guid("c82a47d8-1c43-4c71-b343-64ce0cd4e80f"), "Dolor esse nam nulla. Porro dolores eum mollitia nostrum dolores amet quam. Ullam dicta temporibus aperiam vel aperiam aliquam. Deserunt et voluptates aut corrupti recusandae impedit commodi.\n\nTemporibus quis harum culpa qui delectus reiciendis. Fugit voluptates a. Dolores fuga eum.\n\nEa temporibus magni dolores officiis rerum dolorum. Quis atque et ea natus expedita. Placeat quia reprehenderit natus itaque voluptates similique et alias a. Adipisci tenetur quasi maxime sunt fugit.", new Guid("dfd7c6cb-99de-434d-9ffd-c3f81a633d6d"), "Eum labore provident culpa omnis sequi ullam quia aut." },
                    { new Guid("e1ae6ed9-9b12-42e4-a90e-a16432051aae"), "Officia dicta illo quis ad. Tenetur quod dolorum. Libero hic aut nihil voluptatem sed et beatae. Autem assumenda vel qui. Possimus neque enim nulla harum dolor aut numquam aut. Et similique perspiciatis cupiditate excepturi quam perferendis quia ut.\n\nNesciunt molestiae eius excepturi voluptatem cum. Sapiente deserunt ducimus aliquid voluptate sit. Distinctio animi alias. Doloribus autem est voluptatem aut rerum ratione quas.\n\nQui veniam aut sequi est ut quia commodi. Hic et esse. Quidem officiis assumenda sapiente alias ducimus et. Omnis perferendis est officiis.", new Guid("8fb4b6c3-52dd-4041-91b0-945df91daf04"), "Soluta fuga tenetur libero aut est illum." },
                    { new Guid("8582dff6-6dd5-4d88-8e0b-543cc9f6d51a"), "Itaque veritatis ut rem. Aspernatur occaecati quaerat. Nemo laboriosam est dolor soluta laudantium. Repellat ipsa eum.\n\nAccusamus quibusdam itaque. Dolor nemo error quis incidunt aliquam ipsam praesentium aliquid. Ipsam qui quis consectetur sequi. Cupiditate earum est inventore sit fugit praesentium debitis consequatur. Et explicabo quos aut aut.\n\nEst error eius eum eos a magnam. Tempora doloremque nihil quis dicta. Quidem quia aliquam voluptate ut accusantium blanditiis aut laudantium eaque. Ut tempora nesciunt. Dolorem temporibus nihil dicta error dolor.", new Guid("89b9fbaf-1a0d-4e71-8c21-a86d52d6ec76"), "Atque quos et vitae dignissimos sequi rerum earum." },
                    { new Guid("a8a3d4e2-c898-4d52-b31d-36d251846520"), "Voluptas optio in saepe sint dolores consequatur quaerat. Harum vitae voluptas deserunt quam debitis reiciendis. Magnam sit accusantium et blanditiis. Ipsa soluta illum et sed.\n\nEt inventore illum aut tenetur cupiditate. Est voluptatem repudiandae aut. Consequatur nihil fugit fuga rerum tenetur veritatis quibusdam. Doloribus quis architecto aut omnis ex molestias natus voluptas unde. Voluptatem quis rem ut in eos ea. Minus aut consequuntur ullam numquam ex nisi.\n\nVelit voluptas nesciunt numquam error est non. Ut est harum doloribus. Corporis cum veniam.", new Guid("95a7f6c3-c9fd-4350-9e84-a4e7c01fbaf7"), "Aut placeat numquam dignissimos omnis est voluptas amet iure." }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Products_ProductTypeId",
                table: "Products",
                column: "ProductTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_Reviews_ProductId",
                table: "Reviews",
                column: "ProductId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Reviews");

            migrationBuilder.DropTable(
                name: "Products");

            migrationBuilder.DropTable(
                name: "ProductTypes");
        }
    }
}
