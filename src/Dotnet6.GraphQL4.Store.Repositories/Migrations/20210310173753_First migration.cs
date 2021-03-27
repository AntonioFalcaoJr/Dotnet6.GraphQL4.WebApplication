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
                values: new object[] { new Guid("fcf9d0df-a663-4687-bdae-4c2b2db3ac15"), "TypeOne" });

            migrationBuilder.InsertData(
                table: "ProductTypes",
                columns: new[] { "Id", "Discriminator" },
                values: new object[] { new Guid("f0156fb5-a199-4e0a-8202-00492d9ef006"), "TypeThree" });

            migrationBuilder.InsertData(
                table: "ProductTypes",
                columns: new[] { "Id", "Discriminator" },
                values: new object[] { new Guid("8be5fcac-91a2-40e8-b23e-e2d9c24b0bc8"), "TypeTwo" });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "BackpackType", "Description", "Discriminator", "IntroduceAt", "Name", "Option", "PhotoUrl", "Price", "ProductTypeId", "Rating", "Stock" },
                values: new object[] { new Guid("8c78129c-0cdf-4efc-b9dd-26daa427cec7"), "Snowsports", "The Football Is Good For Training And Recreational Purposes", "Backpack", new DateTimeOffset(new DateTime(2021, 4, 23, 20, 21, 12, 456, DateTimeKind.Unspecified).AddTicks(3393), new TimeSpan(0, -3, 0, 0, 0)), "Refined Soft Towels", "Two", "https://picsum.photos/500/375/?image=179&blur", 101.81m, new Guid("fcf9d0df-a663-4687-bdae-4c2b2db3ac15"), 7, 581 });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "BootType", "Description", "Discriminator", "IntroduceAt", "Name", "Option", "PhotoUrl", "Price", "ProductTypeId", "Rating", "Size", "Stock" },
                values: new object[] { new Guid("8e54b1ba-052a-49a6-9042-81e19ec9c37c"), "Engineer", "New ABC 13 9370, 13.3, 5th Gen CoreA5-8250U, 8GB RAM, 256GB SSD, power UHD Graphics, OS 10 Home, OS Office A & J 2016", "Boot", new DateTimeOffset(new DateTime(2021, 3, 11, 21, 26, 23, 921, DateTimeKind.Unspecified).AddTicks(7406), new TimeSpan(0, -3, 0, 0, 0)), "Small Metal Shoes", "Three", "https://picsum.photos/500/375/?image=158&blur", 199.08m, new Guid("8be5fcac-91a2-40e8-b23e-e2d9c24b0bc8"), 1, 26, 2105 });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "BackpackType", "Description", "Discriminator", "IntroduceAt", "Name", "Option", "PhotoUrl", "Price", "ProductTypeId", "Rating", "Stock" },
                values: new object[,]
                {
                    { new Guid("4909b9a6-6dfc-469c-8eac-cc1ea27968ef"), "Hiking", "Boston's most advanced compression wear technology increases muscle oxygenation, stabilizes active muscles", "Backpack", new DateTimeOffset(new DateTime(2021, 10, 26, 3, 7, 49, 705, DateTimeKind.Unspecified).AddTicks(2788), new TimeSpan(0, -3, 0, 0, 0)), "Unbranded Wooden Hat", "One", "https://picsum.photos/500/375/?image=114&blur", 349.12m, new Guid("8be5fcac-91a2-40e8-b23e-e2d9c24b0bc8"), 9, 2595 },
                    { new Guid("a4779665-8130-4ce5-8b56-768830132007"), "Overnight", "The Apollotech B340 is an affordable wireless mouse with reliable connectivity, 12 months battery life and modern design", "Backpack", new DateTimeOffset(new DateTime(2022, 3, 5, 20, 25, 2, 795, DateTimeKind.Unspecified).AddTicks(2268), new TimeSpan(0, -3, 0, 0, 0)), "Gorgeous Wooden Shirt", "One", "https://picsum.photos/500/375/?image=758&blur", 770.78m, new Guid("8be5fcac-91a2-40e8-b23e-e2d9c24b0bc8"), 4, 4912 },
                    { new Guid("2d26d129-0e07-4222-8924-9ae6d6826b00"), "DayPack", "Boston's most advanced compression wear technology increases muscle oxygenation, stabilizes active muscles", "Backpack", new DateTimeOffset(new DateTime(2021, 9, 30, 12, 19, 15, 132, DateTimeKind.Unspecified).AddTicks(8023), new TimeSpan(0, -3, 0, 0, 0)), "Incredible Steel Fish", "Three", "https://picsum.photos/500/375/?image=1010&blur", 944.09m, new Guid("8be5fcac-91a2-40e8-b23e-e2d9c24b0bc8"), 0, 1195 }
                });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "AmountOfPerson", "Description", "Discriminator", "IntroduceAt", "KayakType", "Name", "Option", "PhotoUrl", "Price", "ProductTypeId", "Rating", "Stock" },
                values: new object[,]
                {
                    { new Guid("8f7cfbdd-3413-44ae-b987-052fd9f3bfdd"), 3, "The Nagasaki Lander is the trademarked name of several series of Nagasaki sport bikes, that started with the 1984 ABC800J", "Kayak", new DateTimeOffset(new DateTime(2021, 6, 26, 8, 51, 18, 511, DateTimeKind.Unspecified).AddTicks(2321), new TimeSpan(0, -3, 0, 0, 0)), "Family", "Tasty Metal Hat", "Two", "https://picsum.photos/500/375/?image=218&blur", 95.87m, new Guid("f0156fb5-a199-4e0a-8202-00492d9ef006"), 0, 2584 },
                    { new Guid("1a209ada-113f-48c6-a446-7f6ed7d74177"), 3, "The automobile layout consists of a front-engine design, with transaxle-type transmissions mounted at the rear of the engine and four wheel drive", "Kayak", new DateTimeOffset(new DateTime(2021, 3, 25, 2, 32, 42, 421, DateTimeKind.Unspecified).AddTicks(252), new TimeSpan(0, -3, 0, 0, 0)), "Racing", "Licensed Rubber Computer", "One", "https://picsum.photos/500/375/?image=1033&blur", 407.97m, new Guid("f0156fb5-a199-4e0a-8202-00492d9ef006"), 9, 4730 },
                    { new Guid("7db9e906-bc20-44c8-8421-204033e81e8d"), 3, "New range of formal shirts are designed keeping you in mind. With fits and styling that will make you stand apart", "Kayak", new DateTimeOffset(new DateTime(2021, 12, 9, 17, 9, 32, 38, DateTimeKind.Unspecified).AddTicks(1829), new TimeSpan(0, -3, 0, 0, 0)), "Racing", "Handcrafted Frozen Ball", "One", "https://picsum.photos/500/375/?image=218&blur", 367.81m, new Guid("f0156fb5-a199-4e0a-8202-00492d9ef006"), 8, 2851 },
                    { new Guid("d5498321-41f6-484c-8228-dc325a357340"), 1, "The Nagasaki Lander is the trademarked name of several series of Nagasaki sport bikes, that started with the 1984 ABC800J", "Kayak", new DateTimeOffset(new DateTime(2021, 5, 26, 0, 23, 4, 722, DateTimeKind.Unspecified).AddTicks(9226), new TimeSpan(0, -3, 0, 0, 0)), "Fishing", "Rustic Concrete Tuna", "Two", "https://picsum.photos/500/375/?image=600&blur", 134.06m, new Guid("f0156fb5-a199-4e0a-8202-00492d9ef006"), 4, 1990 },
                    { new Guid("c5115844-c058-4c9b-870f-345ed623f9eb"), 3, "The Football Is Good For Training And Recreational Purposes", "Kayak", new DateTimeOffset(new DateTime(2021, 4, 7, 5, 37, 12, 266, DateTimeKind.Unspecified).AddTicks(3138), new TimeSpan(0, -3, 0, 0, 0)), "Diving", "Unbranded Steel Ball", "Two", "https://picsum.photos/500/375/?image=136&blur", 819.35m, new Guid("f0156fb5-a199-4e0a-8202-00492d9ef006"), 7, 2553 }
                });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "BootType", "Description", "Discriminator", "IntroduceAt", "Name", "Option", "PhotoUrl", "Price", "ProductTypeId", "Rating", "Size", "Stock" },
                values: new object[,]
                {
                    { new Guid("cc271931-7c04-45ba-b363-c32c50871bf3"), "Drysuit", "The Apollotech B340 is an affordable wireless mouse with reliable connectivity, 12 months battery life and modern design", "Boot", new DateTimeOffset(new DateTime(2021, 5, 12, 17, 37, 3, 457, DateTimeKind.Unspecified).AddTicks(5076), new TimeSpan(0, -3, 0, 0, 0)), "Handcrafted Granite Cheese", "One", "https://picsum.photos/500/375/?image=897&blur", 810.90m, new Guid("f0156fb5-a199-4e0a-8202-00492d9ef006"), 5, 23, 4709 },
                    { new Guid("b1347aef-5a1a-4c91-99ed-b299d93ec59f"), "Harness", "New ABC 13 9370, 13.3, 5th Gen CoreA5-8250U, 8GB RAM, 256GB SSD, power UHD Graphics, OS 10 Home, OS Office A & J 2016", "Boot", new DateTimeOffset(new DateTime(2021, 4, 19, 2, 8, 36, 805, DateTimeKind.Unspecified).AddTicks(3368), new TimeSpan(0, -3, 0, 0, 0)), "Awesome Plastic Salad", "Two", "https://picsum.photos/500/375/?image=675&blur", 767.91m, new Guid("f0156fb5-a199-4e0a-8202-00492d9ef006"), 4, 20, 4849 },
                    { new Guid("10d9b9ec-4dfc-4950-a305-bb1c126bac07"), "Football", "The automobile layout consists of a front-engine design, with transaxle-type transmissions mounted at the rear of the engine and four wheel drive", "Boot", new DateTimeOffset(new DateTime(2021, 10, 3, 23, 36, 58, 77, DateTimeKind.Unspecified).AddTicks(9190), new TimeSpan(0, -3, 0, 0, 0)), "Sleek Concrete Pants", "Three", "https://picsum.photos/500/375/?image=1040&blur", 380.71m, new Guid("f0156fb5-a199-4e0a-8202-00492d9ef006"), 2, 26, 326 }
                });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "BackpackType", "Description", "Discriminator", "IntroduceAt", "Name", "Option", "PhotoUrl", "Price", "ProductTypeId", "Rating", "Stock" },
                values: new object[,]
                {
                    { new Guid("5afd934e-fa56-4ed1-a466-77d0ddc4a8c6"), "Overnight", "The beautiful range of Apple Naturalé that has an exciting mix of natural ingredients. With the Goodness of 100% Natural Ingredients", "Backpack", new DateTimeOffset(new DateTime(2021, 4, 27, 16, 44, 37, 566, DateTimeKind.Unspecified).AddTicks(9590), new TimeSpan(0, -3, 0, 0, 0)), "Gorgeous Rubber Bacon", "Two", "https://picsum.photos/500/375/?image=872&blur", 489.99m, new Guid("f0156fb5-a199-4e0a-8202-00492d9ef006"), 8, 1954 },
                    { new Guid("a8446d31-ce66-4f3f-a283-5de0a6d1284c"), "Snowsports", "The beautiful range of Apple Naturalé that has an exciting mix of natural ingredients. With the Goodness of 100% Natural Ingredients", "Backpack", new DateTimeOffset(new DateTime(2022, 2, 3, 10, 49, 52, 298, DateTimeKind.Unspecified).AddTicks(2036), new TimeSpan(0, -3, 0, 0, 0)), "Licensed Cotton Ball", "Three", "https://picsum.photos/500/375/?image=854&blur", 811.98m, new Guid("f0156fb5-a199-4e0a-8202-00492d9ef006"), 7, 2982 }
                });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "AmountOfPerson", "Description", "Discriminator", "IntroduceAt", "KayakType", "Name", "Option", "PhotoUrl", "Price", "ProductTypeId", "Rating", "Stock" },
                values: new object[,]
                {
                    { new Guid("6c9a1032-b422-4cd7-9527-7b558d9cc2bc"), 2, "New ABC 13 9370, 13.3, 5th Gen CoreA5-8250U, 8GB RAM, 256GB SSD, power UHD Graphics, OS 10 Home, OS Office A & J 2016", "Kayak", new DateTimeOffset(new DateTime(2021, 9, 8, 2, 20, 57, 647, DateTimeKind.Unspecified).AddTicks(1842), new TimeSpan(0, -3, 0, 0, 0)), "Camping", "Intelligent Rubber Mouse", "Two", "https://picsum.photos/500/375/?image=1084&blur", 87.32m, new Guid("fcf9d0df-a663-4687-bdae-4c2b2db3ac15"), 8, 4842 },
                    { new Guid("b03c8456-d4c8-4c6a-aeda-3cb4c4b7acf4"), 1, "Boston's most advanced compression wear technology increases muscle oxygenation, stabilizes active muscles", "Kayak", new DateTimeOffset(new DateTime(2021, 8, 10, 1, 33, 58, 878, DateTimeKind.Unspecified).AddTicks(4324), new TimeSpan(0, -3, 0, 0, 0)), "Fishing", "Sleek Granite Chicken", "Two", "https://picsum.photos/500/375/?image=45&blur", 832.62m, new Guid("fcf9d0df-a663-4687-bdae-4c2b2db3ac15"), 2, 3374 },
                    { new Guid("6c147702-df13-488a-8623-0a12394d4fea"), 1, "Ergonomic executive chair upholstered in bonded black leather and PVC padded seat and back for all-day comfort and support", "Kayak", new DateTimeOffset(new DateTime(2021, 10, 2, 14, 49, 7, 275, DateTimeKind.Unspecified).AddTicks(8430), new TimeSpan(0, -3, 0, 0, 0)), "Fishing", "Ergonomic Soft Gloves", "Three", "https://picsum.photos/500/375/?image=679&blur", 148.96m, new Guid("fcf9d0df-a663-4687-bdae-4c2b2db3ac15"), 9, 1487 },
                    { new Guid("f86e74c6-1c6a-4301-938a-cf62b1779ef7"), 3, "Carbonite web goalkeeper gloves are ergonomically designed to give easy fit", "Kayak", new DateTimeOffset(new DateTime(2021, 3, 25, 23, 16, 36, 887, DateTimeKind.Unspecified).AddTicks(2759), new TimeSpan(0, -3, 0, 0, 0)), "Racing", "Rustic Cotton Ball", "Three", "https://picsum.photos/500/375/?image=702&blur", 518.11m, new Guid("fcf9d0df-a663-4687-bdae-4c2b2db3ac15"), 10, 4957 },
                    { new Guid("7bbbd348-8004-4b1b-891e-801f506569f8"), 2, "Andy shoes are designed to keeping in mind durability as well as trends, the most stylish range of shoes & sandals", "Kayak", new DateTimeOffset(new DateTime(2021, 10, 24, 17, 42, 57, 419, DateTimeKind.Unspecified).AddTicks(1712), new TimeSpan(0, -3, 0, 0, 0)), "Fishing", "Awesome Granite Pants", "Two", "https://picsum.photos/500/375/?image=866&blur", 56.24m, new Guid("fcf9d0df-a663-4687-bdae-4c2b2db3ac15"), 8, 1039 }
                });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "BootType", "Description", "Discriminator", "IntroduceAt", "Name", "Option", "PhotoUrl", "Price", "ProductTypeId", "Rating", "Size", "Stock" },
                values: new object[,]
                {
                    { new Guid("8057a79c-34ac-4699-b2ad-97c8fdda9d5e"), "Chelsea", "New ABC 13 9370, 13.3, 5th Gen CoreA5-8250U, 8GB RAM, 256GB SSD, power UHD Graphics, OS 10 Home, OS Office A & J 2016", "Boot", new DateTimeOffset(new DateTime(2021, 6, 23, 3, 37, 26, 809, DateTimeKind.Unspecified).AddTicks(2142), new TimeSpan(0, -3, 0, 0, 0)), "Sleek Fresh Bacon", "One", "https://picsum.photos/500/375/?image=306&blur", 500.32m, new Guid("fcf9d0df-a663-4687-bdae-4c2b2db3ac15"), 3, 30, 2359 },
                    { new Guid("eddd683d-5311-41d0-b361-8f10bf3e5d1d"), "Chelsea", "Ergonomic executive chair upholstered in bonded black leather and PVC padded seat and back for all-day comfort and support", "Boot", new DateTimeOffset(new DateTime(2021, 12, 2, 3, 48, 40, 851, DateTimeKind.Unspecified).AddTicks(2434), new TimeSpan(0, -3, 0, 0, 0)), "Gorgeous Concrete Bacon", "Two", "https://picsum.photos/500/375/?image=751&blur", 42.64m, new Guid("fcf9d0df-a663-4687-bdae-4c2b2db3ac15"), 3, 28, 4510 },
                    { new Guid("f256d6e1-720d-4add-b9ae-11dd81c41358"), "Engineer", "New ABC 13 9370, 13.3, 5th Gen CoreA5-8250U, 8GB RAM, 256GB SSD, power UHD Graphics, OS 10 Home, OS Office A & J 2016", "Boot", new DateTimeOffset(new DateTime(2021, 5, 29, 6, 56, 48, 421, DateTimeKind.Unspecified).AddTicks(391), new TimeSpan(0, -3, 0, 0, 0)), "Sleek Frozen Table", "Two", "https://picsum.photos/500/375/?image=649&blur", 125.63m, new Guid("fcf9d0df-a663-4687-bdae-4c2b2db3ac15"), 4, 25, 2372 },
                    { new Guid("b3746c74-063f-4f71-816e-c717de1c464d"), "Drysuit", "The Apollotech B340 is an affordable wireless mouse with reliable connectivity, 12 months battery life and modern design", "Boot", new DateTimeOffset(new DateTime(2021, 7, 23, 11, 1, 21, 543, DateTimeKind.Unspecified).AddTicks(2186), new TimeSpan(0, -3, 0, 0, 0)), "Ergonomic Steel Gloves", "Two", "https://picsum.photos/500/375/?image=345&blur", 953.12m, new Guid("fcf9d0df-a663-4687-bdae-4c2b2db3ac15"), 10, 29, 3755 }
                });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "BackpackType", "Description", "Discriminator", "IntroduceAt", "Name", "Option", "PhotoUrl", "Price", "ProductTypeId", "Rating", "Stock" },
                values: new object[,]
                {
                    { new Guid("e38e6ad6-4f73-4973-8f30-5773492b2a72"), "DayPack", "New ABC 13 9370, 13.3, 5th Gen CoreA5-8250U, 8GB RAM, 256GB SSD, power UHD Graphics, OS 10 Home, OS Office A & J 2016", "Backpack", new DateTimeOffset(new DateTime(2021, 6, 16, 17, 15, 9, 619, DateTimeKind.Unspecified).AddTicks(7982), new TimeSpan(0, -3, 0, 0, 0)), "Licensed Rubber Chicken", "One", "https://picsum.photos/500/375/?image=63&blur", 285.69m, new Guid("fcf9d0df-a663-4687-bdae-4c2b2db3ac15"), 7, 3087 },
                    { new Guid("cb342ad0-ce8d-418b-8eae-b05cd32ddff9"), "Snowsports", "Carbonite web goalkeeper gloves are ergonomically designed to give easy fit", "Backpack", new DateTimeOffset(new DateTime(2021, 5, 18, 10, 50, 29, 635, DateTimeKind.Unspecified).AddTicks(4546), new TimeSpan(0, -3, 0, 0, 0)), "Awesome Metal Shoes", "Three", "https://picsum.photos/500/375/?image=283&blur", 701.24m, new Guid("fcf9d0df-a663-4687-bdae-4c2b2db3ac15"), 7, 2548 },
                    { new Guid("ef478e2f-e8f5-4b5b-8cb8-0be62066a2d1"), "Snowsports", "The beautiful range of Apple Naturalé that has an exciting mix of natural ingredients. With the Goodness of 100% Natural Ingredients", "Backpack", new DateTimeOffset(new DateTime(2021, 5, 22, 22, 5, 19, 269, DateTimeKind.Unspecified).AddTicks(4749), new TimeSpan(0, -3, 0, 0, 0)), "Awesome Soft Tuna", "One", "https://picsum.photos/500/375/?image=706&blur", 209.82m, new Guid("fcf9d0df-a663-4687-bdae-4c2b2db3ac15"), 9, 444 },
                    { new Guid("fac1b0aa-ba75-434a-beb3-cdf3322678ea"), "Climbing", "New ABC 13 9370, 13.3, 5th Gen CoreA5-8250U, 8GB RAM, 256GB SSD, power UHD Graphics, OS 10 Home, OS Office A & J 2016", "Backpack", new DateTimeOffset(new DateTime(2022, 1, 10, 7, 24, 59, 922, DateTimeKind.Unspecified).AddTicks(4141), new TimeSpan(0, -3, 0, 0, 0)), "Practical Steel Computer", "Two", "https://picsum.photos/500/375/?image=603&blur", 410.94m, new Guid("fcf9d0df-a663-4687-bdae-4c2b2db3ac15"), 3, 4523 }
                });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "BootType", "Description", "Discriminator", "IntroduceAt", "Name", "Option", "PhotoUrl", "Price", "ProductTypeId", "Rating", "Size", "Stock" },
                values: new object[,]
                {
                    { new Guid("f6381f0e-6954-4581-88e1-cb033794cb04"), "Football", "The automobile layout consists of a front-engine design, with transaxle-type transmissions mounted at the rear of the engine and four wheel drive", "Boot", new DateTimeOffset(new DateTime(2021, 9, 27, 13, 35, 26, 566, DateTimeKind.Unspecified).AddTicks(2722), new TimeSpan(0, -3, 0, 0, 0)), "Incredible Soft Cheese", "One", "https://picsum.photos/500/375/?image=337&blur", 530.99m, new Guid("8be5fcac-91a2-40e8-b23e-e2d9c24b0bc8"), 5, 25, 2692 },
                    { new Guid("d8cce645-be14-42c2-96b2-7720b9d1e433"), "Harness", "The Football Is Good For Training And Recreational Purposes", "Boot", new DateTimeOffset(new DateTime(2021, 4, 17, 19, 10, 31, 666, DateTimeKind.Unspecified).AddTicks(895), new TimeSpan(0, -3, 0, 0, 0)), "Incredible Fresh Towels", "One", "https://picsum.photos/500/375/?image=915&blur", 264.98m, new Guid("8be5fcac-91a2-40e8-b23e-e2d9c24b0bc8"), 3, 29, 3190 }
                });

            migrationBuilder.InsertData(
                table: "Reviews",
                columns: new[] { "Id", "Comment", "ProductId", "Title" },
                values: new object[,]
                {
                    { new Guid("9dc3f7ed-69dd-439c-9cf7-0d5cc33d3bef"), "Dolor possimus nobis iste laboriosam cupiditate et velit qui est. Alias consequatur velit ducimus. Quas expedita quia qui. Nemo quidem nihil. Debitis id eveniet autem.\n\nQuaerat quidem veniam. Velit quia dolor nostrum vel harum corporis. Fuga quis ut impedit unde molestiae voluptatibus a voluptatem odio. Et rem sed reiciendis ea praesentium temporibus animi dolorem quia. Molestiae consequatur cupiditate saepe aperiam fugit voluptas consequatur. Explicabo temporibus nisi perferendis suscipit exercitationem ipsum amet rem.\n\nEst illum quo. Quae nostrum ratione qui eum deserunt. Deleniti temporibus et. Sed sit expedita reprehenderit accusamus harum.", new Guid("7bbbd348-8004-4b1b-891e-801f506569f8"), "Est dolorem beatae magni odit facilis veritatis nostrum animi magni." },
                    { new Guid("71854736-db2b-4142-b779-f3109495496b"), "Ut voluptates delectus molestiae veniam alias doloremque et aspernatur eum. Earum reiciendis accusantium nobis odit. Recusandae facilis dignissimos et sed ut. Cupiditate tempore qui voluptate quia est veritatis animi.\n\nSit explicabo rerum neque aut et ratione. Necessitatibus asperiores ut autem recusandae at. Illo magni non eos accusamus.\n\nCum suscipit ut est eos. Blanditiis voluptas quia facere itaque commodi optio. Laudantium voluptas magni quod ullam atque ipsam. Sunt voluptatem id nostrum. Quia rerum dolores. Dolores dolorum asperiores quam nemo voluptatem.", new Guid("f86e74c6-1c6a-4301-938a-cf62b1779ef7"), "Quae cupiditate voluptatibus error." },
                    { new Guid("84ebe1d8-134b-4cf8-947c-4a0c7cc2b2a2"), "Iusto sunt sequi placeat officia aut quibusdam in sunt. Voluptatem iusto et placeat officiis similique iste. Nobis consectetur nostrum et quod. Quia nesciunt veritatis itaque eligendi est quas facere. Corporis porro dolorem dolores voluptatem provident quo.\n\nError aut aut. Et sint quia voluptatum ut facilis debitis atque dolores harum. Qui in et quod eos impedit quibusdam consequatur enim. Itaque aperiam impedit iusto ut et pariatur at incidunt.\n\nQui consectetur sunt unde et numquam aut vero. Vitae consequatur vitae suscipit soluta maxime aut explicabo rem. Voluptas aut nihil fugit magni.", new Guid("6c147702-df13-488a-8623-0a12394d4fea"), "Et ipsa minus nulla doloremque et." },
                    { new Guid("135411cb-4cec-4164-9185-d336bf137f41"), "Velit est eum laboriosam adipisci dolore. Asperiores voluptatem qui repellendus magni hic. Facere quos optio facere vel. Rem provident voluptatem beatae sapiente et alias quia quasi aut.\n\nPerspiciatis est eos tenetur ea voluptas. Tempora eos est hic nemo sit repellat provident et nostrum. Voluptatem minima dolore eum. Libero nihil nemo vel consequuntur dolore ipsam et eos iste. Qui voluptatem ut quibusdam magni. Pariatur sequi voluptatem cumque culpa porro maxime sapiente sed possimus.\n\nEos error non neque voluptas rem magnam illo eum. Voluptatibus perspiciatis pariatur vel facere alias esse ut aut. Odit eius molestiae explicabo ea eius. Maiores natus esse. Corrupti et sunt minima doloribus sed quam. Omnis perspiciatis beatae unde beatae ipsum.", new Guid("b03c8456-d4c8-4c6a-aeda-3cb4c4b7acf4"), "At voluptas sapiente maxime unde ut." },
                    { new Guid("0be6c303-8fa4-41a0-ac75-f71234e1ecb6"), "Ut at quasi soluta eaque iste harum unde. Voluptate quia eius similique facere provident aut. Ratione laborum qui iusto. Quisquam vero nostrum officiis laboriosam et quia optio sit.\n\nRepellat aspernatur iusto voluptates et facilis architecto ratione eligendi. Recusandae et amet suscipit modi. Facere est aut eveniet expedita ad blanditiis magni numquam iure. Numquam perferendis quis repudiandae.\n\nQui similique et explicabo veritatis quidem et ut tempore quod. Temporibus tempora odit ut fugit minus nihil. Eos excepturi dolorem. Rerum nemo optio fugit deleniti vero dolores quia.", new Guid("6c9a1032-b422-4cd7-9527-7b558d9cc2bc"), "Perspiciatis porro autem voluptas sunt." },
                    { new Guid("fe064c58-5f3d-4898-a0e5-9647744740d8"), "Accusantium odit et odit. Quod ut molestias sed sed veritatis enim omnis odit. Omnis doloribus provident beatae occaecati vel id ipsum necessitatibus laboriosam. Amet et possimus ut asperiores ut ipsa et aut laboriosam.\n\nConsequatur et ut. Esse ducimus voluptas. Culpa repellat facere ullam ullam et illo repudiandae repellendus. Itaque voluptas assumenda recusandae iste. Placeat repellat quia nesciunt ut molestiae. Omnis aut repudiandae quisquam.\n\nAliquam voluptatem est quia in sit amet. Blanditiis labore molestiae pariatur magni voluptas officia in. Nemo debitis aspernatur. Autem quam labore est dolores expedita.", new Guid("c5115844-c058-4c9b-870f-345ed623f9eb"), "Sed quam eum nisi et exercitationem provident ut numquam." },
                    { new Guid("234f9983-d776-431e-aee1-acb47ae02fea"), "Animi consequatur quisquam nostrum. Minima enim eos vitae rerum voluptatem omnis est nulla. Amet aut ut atque sint. Cum esse perspiciatis. At culpa eius.\n\nEt amet rem fugit ad. Quo vitae distinctio a ullam ea sunt magni. Expedita omnis et. Aut et et qui magni. Molestiae tenetur quia. Ut optio explicabo corporis est.\n\nQuis dolores similique animi rem quibusdam et non numquam quisquam. Veniam dolores vel. Vitae sint est.", new Guid("d5498321-41f6-484c-8228-dc325a357340"), "Omnis blanditiis nisi repellat aliquid omnis sed eum." },
                    { new Guid("1211a217-b147-4f87-9eef-c274df60f2d2"), "Sed illo et aut vitae. Minima recusandae cumque quidem at. Sed repudiandae qui dolorem libero soluta debitis dolorem et. Culpa fugit rem excepturi. Et numquam dolorem itaque ut atque ut perferendis nam ullam. Velit aut et voluptatem.\n\nAut est aliquam. Animi non odit vero hic recusandae. Accusantium voluptatum nobis rerum sunt nihil omnis porro.\n\nAut laboriosam itaque ut qui cupiditate dolores ut. Accusantium laudantium sapiente corrupti nemo maxime quaerat excepturi eveniet. Porro beatae sit omnis fuga maiores consectetur laborum. Voluptas qui voluptatem iusto suscipit reprehenderit molestiae. Ipsam provident accusamus alias est officia. Voluptates dolor et.", new Guid("7db9e906-bc20-44c8-8421-204033e81e8d"), "Vel eveniet ipsam repudiandae aut accusantium neque dolorum eos repellendus." },
                    { new Guid("13994935-5a71-48f1-a51b-5b853c42b8f4"), "Est facilis eos fugit et perspiciatis. Ut dolores ut dolor dolores aut. Provident omnis aut asperiores assumenda dolore hic doloremque libero. Et aut consequatur voluptatem voluptatem. Accusamus voluptas quod eaque consequatur quidem pariatur alias et.\n\nMinima culpa culpa eveniet cum consequatur. Ut sed eos. Et et dignissimos eligendi aut temporibus adipisci. Quia veritatis et soluta aspernatur at facere quasi iure eveniet. Aut autem illum accusamus libero ducimus sunt qui et sint. Dicta qui tenetur ipsam eum.\n\nCum distinctio inventore consequatur optio omnis ipsam. Ut deleniti ipsa. Ullam impedit suscipit nostrum voluptatibus dolor soluta et omnis et.", new Guid("1a209ada-113f-48c6-a446-7f6ed7d74177"), "Laboriosam hic ea ut aut quam est repellendus accusantium excepturi." },
                    { new Guid("73eddb2b-cf7b-4c8f-bbc2-a01ecd1ef9c0"), "Aut vel ex voluptatibus sed tenetur nisi maiores. Fuga aspernatur minima rerum accusamus. In tempora pariatur aut temporibus. Cupiditate voluptatem nobis ut esse. Et molestias enim est. Itaque minus eaque possimus sequi amet amet.\n\nImpedit eum at possimus at autem quos nostrum voluptatem similique. Natus alias quia atque ex tempore odio sed consequatur aspernatur. Ut at iste nisi non eum. Et eaque distinctio voluptatem dolorem expedita. Dolorem molestiae est ipsa et hic consectetur maxime.\n\nRecusandae velit omnis ea atque placeat quasi aut eos ut. Alias sed molestias neque distinctio et beatae non quaerat. Dolor nam temporibus consectetur. Placeat beatae sequi voluptatem quis tempora repellat sunt. Et minima sunt omnis quis deserunt. Delectus quam fugiat dolorem quisquam dolor.", new Guid("8f7cfbdd-3413-44ae-b987-052fd9f3bfdd"), "Asperiores voluptatem fugit numquam mollitia quod possimus maxime voluptas non." }
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
