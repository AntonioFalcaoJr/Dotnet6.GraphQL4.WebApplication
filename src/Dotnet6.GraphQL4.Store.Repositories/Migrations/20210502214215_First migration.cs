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
                values: new object[] { new Guid("cedff71a-8449-4ff7-99d8-1823a1bfbe84"), "TypeOne" });

            migrationBuilder.InsertData(
                table: "ProductTypes",
                columns: new[] { "Id", "Discriminator" },
                values: new object[] { new Guid("3a1f0f73-2cd2-48a4-b343-d7df28b5387b"), "TypeThree" });

            migrationBuilder.InsertData(
                table: "ProductTypes",
                columns: new[] { "Id", "Discriminator" },
                values: new object[] { new Guid("54859554-ca78-4f20-ac6d-c23e43865384"), "TypeTwo" });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "BackpackType", "Description", "Discriminator", "IntroduceAt", "Name", "Option", "PhotoUrl", "Price", "ProductTypeId", "Rating", "Stock" },
                values: new object[,]
                {
                    { new Guid("0ed299fd-42df-4496-bcd7-aef4047302f7"), "Hiking", "Boston's most advanced compression wear technology increases muscle oxygenation, stabilizes active muscles", "Backpack", new DateTimeOffset(new DateTime(2021, 10, 21, 13, 21, 42, 737, DateTimeKind.Unspecified).AddTicks(8406), new TimeSpan(0, -3, 0, 0, 0)), "Practical Steel Ball", "One", "https://picsum.photos/500/375/?image=447&blur", 444.15m, new Guid("cedff71a-8449-4ff7-99d8-1823a1bfbe84"), 8, 3190 },
                    { new Guid("fb463c8d-9d4f-42eb-8c4b-d69944c1bd35"), "Snowsports", "The automobile layout consists of a front-engine design, with transaxle-type transmissions mounted at the rear of the engine and four wheel drive", "Backpack", new DateTimeOffset(new DateTime(2022, 3, 25, 2, 2, 32, 168, DateTimeKind.Unspecified).AddTicks(2933), new TimeSpan(0, -3, 0, 0, 0)), "Practical Fresh Keyboard", "One", "https://picsum.photos/500/375/?image=447&blur", 472.24m, new Guid("54859554-ca78-4f20-ac6d-c23e43865384"), 4, 1938 },
                    { new Guid("0230cce1-1742-4b07-9db1-664bc9c66eb2"), "Snowsports", "New range of formal shirts are designed keeping you in mind. With fits and styling that will make you stand apart", "Backpack", new DateTimeOffset(new DateTime(2021, 8, 16, 11, 43, 39, 710, DateTimeKind.Unspecified).AddTicks(7882), new TimeSpan(0, -3, 0, 0, 0)), "Tasty Frozen Bacon", "Three", "https://picsum.photos/500/375/?image=227&blur", 776.75m, new Guid("54859554-ca78-4f20-ac6d-c23e43865384"), 5, 882 },
                    { new Guid("ef82c6fc-569d-43a3-9714-f20a962fd669"), "Hiking", "The beautiful range of Apple Naturalé that has an exciting mix of natural ingredients. With the Goodness of 100% Natural Ingredients", "Backpack", new DateTimeOffset(new DateTime(2021, 8, 6, 12, 48, 37, 577, DateTimeKind.Unspecified).AddTicks(1148), new TimeSpan(0, -3, 0, 0, 0)), "Generic Fresh Ball", "Two", "https://picsum.photos/500/375/?image=730&blur", 569.02m, new Guid("3a1f0f73-2cd2-48a4-b343-d7df28b5387b"), 1, 1430 },
                    { new Guid("43e0733b-5672-4c76-a2e7-4d1d3cc68182"), "Climbing", "The automobile layout consists of a front-engine design, with transaxle-type transmissions mounted at the rear of the engine and four wheel drive", "Backpack", new DateTimeOffset(new DateTime(2021, 7, 24, 11, 44, 30, 701, DateTimeKind.Unspecified).AddTicks(5852), new TimeSpan(0, -3, 0, 0, 0)), "Handmade Plastic Chicken", "Three", "https://picsum.photos/500/375/?image=3&blur", 881.88m, new Guid("3a1f0f73-2cd2-48a4-b343-d7df28b5387b"), 5, 347 },
                    { new Guid("b7c45bb6-24a1-4a4f-99ab-5e7d44a9822f"), "Climbing", "The Football Is Good For Training And Recreational Purposes", "Backpack", new DateTimeOffset(new DateTime(2022, 3, 18, 6, 58, 9, 409, DateTimeKind.Unspecified).AddTicks(7453), new TimeSpan(0, -3, 0, 0, 0)), "Awesome Plastic Pants", "Two", "https://picsum.photos/500/375/?image=147&blur", 421.32m, new Guid("3a1f0f73-2cd2-48a4-b343-d7df28b5387b"), 7, 2377 },
                    { new Guid("f2e219df-a2e1-4ed1-8c31-bf89588ce3f3"), "DayPack", "The slim & simple Maple Gaming Keyboard from Dev Byte comes with a sleek body and 7- Color RGB LED Back-lighting for smart functionality", "Backpack", new DateTimeOffset(new DateTime(2021, 12, 2, 4, 39, 11, 281, DateTimeKind.Unspecified).AddTicks(2687), new TimeSpan(0, -3, 0, 0, 0)), "Unbranded Plastic Cheese", "Three", "https://picsum.photos/500/375/?image=272&blur", 476.66m, new Guid("3a1f0f73-2cd2-48a4-b343-d7df28b5387b"), 9, 1579 },
                    { new Guid("a682d821-1770-4595-98a9-f5f6d4e7a50c"), "Overnight", "The Football Is Good For Training And Recreational Purposes", "Backpack", new DateTimeOffset(new DateTime(2021, 9, 3, 1, 8, 11, 214, DateTimeKind.Unspecified).AddTicks(7356), new TimeSpan(0, -3, 0, 0, 0)), "Refined Cotton Gloves", "One", "https://picsum.photos/500/375/?image=712&blur", 64.28m, new Guid("cedff71a-8449-4ff7-99d8-1823a1bfbe84"), 3, 200 },
                    { new Guid("3f9062b0-1c34-4ddc-a280-23662e67c0db"), "Hiking", "Carbonite web goalkeeper gloves are ergonomically designed to give easy fit", "Backpack", new DateTimeOffset(new DateTime(2021, 5, 12, 10, 46, 31, 973, DateTimeKind.Unspecified).AddTicks(1959), new TimeSpan(0, -3, 0, 0, 0)), "Awesome Concrete Bacon", "One", "https://picsum.photos/500/375/?image=650&blur", 355.70m, new Guid("cedff71a-8449-4ff7-99d8-1823a1bfbe84"), 8, 910 },
                    { new Guid("ffbdbe41-131c-425a-8eca-9585492f3913"), "DayPack", "New range of formal shirts are designed keeping you in mind. With fits and styling that will make you stand apart", "Backpack", new DateTimeOffset(new DateTime(2022, 1, 8, 17, 57, 54, 362, DateTimeKind.Unspecified).AddTicks(8545), new TimeSpan(0, -3, 0, 0, 0)), "Small Granite Fish", "Three", "https://picsum.photos/500/375/?image=1055&blur", 395.43m, new Guid("cedff71a-8449-4ff7-99d8-1823a1bfbe84"), 6, 219 }
                });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "BootType", "Description", "Discriminator", "IntroduceAt", "Name", "Option", "PhotoUrl", "Price", "ProductTypeId", "Rating", "Size", "Stock" },
                values: new object[,]
                {
                    { new Guid("7a72861a-479e-40ae-b8d4-7a9b1e152a2a"), "Chelsea", "The automobile layout consists of a front-engine design, with transaxle-type transmissions mounted at the rear of the engine and four wheel drive", "Boot", new DateTimeOffset(new DateTime(2021, 8, 6, 11, 0, 29, 810, DateTimeKind.Unspecified).AddTicks(5968), new TimeSpan(0, -3, 0, 0, 0)), "Rustic Soft Pizza", "One", "https://picsum.photos/500/375/?image=626&blur", 28.78m, new Guid("cedff71a-8449-4ff7-99d8-1823a1bfbe84"), 2, 24, 4727 },
                    { new Guid("009cb5a5-6114-4e34-9513-fe04777a6910"), "Engineer", "The Apollotech B340 is an affordable wireless mouse with reliable connectivity, 12 months battery life and modern design", "Boot", new DateTimeOffset(new DateTime(2021, 6, 22, 13, 43, 1, 828, DateTimeKind.Unspecified).AddTicks(4381), new TimeSpan(0, -3, 0, 0, 0)), "Awesome Metal Chair", "Two", "https://picsum.photos/500/375/?image=90&blur", 322.81m, new Guid("54859554-ca78-4f20-ac6d-c23e43865384"), 0, 26, 12 },
                    { new Guid("6b70c11d-99f1-48d9-832b-c26f70ba16f3"), "Cowboy", "The Apollotech B340 is an affordable wireless mouse with reliable connectivity, 12 months battery life and modern design", "Boot", new DateTimeOffset(new DateTime(2022, 1, 25, 8, 33, 37, 413, DateTimeKind.Unspecified).AddTicks(559), new TimeSpan(0, -3, 0, 0, 0)), "Tasty Fresh Soap", "One", "https://picsum.photos/500/375/?image=392&blur", 940.50m, new Guid("54859554-ca78-4f20-ac6d-c23e43865384"), 8, 30, 4042 },
                    { new Guid("dc1ad637-d68b-459c-9fd6-7a86c406f594"), "Harness", "The Nagasaki Lander is the trademarked name of several series of Nagasaki sport bikes, that started with the 1984 ABC800J", "Boot", new DateTimeOffset(new DateTime(2021, 9, 5, 21, 38, 54, 263, DateTimeKind.Unspecified).AddTicks(9306), new TimeSpan(0, -3, 0, 0, 0)), "Practical Fresh Towels", "Two", "https://picsum.photos/500/375/?image=240&blur", 588.93m, new Guid("54859554-ca78-4f20-ac6d-c23e43865384"), 0, 22, 2169 },
                    { new Guid("50d64371-7cf7-4d9a-b5c5-ca43711b90e2"), "Harness", "New ABC 13 9370, 13.3, 5th Gen CoreA5-8250U, 8GB RAM, 256GB SSD, power UHD Graphics, OS 10 Home, OS Office A & J 2016", "Boot", new DateTimeOffset(new DateTime(2021, 6, 24, 3, 40, 35, 581, DateTimeKind.Unspecified).AddTicks(1409), new TimeSpan(0, -3, 0, 0, 0)), "Refined Fresh Keyboard", "Two", "https://picsum.photos/500/375/?image=574&blur", 722.06m, new Guid("cedff71a-8449-4ff7-99d8-1823a1bfbe84"), 6, 27, 901 },
                    { new Guid("53e062d2-9143-451e-ace6-c47b4623d1e2"), "Engineer", "Ergonomic executive chair upholstered in bonded black leather and PVC padded seat and back for all-day comfort and support", "Boot", new DateTimeOffset(new DateTime(2021, 6, 10, 10, 9, 47, 12, DateTimeKind.Unspecified).AddTicks(9922), new TimeSpan(0, -3, 0, 0, 0)), "Sleek Cotton Table", "Two", "https://picsum.photos/500/375/?image=1023&blur", 731.27m, new Guid("cedff71a-8449-4ff7-99d8-1823a1bfbe84"), 6, 24, 4310 },
                    { new Guid("47fb309e-8245-4618-8498-59ec9b8978b1"), "Chelsea", "New ABC 13 9370, 13.3, 5th Gen CoreA5-8250U, 8GB RAM, 256GB SSD, power UHD Graphics, OS 10 Home, OS Office A & J 2016", "Boot", new DateTimeOffset(new DateTime(2021, 11, 13, 17, 19, 33, 324, DateTimeKind.Unspecified).AddTicks(7319), new TimeSpan(0, -3, 0, 0, 0)), "Rustic Frozen Fish", "Three", "https://picsum.photos/500/375/?image=717&blur", 442.96m, new Guid("54859554-ca78-4f20-ac6d-c23e43865384"), 8, 29, 2110 },
                    { new Guid("046a976d-9a2c-4617-955c-d83480745d34"), "Football", "Carbonite web goalkeeper gloves are ergonomically designed to give easy fit", "Boot", new DateTimeOffset(new DateTime(2021, 7, 17, 9, 31, 19, 208, DateTimeKind.Unspecified).AddTicks(2974), new TimeSpan(0, -3, 0, 0, 0)), "Intelligent Cotton Car", "One", "https://picsum.photos/500/375/?image=857&blur", 230.38m, new Guid("54859554-ca78-4f20-ac6d-c23e43865384"), 4, 27, 4356 },
                    { new Guid("a8333c47-6769-4c75-a8ea-5f2f421228d2"), "Cowboy", "Ergonomic executive chair upholstered in bonded black leather and PVC padded seat and back for all-day comfort and support", "Boot", new DateTimeOffset(new DateTime(2021, 7, 5, 22, 26, 31, 313, DateTimeKind.Unspecified).AddTicks(2757), new TimeSpan(0, -3, 0, 0, 0)), "Refined Plastic Gloves", "Two", "https://picsum.photos/500/375/?image=308&blur", 889.90m, new Guid("54859554-ca78-4f20-ac6d-c23e43865384"), 8, 27, 219 },
                    { new Guid("77077e9d-7099-43b8-8f96-57e97bc52de2"), "Engineer", "The beautiful range of Apple Naturalé that has an exciting mix of natural ingredients. With the Goodness of 100% Natural Ingredients", "Boot", new DateTimeOffset(new DateTime(2021, 7, 7, 4, 45, 12, 234, DateTimeKind.Unspecified).AddTicks(1139), new TimeSpan(0, -3, 0, 0, 0)), "Gorgeous Soft Towels", "Three", "https://picsum.photos/500/375/?image=574&blur", 894.39m, new Guid("cedff71a-8449-4ff7-99d8-1823a1bfbe84"), 10, 22, 2789 }
                });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "AmountOfPerson", "Description", "Discriminator", "IntroduceAt", "KayakType", "Name", "Option", "PhotoUrl", "Price", "ProductTypeId", "Rating", "Stock" },
                values: new object[,]
                {
                    { new Guid("ad5fd707-1f4b-494c-b77a-8d19012477ca"), 2, "Andy shoes are designed to keeping in mind durability as well as trends, the most stylish range of shoes & sandals", "Kayak", new DateTimeOffset(new DateTime(2022, 1, 9, 19, 50, 22, 394, DateTimeKind.Unspecified).AddTicks(652), new TimeSpan(0, -3, 0, 0, 0)), "Racing", "Awesome Fresh Keyboard", "Three", "https://picsum.photos/500/375/?image=130&blur", 65.31m, new Guid("54859554-ca78-4f20-ac6d-c23e43865384"), 7, 1385 },
                    { new Guid("18a4ea4e-0c2b-493a-a0cf-6f1ea30a61b6"), 3, "New range of formal shirts are designed keeping you in mind. With fits and styling that will make you stand apart", "Kayak", new DateTimeOffset(new DateTime(2021, 6, 15, 0, 31, 54, 978, DateTimeKind.Unspecified).AddTicks(9743), new TimeSpan(0, -3, 0, 0, 0)), "Racing", "Rustic Frozen Pants", "One", "https://picsum.photos/500/375/?image=1041&blur", 53.51m, new Guid("3a1f0f73-2cd2-48a4-b343-d7df28b5387b"), 10, 2036 },
                    { new Guid("daad337a-6761-4022-ba07-9717de42d19e"), 1, "The Football Is Good For Training And Recreational Purposes", "Kayak", new DateTimeOffset(new DateTime(2021, 5, 17, 22, 28, 13, 546, DateTimeKind.Unspecified).AddTicks(9277), new TimeSpan(0, -3, 0, 0, 0)), "Fishing", "Handcrafted Steel Table", "One", "https://picsum.photos/500/375/?image=434&blur", 663.72m, new Guid("3a1f0f73-2cd2-48a4-b343-d7df28b5387b"), 4, 4932 },
                    { new Guid("e0163b62-59d2-4fb5-92ee-8cefd8687b93"), 2, "Ergonomic executive chair upholstered in bonded black leather and PVC padded seat and back for all-day comfort and support", "Kayak", new DateTimeOffset(new DateTime(2021, 12, 18, 11, 47, 5, 168, DateTimeKind.Unspecified).AddTicks(3889), new TimeSpan(0, -3, 0, 0, 0)), "Diving", "Tasty Fresh Shirt", "Three", "https://picsum.photos/500/375/?image=520&blur", 608.07m, new Guid("54859554-ca78-4f20-ac6d-c23e43865384"), 0, 3635 },
                    { new Guid("fc4edcd6-7412-49be-8d96-296a4b399a8e"), 1, "Boston's most advanced compression wear technology increases muscle oxygenation, stabilizes active muscles", "Kayak", new DateTimeOffset(new DateTime(2021, 7, 21, 16, 46, 0, 252, DateTimeKind.Unspecified).AddTicks(3705), new TimeSpan(0, -3, 0, 0, 0)), "Camping", "Handmade Rubber Soap", "Two", "https://picsum.photos/500/375/?image=947&blur", 16.22m, new Guid("cedff71a-8449-4ff7-99d8-1823a1bfbe84"), 1, 1264 },
                    { new Guid("b9145011-9f69-4fea-9ef4-71fb913fd8fc"), 1, "The beautiful range of Apple Naturalé that has an exciting mix of natural ingredients. With the Goodness of 100% Natural Ingredients", "Kayak", new DateTimeOffset(new DateTime(2021, 10, 24, 10, 11, 47, 544, DateTimeKind.Unspecified).AddTicks(3101), new TimeSpan(0, -3, 0, 0, 0)), "Camping", "Incredible Frozen Pants", "One", "https://picsum.photos/500/375/?image=295&blur", 117.45m, new Guid("cedff71a-8449-4ff7-99d8-1823a1bfbe84"), 10, 2234 },
                    { new Guid("b18aba7c-f135-4ada-8576-38b5a0acf974"), 1, "The slim & simple Maple Gaming Keyboard from Dev Byte comes with a sleek body and 7- Color RGB LED Back-lighting for smart functionality", "Kayak", new DateTimeOffset(new DateTime(2021, 8, 22, 11, 15, 49, 817, DateTimeKind.Unspecified).AddTicks(7050), new TimeSpan(0, -3, 0, 0, 0)), "Diving", "Tasty Granite Car", "Three", "https://picsum.photos/500/375/?image=471&blur", 914.45m, new Guid("cedff71a-8449-4ff7-99d8-1823a1bfbe84"), 10, 4222 },
                    { new Guid("414d6a4c-e1a8-4954-8ebb-ff52a7a80235"), 3, "Ergonomic executive chair upholstered in bonded black leather and PVC padded seat and back for all-day comfort and support", "Kayak", new DateTimeOffset(new DateTime(2022, 1, 28, 12, 46, 50, 237, DateTimeKind.Unspecified).AddTicks(391), new TimeSpan(0, -3, 0, 0, 0)), "Family", "Awesome Granite Cheese", "Three", "https://picsum.photos/500/375/?image=476&blur", 393.53m, new Guid("cedff71a-8449-4ff7-99d8-1823a1bfbe84"), 2, 4493 },
                    { new Guid("d3fca6f7-ed4f-4b9b-ad99-142ca5e95dd9"), 1, "Carbonite web goalkeeper gloves are ergonomically designed to give easy fit", "Kayak", new DateTimeOffset(new DateTime(2021, 12, 23, 11, 6, 34, 8, DateTimeKind.Unspecified).AddTicks(2424), new TimeSpan(0, -3, 0, 0, 0)), "Racing", "Small Frozen Pizza", "One", "https://picsum.photos/500/375/?image=56&blur", 409.18m, new Guid("3a1f0f73-2cd2-48a4-b343-d7df28b5387b"), 6, 3649 },
                    { new Guid("5e73023d-d64f-4fe7-ad5a-5088c43bf624"), 3, "The beautiful range of Apple Naturalé that has an exciting mix of natural ingredients. With the Goodness of 100% Natural Ingredients", "Kayak", new DateTimeOffset(new DateTime(2021, 5, 22, 23, 18, 50, 887, DateTimeKind.Unspecified).AddTicks(5207), new TimeSpan(0, -3, 0, 0, 0)), "Family", "Gorgeous Concrete Keyboard", "Three", "https://picsum.photos/500/375/?image=1057&blur", 301.05m, new Guid("54859554-ca78-4f20-ac6d-c23e43865384"), 6, 4433 }
                });

            migrationBuilder.InsertData(
                table: "Reviews",
                columns: new[] { "Id", "Comment", "ProductId", "Title" },
                values: new object[,]
                {
                    { new Guid("812c2286-449c-49c2-a7ff-1ea54ad2dbec"), "Qui perferendis dolores in laboriosam sit sint nulla dolor magnam. Odio qui saepe nam et veniam. Sit repellat et eos dicta nisi sint voluptas eius. Assumenda voluptatem repudiandae sed ad temporibus molestiae animi nisi dolorem. Repellat corrupti expedita rerum necessitatibus voluptatum labore et sint.\n\nQuo quod officia itaque est. Dolorem non qui sit adipisci maxime rem ut. Impedit animi cum corrupti.\n\nConsectetur molestiae enim et veniam odio occaecati amet est voluptate. Non ratione autem. Fuga et quas unde amet sequi accusamus dolor fuga. Dicta ab libero magni qui ut sit.", new Guid("414d6a4c-e1a8-4954-8ebb-ff52a7a80235"), "Totam temporibus totam eaque ut tempore repudiandae." },
                    { new Guid("d1f502af-5860-4121-9945-4f24c5fcadb8"), "Vero autem facilis quibusdam enim saepe. Ullam illo praesentium quia et aut. Itaque qui ipsum et temporibus nihil excepturi quas. Sunt occaecati vel. Autem ex porro dolorum suscipit quibusdam dignissimos culpa ullam. Laborum ad dolorem blanditiis.\n\nReiciendis qui tempore reprehenderit optio ab est sit quia. Quisquam quidem ipsum sit sit voluptas aut veritatis dolor. Soluta temporibus dolorum.\n\nItaque modi hic dolore in. Et minus repudiandae soluta tempora quae sit dolores quidem. Voluptate magni temporibus atque est nemo exercitationem illum suscipit beatae.", new Guid("b18aba7c-f135-4ada-8576-38b5a0acf974"), "Accusantium omnis cumque et placeat quam fugit." },
                    { new Guid("5c6c55a9-5c5d-4214-8f97-5e5c41436753"), "Hic ullam repellat doloremque est perferendis corrupti sit nesciunt hic. Sit nemo laborum. Velit ab culpa et quaerat delectus. Non laudantium sapiente dolorem ab omnis.\n\nUt suscipit voluptatum omnis occaecati dolorem. Sed molestias quod. Quos dolorum omnis iusto quisquam dicta quasi et quis. Et suscipit temporibus sapiente iste maxime nulla sunt iste cupiditate. Praesentium dignissimos libero maiores nobis et.\n\nNulla officiis veniam. Ut ea perferendis quia quod. Totam molestias error repellat. Ad ut quis quia et voluptate consequatur sit.", new Guid("b9145011-9f69-4fea-9ef4-71fb913fd8fc"), "Tempora quia repellendus." },
                    { new Guid("be47a10d-64c8-4170-941c-6adf31558140"), "Adipisci quae nemo excepturi ducimus voluptate aut voluptas voluptatem adipisci. Ut eos natus fugiat ut commodi ex id aut et. Est quae deserunt quaerat inventore aperiam. Et dolores ipsa architecto reprehenderit ipsa amet non. Culpa ut vero laudantium dolores ullam dignissimos. Dolorum ut quam.\n\nAmet neque adipisci. In aut in. Voluptas dolor doloribus aut beatae debitis officiis dolores. Facere assumenda ut rerum debitis consequatur laudantium. Eius quidem quos reiciendis et consequatur placeat in doloribus.\n\nLaborum distinctio at officiis minima labore quis culpa. Quos eveniet sint quisquam aspernatur et non temporibus. Corrupti ea dolor tenetur asperiores sit omnis. Aut voluptate veniam tempore quia possimus et provident ipsum aut.", new Guid("fc4edcd6-7412-49be-8d96-296a4b399a8e"), "Nostrum sunt molestiae illo." },
                    { new Guid("2729ee8e-4160-46ea-b68f-508bb5570bc9"), "Deleniti odio facere dolores quae sunt ipsam. Odio deserunt voluptates corrupti dolorum totam quis et incidunt eius. Voluptas optio accusantium vero eum. Consequatur et nesciunt.\n\nUt praesentium commodi commodi nostrum non beatae sunt delectus nihil. Repudiandae a consequuntur impedit. Quibusdam magnam voluptate asperiores perferendis atque et sequi. Cumque quibusdam dolor aut officiis. Debitis mollitia nostrum ea qui ut ratione. Delectus ea ea nulla minus sed saepe.\n\nVelit vel quo quo voluptatem tempore corrupti et. Beatae et sunt ut doloremque provident necessitatibus qui veniam dignissimos. Dolore voluptatibus numquam. Dolorem et reiciendis dolore et et. Assumenda debitis laborum non ipsum. Est perferendis omnis suscipit rerum.", new Guid("daad337a-6761-4022-ba07-9717de42d19e"), "Vero sit mollitia occaecati." },
                    { new Guid("e5287afb-acb9-4873-9c50-caf0ed76cfea"), "Est molestiae aut aut ad. Sit facilis molestias nobis delectus nesciunt consectetur modi. Pariatur et et. Numquam porro rerum in qui. Qui amet quis. Consequuntur vitae alias iure mollitia voluptatem exercitationem qui.\n\nConsequatur quasi possimus natus sint deserunt. Commodi consequatur ad eligendi sit libero sunt eum magnam. Dolore tenetur nisi et. Neque ut itaque qui perferendis dolorum fuga hic.\n\nAperiam consequatur temporibus eum vel recusandae maxime vitae aut. Assumenda est illo dolorem. Occaecati inventore ipsam cumque. Mollitia quo omnis nisi repellendus veniam porro repellat. Corporis consequuntur earum quia nostrum ratione. Eveniet rerum rem qui.", new Guid("d3fca6f7-ed4f-4b9b-ad99-142ca5e95dd9"), "Excepturi ab voluptate." },
                    { new Guid("c5173bff-2f21-425f-9608-b2d1fd388a31"), "Eum sapiente et voluptatem corporis similique non veritatis amet vel. Eos exercitationem corrupti illum quidem quia voluptatem. Deleniti ratione optio. Optio qui aliquid repellat sed culpa. Ea blanditiis eveniet dolores aut qui aut. Sit qui voluptas quis fugit ipsa fugit est voluptates.\n\nQuas vero est sit modi animi ut. Facere non ab. Autem quis et quas tempora enim optio aspernatur quis.\n\nSint suscipit illum dolor sequi eos. Vel tempore dolores et ut totam cumque non maiores itaque. Quas laborum minus sint voluptates molestias reprehenderit sit. Nihil laborum et minus placeat aut aut nisi. Cumque minima eveniet qui est blanditiis voluptas unde nihil. Quis quos fuga dolores.", new Guid("18a4ea4e-0c2b-493a-a0cf-6f1ea30a61b6"), "Adipisci id dignissimos." },
                    { new Guid("9f4ae24b-3705-4b15-a8f1-f4f4ef3c391b"), "Qui ea non dolore a aliquam. Voluptate est optio voluptatem sapiente excepturi itaque consequatur. Ratione saepe quo delectus accusantium. In illo quia impedit iste aut non id accusamus. Amet quia veniam nihil in fugit.\n\nQuos illo error aut nihil amet magni quas ut corrupti. Occaecati aut nihil ut odio placeat deleniti reiciendis. Fugiat animi dolor corporis molestias numquam tempore veritatis. Laboriosam quos illum eum. Voluptates qui exercitationem vel suscipit iusto molestiae magni. Facilis aut voluptatem rerum.\n\nDeserunt et et et. Tempora quia autem soluta voluptates vero. Voluptate dolores maiores dolores. Quo reiciendis omnis reiciendis. Omnis ducimus sed voluptas quis saepe nobis.", new Guid("ad5fd707-1f4b-494c-b77a-8d19012477ca"), "Sapiente dolores et et." },
                    { new Guid("45419636-f0c1-41ed-8315-1c2e260afda4"), "Tempore sint minus similique in velit fugit magni iure numquam. Vitae neque saepe pariatur voluptas. Saepe earum ut vitae autem. Eius consequuntur recusandae omnis expedita. Suscipit dolores et repellat natus adipisci explicabo iste eligendi.\n\nAnimi id molestiae ab quae. Voluptatum quae voluptate aut ipsa a. Dolorum quia dignissimos aut est quibusdam maxime.\n\nPorro provident iste sunt sint ea fugit et tempore. Ut ipsam deserunt neque molestiae aspernatur iusto mollitia nisi. Sunt quae libero minima inventore labore qui. Et repudiandae velit dignissimos. Sed in cupiditate quasi praesentium dignissimos ipsum quisquam veniam vel.", new Guid("e0163b62-59d2-4fb5-92ee-8cefd8687b93"), "Quo similique commodi soluta expedita optio quis veniam est iusto." },
                    { new Guid("222ae5ad-574e-493b-aa27-d20c14529f08"), "Aut ut eveniet optio odio ipsam iure at earum praesentium. Inventore delectus et iusto porro doloribus aut iusto. Sunt voluptates iste sint quis voluptatem et eos magni. Natus ipsam officiis harum aliquid. Non rerum omnis ullam et perferendis quasi ut. Voluptatem dignissimos ullam fugiat dolor.\n\nNon ut aut consequatur. Est temporibus aut eaque ex laborum rerum voluptas quos. Velit sequi voluptas.\n\nEveniet cupiditate explicabo magni ducimus numquam ratione. Fugiat earum laborum eligendi quis. Ducimus dignissimos occaecati ipsum et et vel dolores veniam nihil. Voluptas voluptas quia amet quia et et. Voluptates sit possimus harum officia ducimus vel.", new Guid("5e73023d-d64f-4fe7-ad5a-5088c43bf624"), "Quia magnam aliquid atque eaque mollitia ducimus." }
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
