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
                values: new object[] { new Guid("301e6738-d1db-4836-8f52-9e8b8d861661"), "TypeOne" });

            migrationBuilder.InsertData(
                table: "ProductTypes",
                columns: new[] { "Id", "Discriminator" },
                values: new object[] { new Guid("626cac8b-2c91-4f20-9bf3-72b86e31f119"), "TypeThree" });

            migrationBuilder.InsertData(
                table: "ProductTypes",
                columns: new[] { "Id", "Discriminator" },
                values: new object[] { new Guid("3a02a977-1124-405f-a52f-978887273586"), "TypeTwo" });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "BackpackType", "Description", "Discriminator", "IntroduceAt", "Name", "Option", "PhotoUrl", "Price", "ProductTypeId", "Rating", "Stock" },
                values: new object[,]
                {
                    { new Guid("b825d366-0023-4a5c-8ea8-da2057d624e8"), "Snowsports", "Boston's most advanced compression wear technology increases muscle oxygenation, stabilizes active muscles", "Backpack", new DateTimeOffset(new DateTime(2021, 5, 9, 9, 53, 44, 841, DateTimeKind.Unspecified).AddTicks(4263), new TimeSpan(0, -3, 0, 0, 0)), "Handmade Rubber Ball", "Three", "https://picsum.photos/500/375/?image=323&blur", 878.78m, new Guid("301e6738-d1db-4836-8f52-9e8b8d861661"), 10, 784 },
                    { new Guid("5906af6d-7d9a-439c-96ad-b5918d3bf9de"), "Climbing", "The slim & simple Maple Gaming Keyboard from Dev Byte comes with a sleek body and 7- Color RGB LED Back-lighting for smart functionality", "Backpack", new DateTimeOffset(new DateTime(2021, 12, 2, 18, 30, 51, 364, DateTimeKind.Unspecified).AddTicks(7441), new TimeSpan(0, -3, 0, 0, 0)), "Licensed Steel Keyboard", "Three", "https://picsum.photos/500/375/?image=983&blur", 143.19m, new Guid("301e6738-d1db-4836-8f52-9e8b8d861661"), 0, 3470 },
                    { new Guid("39caff60-96b6-4205-9cb1-307e0462f661"), "Climbing", "The automobile layout consists of a front-engine design, with transaxle-type transmissions mounted at the rear of the engine and four wheel drive", "Backpack", new DateTimeOffset(new DateTime(2021, 7, 18, 4, 12, 7, 233, DateTimeKind.Unspecified).AddTicks(5514), new TimeSpan(0, -3, 0, 0, 0)), "Unbranded Plastic Soap", "Two", "https://picsum.photos/500/375/?image=703&blur", 282.71m, new Guid("626cac8b-2c91-4f20-9bf3-72b86e31f119"), 4, 3584 },
                    { new Guid("901d3139-d7a7-45ba-9ecc-66305d7963fe"), "Overnight", "New range of formal shirts are designed keeping you in mind. With fits and styling that will make you stand apart", "Backpack", new DateTimeOffset(new DateTime(2022, 4, 30, 20, 18, 28, 243, DateTimeKind.Unspecified).AddTicks(6779), new TimeSpan(0, -3, 0, 0, 0)), "Small Fresh Bacon", "One", "https://picsum.photos/500/375/?image=1011&blur", 250.23m, new Guid("626cac8b-2c91-4f20-9bf3-72b86e31f119"), 0, 434 },
                    { new Guid("8c6cadbe-8976-41a8-aa61-3605f56df5fd"), "DayPack", "Andy shoes are designed to keeping in mind durability as well as trends, the most stylish range of shoes & sandals", "Backpack", new DateTimeOffset(new DateTime(2022, 1, 21, 18, 27, 54, 601, DateTimeKind.Unspecified).AddTicks(3124), new TimeSpan(0, -3, 0, 0, 0)), "Handmade Plastic Keyboard", "Two", "https://picsum.photos/500/375/?image=995&blur", 638.39m, new Guid("626cac8b-2c91-4f20-9bf3-72b86e31f119"), 7, 4841 },
                    { new Guid("c56b7fa4-0435-46be-a117-08aa0d64eb54"), "Hiking", "New ABC 13 9370, 13.3, 5th Gen CoreA5-8250U, 8GB RAM, 256GB SSD, power UHD Graphics, OS 10 Home, OS Office A & J 2016", "Backpack", new DateTimeOffset(new DateTime(2021, 9, 4, 6, 54, 41, 482, DateTimeKind.Unspecified).AddTicks(9168), new TimeSpan(0, -3, 0, 0, 0)), "Handmade Concrete Hat", "One", "https://picsum.photos/500/375/?image=55&blur", 312.40m, new Guid("626cac8b-2c91-4f20-9bf3-72b86e31f119"), 1, 4635 },
                    { new Guid("f2fb341c-e8d7-4b82-acd3-e0d31b540e33"), "DayPack", "The Football Is Good For Training And Recreational Purposes", "Backpack", new DateTimeOffset(new DateTime(2021, 8, 18, 15, 14, 41, 529, DateTimeKind.Unspecified).AddTicks(7507), new TimeSpan(0, -3, 0, 0, 0)), "Unbranded Metal Cheese", "Two", "https://picsum.photos/500/375/?image=910&blur", 922.84m, new Guid("626cac8b-2c91-4f20-9bf3-72b86e31f119"), 6, 3606 },
                    { new Guid("f59364a4-0fa5-4d13-a5bb-3ce64fb73ce0"), "Overnight", "Andy shoes are designed to keeping in mind durability as well as trends, the most stylish range of shoes & sandals", "Backpack", new DateTimeOffset(new DateTime(2021, 7, 27, 4, 59, 57, 43, DateTimeKind.Unspecified).AddTicks(2323), new TimeSpan(0, -3, 0, 0, 0)), "Gorgeous Cotton Table", "Three", "https://picsum.photos/500/375/?image=808&blur", 884.22m, new Guid("626cac8b-2c91-4f20-9bf3-72b86e31f119"), 7, 4004 },
                    { new Guid("8156e01c-71c4-45b1-9e30-1c0e1c12c15a"), "Hiking", "Boston's most advanced compression wear technology increases muscle oxygenation, stabilizes active muscles", "Backpack", new DateTimeOffset(new DateTime(2021, 10, 6, 23, 41, 27, 204, DateTimeKind.Unspecified).AddTicks(9637), new TimeSpan(0, -3, 0, 0, 0)), "Intelligent Steel Gloves", "One", "https://picsum.photos/500/375/?image=300&blur", 755.50m, new Guid("3a02a977-1124-405f-a52f-978887273586"), 7, 3571 },
                    { new Guid("bf3eb5f8-d884-4c52-96ff-8fbe4529bd2c"), "Hiking", "Ergonomic executive chair upholstered in bonded black leather and PVC padded seat and back for all-day comfort and support", "Backpack", new DateTimeOffset(new DateTime(2022, 3, 18, 8, 59, 10, 163, DateTimeKind.Unspecified).AddTicks(8137), new TimeSpan(0, -3, 0, 0, 0)), "Licensed Metal Soap", "One", "https://picsum.photos/500/375/?image=17&blur", 932.60m, new Guid("3a02a977-1124-405f-a52f-978887273586"), 7, 1499 }
                });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "BootType", "Description", "Discriminator", "IntroduceAt", "Name", "Option", "PhotoUrl", "Price", "ProductTypeId", "Rating", "Size", "Stock" },
                values: new object[,]
                {
                    { new Guid("e5b26f70-4211-4308-b445-ee0a4a2a5f19"), "Engineer", "Ergonomic executive chair upholstered in bonded black leather and PVC padded seat and back for all-day comfort and support", "Boot", new DateTimeOffset(new DateTime(2022, 2, 17, 10, 55, 33, 750, DateTimeKind.Unspecified).AddTicks(922), new TimeSpan(0, -3, 0, 0, 0)), "Intelligent Steel Chair", "Two", "https://picsum.photos/500/375/?image=817&blur", 175.86m, new Guid("3a02a977-1124-405f-a52f-978887273586"), 10, 30, 193 },
                    { new Guid("bd379ae6-daf4-4b70-9e30-3dd180f511d2"), "Engineer", "The slim & simple Maple Gaming Keyboard from Dev Byte comes with a sleek body and 7- Color RGB LED Back-lighting for smart functionality", "Boot", new DateTimeOffset(new DateTime(2021, 5, 28, 16, 47, 33, 743, DateTimeKind.Unspecified).AddTicks(3908), new TimeSpan(0, -3, 0, 0, 0)), "Refined Rubber Cheese", "Three", "https://picsum.photos/500/375/?image=206&blur", 254.07m, new Guid("3a02a977-1124-405f-a52f-978887273586"), 5, 20, 966 },
                    { new Guid("88a354e4-5e40-4ab6-a699-86d557b8710d"), "Chelsea", "The automobile layout consists of a front-engine design, with transaxle-type transmissions mounted at the rear of the engine and four wheel drive", "Boot", new DateTimeOffset(new DateTime(2021, 8, 22, 20, 39, 31, 641, DateTimeKind.Unspecified).AddTicks(9244), new TimeSpan(0, -3, 0, 0, 0)), "Sleek Metal Towels", "Two", "https://picsum.photos/500/375/?image=927&blur", 478.69m, new Guid("3a02a977-1124-405f-a52f-978887273586"), 7, 24, 709 },
                    { new Guid("4f3094ec-ec70-4f5f-b53e-7fd0801c12ab"), "Cowboy", "Carbonite web goalkeeper gloves are ergonomically designed to give easy fit", "Boot", new DateTimeOffset(new DateTime(2021, 5, 2, 21, 28, 34, 791, DateTimeKind.Unspecified).AddTicks(4065), new TimeSpan(0, -3, 0, 0, 0)), "Handcrafted Rubber Chair", "One", "https://picsum.photos/500/375/?image=332&blur", 879.45m, new Guid("3a02a977-1124-405f-a52f-978887273586"), 10, 22, 2747 },
                    { new Guid("43905107-13ef-4a79-83f0-f2387aab98ae"), "Drysuit", "Ergonomic executive chair upholstered in bonded black leather and PVC padded seat and back for all-day comfort and support", "Boot", new DateTimeOffset(new DateTime(2021, 11, 1, 19, 44, 55, 369, DateTimeKind.Unspecified).AddTicks(3693), new TimeSpan(0, -3, 0, 0, 0)), "Intelligent Soft Soap", "Two", "https://picsum.photos/500/375/?image=951&blur", 490.50m, new Guid("626cac8b-2c91-4f20-9bf3-72b86e31f119"), 8, 21, 3155 },
                    { new Guid("e879d31d-af94-4075-848b-9b898e6d8a8c"), "Drysuit", "Boston's most advanced compression wear technology increases muscle oxygenation, stabilizes active muscles", "Boot", new DateTimeOffset(new DateTime(2021, 5, 22, 1, 46, 10, 679, DateTimeKind.Unspecified).AddTicks(8419), new TimeSpan(0, -3, 0, 0, 0)), "Sleek Granite Shoes", "One", "https://picsum.photos/500/375/?image=260&blur", 882.66m, new Guid("626cac8b-2c91-4f20-9bf3-72b86e31f119"), 0, 20, 4232 },
                    { new Guid("4af43ffd-b763-44ef-b030-9e166cc46fe0"), "Chelsea", "Carbonite web goalkeeper gloves are ergonomically designed to give easy fit", "Boot", new DateTimeOffset(new DateTime(2022, 3, 22, 6, 33, 4, 113, DateTimeKind.Unspecified).AddTicks(677), new TimeSpan(0, -3, 0, 0, 0)), "Intelligent Granite Cheese", "One", "https://picsum.photos/500/375/?image=155&blur", 261.28m, new Guid("626cac8b-2c91-4f20-9bf3-72b86e31f119"), 0, 20, 1591 },
                    { new Guid("16519414-ac3b-4900-a80c-190c69859e55"), "Engineer", "Boston's most advanced compression wear technology increases muscle oxygenation, stabilizes active muscles", "Boot", new DateTimeOffset(new DateTime(2021, 5, 14, 18, 13, 58, 881, DateTimeKind.Unspecified).AddTicks(703), new TimeSpan(0, -3, 0, 0, 0)), "Practical Fresh Ball", "One", "https://picsum.photos/500/375/?image=948&blur", 209.07m, new Guid("626cac8b-2c91-4f20-9bf3-72b86e31f119"), 1, 22, 2400 },
                    { new Guid("d3123987-8390-41e1-be0b-d0d4f578bd6a"), "Harness", "New ABC 13 9370, 13.3, 5th Gen CoreA5-8250U, 8GB RAM, 256GB SSD, power UHD Graphics, OS 10 Home, OS Office A & J 2016", "Boot", new DateTimeOffset(new DateTime(2022, 4, 7, 5, 33, 54, 659, DateTimeKind.Unspecified).AddTicks(3281), new TimeSpan(0, -3, 0, 0, 0)), "Ergonomic Wooden Table", "Three", "https://picsum.photos/500/375/?image=328&blur", 524.59m, new Guid("301e6738-d1db-4836-8f52-9e8b8d861661"), 2, 20, 2371 },
                    { new Guid("528969f7-c7be-4679-a974-b7eb9b6e9d0c"), "Engineer", "Boston's most advanced compression wear technology increases muscle oxygenation, stabilizes active muscles", "Boot", new DateTimeOffset(new DateTime(2022, 3, 18, 3, 23, 41, 799, DateTimeKind.Unspecified).AddTicks(8409), new TimeSpan(0, -3, 0, 0, 0)), "Gorgeous Steel Chips", "Two", "https://picsum.photos/500/375/?image=879&blur", 949.71m, new Guid("301e6738-d1db-4836-8f52-9e8b8d861661"), 8, 20, 1935 }
                });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "AmountOfPerson", "Description", "Discriminator", "IntroduceAt", "KayakType", "Name", "Option", "PhotoUrl", "Price", "ProductTypeId", "Rating", "Stock" },
                values: new object[,]
                {
                    { new Guid("8c15793b-bdf5-4818-950b-3cad57493d93"), 2, "The Apollotech B340 is an affordable wireless mouse with reliable connectivity, 12 months battery life and modern design", "Kayak", new DateTimeOffset(new DateTime(2021, 12, 27, 16, 46, 53, 906, DateTimeKind.Unspecified).AddTicks(5469), new TimeSpan(0, -3, 0, 0, 0)), "Fishing", "Small Granite Salad", "One", "https://picsum.photos/500/375/?image=116&blur", 610.22m, new Guid("626cac8b-2c91-4f20-9bf3-72b86e31f119"), 3, 1000 },
                    { new Guid("2416836c-ee63-4252-9b3d-34a28d8f86c8"), 1, "Ergonomic executive chair upholstered in bonded black leather and PVC padded seat and back for all-day comfort and support", "Kayak", new DateTimeOffset(new DateTime(2021, 7, 2, 15, 18, 37, 873, DateTimeKind.Unspecified).AddTicks(115), new TimeSpan(0, -3, 0, 0, 0)), "Family", "Ergonomic Plastic Soap", "Two", "https://picsum.photos/500/375/?image=208&blur", 383.03m, new Guid("626cac8b-2c91-4f20-9bf3-72b86e31f119"), 2, 1959 },
                    { new Guid("12094de7-443d-4ebb-a887-49a01d6c5c65"), 3, "Ergonomic executive chair upholstered in bonded black leather and PVC padded seat and back for all-day comfort and support", "Kayak", new DateTimeOffset(new DateTime(2021, 9, 26, 13, 11, 50, 685, DateTimeKind.Unspecified).AddTicks(5116), new TimeSpan(0, -3, 0, 0, 0)), "Diving", "Intelligent Fresh Hat", "One", "https://picsum.photos/500/375/?image=219&blur", 20.93m, new Guid("626cac8b-2c91-4f20-9bf3-72b86e31f119"), 6, 4182 },
                    { new Guid("66351a09-cc05-4983-8af9-67233b51a9e6"), 2, "Ergonomic executive chair upholstered in bonded black leather and PVC padded seat and back for all-day comfort and support", "Kayak", new DateTimeOffset(new DateTime(2021, 6, 24, 23, 31, 1, 614, DateTimeKind.Unspecified).AddTicks(5075), new TimeSpan(0, -3, 0, 0, 0)), "Fishing", "Refined Steel Computer", "Three", "https://picsum.photos/500/375/?image=867&blur", 62.54m, new Guid("626cac8b-2c91-4f20-9bf3-72b86e31f119"), 6, 3259 },
                    { new Guid("c3d65c01-be1d-4577-8acd-cae54e37b4d3"), 1, "Carbonite web goalkeeper gloves are ergonomically designed to give easy fit", "Kayak", new DateTimeOffset(new DateTime(2021, 12, 20, 15, 26, 41, 917, DateTimeKind.Unspecified).AddTicks(1912), new TimeSpan(0, -3, 0, 0, 0)), "Racing", "Licensed Concrete Mouse", "Three", "https://picsum.photos/500/375/?image=418&blur", 711.34m, new Guid("301e6738-d1db-4836-8f52-9e8b8d861661"), 0, 501 },
                    { new Guid("efb39614-f2dc-489b-a458-e97e7bd49d60"), 1, "Carbonite web goalkeeper gloves are ergonomically designed to give easy fit", "Kayak", new DateTimeOffset(new DateTime(2021, 7, 12, 1, 34, 59, 49, DateTimeKind.Unspecified).AddTicks(4261), new TimeSpan(0, -3, 0, 0, 0)), "Camping", "Practical Steel Gloves", "One", "https://picsum.photos/500/375/?image=1080&blur", 86.25m, new Guid("301e6738-d1db-4836-8f52-9e8b8d861661"), 10, 2862 },
                    { new Guid("1aff9598-62dc-4fab-83fb-d4bb71bd81ee"), 1, "The automobile layout consists of a front-engine design, with transaxle-type transmissions mounted at the rear of the engine and four wheel drive", "Kayak", new DateTimeOffset(new DateTime(2021, 9, 29, 8, 32, 43, 234, DateTimeKind.Unspecified).AddTicks(3685), new TimeSpan(0, -3, 0, 0, 0)), "Racing", "Gorgeous Metal Bacon", "Three", "https://picsum.photos/500/375/?image=7&blur", 864.81m, new Guid("3a02a977-1124-405f-a52f-978887273586"), 10, 1883 },
                    { new Guid("d5867a40-9000-4c19-baa2-92c88c1029ed"), 2, "New range of formal shirts are designed keeping you in mind. With fits and styling that will make you stand apart", "Kayak", new DateTimeOffset(new DateTime(2021, 7, 7, 3, 5, 15, 333, DateTimeKind.Unspecified).AddTicks(5963), new TimeSpan(0, -3, 0, 0, 0)), "Family", "Ergonomic Granite Computer", "Two", "https://picsum.photos/500/375/?image=643&blur", 463.99m, new Guid("3a02a977-1124-405f-a52f-978887273586"), 1, 23 },
                    { new Guid("f7db1c45-3751-4b21-af88-7fb951a7ce53"), 2, "The automobile layout consists of a front-engine design, with transaxle-type transmissions mounted at the rear of the engine and four wheel drive", "Kayak", new DateTimeOffset(new DateTime(2021, 12, 25, 18, 4, 14, 264, DateTimeKind.Unspecified).AddTicks(6747), new TimeSpan(0, -3, 0, 0, 0)), "Family", "Awesome Metal Soap", "Two", "https://picsum.photos/500/375/?image=346&blur", 741.22m, new Guid("3a02a977-1124-405f-a52f-978887273586"), 10, 1474 },
                    { new Guid("f4e63cbc-05f9-429d-bb06-f1c738bc35bc"), 2, "New range of formal shirts are designed keeping you in mind. With fits and styling that will make you stand apart", "Kayak", new DateTimeOffset(new DateTime(2021, 6, 1, 15, 51, 24, 697, DateTimeKind.Unspecified).AddTicks(9549), new TimeSpan(0, -3, 0, 0, 0)), "Racing", "Unbranded Metal Chair", "Three", "https://picsum.photos/500/375/?image=179&blur", 922.65m, new Guid("3a02a977-1124-405f-a52f-978887273586"), 0, 1896 }
                });

            migrationBuilder.InsertData(
                table: "Reviews",
                columns: new[] { "Id", "Comment", "ProductId", "Title" },
                values: new object[,]
                {
                    { new Guid("0d9dc902-fe76-4e44-beaf-e37231ca9fe3"), "Quae sit ut id blanditiis. Ut dicta atque non sint eum. Non aut fugiat. Quo inventore sint qui et praesentium a est quaerat. Perferendis incidunt mollitia eum distinctio ut doloremque soluta ipsa fugit.\n\nDolor facere dolorem dicta ut distinctio voluptatem velit eaque. Qui quos est quisquam facere qui. Voluptatem sint deserunt cum ea est cupiditate reprehenderit. Architecto cupiditate enim dolore quo. Fuga facere nihil dicta nihil corrupti.\n\nMinus perferendis non rerum. Nisi consequuntur omnis laborum voluptatem quasi quis excepturi. Blanditiis nemo nesciunt nulla eum aliquam architecto eaque doloremque voluptas. Vero illo voluptates eum.", new Guid("efb39614-f2dc-489b-a458-e97e7bd49d60"), "Esse excepturi impedit quisquam at temporibus tenetur." },
                    { new Guid("2e5254bf-5d86-4b6a-8444-ce0e0d2109a3"), "Corrupti doloremque eos eum neque. Est itaque repudiandae temporibus et ut fugit et. Autem et minus asperiores libero fugit est quod architecto.\n\nAsperiores aut omnis cum impedit. Commodi molestias tempore deleniti non nihil dolor. Enim ut eum dolorem. Velit perspiciatis voluptas. Reiciendis cupiditate commodi aut velit fugit odio.\n\nRatione totam maxime qui soluta ipsa optio. Accusamus omnis sed ut explicabo temporibus. Et repellat et itaque aut quia. Amet qui qui dolores eligendi numquam sapiente.", new Guid("c3d65c01-be1d-4577-8acd-cae54e37b4d3"), "Velit dolore minima." },
                    { new Guid("eb8c7018-3131-48b1-af29-d3dc1400fbbb"), "Est sapiente et saepe ea ut non culpa. Cupiditate est neque ut saepe fuga suscipit nulla facilis aliquam. Et numquam enim vero magni harum itaque quae.\n\nDicta laborum ab et. Tempore dignissimos et minima distinctio soluta maiores. Qui officiis necessitatibus. Eum ut optio in voluptatem deserunt eaque sint.\n\nVoluptas officia perspiciatis sit quia quia aut et. Rerum sit aut. Iure facilis officia et mollitia quasi fugiat quae nemo. Ut enim voluptas est beatae modi ut. Ut autem eveniet voluptatem et beatae neque culpa magni sapiente. Iure enim reprehenderit iure et incidunt odio sapiente maxime et.", new Guid("8c15793b-bdf5-4818-950b-3cad57493d93"), "Voluptatum minima assumenda quis veritatis reiciendis facere similique iusto." },
                    { new Guid("102fc691-c447-47a8-b274-f1d1c87925de"), "Excepturi voluptas in doloremque non. Velit quidem quos consequatur et. Mollitia accusamus excepturi. Et fuga quibusdam. Cum ut ex est quae officiis modi. Cupiditate veritatis architecto sed.\n\nQuia fugit totam excepturi minus quasi. Facilis dolores molestias unde facere. Itaque perspiciatis hic provident.\n\nConsectetur dolorem earum esse saepe et et in cumque. Non culpa error. Nulla odit sequi. Et voluptatem itaque. Dolorem voluptas ad.", new Guid("2416836c-ee63-4252-9b3d-34a28d8f86c8"), "Ad facere tempore." },
                    { new Guid("8a8d7aec-b665-4e9a-a628-7ce00ae62551"), "Commodi illo modi dolorum facere quidem maxime. Nostrum aspernatur sunt rerum explicabo eveniet. Omnis velit expedita aliquid aut voluptatem ut ut. Voluptatem voluptates sequi nulla.\n\nRepellat ut et aut. Sed et et. Consequatur optio ipsa corporis debitis tempore dolorem qui accusantium. Et magnam velit non.\n\nSint quisquam minima rerum ut aut voluptatibus sunt illo. Exercitationem accusantium repudiandae possimus voluptatem ut dicta numquam reprehenderit architecto. Qui asperiores et ut. Illum natus voluptas facilis est unde. Harum repellat eum numquam tempore earum dicta dolor fugit.", new Guid("12094de7-443d-4ebb-a887-49a01d6c5c65"), "Numquam suscipit illo ut voluptatem aspernatur." },
                    { new Guid("ca6f8d18-17ec-49dd-9f14-310c9f1da02d"), "Ea iusto officia id. Cumque sit aut fuga facere fugiat sit. Non voluptatem nisi veniam cum eum eos et.\n\nQui ullam veritatis molestiae amet. Aliquid provident sed ex officia rerum consequuntur. Dicta consectetur laboriosam aut.\n\nQuis et veritatis quia voluptate consequatur eum et. Ab nam quidem quis ipsum eligendi quas ut nisi harum. Vel consequatur dolor iusto officia sed eum commodi magnam omnis.", new Guid("66351a09-cc05-4983-8af9-67233b51a9e6"), "Impedit qui eligendi nisi ipsam non beatae." },
                    { new Guid("a702b5c9-81e6-477e-a953-721fc5a92a9f"), "Ab beatae sed accusantium praesentium harum. Et est omnis eos nihil sint asperiores quas. Assumenda est ea quos eos dolor velit praesentium occaecati.\n\nVoluptatem officiis atque nisi sit necessitatibus rem. Facilis eos ullam possimus accusamus ratione. Tenetur neque laudantium suscipit rem doloremque fuga ex. Quidem recusandae dolorem maiores voluptatem et sunt ipsam temporibus.\n\nLaborum dolorum animi mollitia qui temporibus sapiente est et tenetur. Ut temporibus quis dolorem quo nisi repudiandae. Est occaecati recusandae iste earum. Qui sed totam accusantium repudiandae. Sed dicta earum maxime. Fugit omnis porro molestias nihil.", new Guid("1aff9598-62dc-4fab-83fb-d4bb71bd81ee"), "Dolore sapiente et aut ipsam eum." },
                    { new Guid("124f65c6-632b-4735-abaa-a6bfa06cee06"), "Rerum autem illo quia dignissimos fuga ducimus facilis nulla rem. Libero soluta nobis quis quia deserunt in nulla omnis. Autem officiis nostrum repudiandae eius voluptatem dolore ipsam neque inventore. Qui dolores delectus nostrum totam aut. Earum voluptate reprehenderit velit qui aut illo. Voluptas libero enim neque laborum illum esse.\n\nEaque eum laboriosam rerum ipsa. Quidem unde nihil nostrum. Dolorum vitae et consequatur ut quos et. Nisi consequatur magnam iste omnis sint sed adipisci. Sit illum ratione illum aut vel odit itaque occaecati. Est doloribus fuga quasi.\n\nUt eaque possimus quis aut. Eius suscipit enim ducimus minus blanditiis. Accusantium eum nemo.", new Guid("d5867a40-9000-4c19-baa2-92c88c1029ed"), "Suscipit quas optio necessitatibus quis quasi qui qui eaque." },
                    { new Guid("518085b8-33c8-4c8a-ba3d-ccca7246b952"), "Numquam molestiae natus est sunt consequatur tempora. Aut quia nostrum modi consequuntur quisquam cumque numquam. Beatae alias cum magnam ab id quo ea. Nihil est facere. Placeat adipisci recusandae quod a dolorem. Debitis deleniti sint.\n\nEius optio dolores est qui nam non et impedit. Cumque expedita et. Aspernatur impedit ipsum officiis. Nesciunt eos ut voluptas. Maiores repellat aliquam.\n\nEt sed repudiandae maxime est. Repellat sequi in ad fugiat velit incidunt nihil optio fugiat. Ea et rerum dignissimos minima tempora sed velit soluta quos. Laudantium voluptas nemo et impedit. Maiores possimus incidunt dolorem temporibus sapiente aut.", new Guid("f7db1c45-3751-4b21-af88-7fb951a7ce53"), "Illum qui totam suscipit." },
                    { new Guid("8e1001b4-dfd2-48f2-9a9d-45c53c249c8f"), "Quia nostrum eum provident. Nobis quas et dicta vel nihil dolore magni doloremque. Error voluptatem natus unde. Velit doloremque ut esse recusandae voluptatem cupiditate. Ea enim et facilis ab.\n\nNon sint sequi perferendis est dolor ullam. Ea id similique et sit et sunt numquam suscipit. Enim consequatur qui cupiditate. Consequatur ullam molestiae nesciunt quaerat aspernatur unde. Aut et natus quaerat voluptas in similique ad nisi. Deserunt blanditiis velit qui ipsa ipsam saepe beatae.\n\nId ab tempore. Repellat provident magnam. Error ab omnis in vero dicta saepe dolorem aliquam eaque. Sit sed dolores debitis eaque laborum dolor. Corporis magnam eum ex est magnam sit.", new Guid("f4e63cbc-05f9-429d-bb06-f1c738bc35bc"), "Quod enim minus." }
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
