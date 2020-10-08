using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Dotnet5.GraphQL3.Store.Repositories.Migrations
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
                    Price = table.Column<decimal>(type: "decimal(18,2)", precision: 18, scale: 2, nullable: false),
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
                values: new object[] { new Guid("1a7778d6-ea91-4db2-b60b-c5478e689d47"), "TypeOne" });

            migrationBuilder.InsertData(
                table: "ProductTypes",
                columns: new[] { "Id", "Discriminator" },
                values: new object[] { new Guid("5db6a180-8d06-4bb2-8c63-be91c09621e1"), "TypeThree" });

            migrationBuilder.InsertData(
                table: "ProductTypes",
                columns: new[] { "Id", "Discriminator" },
                values: new object[] { new Guid("e6a4ac8a-4210-4ae1-bfde-4cf85951118b"), "TypeTwo" });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "Description", "Discriminator", "IntroduceAt", "Name", "Option", "PhotoUrl", "Price", "ProductTypeId", "Rating", "Stock", "BackpackType" },
                values: new object[] { new Guid("7913ff8e-96f6-45a0-9f64-1ca806283cf6"), "Boston's most advanced compression wear technology increases muscle oxygenation, stabilizes active muscles", "Backpack", new DateTimeOffset(new DateTime(2020, 10, 27, 7, 33, 16, 398, DateTimeKind.Unspecified).AddTicks(4255), new TimeSpan(0, -3, 0, 0, 0)), "Gorgeous Rubber Sausages", "Two", "https://picsum.photos/500/375/?image=307&blur", 673.35m, new Guid("1a7778d6-ea91-4db2-b60b-c5478e689d47"), 7, 1974, "Overnight" });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "Description", "Discriminator", "IntroduceAt", "Name", "Option", "PhotoUrl", "Price", "ProductTypeId", "Rating", "Stock", "AmountOfPerson", "KayakType" },
                values: new object[] { new Guid("509dde22-cf6b-42c3-b21a-513ad3670cf6"), "The slim & simple Maple Gaming Keyboard from Dev Byte comes with a sleek body and 7- Color RGB LED Back-lighting for smart functionality", "Kayak", new DateTimeOffset(new DateTime(2021, 3, 1, 20, 53, 28, 431, DateTimeKind.Unspecified).AddTicks(1754), new TimeSpan(0, -3, 0, 0, 0)), "Rustic Steel Mouse", "Three", "https://picsum.photos/500/375/?image=1076&blur", 853.92m, new Guid("e6a4ac8a-4210-4ae1-bfde-4cf85951118b"), 1, 4948, 3, "Racing" });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "Description", "Discriminator", "IntroduceAt", "Name", "Option", "PhotoUrl", "Price", "ProductTypeId", "Rating", "Stock", "BootType", "Size" },
                values: new object[,]
                {
                    { new Guid("38d1d7bc-591c-410a-8b1a-45cf18ab88c2"), "The Apollotech B340 is an affordable wireless mouse with reliable connectivity, 12 months battery life and modern design", "Boot", new DateTimeOffset(new DateTime(2021, 6, 18, 8, 48, 24, 460, DateTimeKind.Unspecified).AddTicks(7231), new TimeSpan(0, -3, 0, 0, 0)), "Gorgeous Rubber Shoes", "One", "https://picsum.photos/500/375/?image=292&blur", 23.65m, new Guid("e6a4ac8a-4210-4ae1-bfde-4cf85951118b"), 1, 3326, "Engineer", 23 },
                    { new Guid("c206c776-51d4-4cc6-8623-598224bd4d0a"), "New ABC 13 9370, 13.3, 5th Gen CoreA5-8250U, 8GB RAM, 256GB SSD, power UHD Graphics, OS 10 Home, OS Office A & J 2016", "Boot", new DateTimeOffset(new DateTime(2021, 2, 9, 4, 38, 10, 985, DateTimeKind.Unspecified).AddTicks(6311), new TimeSpan(0, -3, 0, 0, 0)), "Rustic Rubber Sausages", "One", "https://picsum.photos/500/375/?image=830&blur", 999.39m, new Guid("e6a4ac8a-4210-4ae1-bfde-4cf85951118b"), 10, 2234, "Football", 30 },
                    { new Guid("af369ce8-c02e-4483-822e-11232c2a23c1"), "The beautiful range of Apple Naturalé that has an exciting mix of natural ingredients. With the Goodness of 100% Natural Ingredients", "Boot", new DateTimeOffset(new DateTime(2021, 8, 27, 8, 36, 3, 643, DateTimeKind.Unspecified).AddTicks(5570), new TimeSpan(0, -3, 0, 0, 0)), "Tasty Fresh Chicken", "One", "https://picsum.photos/500/375/?image=1054&blur", 756.00m, new Guid("e6a4ac8a-4210-4ae1-bfde-4cf85951118b"), 10, 3894, "Harness", 23 },
                    { new Guid("cf5ee50f-f503-4be0-b808-d3011cd8b0a9"), "The Nagasaki Lander is the trademarked name of several series of Nagasaki sport bikes, that started with the 1984 ABC800J", "Boot", new DateTimeOffset(new DateTime(2021, 9, 9, 21, 25, 4, 739, DateTimeKind.Unspecified).AddTicks(6628), new TimeSpan(0, -3, 0, 0, 0)), "Practical Soft Bike", "Two", "https://picsum.photos/500/375/?image=736&blur", 48.97m, new Guid("e6a4ac8a-4210-4ae1-bfde-4cf85951118b"), 7, 2462, "Football", 26 }
                });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "Description", "Discriminator", "IntroduceAt", "Name", "Option", "PhotoUrl", "Price", "ProductTypeId", "Rating", "Stock", "BackpackType" },
                values: new object[,]
                {
                    { new Guid("7eba66df-43a4-43aa-ac78-8812d7e33514"), "New range of formal shirts are designed keeping you in mind. With fits and styling that will make you stand apart", "Backpack", new DateTimeOffset(new DateTime(2020, 11, 10, 17, 31, 37, 316, DateTimeKind.Unspecified).AddTicks(2864), new TimeSpan(0, -3, 0, 0, 0)), "Unbranded Metal Shirt", "One", "https://picsum.photos/500/375/?image=167&blur", 664.47m, new Guid("e6a4ac8a-4210-4ae1-bfde-4cf85951118b"), 7, 4659, "DayPack" },
                    { new Guid("9b8e0624-75a1-4f3f-8d90-bd2b24263313"), "New range of formal shirts are designed keeping you in mind. With fits and styling that will make you stand apart", "Backpack", new DateTimeOffset(new DateTime(2021, 4, 28, 8, 22, 55, 858, DateTimeKind.Unspecified).AddTicks(3973), new TimeSpan(0, -3, 0, 0, 0)), "Practical Fresh Chips", "Two", "https://picsum.photos/500/375/?image=406&blur", 258.29m, new Guid("e6a4ac8a-4210-4ae1-bfde-4cf85951118b"), 2, 2262, "Overnight" },
                    { new Guid("0bb19e74-6a7d-45a1-a4e7-2de6e7c2872a"), "The slim & simple Maple Gaming Keyboard from Dev Byte comes with a sleek body and 7- Color RGB LED Back-lighting for smart functionality", "Backpack", new DateTimeOffset(new DateTime(2021, 3, 12, 4, 20, 9, 119, DateTimeKind.Unspecified).AddTicks(99), new TimeSpan(0, -3, 0, 0, 0)), "Incredible Soft Hat", "Three", "https://picsum.photos/500/375/?image=501&blur", 109.11m, new Guid("e6a4ac8a-4210-4ae1-bfde-4cf85951118b"), 5, 1229, "Hiking" }
                });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "Description", "Discriminator", "IntroduceAt", "Name", "Option", "PhotoUrl", "Price", "ProductTypeId", "Rating", "Stock", "AmountOfPerson", "KayakType" },
                values: new object[,]
                {
                    { new Guid("c0ff065a-7bcb-4a7a-bbd9-398a9a4d1cc1"), "Ergonomic executive chair upholstered in bonded black leather and PVC padded seat and back for all-day comfort and support", "Kayak", new DateTimeOffset(new DateTime(2021, 3, 12, 18, 48, 2, 933, DateTimeKind.Unspecified).AddTicks(3971), new TimeSpan(0, -3, 0, 0, 0)), "Tasty Concrete Gloves", "Three", "https://picsum.photos/500/375/?image=27&blur", 970.62m, new Guid("5db6a180-8d06-4bb2-8c63-be91c09621e1"), 7, 2673, 2, "Racing" },
                    { new Guid("6be22f13-2662-4e8e-8c29-ac64f0cc6030"), "Boston's most advanced compression wear technology increases muscle oxygenation, stabilizes active muscles", "Kayak", new DateTimeOffset(new DateTime(2021, 3, 29, 15, 35, 52, 310, DateTimeKind.Unspecified).AddTicks(3794), new TimeSpan(0, -3, 0, 0, 0)), "Unbranded Cotton Towels", "Two", "https://picsum.photos/500/375/?image=994&blur", 577.63m, new Guid("5db6a180-8d06-4bb2-8c63-be91c09621e1"), 7, 1628, 1, "Fishing" }
                });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "Description", "Discriminator", "IntroduceAt", "Name", "Option", "PhotoUrl", "Price", "ProductTypeId", "Rating", "Stock", "BootType", "Size" },
                values: new object[,]
                {
                    { new Guid("8dceee94-060a-47d7-8564-2ebab818ab67"), "The Football Is Good For Training And Recreational Purposes", "Boot", new DateTimeOffset(new DateTime(2020, 10, 14, 11, 23, 12, 749, DateTimeKind.Unspecified).AddTicks(8916), new TimeSpan(0, -3, 0, 0, 0)), "Ergonomic Rubber Chicken", "One", "https://picsum.photos/500/375/?image=813&blur", 154.85m, new Guid("5db6a180-8d06-4bb2-8c63-be91c09621e1"), 0, 729, "Harness", 26 },
                    { new Guid("a197f1c3-35f1-41e0-b7fb-be528a9bed39"), "New range of formal shirts are designed keeping you in mind. With fits and styling that will make you stand apart", "Boot", new DateTimeOffset(new DateTime(2021, 7, 26, 4, 53, 19, 384, DateTimeKind.Unspecified).AddTicks(1053), new TimeSpan(0, -3, 0, 0, 0)), "Rustic Granite Shoes", "Three", "https://picsum.photos/500/375/?image=148&blur", 433.61m, new Guid("5db6a180-8d06-4bb2-8c63-be91c09621e1"), 9, 1353, "Football", 27 },
                    { new Guid("8188cefe-898b-48aa-989b-a2e92f7c9f66"), "New ABC 13 9370, 13.3, 5th Gen CoreA5-8250U, 8GB RAM, 256GB SSD, power UHD Graphics, OS 10 Home, OS Office A & J 2016", "Boot", new DateTimeOffset(new DateTime(2021, 8, 17, 23, 46, 26, 869, DateTimeKind.Unspecified).AddTicks(9510), new TimeSpan(0, -3, 0, 0, 0)), "Refined Fresh Bacon", "Three", "https://picsum.photos/500/375/?image=48&blur", 390.87m, new Guid("5db6a180-8d06-4bb2-8c63-be91c09621e1"), 3, 639, "Engineer", 21 },
                    { new Guid("f9217e28-d6cd-4c15-9225-cf6ce1210d76"), "The Apollotech B340 is an affordable wireless mouse with reliable connectivity, 12 months battery life and modern design", "Boot", new DateTimeOffset(new DateTime(2020, 11, 15, 2, 23, 19, 518, DateTimeKind.Unspecified).AddTicks(2258), new TimeSpan(0, -3, 0, 0, 0)), "Incredible Plastic Bacon", "Three", "https://picsum.photos/500/375/?image=99&blur", 643.48m, new Guid("5db6a180-8d06-4bb2-8c63-be91c09621e1"), 8, 3477, "Drysuit", 21 },
                    { new Guid("3b2f6ce4-1b1d-4376-80a6-0b8d51932757"), "Carbonite web goalkeeper gloves are ergonomically designed to give easy fit", "Boot", new DateTimeOffset(new DateTime(2021, 6, 3, 20, 52, 56, 798, DateTimeKind.Unspecified).AddTicks(6485), new TimeSpan(0, -3, 0, 0, 0)), "Refined Frozen Ball", "One", "https://picsum.photos/500/375/?image=602&blur", 203.45m, new Guid("5db6a180-8d06-4bb2-8c63-be91c09621e1"), 6, 433, "Chelsea", 29 }
                });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "Description", "Discriminator", "IntroduceAt", "Name", "Option", "PhotoUrl", "Price", "ProductTypeId", "Rating", "Stock", "BackpackType" },
                values: new object[,]
                {
                    { new Guid("940abbf5-12f2-4dec-b163-4794aa48b9b7"), "The automobile layout consists of a front-engine design, with transaxle-type transmissions mounted at the rear of the engine and four wheel drive", "Backpack", new DateTimeOffset(new DateTime(2020, 12, 17, 11, 4, 17, 344, DateTimeKind.Unspecified).AddTicks(9961), new TimeSpan(0, -3, 0, 0, 0)), "Ergonomic Metal Tuna", "One", "https://picsum.photos/500/375/?image=373&blur", 607.52m, new Guid("5db6a180-8d06-4bb2-8c63-be91c09621e1"), 6, 2095, "Hiking" },
                    { new Guid("436ea568-ece0-43f6-a7d7-9bbea9f3362e"), "The Football Is Good For Training And Recreational Purposes", "Backpack", new DateTimeOffset(new DateTime(2021, 8, 9, 0, 53, 48, 348, DateTimeKind.Unspecified).AddTicks(5148), new TimeSpan(0, -3, 0, 0, 0)), "Awesome Frozen Salad", "Three", "https://picsum.photos/500/375/?image=85&blur", 716.56m, new Guid("5db6a180-8d06-4bb2-8c63-be91c09621e1"), 2, 4093, "Hiking" },
                    { new Guid("89b7b202-3fb2-4613-9a78-f9c60ac3ce32"), "New range of formal shirts are designed keeping you in mind. With fits and styling that will make you stand apart", "Backpack", new DateTimeOffset(new DateTime(2021, 8, 24, 7, 5, 50, 681, DateTimeKind.Unspecified).AddTicks(4536), new TimeSpan(0, -3, 0, 0, 0)), "Sleek Concrete Chair", "Three", "https://picsum.photos/500/375/?image=68&blur", 555.26m, new Guid("5db6a180-8d06-4bb2-8c63-be91c09621e1"), 8, 4633, "Climbing" }
                });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "Description", "Discriminator", "IntroduceAt", "Name", "Option", "PhotoUrl", "Price", "ProductTypeId", "Rating", "Stock", "AmountOfPerson", "KayakType" },
                values: new object[,]
                {
                    { new Guid("3287229c-8126-4ff6-b08d-4b7410bd1c35"), "The Apollotech B340 is an affordable wireless mouse with reliable connectivity, 12 months battery life and modern design", "Kayak", new DateTimeOffset(new DateTime(2020, 12, 25, 16, 28, 46, 421, DateTimeKind.Unspecified).AddTicks(614), new TimeSpan(0, -3, 0, 0, 0)), "Practical Soft Bike", "Three", "https://picsum.photos/500/375/?image=969&blur", 112.42m, new Guid("1a7778d6-ea91-4db2-b60b-c5478e689d47"), 9, 4686, 2, "Family" },
                    { new Guid("a2918028-bf5c-433b-b0f3-085dcee35a1b"), "Boston's most advanced compression wear technology increases muscle oxygenation, stabilizes active muscles", "Kayak", new DateTimeOffset(new DateTime(2020, 11, 27, 15, 46, 22, 706, DateTimeKind.Unspecified).AddTicks(4625), new TimeSpan(0, -3, 0, 0, 0)), "Awesome Soft Gloves", "One", "https://picsum.photos/500/375/?image=773&blur", 645.70m, new Guid("1a7778d6-ea91-4db2-b60b-c5478e689d47"), 4, 4579, 3, "Camping" },
                    { new Guid("ebf718e8-8c89-4e9e-aa71-88aac943d5d7"), "Carbonite web goalkeeper gloves are ergonomically designed to give easy fit", "Kayak", new DateTimeOffset(new DateTime(2021, 7, 16, 14, 48, 58, 283, DateTimeKind.Unspecified).AddTicks(8930), new TimeSpan(0, -3, 0, 0, 0)), "Ergonomic Cotton Hat", "Three", "https://picsum.photos/500/375/?image=301&blur", 78.19m, new Guid("1a7778d6-ea91-4db2-b60b-c5478e689d47"), 9, 1977, 1, "Diving" },
                    { new Guid("ecbdf03a-dc12-4a35-ab61-c55d959ecaff"), "The automobile layout consists of a front-engine design, with transaxle-type transmissions mounted at the rear of the engine and four wheel drive", "Kayak", new DateTimeOffset(new DateTime(2021, 3, 3, 20, 1, 29, 28, DateTimeKind.Unspecified).AddTicks(194), new TimeSpan(0, -3, 0, 0, 0)), "Fantastic Rubber Shoes", "Three", "https://picsum.photos/500/375/?image=889&blur", 981.88m, new Guid("1a7778d6-ea91-4db2-b60b-c5478e689d47"), 8, 718, 1, "Fishing" },
                    { new Guid("e7f38a31-5709-40c1-a434-7b4a50434e68"), "New ABC 13 9370, 13.3, 5th Gen CoreA5-8250U, 8GB RAM, 256GB SSD, power UHD Graphics, OS 10 Home, OS Office A & J 2016", "Kayak", new DateTimeOffset(new DateTime(2020, 10, 12, 3, 32, 34, 251, DateTimeKind.Unspecified).AddTicks(9837), new TimeSpan(0, -3, 0, 0, 0)), "Intelligent Steel Chips", "Three", "https://picsum.photos/500/375/?image=630&blur", 244.21m, new Guid("1a7778d6-ea91-4db2-b60b-c5478e689d47"), 1, 3178, 3, "Racing" }
                });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "Description", "Discriminator", "IntroduceAt", "Name", "Option", "PhotoUrl", "Price", "ProductTypeId", "Rating", "Stock", "BootType", "Size" },
                values: new object[] { new Guid("9e37da41-a97f-4a70-b29d-2413c21c447a"), "Andy shoes are designed to keeping in mind durability as well as trends, the most stylish range of shoes & sandals", "Boot", new DateTimeOffset(new DateTime(2020, 12, 10, 12, 27, 31, 523, DateTimeKind.Unspecified).AddTicks(6023), new TimeSpan(0, -3, 0, 0, 0)), "Unbranded Fresh Chips", "Two", "https://picsum.photos/500/375/?image=645&blur", 687.86m, new Guid("1a7778d6-ea91-4db2-b60b-c5478e689d47"), 0, 1875, "Harness", 22 });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "Description", "Discriminator", "IntroduceAt", "Name", "Option", "PhotoUrl", "Price", "ProductTypeId", "Rating", "Stock", "BackpackType" },
                values: new object[,]
                {
                    { new Guid("5202c2f1-0385-412b-9f7b-dabd647ca3a1"), "The beautiful range of Apple Naturalé that has an exciting mix of natural ingredients. With the Goodness of 100% Natural Ingredients", "Backpack", new DateTimeOffset(new DateTime(2021, 6, 7, 3, 48, 34, 533, DateTimeKind.Unspecified).AddTicks(7009), new TimeSpan(0, -3, 0, 0, 0)), "Handcrafted Concrete Computer", "One", "https://picsum.photos/500/375/?image=872&blur", 193.03m, new Guid("1a7778d6-ea91-4db2-b60b-c5478e689d47"), 5, 2146, "Climbing" },
                    { new Guid("c2a98a49-de9d-42dc-beb2-bccf2cc3ec77"), "Andy shoes are designed to keeping in mind durability as well as trends, the most stylish range of shoes & sandals", "Backpack", new DateTimeOffset(new DateTime(2020, 12, 22, 6, 35, 23, 959, DateTimeKind.Unspecified).AddTicks(5490), new TimeSpan(0, -3, 0, 0, 0)), "Licensed Granite Car", "Two", "https://picsum.photos/500/375/?image=426&blur", 369.36m, new Guid("1a7778d6-ea91-4db2-b60b-c5478e689d47"), 1, 1085, "Climbing" },
                    { new Guid("2cd1644d-81ed-48a0-8860-a20d5ae885b7"), "Andy shoes are designed to keeping in mind durability as well as trends, the most stylish range of shoes & sandals", "Backpack", new DateTimeOffset(new DateTime(2020, 12, 28, 19, 10, 3, 552, DateTimeKind.Unspecified).AddTicks(9468), new TimeSpan(0, -3, 0, 0, 0)), "Fantastic Cotton Mouse", "Two", "https://picsum.photos/500/375/?image=652&blur", 449.52m, new Guid("1a7778d6-ea91-4db2-b60b-c5478e689d47"), 0, 3875, "Snowsports" }
                });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "Description", "Discriminator", "IntroduceAt", "Name", "Option", "PhotoUrl", "Price", "ProductTypeId", "Rating", "Stock", "AmountOfPerson", "KayakType" },
                values: new object[,]
                {
                    { new Guid("d605afe8-38a9-4971-8a82-af375a0ff295"), "The Apollotech B340 is an affordable wireless mouse with reliable connectivity, 12 months battery life and modern design", "Kayak", new DateTimeOffset(new DateTime(2021, 6, 24, 22, 45, 38, 687, DateTimeKind.Unspecified).AddTicks(3931), new TimeSpan(0, -3, 0, 0, 0)), "Licensed Cotton Chips", "Three", "https://picsum.photos/500/375/?image=398&blur", 333.37m, new Guid("e6a4ac8a-4210-4ae1-bfde-4cf85951118b"), 9, 1742, 3, "Fishing" },
                    { new Guid("75b68dd9-6196-4a8d-8255-b05334e76fa0"), "The automobile layout consists of a front-engine design, with transaxle-type transmissions mounted at the rear of the engine and four wheel drive", "Kayak", new DateTimeOffset(new DateTime(2020, 9, 19, 21, 25, 43, 472, DateTimeKind.Unspecified).AddTicks(8558), new TimeSpan(0, -3, 0, 0, 0)), "Gorgeous Frozen Sausages", "Three", "https://picsum.photos/500/375/?image=652&blur", 702.59m, new Guid("e6a4ac8a-4210-4ae1-bfde-4cf85951118b"), 9, 106, 3, "Family" }
                });

            migrationBuilder.InsertData(
                table: "Reviews",
                columns: new[] { "Id", "Comment", "ProductId", "Title" },
                values: new object[,]
                {
                    { new Guid("d7befed9-7ee1-49e1-8be2-b50f1a4f10a8"), "Veniam est officiis possimus ut. Et rerum dolor numquam officia. Soluta quae et ut unde et rem mollitia magni facere. Quasi qui dolorem. Ut voluptatibus cupiditate ea sapiente est vero et aut repellendus. Saepe iste et.\n\nQui ipsa est magnam et pariatur expedita praesentium voluptatem quia. Non non perspiciatis et quia. Laudantium non ut. Vero et numquam dolorem aut autem possimus dolores. Sint voluptatibus est.\n\nAccusantium eos repudiandae voluptatem est quia veritatis. Rerum eum est quo. Voluptatibus debitis autem sunt dicta dolorum. Mollitia esse molestias molestiae veritatis. Ut sapiente quia. Commodi animi placeat non est ipsam.", new Guid("e7f38a31-5709-40c1-a434-7b4a50434e68"), "Odio quo in deserunt." },
                    { new Guid("f705cae5-b317-4edc-9ec4-11449081ad80"), "Fugiat quia sunt voluptas est dolorum ut dolorem saepe maiores. Sit laborum ex atque sapiente harum. Aspernatur dicta ut voluptatem quae delectus. Quia error id est magnam quae est. Molestiae tempore magnam ut minus consequuntur nisi rerum culpa totam.\n\nVoluptates neque a cumque deleniti. Sequi dolores error placeat. Magni consequuntur autem similique illo et dolor rerum earum. Quasi sit soluta ut doloribus eveniet exercitationem possimus. Expedita omnis et cum.\n\nId et dolorem. Saepe incidunt eum. Eos quia nulla earum natus quis aliquam in. Tempore omnis quo reiciendis minima totam corrupti nemo eos. Commodi explicabo quaerat optio qui dolorem cupiditate qui.", new Guid("ecbdf03a-dc12-4a35-ab61-c55d959ecaff"), "Aut mollitia ab molestias est quas illum aut." },
                    { new Guid("54b973d9-c6ae-4c29-a144-8ba3a540acbc"), "Dolore aut nam accusamus repellat recusandae repellat a doloribus. Incidunt ut incidunt. Iure impedit dolore ex pariatur dolorem fugit debitis. Reprehenderit praesentium commodi minus maxime doloremque. Eius vitae sint. Debitis tenetur unde nesciunt fugiat consequatur distinctio sunt.\n\nDolorum enim harum accusantium magnam reprehenderit ipsum veniam non. Cum consequatur eum ad voluptate quidem sed aliquam. Repudiandae quo voluptatem iure sed nulla et neque dicta occaecati. Molestias perspiciatis hic. Assumenda consectetur qui impedit quos rerum voluptates recusandae. Autem perferendis molestias sunt enim facere velit est ea.\n\nEarum totam aut. Dolor qui tempora. Omnis ipsum numquam. Esse id quas eius. Quos omnis veniam alias ut ad deserunt cupiditate suscipit vero.", new Guid("ebf718e8-8c89-4e9e-aa71-88aac943d5d7"), "Suscipit voluptatem iusto aut saepe recusandae nihil corporis nemo quidem." },
                    { new Guid("231ffc6d-255a-4a57-b44b-f45fef7fe325"), "Ex quos maxime. Sunt est officiis eos. Omnis illum molestiae illo odio.\n\nIllum debitis sit porro id enim perferendis qui. Delectus est est voluptas esse dolore placeat nobis totam aut. Ratione quasi sit id voluptates sapiente nobis. Est beatae in.\n\nDucimus sit nostrum. Enim aliquid ipsa voluptatum perferendis numquam consequuntur quae. Quis ut nemo quasi. Officia molestiae accusamus qui. Optio in aut omnis et delectus consequatur nulla. Rerum iste voluptatem incidunt a accusantium.", new Guid("a2918028-bf5c-433b-b0f3-085dcee35a1b"), "Fugit ut consequuntur dolores at." },
                    { new Guid("e9c7d116-d1bb-4cbd-b854-3a046653ab24"), "Ea qui sapiente qui. Aliquid vitae consequuntur quidem iste ad minus eum praesentium et. Iusto et voluptatum perspiciatis dolorum. Qui cupiditate omnis sint et vero exercitationem. Et molestiae porro et molestiae. Beatae nemo quisquam quas delectus.\n\nQuia sed quam nesciunt et unde autem natus voluptatem. Reprehenderit laborum dolorem inventore. Aut quasi omnis tempora fugiat voluptatem.\n\nPerferendis sit aperiam quidem et magni vitae aut culpa. Aut amet voluptatem ea possimus recusandae. Et omnis totam tempora voluptas. Id tempora rerum et est tenetur quod nostrum blanditiis enim. Ea dolorem fugiat voluptates unde. Et incidunt vel sed sit accusamus.", new Guid("3287229c-8126-4ff6-b08d-4b7410bd1c35"), "Dignissimos enim et." },
                    { new Guid("8dd94aa6-bdd5-4da1-ad89-83604be5e7d4"), "Minus totam earum quaerat est omnis consequuntur repellendus et quia. Soluta id doloremque corrupti sit qui. Molestiae qui est eaque fugiat provident iure.\n\nIpsa voluptatem rem praesentium ex nisi ut consequuntur. Quam fugiat sed recusandae voluptas. Blanditiis magni quis sit vero sit.\n\nEt eius soluta placeat sit optio harum velit. Quos dolores vitae quidem deserunt eos vitae suscipit reprehenderit. Eius animi placeat et quos quasi qui culpa nihil dolore.", new Guid("6be22f13-2662-4e8e-8c29-ac64f0cc6030"), "Autem est accusantium." },
                    { new Guid("33c005a9-7ffc-401f-a07b-093021e166ed"), "Esse dolorem quia nihil culpa aut explicabo quo. Provident exercitationem fugit facilis consequatur aut eaque consectetur quis. Voluptas sapiente suscipit maxime dignissimos id aut. Deleniti aperiam sed voluptates. Sapiente dicta et dolor qui.\n\nFacilis et voluptatem. Et accusantium voluptatem praesentium. Et nam aut sit veritatis est quo. Beatae qui ut. Rerum laborum aut error fuga voluptatem.\n\nEt fugiat enim dolorum ad molestiae mollitia. Quia earum esse esse et quo iste consequatur explicabo necessitatibus. Ad autem repellendus aspernatur.", new Guid("c0ff065a-7bcb-4a7a-bbd9-398a9a4d1cc1"), "Id perspiciatis consequatur et numquam natus dolor alias dolorem ut." },
                    { new Guid("1d3c6d80-9585-49d2-9431-1e8b764e9ccd"), "Et cum deserunt neque molestiae rerum aut. Ipsa et et maxime et ut sed repellat totam aut. Quasi ipsum sequi amet soluta temporibus sed molestiae dolorem. Sed cupiditate inventore sequi eaque dolorum voluptate maxime tempora.\n\nDeserunt repellendus voluptatem eligendi dolorem est quo. Ipsa inventore et et modi velit. Sunt corrupti voluptates autem nemo quo. Ratione et ad amet deserunt dolorem est quibusdam aliquam.\n\nTempora deleniti eum magni dolores vero qui ea. Quia omnis non accusantium fugiat quod. Provident sint fugiat at ipsum eos maxime rerum.", new Guid("509dde22-cf6b-42c3-b21a-513ad3670cf6"), "Esse quidem inventore." },
                    { new Guid("52acb47a-5294-449d-9135-cbbff95ad96f"), "Nobis officia dolor maxime expedita quo maiores. Modi eos iusto deserunt qui. In velit excepturi aut quis minus aut.\n\nTempore aliquid ipsa. Rem praesentium quod qui saepe rerum voluptatem quia amet. Modi aliquid consequatur ea mollitia suscipit praesentium autem commodi. Et ut iste et consequuntur atque quia blanditiis perferendis provident. Reprehenderit laborum delectus.\n\nDeleniti voluptate ut tenetur quia eum iure similique nostrum expedita. Voluptas quas suscipit mollitia debitis. Nesciunt consequatur non et consequuntur voluptas velit ipsam similique odit. Id eum id ipsa necessitatibus nihil vero ab. Voluptate omnis deleniti voluptatem doloribus.", new Guid("d605afe8-38a9-4971-8a82-af375a0ff295"), "Totam sed repellat hic soluta." },
                    { new Guid("c5e5386d-f5ed-4dc7-90a4-55c918deebdf"), "Natus totam fuga est dignissimos. Voluptate id harum et voluptatem quo. Aliquid sint sapiente tenetur. Aut in hic sit in repellat excepturi assumenda qui ea. Illo laboriosam suscipit eum a eveniet et. Quo vel in quas rerum quibusdam quidem quia.\n\nNam tenetur nesciunt corrupti vel sint excepturi eum tempora et. Quia cum nulla quae dicta in explicabo nobis. Et blanditiis fugit. Et omnis cumque eveniet. Provident voluptas temporibus. At sint voluptate ea error a qui.\n\nLibero minus odit sed nihil iste blanditiis. Eius ut cupiditate sapiente tempore non quo non dolore. Vel et vel eligendi corporis quo quidem qui molestiae. Est aut dolores et optio libero repellendus vel.", new Guid("75b68dd9-6196-4a8d-8255-b05334e76fa0"), "Nihil nulla ratione." }
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
