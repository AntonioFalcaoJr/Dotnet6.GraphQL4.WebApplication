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
                    Description = table.Column<string>(type: "varchar(300)", unicode: false, maxLength: 300, nullable: true),
                    IntroduceAt = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: false),
                    Name = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: false),
                    Option = table.Column<string>(type: "varchar(30)", unicode: false, maxLength: 30, nullable: false),
                    PhotoUrl = table.Column<string>(type: "varchar(100)", unicode: false, maxLength: 100, nullable: true),
                    Price = table.Column<decimal>(type: "decimal(10,2)", precision: 10, scale: 2, nullable: false),
                    ProductTypeId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    Rating = table.Column<int>(type: "int", nullable: false),
                    Stock = table.Column<int>(type: "int", nullable: false),
                    Discriminator = table.Column<string>(type: "varchar(30)", unicode: false, maxLength: 30, nullable: false),
                    BackpackType = table.Column<string>(type: "varchar(30)", unicode: false, maxLength: 30, nullable: true),
                    BootType = table.Column<string>(type: "varchar(30)", unicode: false, maxLength: 30, nullable: true),
                    Size = table.Column<int>(type: "int", nullable: true),
                    AmountOfPerson = table.Column<int>(type: "int", nullable: true),
                    KayakType = table.Column<string>(type: "varchar(30)", unicode: false, maxLength: 30, nullable: true)
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
                    Comment = table.Column<string>(type: "varchar(1000)", unicode: false, maxLength: 1000, nullable: true),
                    ProductId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Title = table.Column<string>(type: "varchar(100)", unicode: false, maxLength: 100, nullable: true)
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
                values: new object[] { new Guid("6f0631e5-a1f0-4abc-845a-c23614c03412"), "TypeOne" });

            migrationBuilder.InsertData(
                table: "ProductTypes",
                columns: new[] { "Id", "Discriminator" },
                values: new object[] { new Guid("daeca18f-9b56-4990-88a4-5537c48a5e80"), "TypeThree" });

            migrationBuilder.InsertData(
                table: "ProductTypes",
                columns: new[] { "Id", "Discriminator" },
                values: new object[] { new Guid("6a88b5a9-79e5-47bd-b8ae-5bdbafa19df1"), "TypeTwo" });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "BackpackType", "Description", "Discriminator", "IntroduceAt", "Name", "Option", "PhotoUrl", "Price", "ProductTypeId", "Rating", "Stock" },
                values: new object[,]
                {
                    { new Guid("ad1d0233-e24b-47eb-a65a-c6600f350221"), "Snowsports", "Ergonomic executive chair upholstered in bonded black leather and PVC padded seat and back for all-day comfort and support", "Backpack", new DateTimeOffset(new DateTime(2021, 10, 3, 4, 26, 29, 489, DateTimeKind.Unspecified).AddTicks(3672), new TimeSpan(0, -3, 0, 0, 0)), "Licensed Fresh Salad", "Two", "https://picsum.photos/500/375/?image=925&blur", 421.78m, new Guid("6f0631e5-a1f0-4abc-845a-c23614c03412"), 9, 2679 },
                    { new Guid("9682b5e3-6a08-4323-945a-2afc6f868069"), "Hiking", "New range of formal shirts are designed keeping you in mind. With fits and styling that will make you stand apart", "Backpack", new DateTimeOffset(new DateTime(2021, 11, 8, 13, 14, 40, 82, DateTimeKind.Unspecified).AddTicks(2617), new TimeSpan(0, -3, 0, 0, 0)), "Small Wooden Salad", "One", "https://picsum.photos/500/375/?image=659&blur", 685.77m, new Guid("6f0631e5-a1f0-4abc-845a-c23614c03412"), 1, 1852 },
                    { new Guid("816852bd-2913-491d-b205-93a2f26975c5"), "Overnight", "Carbonite web goalkeeper gloves are ergonomically designed to give easy fit", "Backpack", new DateTimeOffset(new DateTime(2022, 3, 25, 6, 5, 29, 830, DateTimeKind.Unspecified).AddTicks(8756), new TimeSpan(0, -3, 0, 0, 0)), "Incredible Granite Sausages", "One", "https://picsum.photos/500/375/?image=373&blur", 775.58m, new Guid("6f0631e5-a1f0-4abc-845a-c23614c03412"), 2, 1232 },
                    { new Guid("a4c571f4-d6fe-44ed-8917-420fea29e8aa"), "Cycling", "New ABC 13 9370, 13.3, 5th Gen CoreA5-8250U, 8GB RAM, 256GB SSD, power UHD Graphics, OS 10 Home, OS Office A & J 2016", "Backpack", new DateTimeOffset(new DateTime(2021, 9, 6, 17, 55, 26, 987, DateTimeKind.Unspecified).AddTicks(2389), new TimeSpan(0, -3, 0, 0, 0)), "Handcrafted Rubber Table", "Two", "https://picsum.photos/500/375/?image=18&blur", 540.30m, new Guid("6f0631e5-a1f0-4abc-845a-c23614c03412"), 2, 1809 },
                    { new Guid("327957fa-7dfd-415f-97e1-2b46719a86a0"), "Climbing", "New ABC 13 9370, 13.3, 5th Gen CoreA5-8250U, 8GB RAM, 256GB SSD, power UHD Graphics, OS 10 Home, OS Office A & J 2016", "Backpack", new DateTimeOffset(new DateTime(2021, 11, 30, 1, 4, 53, 375, DateTimeKind.Unspecified).AddTicks(8461), new TimeSpan(0, -3, 0, 0, 0)), "Generic Concrete Shirt", "Two", "https://picsum.photos/500/375/?image=1015&blur", 977.68m, new Guid("6a88b5a9-79e5-47bd-b8ae-5bdbafa19df1"), 8, 38 },
                    { new Guid("4759a39a-510d-4f9d-836b-81487935d9b2"), "Cycling", "The beautiful range of Apple Naturalé that has an exciting mix of natural ingredients. With the Goodness of 100% Natural Ingredients", "Backpack", new DateTimeOffset(new DateTime(2021, 10, 5, 10, 1, 36, 343, DateTimeKind.Unspecified).AddTicks(3867), new TimeSpan(0, -3, 0, 0, 0)), "Intelligent Granite Fish", "One", "https://picsum.photos/500/375/?image=244&blur", 588.12m, new Guid("6a88b5a9-79e5-47bd-b8ae-5bdbafa19df1"), 4, 1964 },
                    { new Guid("8b8c464a-05e5-4b4d-8012-91405b8531d8"), "Overnight", "New range of formal shirts are designed keeping you in mind. With fits and styling that will make you stand apart", "Backpack", new DateTimeOffset(new DateTime(2021, 11, 10, 14, 47, 48, 751, DateTimeKind.Unspecified).AddTicks(6164), new TimeSpan(0, -3, 0, 0, 0)), "Incredible Frozen Salad", "Three", "https://picsum.photos/500/375/?image=52&blur", 780.15m, new Guid("daeca18f-9b56-4990-88a4-5537c48a5e80"), 4, 7 },
                    { new Guid("9bc16d1d-6a51-4281-9c35-99432d0eca9a"), "Hiking", "The Apollotech B340 is an affordable wireless mouse with reliable connectivity, 12 months battery life and modern design", "Backpack", new DateTimeOffset(new DateTime(2021, 6, 27, 20, 30, 27, 276, DateTimeKind.Unspecified).AddTicks(2598), new TimeSpan(0, -3, 0, 0, 0)), "Sleek Steel Shirt", "Three", "https://picsum.photos/500/375/?image=912&blur", 114.61m, new Guid("6a88b5a9-79e5-47bd-b8ae-5bdbafa19df1"), 1, 2823 },
                    { new Guid("4f977bb7-72d0-464b-aafd-4827c94a0a07"), "Overnight", "The Football Is Good For Training And Recreational Purposes", "Backpack", new DateTimeOffset(new DateTime(2022, 4, 21, 0, 35, 26, 699, DateTimeKind.Unspecified).AddTicks(4147), new TimeSpan(0, -3, 0, 0, 0)), "Rustic Soft Fish", "Three", "https://picsum.photos/500/375/?image=351&blur", 181.18m, new Guid("6a88b5a9-79e5-47bd-b8ae-5bdbafa19df1"), 6, 2794 },
                    { new Guid("bfd3e80e-4e67-42b3-9a1e-1c5599786205"), "Cycling", "The Football Is Good For Training And Recreational Purposes", "Backpack", new DateTimeOffset(new DateTime(2022, 5, 1, 7, 42, 15, 768, DateTimeKind.Unspecified).AddTicks(3220), new TimeSpan(0, -3, 0, 0, 0)), "Practical Plastic Sausages", "Two", "https://picsum.photos/500/375/?image=227&blur", 978.08m, new Guid("6a88b5a9-79e5-47bd-b8ae-5bdbafa19df1"), 2, 7 }
                });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "BootType", "Description", "Discriminator", "IntroduceAt", "Name", "Option", "PhotoUrl", "Price", "ProductTypeId", "Rating", "Size", "Stock" },
                values: new object[,]
                {
                    { new Guid("0cca14e7-767a-4906-8dc7-1e53b14442ca"), "Cowboy", "New ABC 13 9370, 13.3, 5th Gen CoreA5-8250U, 8GB RAM, 256GB SSD, power UHD Graphics, OS 10 Home, OS Office A & J 2016", "Boot", new DateTimeOffset(new DateTime(2021, 8, 3, 19, 22, 11, 754, DateTimeKind.Unspecified).AddTicks(3283), new TimeSpan(0, -3, 0, 0, 0)), "Practical Concrete Car", "One", "https://picsum.photos/500/375/?image=1075&blur", 923.98m, new Guid("6a88b5a9-79e5-47bd-b8ae-5bdbafa19df1"), 10, 21, 3209 },
                    { new Guid("70d70ad7-9b33-4c55-8e45-4cca87137ac3"), "Cowboy", "Andy shoes are designed to keeping in mind durability as well as trends, the most stylish range of shoes & sandals", "Boot", new DateTimeOffset(new DateTime(2022, 1, 19, 2, 40, 1, 890, DateTimeKind.Unspecified).AddTicks(1737), new TimeSpan(0, -3, 0, 0, 0)), "Rustic Steel Keyboard", "Three", "https://picsum.photos/500/375/?image=26&blur", 823.38m, new Guid("6a88b5a9-79e5-47bd-b8ae-5bdbafa19df1"), 6, 20, 1442 },
                    { new Guid("3ff051dc-990e-4c93-b9a9-7b4a0fdd366b"), "Harness", "The Apollotech B340 is an affordable wireless mouse with reliable connectivity, 12 months battery life and modern design", "Boot", new DateTimeOffset(new DateTime(2021, 11, 15, 2, 33, 16, 570, DateTimeKind.Unspecified).AddTicks(7401), new TimeSpan(0, -3, 0, 0, 0)), "Incredible Granite Fish", "Two", "https://picsum.photos/500/375/?image=68&blur", 191.02m, new Guid("daeca18f-9b56-4990-88a4-5537c48a5e80"), 9, 26, 2985 },
                    { new Guid("5991d3c5-4614-4c3b-80aa-ddf6f07a462a"), "Harness", "Ergonomic executive chair upholstered in bonded black leather and PVC padded seat and back for all-day comfort and support", "Boot", new DateTimeOffset(new DateTime(2021, 5, 26, 16, 43, 40, 666, DateTimeKind.Unspecified).AddTicks(5178), new TimeSpan(0, -3, 0, 0, 0)), "Rustic Plastic Bacon", "One", "https://picsum.photos/500/375/?image=426&blur", 253.08m, new Guid("daeca18f-9b56-4990-88a4-5537c48a5e80"), 10, 26, 2553 },
                    { new Guid("5c71a42a-90fa-495d-af1f-dfcf61065e15"), "Football", "Andy shoes are designed to keeping in mind durability as well as trends, the most stylish range of shoes & sandals", "Boot", new DateTimeOffset(new DateTime(2021, 12, 24, 1, 53, 28, 702, DateTimeKind.Unspecified).AddTicks(7512), new TimeSpan(0, -3, 0, 0, 0)), "Rustic Granite Computer", "One", "https://picsum.photos/500/375/?image=770&blur", 576.72m, new Guid("daeca18f-9b56-4990-88a4-5537c48a5e80"), 5, 20, 217 },
                    { new Guid("e106e0a6-35dd-4b5c-b43e-6e3290d0b2ff"), "Cowboy", "Ergonomic executive chair upholstered in bonded black leather and PVC padded seat and back for all-day comfort and support", "Boot", new DateTimeOffset(new DateTime(2022, 1, 8, 0, 3, 22, 374, DateTimeKind.Unspecified).AddTicks(1778), new TimeSpan(0, -3, 0, 0, 0)), "Licensed Frozen Fish", "One", "https://picsum.photos/500/375/?image=222&blur", 453.13m, new Guid("daeca18f-9b56-4990-88a4-5537c48a5e80"), 7, 26, 509 },
                    { new Guid("2cae3c54-4daf-4106-8c32-a7237fa880a7"), "Football", "The automobile layout consists of a front-engine design, with transaxle-type transmissions mounted at the rear of the engine and four wheel drive", "Boot", new DateTimeOffset(new DateTime(2022, 1, 16, 19, 1, 7, 130, DateTimeKind.Unspecified).AddTicks(4129), new TimeSpan(0, -3, 0, 0, 0)), "Tasty Plastic Shirt", "Two", "https://picsum.photos/500/375/?image=614&blur", 877.68m, new Guid("daeca18f-9b56-4990-88a4-5537c48a5e80"), 4, 24, 4537 },
                    { new Guid("49b5c9ba-da6f-4948-9e76-f0ad41e59cad"), "Engineer", "The Nagasaki Lander is the trademarked name of several series of Nagasaki sport bikes, that started with the 1984 ABC800J", "Boot", new DateTimeOffset(new DateTime(2022, 4, 17, 16, 54, 19, 14, DateTimeKind.Unspecified).AddTicks(5102), new TimeSpan(0, -3, 0, 0, 0)), "Refined Concrete Salad", "Three", "https://picsum.photos/500/375/?image=433&blur", 78.69m, new Guid("6f0631e5-a1f0-4abc-845a-c23614c03412"), 8, 26, 1519 },
                    { new Guid("4fe76041-da71-45a9-83d2-5bbc91b8979f"), "Harness", "The beautiful range of Apple Naturalé that has an exciting mix of natural ingredients. With the Goodness of 100% Natural Ingredients", "Boot", new DateTimeOffset(new DateTime(2021, 11, 10, 12, 0, 4, 11, DateTimeKind.Unspecified).AddTicks(8389), new TimeSpan(0, -3, 0, 0, 0)), "Refined Granite Shoes", "One", "https://picsum.photos/500/375/?image=537&blur", 255.42m, new Guid("6f0631e5-a1f0-4abc-845a-c23614c03412"), 9, 22, 1494 },
                    { new Guid("4a6e0b20-4733-4de9-8072-3002dc0e3b40"), "Engineer", "The Nagasaki Lander is the trademarked name of several series of Nagasaki sport bikes, that started with the 1984 ABC800J", "Boot", new DateTimeOffset(new DateTime(2022, 2, 6, 23, 7, 48, 218, DateTimeKind.Unspecified).AddTicks(6105), new TimeSpan(0, -3, 0, 0, 0)), "Refined Rubber Sausages", "Two", "https://picsum.photos/500/375/?image=704&blur", 665.97m, new Guid("daeca18f-9b56-4990-88a4-5537c48a5e80"), 3, 22, 4838 }
                });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "AmountOfPerson", "Description", "Discriminator", "IntroduceAt", "KayakType", "Name", "Option", "PhotoUrl", "Price", "ProductTypeId", "Rating", "Stock" },
                values: new object[,]
                {
                    { new Guid("bfd1ad24-fa5b-4778-a487-b7deb72f711c"), 3, "Boston's most advanced compression wear technology increases muscle oxygenation, stabilizes active muscles", "Kayak", new DateTimeOffset(new DateTime(2022, 3, 1, 3, 54, 17, 937, DateTimeKind.Unspecified).AddTicks(645), new TimeSpan(0, -3, 0, 0, 0)), "Diving", "Rustic Cotton Ball", "Two", "https://picsum.photos/500/375/?image=1075&blur", 50.12m, new Guid("6a88b5a9-79e5-47bd-b8ae-5bdbafa19df1"), 0, 3560 },
                    { new Guid("78052cdc-dc65-461e-b322-01758f13ddc2"), 3, "Carbonite web goalkeeper gloves are ergonomically designed to give easy fit", "Kayak", new DateTimeOffset(new DateTime(2021, 6, 9, 18, 23, 54, 307, DateTimeKind.Unspecified).AddTicks(1637), new TimeSpan(0, -3, 0, 0, 0)), "Camping", "Gorgeous Rubber Chair", "One", "https://picsum.photos/500/375/?image=2&blur", 300.35m, new Guid("daeca18f-9b56-4990-88a4-5537c48a5e80"), 10, 2793 },
                    { new Guid("a1c5cf0c-ff9b-485c-a671-c29c72d7fa5f"), 3, "The Football Is Good For Training And Recreational Purposes", "Kayak", new DateTimeOffset(new DateTime(2021, 8, 31, 15, 29, 20, 438, DateTimeKind.Unspecified).AddTicks(6762), new TimeSpan(0, -3, 0, 0, 0)), "Diving", "Gorgeous Frozen Tuna", "Three", "https://picsum.photos/500/375/?image=22&blur", 161.00m, new Guid("daeca18f-9b56-4990-88a4-5537c48a5e80"), 0, 1583 },
                    { new Guid("1f1608cf-bcce-48d5-a4d0-19df4ad0b01f"), 3, "Carbonite web goalkeeper gloves are ergonomically designed to give easy fit", "Kayak", new DateTimeOffset(new DateTime(2021, 12, 1, 8, 46, 29, 426, DateTimeKind.Unspecified).AddTicks(1798), new TimeSpan(0, -3, 0, 0, 0)), "Family", "Rustic Wooden Bike", "One", "https://picsum.photos/500/375/?image=805&blur", 733.02m, new Guid("daeca18f-9b56-4990-88a4-5537c48a5e80"), 10, 2186 },
                    { new Guid("98d66ea7-e527-4991-817f-1d1f77d9a792"), 3, "Ergonomic executive chair upholstered in bonded black leather and PVC padded seat and back for all-day comfort and support", "Kayak", new DateTimeOffset(new DateTime(2021, 11, 22, 10, 26, 13, 976, DateTimeKind.Unspecified).AddTicks(8238), new TimeSpan(0, -3, 0, 0, 0)), "Fishing", "Gorgeous Steel Bike", "One", "https://picsum.photos/500/375/?image=446&blur", 861.32m, new Guid("daeca18f-9b56-4990-88a4-5537c48a5e80"), 8, 1010 },
                    { new Guid("ca0a33b8-d8bb-4111-adfe-d0bfe99b6829"), 2, "Boston's most advanced compression wear technology increases muscle oxygenation, stabilizes active muscles", "Kayak", new DateTimeOffset(new DateTime(2021, 5, 27, 0, 30, 16, 838, DateTimeKind.Unspecified).AddTicks(1280), new TimeSpan(0, -3, 0, 0, 0)), "Family", "Sleek Fresh Chair", "Two", "https://picsum.photos/500/375/?image=706&blur", 936.44m, new Guid("6f0631e5-a1f0-4abc-845a-c23614c03412"), 1, 166 },
                    { new Guid("ffdbd5d2-2036-4ac7-872a-1e1642af2d35"), 2, "Carbonite web goalkeeper gloves are ergonomically designed to give easy fit", "Kayak", new DateTimeOffset(new DateTime(2021, 11, 1, 17, 35, 4, 88, DateTimeKind.Unspecified).AddTicks(5976), new TimeSpan(0, -3, 0, 0, 0)), "Fishing", "Gorgeous Rubber Keyboard", "Two", "https://picsum.photos/500/375/?image=866&blur", 280.30m, new Guid("6f0631e5-a1f0-4abc-845a-c23614c03412"), 2, 221 },
                    { new Guid("e852fab1-4dc0-46ec-a9db-184e4b8d96a6"), 2, "The slim & simple Maple Gaming Keyboard from Dev Byte comes with a sleek body and 7- Color RGB LED Back-lighting for smart functionality", "Kayak", new DateTimeOffset(new DateTime(2021, 10, 28, 5, 21, 25, 818, DateTimeKind.Unspecified).AddTicks(9159), new TimeSpan(0, -3, 0, 0, 0)), "Racing", "Fantastic Metal Chicken", "Two", "https://picsum.photos/500/375/?image=348&blur", 762.10m, new Guid("6a88b5a9-79e5-47bd-b8ae-5bdbafa19df1"), 3, 2636 },
                    { new Guid("5b007f1b-d0fd-4d8d-9fb9-8be48886bd76"), 1, "Andy shoes are designed to keeping in mind durability as well as trends, the most stylish range of shoes & sandals", "Kayak", new DateTimeOffset(new DateTime(2021, 7, 31, 17, 23, 47, 807, DateTimeKind.Unspecified).AddTicks(7624), new TimeSpan(0, -3, 0, 0, 0)), "Diving", "Gorgeous Fresh Pants", "Three", "https://picsum.photos/500/375/?image=866&blur", 188.39m, new Guid("6a88b5a9-79e5-47bd-b8ae-5bdbafa19df1"), 5, 1478 },
                    { new Guid("f083f613-b852-4a04-8dad-9911bbfe0e82"), 1, "Ergonomic executive chair upholstered in bonded black leather and PVC padded seat and back for all-day comfort and support", "Kayak", new DateTimeOffset(new DateTime(2021, 8, 7, 3, 35, 16, 525, DateTimeKind.Unspecified).AddTicks(1487), new TimeSpan(0, -3, 0, 0, 0)), "Racing", "Rustic Rubber Table", "Two", "https://picsum.photos/500/375/?image=63&blur", 79.46m, new Guid("6a88b5a9-79e5-47bd-b8ae-5bdbafa19df1"), 2, 1537 }
                });

            migrationBuilder.InsertData(
                table: "Reviews",
                columns: new[] { "Id", "Comment", "ProductId", "Title" },
                values: new object[,]
                {
                    { new Guid("ace7402a-0e3b-4d64-8575-28b81076d80e"), "Maxime quia corporis atque accusamus et quasi rerum. Labore qui delectus qui quo nisi cumque officia enim. Sunt quam odio explicabo corporis. Molestiae et accusantium molestiae. Ullam molestiae dolorum quia.\n\nVoluptatem non facere voluptatem voluptatem eaque. Vero dignissimos illum qui aliquid rerum ipsam harum. Qui non quam quaerat id. Est qui tempora modi molestiae est error corrupti.\n\nVeniam et in laudantium laudantium commodi eligendi et. Eligendi magni a tempora. Saepe qui repellendus aut et. Amet natus voluptatem assumenda mollitia ratione. Enim eos occaecati fugit numquam ipsam consequatur distinctio. Fugit molestiae minus in reiciendis.", new Guid("ffdbd5d2-2036-4ac7-872a-1e1642af2d35"), "Aperiam accusamus recusandae ea veritatis illo dolor eaque hic." },
                    { new Guid("5daaf9e8-bf86-4ae0-85eb-baaea2e6a242"), "Dignissimos consequatur est vel harum vitae. Eius esse culpa reprehenderit libero provident doloribus labore. Veniam doloribus minus et fuga nostrum sunt. Autem sit et.\n\nQuo est quia rem iusto eum voluptate saepe vel ipsum. Delectus qui debitis cumque cumque amet sapiente. Quis illum magnam dolorum et quis. Eaque ut aut aut voluptatum. Non eos sunt fugit veniam ipsam enim et repudiandae omnis. Velit ut quo.\n\nEligendi velit voluptatem qui molestiae rem ratione qui tenetur quia. Quis ut atque porro. Consequatur ea qui consequatur molestiae velit ut consectetur. Laudantium reprehenderit aspernatur natus. Ut fugiat dolore et nisi voluptas temporibus quos ab corporis. Non enim accusantium quia.", new Guid("ca0a33b8-d8bb-4111-adfe-d0bfe99b6829"), "Rem sunt sit dolores." },
                    { new Guid("28bea6fe-9e8b-4b19-aaa3-e96e12a5c954"), "Dolor quibusdam atque esse officiis. Aperiam quaerat sit vel nostrum. Optio aut cupiditate. Debitis perspiciatis qui minima ut dolor. Sint dolorem labore maxime sequi quia. Qui dolor qui libero dignissimos iusto eos qui totam esse.\n\nFugiat ullam atque et enim autem. Omnis reiciendis sint debitis sed quis autem et vitae qui. Itaque quis ut modi assumenda. Itaque eligendi consequatur voluptatem occaecati atque voluptatem quod consequatur. Adipisci voluptas est.\n\nEum pariatur consequatur aliquam. Iure qui omnis corrupti nihil beatae. Iure voluptatibus et omnis saepe. Sit ipsam sunt. Voluptatem modi deserunt at quia iure pariatur. Qui qui velit delectus animi eum ad nobis qui.", new Guid("78052cdc-dc65-461e-b322-01758f13ddc2"), "Necessitatibus consequatur architecto est consequatur." },
                    { new Guid("bd8c27aa-eab7-47fa-a793-b05d4d301705"), "Non consequuntur sed qui vero. Et quibusdam iste omnis numquam in sint voluptas velit recusandae. Aut quia quisquam illum. Et id ex laboriosam neque ratione magni. Sint rerum dolorum velit aut qui qui deleniti. Reiciendis hic distinctio et eos quos voluptate.\n\nSoluta dignissimos modi ea quo quis nemo sit. Mollitia consequatur quibusdam excepturi. Illum id libero adipisci dolore qui est accusantium tempora. Repellat quis tempore voluptate cumque consequuntur earum. Nihil labore sapiente ducimus repudiandae officiis.\n\nConsequuntur atque ducimus facilis voluptatem et inventore. Ut vitae labore labore itaque debitis sint deleniti corporis illo. Harum magni architecto atque accusantium in ut eum unde voluptatem.", new Guid("a1c5cf0c-ff9b-485c-a671-c29c72d7fa5f"), "Occaecati quia dolorem nesciunt est nihil magnam et." },
                    { new Guid("25b2f990-f9fb-4ca0-9373-fe8951fd6cea"), "Rerum sunt est autem molestiae libero natus impedit. Quibusdam sit quia id voluptatem laborum id iure aut. Eveniet ullam debitis recusandae quae praesentium omnis voluptas. Sit maxime odit possimus fugit autem non corrupti tempore.\n\nAut temporibus earum quo animi voluptate mollitia. Reprehenderit architecto blanditiis occaecati in enim. Nihil nihil pariatur omnis id fugiat voluptatem beatae officiis est. Possimus sit eaque et ratione. Aliquid perspiciatis nihil qui at ipsum neque.\n\nIllum consequatur exercitationem sapiente ea facilis ea quos consequatur. A a voluptas consectetur qui debitis delectus saepe illo. Explicabo fugit nesciunt dolorem autem odio magni ad impedit. Laudantium cupiditate aut quas nesciunt voluptatum. Deleniti omnis commodi officia. Ducimus error totam nihil deleniti aut.", new Guid("1f1608cf-bcce-48d5-a4d0-19df4ad0b01f"), "Animi deleniti repudiandae aut est voluptatem placeat quas." },
                    { new Guid("05faa885-818e-44b6-8a00-3dcc4ee4c3a9"), "Aut et sint minima nihil. Minus natus eum quaerat ea asperiores consequuntur quis. Voluptas qui explicabo.\n\nTempore nisi aliquam nam alias. Harum molestiae error laboriosam vel neque. Laboriosam distinctio sed perspiciatis asperiores id error. Architecto dolorem vel nemo doloremque voluptates sit. Dolor maiores eligendi repellendus qui. Ipsum est quo sed in et odit sapiente.\n\nTempora exercitationem nisi tempora labore illum dignissimos atque ut perspiciatis. Atque corporis pariatur ipsa voluptatem a et ipsum ut. Sed ab quia commodi dolore doloremque aut. Facilis minima libero neque. Nihil ab quia.", new Guid("98d66ea7-e527-4991-817f-1d1f77d9a792"), "Autem et et est aut." },
                    { new Guid("c41b1eb3-ddfc-403b-a3ce-e74939d45864"), "Cumque impedit et labore velit. Iure et in aut consequatur. Veniam qui aut est sapiente.\n\nEt ducimus saepe possimus. Consectetur delectus eveniet deserunt et nulla in dignissimos magnam. Repellendus officia minus.\n\nOmnis aspernatur voluptatum. Minus natus culpa. At est omnis.", new Guid("e852fab1-4dc0-46ec-a9db-184e4b8d96a6"), "Sunt consequatur atque eius provident quam nesciunt." },
                    { new Guid("fa9912bc-6166-4e9b-810e-e359e78164e3"), "Quisquam et maxime. Sed qui quia atque. Omnis eum laborum qui facere sequi non cum reiciendis praesentium. Dicta dolorem inventore doloremque similique sed quisquam. Ab ipsum ea non accusamus rem voluptatem consectetur et similique. Nemo est incidunt.\n\nDoloribus ipsam sed. Soluta dolores ad unde expedita. Provident ut omnis incidunt debitis. Cum sit id autem provident pariatur ea ad.\n\nQuas nam id fugiat velit et nulla. Ex sit ut saepe ipsam possimus voluptatem. Quam ipsam laboriosam eligendi saepe sunt consequuntur nemo. Eaque et a nesciunt minima earum numquam quia.", new Guid("5b007f1b-d0fd-4d8d-9fb9-8be48886bd76"), "Nisi voluptatibus sed." },
                    { new Guid("b5733d4c-54ef-49ee-a06f-585d0400f579"), "Iusto voluptates ut aliquid et est nostrum officiis. Sapiente quo neque ut dolores ipsam. Inventore et temporibus culpa voluptatem.\n\nFacere tenetur nobis asperiores quia. Consequatur sunt reiciendis illo tenetur omnis quae. Perferendis quo cum nulla libero nostrum et consequuntur et. Nam fugit facilis consequatur sit.\n\nPlaceat dolor et ut consequuntur qui quasi a tempore natus. Reiciendis qui et impedit libero id voluptate. Ratione autem molestias autem id voluptatem autem qui et numquam. Inventore est hic voluptatem dicta ipsa incidunt illo.", new Guid("bfd1ad24-fa5b-4778-a487-b7deb72f711c"), "Rerum in et vitae odio sit porro." },
                    { new Guid("a9cfae22-19fe-4cad-9234-816962cf5dd0"), "Autem consequatur eum reiciendis. Maiores animi suscipit nam blanditiis doloribus minus. Consectetur incidunt soluta et pariatur aut natus. Culpa placeat possimus tenetur laudantium veritatis id. Iure sunt in iure eaque. Dolor exercitationem doloremque voluptatibus.\n\nError ratione et iste in. Quod enim beatae quam. Et est sunt unde ut odio aperiam modi sit velit. Ea commodi dolorem unde voluptas. Eum magni aut veniam velit harum. Ut dolores magni voluptatem quasi qui nemo.\n\nEst corporis tenetur similique aut. Ut veritatis et similique quae suscipit recusandae. Ea sint aperiam consequatur distinctio qui id et. Delectus architecto vero quaerat eum perferendis corrupti dolores.", new Guid("f083f613-b852-4a04-8dad-9911bbfe0e82"), "Dicta inventore quas eos veniam." }
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
