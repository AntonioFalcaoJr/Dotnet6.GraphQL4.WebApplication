using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Dotnet5.GraphQL.Store.Repositories.Migrations
{
    public partial class Firstmigration : Migration
    {
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable("Reviews");

            migrationBuilder.DropTable("Products");

            migrationBuilder.DropTable("ProductTypes");
        }

        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable("ProductTypes",
                table => new
                {
                    Id = table.Column<Guid>("uniqueidentifier", nullable: false),
                    Discriminator = table.Column<string>("nvarchar(30)", maxLength: 30, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProductTypes", x => x.Id);
                });

            migrationBuilder.CreateTable("Products",
                table => new
                {
                    Id = table.Column<Guid>("uniqueidentifier", nullable: false),
                    Description = table.Column<string>("nvarchar(100)", maxLength: 100, nullable: true),
                    IntroduceAt = table.Column<DateTimeOffset>("datetimeoffset", nullable: false),
                    Name = table.Column<string>("nvarchar(50)", maxLength: 50, nullable: false),
                    Option = table.Column<string>("nvarchar(max)", nullable: false),
                    PhotoUrl = table.Column<string>("nvarchar(100)", maxLength: 100, nullable: true),
                    Price = table.Column<decimal>("decimal(18,2)", precision: 18, scale: 2, nullable: false),
                    ProductTypeId = table.Column<Guid>("uniqueidentifier", nullable: true),
                    Rating = table.Column<int>("int", nullable: false),
                    Stock = table.Column<int>("int", nullable: false),
                    Discriminator = table.Column<string>("nvarchar(max)", nullable: false),
                    BackpackType = table.Column<string>("nvarchar(max)", nullable: true),
                    BootType = table.Column<string>("nvarchar(max)", nullable: true),
                    Size = table.Column<int>("int", nullable: true),
                    AmountOfPerson = table.Column<int>("int", nullable: true),
                    KayakType = table.Column<string>("nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Products", x => x.Id);
                    table.ForeignKey("FK_Products_ProductTypes_ProductTypeId",
                        x => x.ProductTypeId,
                        "ProductTypes",
                        "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable("Reviews",
                table => new
                {
                    Id = table.Column<Guid>("uniqueidentifier", nullable: false),
                    Comment = table.Column<string>("nvarchar(300)", maxLength: 300, nullable: true),
                    ProductId = table.Column<Guid>("uniqueidentifier", nullable: true),
                    Title = table.Column<string>("nvarchar(50)", maxLength: 50, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Reviews", x => x.Id);
                    table.ForeignKey("FK_Reviews_Products_ProductId",
                        x => x.ProductId,
                        "Products",
                        "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.InsertData("ProductTypes",
                new[] {"Id", "Discriminator"},
                new object[] {new Guid("c814a26e-6e82-43ed-8e08-6eaa45d741ff"), "TypeOne"});

            migrationBuilder.InsertData("ProductTypes",
                new[] {"Id", "Discriminator"},
                new object[] {new Guid("95a5fa4a-41fb-44ee-8670-a9305d24fe94"), "TypeThree"});

            migrationBuilder.InsertData("ProductTypes",
                new[] {"Id", "Discriminator"},
                new object[] {new Guid("d3e13982-118b-4b99-ac5d-cd3da3b4cc35"), "TypeTwo"});

            migrationBuilder.InsertData("Products",
                new[]
                {
                    "Id", "Description", "Discriminator", "IntroduceAt", "Name", "Option", "PhotoUrl", "Price", "ProductTypeId", "Rating", "Stock",
                    "BackpackType"
                },
                new object[]
                {
                    new Guid("a0569d82-471c-4687-a203-154ae511d1f2"), "Provident non non aperiam ex perspiciatis dignissimos.", "Backpack",
                    new DateTimeOffset(new DateTime(2021, 7, 17, 15, 9, 24, 390, DateTimeKind.Unspecified).AddTicks(5457),
                        new TimeSpan(0, -3, 0, 0, 0)),
                    "vitae", "One", "https://picsum.photos/640/480/?image=487", 0.3220846169413446663281397408m,
                    new Guid("c814a26e-6e82-43ed-8e08-6eaa45d741ff"), -215932871, -2095264362, "Overnight"
                });

            migrationBuilder.InsertData("Products",
                new[]
                {
                    "Id", "Description", "Discriminator", "IntroduceAt", "Name", "Option", "PhotoUrl", "Price", "ProductTypeId", "Rating", "Stock",
                    "AmountOfPerson", "KayakType"
                },
                new object[,]
                {
                    {
                        new Guid("40d2736d-9b0b-4b17-a4b9-957a1b8362a7"), "Explicabo est cum aut voluptatum.", "Kayak",
                        new DateTimeOffset(new DateTime(2021, 5, 12, 16, 26, 12, 284, DateTimeKind.Unspecified).AddTicks(195),
                            new TimeSpan(0, -3, 0, 0, 0)),
                        "vitae", "Three", "https://picsum.photos/640/480/?image=830", 0.8880791808408761489715905911m,
                        new Guid("95a5fa4a-41fb-44ee-8670-a9305d24fe94"), -1943901911, -40836143, -1360855746, "Fishing"
                    },
                    {
                        new Guid("4fc7687b-9798-4345-a62c-0e8486a2fdbb"), "Accusamus enim architecto.", "Kayak",
                        new DateTimeOffset(new DateTime(2020, 8, 13, 7, 38, 39, 940, DateTimeKind.Unspecified).AddTicks(3301),
                            new TimeSpan(0, -3, 0, 0, 0)),
                        "consequatur", "Two", "https://picsum.photos/640/480/?image=402", 0.7048112408699497512151115482m,
                        new Guid("95a5fa4a-41fb-44ee-8670-a9305d24fe94"), 5091656, -216935343, 2018603750, "Diving"
                    },
                    {
                        new Guid("d57ac519-4637-4580-90f7-d55f71ee5662"), "Et ad laboriosam.", "Kayak",
                        new DateTimeOffset(new DateTime(2021, 5, 1, 22, 17, 6, 850, DateTimeKind.Unspecified).AddTicks(9617),
                            new TimeSpan(0, -3, 0, 0, 0)),
                        "qui", "Two", "https://picsum.photos/640/480/?image=332", 0.3055967472695038192349125996m,
                        new Guid("95a5fa4a-41fb-44ee-8670-a9305d24fe94"), 903583053, 1840197606, 178729091, "Diving"
                    },
                    {
                        new Guid("97c4d6d5-9879-4c3f-b77e-79f12dde1082"), "A eveniet qui quae sed est voluptate facilis quas mollitia.", "Kayak",
                        new DateTimeOffset(new DateTime(2021, 5, 30, 21, 51, 0, 885, DateTimeKind.Unspecified).AddTicks(5533),
                            new TimeSpan(0, -3, 0, 0, 0)),
                        "eos", "Three", "https://picsum.photos/640/480/?image=803", 0.4043081835178345150417074274m,
                        new Guid("95a5fa4a-41fb-44ee-8670-a9305d24fe94"), -653289428, 766904561, -731334327, "Racing"
                    },
                    {
                        new Guid("7ee45a11-2af4-4c41-adfb-8e5d292f7b8c"), "Quam magni sed vitae mollitia.", "Kayak",
                        new DateTimeOffset(new DateTime(2020, 10, 3, 17, 55, 51, 285, DateTimeKind.Unspecified).AddTicks(7103),
                            new TimeSpan(0, -3, 0, 0, 0)),
                        "qui", "One", "https://picsum.photos/640/480/?image=115", 0.2858609342207917298449093326m,
                        new Guid("95a5fa4a-41fb-44ee-8670-a9305d24fe94"), -1054259024, -1356861826, 1893056032, "Racing"
                    },
                    {
                        new Guid("e65f5cdf-6e88-46ef-8833-4dc99fb7fa68"), "Nemo voluptatem minus cupiditate cumque non molestias sed laboriosam.",
                        "Kayak",
                        new DateTimeOffset(new DateTime(2021, 1, 11, 19, 55, 27, 889, DateTimeKind.Unspecified).AddTicks(7714),
                            new TimeSpan(0, -3, 0, 0, 0)),
                        "pariatur", "Three", "https://picsum.photos/640/480/?image=570", 0.3186577190818941996466647378m,
                        new Guid("95a5fa4a-41fb-44ee-8670-a9305d24fe94"), -986932532, -1678144084, 1699916934, "Fishing"
                    },
                    {
                        new Guid("d21a5f07-204f-4aed-857e-186e5127e257"), "Ratione ratione iusto nostrum dolor rerum est vel.", "Kayak",
                        new DateTimeOffset(new DateTime(2020, 8, 27, 13, 26, 39, 372, DateTimeKind.Unspecified).AddTicks(2383),
                            new TimeSpan(0, -3, 0, 0, 0)),
                        "nemo", "Two", "https://picsum.photos/640/480/?image=323", 0.6563392465459756411457393355m,
                        new Guid("95a5fa4a-41fb-44ee-8670-a9305d24fe94"), 968715424, -788303762, 1975336817, "Diving"
                    }
                });

            migrationBuilder.InsertData("Products",
                new[]
                {
                    "Id", "Description", "Discriminator", "IntroduceAt", "Name", "Option", "PhotoUrl", "Price", "ProductTypeId", "Rating", "Stock",
                    "BackpackType"
                },
                new object[,]
                {
                    {
                        new Guid("fbf6db5c-dc78-4bc5-a4a7-b562768481e7"), "Dolor ut quia.", "Backpack",
                        new DateTimeOffset(new DateTime(2021, 4, 16, 21, 36, 53, 701, DateTimeKind.Unspecified).AddTicks(1821),
                            new TimeSpan(0, -3, 0, 0, 0)),
                        "earum", "Three", "https://picsum.photos/640/480/?image=636", 0.5709511922910926768723162954m,
                        new Guid("d3e13982-118b-4b99-ac5d-cd3da3b4cc35"), 1155568876, 816538778, "Overnight"
                    },
                    {
                        new Guid("104f0c1c-ed80-4a61-906d-ae2d03102096"), "Maxime dicta aliquid qui.", "Backpack",
                        new DateTimeOffset(new DateTime(2021, 1, 8, 20, 16, 44, 985, DateTimeKind.Unspecified).AddTicks(2346),
                            new TimeSpan(0, -3, 0, 0, 0)),
                        "vero", "One", "https://picsum.photos/640/480/?image=901", 0.5983330563519496258287671449m,
                        new Guid("d3e13982-118b-4b99-ac5d-cd3da3b4cc35"), 159646640, -1288407205, "Hiking"
                    },
                    {
                        new Guid("50a2a3c6-40fb-4c62-894a-a70d34b88d9a"), "Corrupti ut culpa.", "Backpack",
                        new DateTimeOffset(new DateTime(2020, 10, 9, 23, 54, 37, 120, DateTimeKind.Unspecified).AddTicks(8613),
                            new TimeSpan(0, -3, 0, 0, 0)),
                        "dicta", "One", "https://picsum.photos/640/480/?image=808", 0.1218234365050341506725397716m,
                        new Guid("d3e13982-118b-4b99-ac5d-cd3da3b4cc35"), 1877836179, 1368305839, "Cycling"
                    },
                    {
                        new Guid("f848ba17-4891-4524-b134-fe9345f2fe9d"), "Quis ut distinctio pariatur eligendi totam non sit harum ea.", "Backpack",
                        new DateTimeOffset(new DateTime(2021, 1, 27, 22, 47, 52, 576, DateTimeKind.Unspecified).AddTicks(1061),
                            new TimeSpan(0, -3, 0, 0, 0)),
                        "enim", "One", "https://picsum.photos/640/480/?image=499", 0.2076779566293578863157875422m,
                        new Guid("d3e13982-118b-4b99-ac5d-cd3da3b4cc35"), -831166576, 1287508878, "Overnight"
                    },
                    {
                        new Guid("060ca68b-f04c-442a-8eaa-ba6153149907"), "Odit et ex est et nesciunt nemo aut tenetur aliquid.", "Backpack",
                        new DateTimeOffset(new DateTime(2020, 12, 17, 7, 43, 34, 507, DateTimeKind.Unspecified).AddTicks(7749),
                            new TimeSpan(0, -3, 0, 0, 0)),
                        "vel", "One", "https://picsum.photos/640/480/?image=4", 0.1976183341935696541941244703m,
                        new Guid("d3e13982-118b-4b99-ac5d-cd3da3b4cc35"), -1472761390, -1306261562, "Overnight"
                    },
                    {
                        new Guid("4c46b3f0-0790-40af-8c08-5f398c4bba7b"), "Tempora occaecati atque rerum dicta.", "Backpack",
                        new DateTimeOffset(new DateTime(2020, 10, 30, 9, 53, 27, 775, DateTimeKind.Unspecified).AddTicks(3519),
                            new TimeSpan(0, -3, 0, 0, 0)),
                        "accusantium", "Three", "https://picsum.photos/640/480/?image=442", 0.9839982161163161657217789559m,
                        new Guid("d3e13982-118b-4b99-ac5d-cd3da3b4cc35"), 2140557451, -1850110908, "Climbing"
                    },
                    {
                        new Guid("06bb8e47-68f9-4505-a789-659bf40e6536"), "Culpa voluptates quas.", "Backpack",
                        new DateTimeOffset(new DateTime(2020, 8, 26, 13, 53, 31, 175, DateTimeKind.Unspecified).AddTicks(4317),
                            new TimeSpan(0, -3, 0, 0, 0)),
                        "adipisci", "One", "https://picsum.photos/640/480/?image=699", 0.9036959764099123950651938396m,
                        new Guid("d3e13982-118b-4b99-ac5d-cd3da3b4cc35"), -510344344, -26842084, "Hiking"
                    },
                    {
                        new Guid("bd53a01a-8c2f-4ed5-bef2-d33dc7c37305"), "Ullam iusto distinctio deleniti.", "Backpack",
                        new DateTimeOffset(new DateTime(2020, 12, 23, 7, 4, 27, 814, DateTimeKind.Unspecified).AddTicks(2219),
                            new TimeSpan(0, -3, 0, 0, 0)),
                        "dolorem", "Two", "https://picsum.photos/640/480/?image=46", 0.5665775113698985646554779331m,
                        new Guid("d3e13982-118b-4b99-ac5d-cd3da3b4cc35"), 1144210711, -1015449642, "Overnight"
                    }
                });

            migrationBuilder.InsertData("Products",
                new[]
                {
                    "Id", "Description", "Discriminator", "IntroduceAt", "Name", "Option", "PhotoUrl", "Price", "ProductTypeId", "Rating", "Stock",
                    "AmountOfPerson", "KayakType"
                },
                new object[,]
                {
                    {
                        new Guid("0d28a1f0-8693-4db0-919b-0ccf0c085fa1"), "Voluptatem ut rem magni repellendus.", "Kayak",
                        new DateTimeOffset(new DateTime(2020, 12, 8, 12, 27, 36, 965, DateTimeKind.Unspecified).AddTicks(7042),
                            new TimeSpan(0, -3, 0, 0, 0)),
                        "inventore", "One", "https://picsum.photos/640/480/?image=633", 0.3432728792595114935102303476m,
                        new Guid("95a5fa4a-41fb-44ee-8670-a9305d24fe94"), -1268575817, -1400170620, 1964012673, "Camping"
                    },
                    {
                        new Guid("d1e038b3-6094-4819-b0eb-3386b8833643"), "Commodi quis facere ea odit.", "Kayak",
                        new DateTimeOffset(new DateTime(2021, 4, 3, 19, 19, 30, 429, DateTimeKind.Unspecified).AddTicks(2373),
                            new TimeSpan(0, -3, 0, 0, 0)),
                        "dolor", "Three", "https://picsum.photos/640/480/?image=30", 0.5494056998912033798745192559m,
                        new Guid("95a5fa4a-41fb-44ee-8670-a9305d24fe94"), 964428673, 2003636048, 485776377, "Diving"
                    },
                    {
                        new Guid("a54eae56-8c95-4a68-ac86-eb6e499ed264"), "Quia praesentium consequuntur cum ipsa rerum.", "Kayak",
                        new DateTimeOffset(new DateTime(2020, 11, 13, 8, 14, 40, 993, DateTimeKind.Unspecified).AddTicks(270),
                            new TimeSpan(0, -3, 0, 0, 0)),
                        "recusandae", "One", "https://picsum.photos/640/480/?image=296", 0.1614055340366985283432684646m,
                        new Guid("95a5fa4a-41fb-44ee-8670-a9305d24fe94"), 1032799336, 236033897, -763230991, "Camping"
                    }
                });

            migrationBuilder.InsertData("Products",
                new[]
                {
                    "Id", "Description", "Discriminator", "IntroduceAt", "Name", "Option", "PhotoUrl", "Price", "ProductTypeId", "Rating", "Stock",
                    "BootType", "Size"
                },
                new object[,]
                {
                    {
                        new Guid("abaaa1a2-683b-4842-8783-daa59e98fbfb"), "Distinctio quisquam assumenda.", "Boot",
                        new DateTimeOffset(new DateTime(2021, 2, 6, 9, 35, 6, 991, DateTimeKind.Unspecified).AddTicks(9544),
                            new TimeSpan(0, -3, 0, 0, 0)),
                        "sed", "Two", "https://picsum.photos/640/480/?image=881", 0.0408171039742295342521581281m,
                        new Guid("95a5fa4a-41fb-44ee-8670-a9305d24fe94"), -2108568547, -1529206194, "Chelsea", 782075286
                    },
                    {
                        new Guid("4da87289-ef28-4572-955a-dd44e762026c"), "Consequuntur nihil minus aut quas soluta.", "Boot",
                        new DateTimeOffset(new DateTime(2020, 11, 12, 3, 48, 45, 928, DateTimeKind.Unspecified).AddTicks(9501),
                            new TimeSpan(0, -3, 0, 0, 0)),
                        "quis", "One", "https://picsum.photos/640/480/?image=290", 0.3700229984580395391467826165m,
                        new Guid("95a5fa4a-41fb-44ee-8670-a9305d24fe94"), 878040505, 2058441610, "Cowboy", -1431759724
                    },
                    {
                        new Guid("61a4fa3d-5d93-4195-b35a-2e2c4fe0006f"), "Accusamus magnam animi.", "Boot",
                        new DateTimeOffset(new DateTime(2020, 10, 27, 16, 21, 23, 349, DateTimeKind.Unspecified).AddTicks(8675),
                            new TimeSpan(0, -3, 0, 0, 0)),
                        "aut", "Three", "https://picsum.photos/640/480/?image=581", 0.22196915359016835090767644m,
                        new Guid("95a5fa4a-41fb-44ee-8670-a9305d24fe94"), 1808696842, 1408124063, "Harness", 984375126
                    },
                    {
                        new Guid("1affc620-c238-48bc-8d39-a519a7d6cc9a"), "Delectus assumenda et aperiam ratione omnis unde.", "Boot",
                        new DateTimeOffset(new DateTime(2021, 2, 17, 20, 53, 52, 764, DateTimeKind.Unspecified).AddTicks(1134),
                            new TimeSpan(0, -3, 0, 0, 0)),
                        "ut", "One", "https://picsum.photos/640/480/?image=386", 0.9745825238923911402553216218m,
                        new Guid("95a5fa4a-41fb-44ee-8670-a9305d24fe94"), 2126147209, -2111224559, "Drysuit", 1812293397
                    },
                    {
                        new Guid("0f4ef39e-2351-4617-b060-1ecc9e273b53"), "Voluptatem sit quo quia qui et.", "Boot",
                        new DateTimeOffset(new DateTime(2020, 12, 4, 22, 30, 6, 900, DateTimeKind.Unspecified).AddTicks(3775),
                            new TimeSpan(0, -3, 0, 0, 0)),
                        "excepturi", "One", "https://picsum.photos/640/480/?image=308", 0.6351595993463167151440433414m,
                        new Guid("95a5fa4a-41fb-44ee-8670-a9305d24fe94"), 1632687569, 1489655011, "Drysuit", -1372688558
                    },
                    {
                        new Guid("94d4155a-728d-4a24-85d4-8e364f22dbf6"), "Excepturi velit officia aut quos et eveniet adipisci officia.", "Boot",
                        new DateTimeOffset(new DateTime(2021, 7, 14, 7, 0, 7, 84, DateTimeKind.Unspecified).AddTicks(9897),
                            new TimeSpan(0, -3, 0, 0, 0)),
                        "quo", "One", "https://picsum.photos/640/480/?image=602", 0.9421948656311287103930497578m,
                        new Guid("95a5fa4a-41fb-44ee-8670-a9305d24fe94"), 1643529896, -1549767596, "Chelsea", -194073079
                    },
                    {
                        new Guid("f571c078-29b3-4aee-b784-f59597b772d4"), "Est vitae eligendi qui officiis.", "Boot",
                        new DateTimeOffset(new DateTime(2021, 3, 25, 14, 21, 47, 106, DateTimeKind.Unspecified).AddTicks(7120),
                            new TimeSpan(0, -3, 0, 0, 0)),
                        "dolorem", "Three", "https://picsum.photos/640/480/?image=13", 0.3004214972746256229742939228m,
                        new Guid("95a5fa4a-41fb-44ee-8670-a9305d24fe94"), -951962979, 554640935, "Cowboy", 263404461
                    },
                    {
                        new Guid("580f7f61-0572-4325-b291-23b67201706c"), "Molestias reprehenderit dolores eius suscipit iusto eum.", "Boot",
                        new DateTimeOffset(new DateTime(2020, 8, 7, 18, 52, 11, 983, DateTimeKind.Unspecified).AddTicks(9404),
                            new TimeSpan(0, -3, 0, 0, 0)),
                        "saepe", "Two", "https://picsum.photos/640/480/?image=606", 0.712059456989644560474989202m,
                        new Guid("95a5fa4a-41fb-44ee-8670-a9305d24fe94"), 1770487509, 121962005, "Drysuit", 328156213
                    },
                    {
                        new Guid("6ec4ac5a-8b96-4f0d-b7e6-1e74c81425d0"), "Sint veniam aut quod laborum aliquam nihil qui.", "Boot",
                        new DateTimeOffset(new DateTime(2020, 8, 4, 4, 23, 12, 138, DateTimeKind.Unspecified).AddTicks(2474),
                            new TimeSpan(0, -3, 0, 0, 0)),
                        "sit", "Three", "https://picsum.photos/640/480/?image=223", 0.1630578964735937400757232495m,
                        new Guid("95a5fa4a-41fb-44ee-8670-a9305d24fe94"), -1720201469, 848558621, "Chelsea", 785570351
                    },
                    {
                        new Guid("21658814-c5ff-40b0-83bc-ad1cff5c9727"), "Eum quos totam.", "Boot",
                        new DateTimeOffset(new DateTime(2021, 2, 3, 11, 4, 56, 62, DateTimeKind.Unspecified).AddTicks(4126),
                            new TimeSpan(0, -3, 0, 0, 0)),
                        "qui", "One", "https://picsum.photos/640/480/?image=619", 0.1469105135441545808322357284m,
                        new Guid("95a5fa4a-41fb-44ee-8670-a9305d24fe94"), -1042012920, -2094315238, "Cowboy", 853831076
                    },
                    {
                        new Guid("2278e5a5-b83b-42ee-b00d-4206d82e12fb"), "Suscipit ipsa et.", "Boot",
                        new DateTimeOffset(new DateTime(2020, 11, 27, 10, 45, 45, 121, DateTimeKind.Unspecified).AddTicks(58),
                            new TimeSpan(0, -3, 0, 0, 0)),
                        "asperiores", "Three", "https://picsum.photos/640/480/?image=267", 0.5332518697701614164948450658m,
                        new Guid("95a5fa4a-41fb-44ee-8670-a9305d24fe94"), 594256158, -698993637, "Engineer", -523040497
                    },
                    {
                        new Guid("1d9b4775-89d4-4cfa-8696-4c540a125793"), "Quo velit amet adipisci qui voluptas ut.", "Boot",
                        new DateTimeOffset(new DateTime(2021, 1, 12, 14, 20, 6, 243, DateTimeKind.Unspecified).AddTicks(1009),
                            new TimeSpan(0, -3, 0, 0, 0)),
                        "ut", "Two", "https://picsum.photos/640/480/?image=929", 0.0174106462759468304655334958m,
                        new Guid("95a5fa4a-41fb-44ee-8670-a9305d24fe94"), 831847080, 390931467, "Chelsea", 1245225058
                    },
                    {
                        new Guid("b69b58f3-3f6f-48a8-bafc-43d9505c8cf9"), "Beatae et architecto aut illum officia et soluta molestiae aut.", "Boot",
                        new DateTimeOffset(new DateTime(2021, 4, 27, 20, 17, 19, 265, DateTimeKind.Unspecified).AddTicks(8872),
                            new TimeSpan(0, -3, 0, 0, 0)),
                        "omnis", "One", "https://picsum.photos/640/480/?image=18", 0.0712844171173358186290961395m,
                        new Guid("95a5fa4a-41fb-44ee-8670-a9305d24fe94"), -1782086574, -1337521737, "Harness", -457763567
                    }
                });

            migrationBuilder.InsertData("Products",
                new[]
                {
                    "Id", "Description", "Discriminator", "IntroduceAt", "Name", "Option", "PhotoUrl", "Price", "ProductTypeId", "Rating", "Stock",
                    "AmountOfPerson", "KayakType"
                },
                new object[,]
                {
                    {
                        new Guid("da851927-a89d-47ad-bad6-d8cc5e5a0971"), "Iure cumque labore quos accusamus praesentium.", "Kayak",
                        new DateTimeOffset(new DateTime(2021, 7, 6, 15, 52, 38, 968, DateTimeKind.Unspecified).AddTicks(2649),
                            new TimeSpan(0, -3, 0, 0, 0)),
                        "et", "Two", "https://picsum.photos/640/480/?image=596", 0.8598738256531111277735163014m,
                        new Guid("95a5fa4a-41fb-44ee-8670-a9305d24fe94"), -1064286490, -602153730, -1163749038, "Camping"
                    },
                    {
                        new Guid("b3a3a5ff-a640-4d35-9161-2b2ae392eb14"), "Odit accusantium at est odio ipsam iste aut perspiciatis.", "Kayak",
                        new DateTimeOffset(new DateTime(2021, 6, 17, 2, 0, 16, 136, DateTimeKind.Unspecified).AddTicks(8988),
                            new TimeSpan(0, -3, 0, 0, 0)),
                        "sed", "One", "https://picsum.photos/640/480/?image=477", 0.1035204379717907908994243252m,
                        new Guid("95a5fa4a-41fb-44ee-8670-a9305d24fe94"), -1603997663, -1949368415, -2084081278, "Family"
                    }
                });

            migrationBuilder.InsertData("Products",
                new[]
                {
                    "Id", "Description", "Discriminator", "IntroduceAt", "Name", "Option", "PhotoUrl", "Price", "ProductTypeId", "Rating", "Stock",
                    "BackpackType"
                },
                new object[,]
                {
                    {
                        new Guid("cd2b29fd-242d-4832-8fb4-3be6e7e41a36"), "Eos quos non sint quam rerum temporibus.", "Backpack",
                        new DateTimeOffset(new DateTime(2020, 9, 23, 0, 1, 46, 194, DateTimeKind.Unspecified).AddTicks(4147),
                            new TimeSpan(0, -3, 0, 0, 0)),
                        "delectus", "One", "https://picsum.photos/640/480/?image=773", 0.2242025725414466871272419944m,
                        new Guid("d3e13982-118b-4b99-ac5d-cd3da3b4cc35"), 572571228, 1617347989, "Hiking"
                    },
                    {
                        new Guid("8f2dd25a-e7a7-4713-9c3a-7c8e39998797"), "Aperiam sunt accusantium consequatur.", "Backpack",
                        new DateTimeOffset(new DateTime(2021, 6, 7, 0, 19, 26, 705, DateTimeKind.Unspecified).AddTicks(5083),
                            new TimeSpan(0, -3, 0, 0, 0)),
                        "vero", "Three", "https://picsum.photos/640/480/?image=177", 0.8452549732110374208457383333m,
                        new Guid("d3e13982-118b-4b99-ac5d-cd3da3b4cc35"), -296759244, 1052486877, "DayPack"
                    },
                    {
                        new Guid("5b81751f-59c0-4829-aeaf-23804cb7c758"), "Dolores ut sed vel fugiat doloribus qui non sed.", "Backpack",
                        new DateTimeOffset(new DateTime(2021, 7, 22, 18, 45, 54, 906, DateTimeKind.Unspecified).AddTicks(1153),
                            new TimeSpan(0, -3, 0, 0, 0)),
                        "earum", "Two", "https://picsum.photos/640/480/?image=569", 0.495884585079388492636020127m,
                        new Guid("d3e13982-118b-4b99-ac5d-cd3da3b4cc35"), 389333267, -2105561645, "Overnight"
                    },
                    {
                        new Guid("a0ed7a52-4782-46f0-b8b3-4d57f15d1e23"), "Voluptatem autem enim explicabo sit provident eaque.", "Backpack",
                        new DateTimeOffset(new DateTime(2021, 6, 11, 14, 33, 55, 419, DateTimeKind.Unspecified).AddTicks(1152),
                            new TimeSpan(0, -3, 0, 0, 0)),
                        "voluptatem", "Two", "https://picsum.photos/640/480/?image=304", 0.6328008607914129500125413989m,
                        new Guid("d3e13982-118b-4b99-ac5d-cd3da3b4cc35"), 491491537, -1503857048, "DayPack"
                    }
                });

            migrationBuilder.InsertData("Products",
                new[]
                {
                    "Id", "Description", "Discriminator", "IntroduceAt", "Name", "Option", "PhotoUrl", "Price", "ProductTypeId", "Rating", "Stock",
                    "AmountOfPerson", "KayakType"
                },
                new object[,]
                {
                    {
                        new Guid("53a17b32-9ad6-4dce-81ab-4c640868a4ea"), "Ipsam labore provident occaecati saepe iure explicabo dolorem amet.",
                        "Kayak",
                        new DateTimeOffset(new DateTime(2020, 9, 4, 8, 34, 3, 991, DateTimeKind.Unspecified).AddTicks(8864),
                            new TimeSpan(0, -3, 0, 0, 0)),
                        "officiis", "Two", "https://picsum.photos/640/480/?image=282", 0.1376353147636336622039825451m,
                        new Guid("d3e13982-118b-4b99-ac5d-cd3da3b4cc35"), -1049495574, -654061204, -1108781576, "Camping"
                    },
                    {
                        new Guid("67c43cb4-dc48-4561-a617-81aef0bdda12"), "Corrupti eos fugiat impedit.", "Kayak",
                        new DateTimeOffset(new DateTime(2021, 1, 2, 7, 0, 37, 238, DateTimeKind.Unspecified).AddTicks(5665),
                            new TimeSpan(0, -3, 0, 0, 0)),
                        "officiis", "Two", "https://picsum.photos/640/480/?image=5", 0.9709228231853227070595241402m,
                        new Guid("d3e13982-118b-4b99-ac5d-cd3da3b4cc35"), 660081531, -208083289, -923792834, "Racing"
                    },
                    {
                        new Guid("8a95a6cc-9623-4edf-a5eb-8d92078d8738"), "Possimus perferendis itaque ut fugiat repellat repudiandae.", "Kayak",
                        new DateTimeOffset(new DateTime(2021, 3, 1, 15, 25, 1, 18, DateTimeKind.Unspecified).AddTicks(4842),
                            new TimeSpan(0, -3, 0, 0, 0)),
                        "ea", "Three", "https://picsum.photos/640/480/?image=469", 0.610122713220316581279168424m,
                        new Guid("d3e13982-118b-4b99-ac5d-cd3da3b4cc35"), -297798030, -564164511, 1146975978, "Diving"
                    },
                    {
                        new Guid("f452e639-5b00-4ce5-bbae-6fb76e069135"), "Sunt corrupti impedit eius sed.", "Kayak",
                        new DateTimeOffset(new DateTime(2021, 4, 27, 0, 34, 57, 43, DateTimeKind.Unspecified).AddTicks(6978),
                            new TimeSpan(0, -3, 0, 0, 0)),
                        "et", "Two", "https://picsum.photos/640/480/?image=344", 0.7189156932589123319564564411m,
                        new Guid("d3e13982-118b-4b99-ac5d-cd3da3b4cc35"), 748940091, -30859816, 315550632, "Racing"
                    }
                });

            migrationBuilder.InsertData("Products",
                new[]
                {
                    "Id", "Description", "Discriminator", "IntroduceAt", "Name", "Option", "PhotoUrl", "Price", "ProductTypeId", "Rating", "Stock",
                    "AmountOfPerson", "KayakType"
                },
                new object[,]
                {
                    {
                        new Guid("0f9d25c6-f185-428b-82a0-c3efc4080ac4"), "Iure enim sint voluptatibus cum exercitationem et maiores harum.", "Kayak",
                        new DateTimeOffset(new DateTime(2021, 2, 25, 12, 25, 10, 34, DateTimeKind.Unspecified).AddTicks(7982),
                            new TimeSpan(0, -3, 0, 0, 0)),
                        "ea", "Two", "https://picsum.photos/640/480/?image=543", 0.2277459987210830225662950129m,
                        new Guid("d3e13982-118b-4b99-ac5d-cd3da3b4cc35"), 1483839394, -396742700, 715369448, "Family"
                    },
                    {
                        new Guid("ae8ba79e-ef91-4934-862e-b7597a20af7e"), "Tenetur officiis odio totam ullam sapiente provident ex numquam.", "Kayak",
                        new DateTimeOffset(new DateTime(2021, 7, 4, 16, 45, 39, 182, DateTimeKind.Unspecified).AddTicks(5077),
                            new TimeSpan(0, -3, 0, 0, 0)),
                        "accusantium", "One", "https://picsum.photos/640/480/?image=996", 0.3211088321935904346970753569m,
                        new Guid("d3e13982-118b-4b99-ac5d-cd3da3b4cc35"), -173865831, 1307221276, 1170361407, "Diving"
                    },
                    {
                        new Guid("8269c550-9f4f-475f-8167-69f69bfc5302"), "Libero magnam consequatur et officia eaque voluptatibus dolores cum.",
                        "Kayak",
                        new DateTimeOffset(new DateTime(2021, 1, 29, 13, 45, 11, 689, DateTimeKind.Unspecified).AddTicks(3313),
                            new TimeSpan(0, -3, 0, 0, 0)),
                        "tempora", "One", "https://picsum.photos/640/480/?image=635", 0.9549282230419998818557739828m,
                        new Guid("d3e13982-118b-4b99-ac5d-cd3da3b4cc35"), -1621370537, -2079297598, 1567433446, "Diving"
                    },
                    {
                        new Guid("61bffc40-93b8-49ba-aab3-26af888c9690"), "Blanditiis sequi magnam omnis dolores quaerat.", "Kayak",
                        new DateTimeOffset(new DateTime(2020, 8, 24, 22, 22, 20, 822, DateTimeKind.Unspecified).AddTicks(2446),
                            new TimeSpan(0, -3, 0, 0, 0)),
                        "modi", "Three", "https://picsum.photos/640/480/?image=299", 0.611517086243293666991503884m,
                        new Guid("d3e13982-118b-4b99-ac5d-cd3da3b4cc35"), 1201292104, -1352556225, -45165690, "Fishing"
                    },
                    {
                        new Guid("fc5c79fa-9acd-49a6-9fb1-22a05235df91"), "Et ad reprehenderit sapiente dolorem magni.", "Kayak",
                        new DateTimeOffset(new DateTime(2021, 5, 12, 20, 19, 8, 954, DateTimeKind.Unspecified).AddTicks(8039),
                            new TimeSpan(0, -3, 0, 0, 0)),
                        "tenetur", "Three", "https://picsum.photos/640/480/?image=510", 0.2508166424931265554274173102m,
                        new Guid("d3e13982-118b-4b99-ac5d-cd3da3b4cc35"), 328109615, 1444084526, 1512899282, "Diving"
                    },
                    {
                        new Guid("165e2bf1-fa24-4bfa-8c26-1d2193e6e6e3"), "Sit dolorem aut qui ut eum repellendus illo perferendis ea.", "Kayak",
                        new DateTimeOffset(new DateTime(2021, 3, 7, 16, 0, 46, 936, DateTimeKind.Unspecified).AddTicks(2196),
                            new TimeSpan(0, -3, 0, 0, 0)),
                        "aut", "Three", "https://picsum.photos/640/480/?image=447", 0.3669955637836361189911542326m,
                        new Guid("d3e13982-118b-4b99-ac5d-cd3da3b4cc35"), -1630174694, -269211070, -1367716237, "Fishing"
                    },
                    {
                        new Guid("5a27bb18-2209-4931-8d2e-c57b82075123"), "Rerum id enim aut.", "Kayak",
                        new DateTimeOffset(new DateTime(2020, 9, 9, 0, 33, 37, 75, DateTimeKind.Unspecified).AddTicks(5385),
                            new TimeSpan(0, -3, 0, 0, 0)),
                        "omnis", "One", "https://picsum.photos/640/480/?image=647", 0.3846316396945366261516217176m,
                        new Guid("d3e13982-118b-4b99-ac5d-cd3da3b4cc35"), -2142471270, -1192455615, 1615218068, "Racing"
                    },
                    {
                        new Guid("699abdb8-e333-43ae-95f7-84d874bca34d"), "Veritatis beatae quam et harum consequuntur autem et et rerum.", "Kayak",
                        new DateTimeOffset(new DateTime(2020, 12, 24, 15, 56, 49, 675, DateTimeKind.Unspecified).AddTicks(608),
                            new TimeSpan(0, -3, 0, 0, 0)),
                        "earum", "One", "https://picsum.photos/640/480/?image=299", 0.4044690902829301743107668967m,
                        new Guid("d3e13982-118b-4b99-ac5d-cd3da3b4cc35"), 1557884860, -909983134, -5214752, "Camping"
                    },
                    {
                        new Guid("ba1f8e54-c3d7-41e3-a32f-4c9e591e2fd4"), "Tempore aliquam repudiandae aliquam.", "Kayak",
                        new DateTimeOffset(new DateTime(2021, 1, 4, 20, 53, 19, 150, DateTimeKind.Unspecified).AddTicks(6446),
                            new TimeSpan(0, -3, 0, 0, 0)),
                        "qui", "Three", "https://picsum.photos/640/480/?image=551", 0.8197070692583373630067827438m,
                        new Guid("d3e13982-118b-4b99-ac5d-cd3da3b4cc35"), -1706041055, 1982334526, -183296729, "Racing"
                    },
                    {
                        new Guid("e0517866-d58b-4af5-b00d-13c6b1db122d"), "Et perspiciatis quo dolor aut accusantium.", "Kayak",
                        new DateTimeOffset(new DateTime(2021, 4, 14, 7, 22, 47, 740, DateTimeKind.Unspecified).AddTicks(9033),
                            new TimeSpan(0, -3, 0, 0, 0)),
                        "quasi", "Three", "https://picsum.photos/640/480/?image=528", 0.7165625172451191782160675134m,
                        new Guid("d3e13982-118b-4b99-ac5d-cd3da3b4cc35"), -730688094, 924368266, -668476868, "Racing"
                    },
                    {
                        new Guid("f998c65c-c2c0-4ea6-9a11-3d1040b2e51a"), "Voluptatem rerum recusandae id a rerum.", "Kayak",
                        new DateTimeOffset(new DateTime(2021, 4, 8, 18, 20, 56, 650, DateTimeKind.Unspecified).AddTicks(5411),
                            new TimeSpan(0, -3, 0, 0, 0)),
                        "optio", "Two", "https://picsum.photos/640/480/?image=632", 0.2953318365515326711289741026m,
                        new Guid("d3e13982-118b-4b99-ac5d-cd3da3b4cc35"), -355733018, -481603342, 806819933, "Racing"
                    },
                    {
                        new Guid("4a5a608a-e1c0-4cf0-9630-81850ec7fc49"), "Recusandae nihil quisquam.", "Kayak",
                        new DateTimeOffset(new DateTime(2021, 7, 20, 22, 2, 4, 241, DateTimeKind.Unspecified).AddTicks(7924),
                            new TimeSpan(0, -3, 0, 0, 0)),
                        "provident", "Two", "https://picsum.photos/640/480/?image=602", 0.3745532945059029770466319646m,
                        new Guid("d3e13982-118b-4b99-ac5d-cd3da3b4cc35"), -434117158, -162775804, 1875566261, "Diving"
                    }
                });

            migrationBuilder.InsertData("Products",
                new[]
                {
                    "Id", "Description", "Discriminator", "IntroduceAt", "Name", "Option", "PhotoUrl", "Price", "ProductTypeId", "Rating", "Stock",
                    "BootType", "Size"
                },
                new object[]
                {
                    new Guid("7c2b35a8-e1c7-4294-93e1-7dc282950d22"), "Cupiditate tempora libero adipisci quas.", "Boot",
                    new DateTimeOffset(new DateTime(2020, 8, 14, 16, 15, 19, 265, DateTimeKind.Unspecified).AddTicks(7032),
                        new TimeSpan(0, -3, 0, 0, 0)),
                    "quidem", "One", "https://picsum.photos/640/480/?image=5", 0.7008931663668790765860305209m,
                    new Guid("95a5fa4a-41fb-44ee-8670-a9305d24fe94"), -765555025, -187988315, "Engineer", 656967978
                });

            migrationBuilder.InsertData("Products",
                new[]
                {
                    "Id", "Description", "Discriminator", "IntroduceAt", "Name", "Option", "PhotoUrl", "Price", "ProductTypeId", "Rating", "Stock",
                    "AmountOfPerson", "KayakType"
                },
                new object[]
                {
                    new Guid("a2e07f87-062d-4fec-b583-104e3379bd9a"), "Ut nam est quo aut consequuntur est modi.", "Kayak",
                    new DateTimeOffset(new DateTime(2021, 7, 25, 0, 40, 29, 310, DateTimeKind.Unspecified).AddTicks(6114),
                        new TimeSpan(0, -3, 0, 0, 0)),
                    "saepe", "Two", "https://picsum.photos/640/480/?image=132", 0.9266727795999204981750910671m,
                    new Guid("d3e13982-118b-4b99-ac5d-cd3da3b4cc35"), -1505192421, -1677427977, -1220084004, "Family"
                });

            migrationBuilder.InsertData("Products",
                new[]
                {
                    "Id", "Description", "Discriminator", "IntroduceAt", "Name", "Option", "PhotoUrl", "Price", "ProductTypeId", "Rating", "Stock",
                    "BootType", "Size"
                },
                new object[]
                {
                    new Guid("77a44930-89e1-40e0-afbc-11b893886fc9"), "Nihil dignissimos commodi sunt ea temporibus earum dicta.", "Boot",
                    new DateTimeOffset(new DateTime(2020, 8, 20, 1, 47, 27, 212, DateTimeKind.Unspecified).AddTicks(9990),
                        new TimeSpan(0, -3, 0, 0, 0)),
                    "incidunt", "Two", "https://picsum.photos/640/480/?image=571", 0.2340802744884805613465574588m,
                    new Guid("d3e13982-118b-4b99-ac5d-cd3da3b4cc35"), 1349668158, 783019855, "Harness", 1963431434
                });

            migrationBuilder.InsertData("Products",
                new[]
                {
                    "Id", "Description", "Discriminator", "IntroduceAt", "Name", "Option", "PhotoUrl", "Price", "ProductTypeId", "Rating", "Stock",
                    "BackpackType"
                },
                new object[,]
                {
                    {
                        new Guid("38a5ec97-bf15-47b3-ad05-f7d5b10220be"), "Voluptatibus sunt temporibus ipsam quas voluptas voluptatem velit.",
                        "Backpack",
                        new DateTimeOffset(new DateTime(2021, 8, 1, 16, 0, 13, 443, DateTimeKind.Unspecified).AddTicks(7178),
                            new TimeSpan(0, -3, 0, 0, 0)),
                        "natus", "Three", "https://picsum.photos/640/480/?image=691", 0.3657773785626542568088694481m,
                        new Guid("d3e13982-118b-4b99-ac5d-cd3da3b4cc35"), -291026361, -1215210857, "Climbing"
                    },
                    {
                        new Guid("43be72a4-2691-4a91-94e6-3762ab5228a5"), "Temporibus ratione aut incidunt iusto reprehenderit et eum culpa et.",
                        "Backpack",
                        new DateTimeOffset(new DateTime(2021, 4, 22, 21, 29, 46, 952, DateTimeKind.Unspecified).AddTicks(89),
                            new TimeSpan(0, -3, 0, 0, 0)),
                        "delectus", "One", "https://picsum.photos/640/480/?image=379", 0.1066756842413618296509278576m,
                        new Guid("d3e13982-118b-4b99-ac5d-cd3da3b4cc35"), -813814913, -1434278080, "Cycling"
                    },
                    {
                        new Guid("49d4e24d-57c2-442e-9979-aa44d677acbc"), "Nisi consequatur cum ut ipsum.", "Backpack",
                        new DateTimeOffset(new DateTime(2020, 10, 30, 6, 18, 47, 978, DateTimeKind.Unspecified).AddTicks(6189),
                            new TimeSpan(0, -3, 0, 0, 0)),
                        "temporibus", "One", "https://picsum.photos/640/480/?image=749", 0.9672496342319568764927512616m,
                        new Guid("d3e13982-118b-4b99-ac5d-cd3da3b4cc35"), 1485649644, -835571664, "Climbing"
                    },
                    {
                        new Guid("95a57bad-66c8-49c1-8c21-ec4b44fe4668"), "Amet fugiat aut modi quidem voluptas rerum at asperiores.", "Backpack",
                        new DateTimeOffset(new DateTime(2021, 2, 12, 0, 58, 47, 697, DateTimeKind.Unspecified).AddTicks(7694),
                            new TimeSpan(0, -3, 0, 0, 0)),
                        "nisi", "One", "https://picsum.photos/640/480/?image=440", 0.5013937131458650005594303676m,
                        new Guid("d3e13982-118b-4b99-ac5d-cd3da3b4cc35"), -732755160, 1802341338, "Climbing"
                    }
                });

            migrationBuilder.InsertData("Products",
                new[]
                {
                    "Id", "Description", "Discriminator", "IntroduceAt", "Name", "Option", "PhotoUrl", "Price", "ProductTypeId", "Rating", "Stock",
                    "BootType", "Size"
                },
                new object[,]
                {
                    {
                        new Guid("95f83460-696a-47f0-b470-291a13e92571"), "Asperiores sit est.", "Boot",
                        new DateTimeOffset(new DateTime(2021, 2, 1, 4, 9, 47, 963, DateTimeKind.Unspecified).AddTicks(8839),
                            new TimeSpan(0, -3, 0, 0, 0)),
                        "illum", "One", "https://picsum.photos/640/480/?image=33", 0.51545940640843640420554552m,
                        new Guid("d3e13982-118b-4b99-ac5d-cd3da3b4cc35"), -999877566, -1720213698, "Cowboy", -968305962
                    },
                    {
                        new Guid("549bc968-3a0b-40ff-97ca-ae5bab983197"), "Excepturi explicabo accusamus.", "Boot",
                        new DateTimeOffset(new DateTime(2020, 12, 8, 15, 27, 4, 722, DateTimeKind.Unspecified).AddTicks(4573),
                            new TimeSpan(0, -3, 0, 0, 0)),
                        "nihil", "One", "https://picsum.photos/640/480/?image=467", 0.3147651993692776993324055604m,
                        new Guid("d3e13982-118b-4b99-ac5d-cd3da3b4cc35"), 319166791, -757094121, "Football", -1181498474
                    },
                    {
                        new Guid("8b0fb6dd-b2f7-48ca-8f26-00a52b0e92fc"), "Sed maxime id doloremque repellendus quod similique ratione sapiente et.",
                        "Boot",
                        new DateTimeOffset(new DateTime(2021, 7, 2, 9, 2, 21, 747, DateTimeKind.Unspecified).AddTicks(4026),
                            new TimeSpan(0, -3, 0, 0, 0)),
                        "nisi", "Two", "https://picsum.photos/640/480/?image=1051", 0.8228390992905499395794088524m,
                        new Guid("d3e13982-118b-4b99-ac5d-cd3da3b4cc35"), 1917645271, -1087216803, "Cowboy", 1917598627
                    },
                    {
                        new Guid("a4388e3d-de5e-4ad4-9764-74cf10ecde25"), "Vel dolorem accusamus consequatur sed consectetur quaerat facere quasi.",
                        "Boot",
                        new DateTimeOffset(new DateTime(2021, 3, 22, 0, 27, 9, 767, DateTimeKind.Unspecified).AddTicks(6478),
                            new TimeSpan(0, -3, 0, 0, 0)),
                        "amet", "One", "https://picsum.photos/640/480/?image=690", 0.403146194399833158420509228m,
                        new Guid("d3e13982-118b-4b99-ac5d-cd3da3b4cc35"), -193267528, -330966441, "Harness", -1090381537
                    },
                    {
                        new Guid("4890996a-ffa2-48d6-913f-f40e7ecfb17d"), "Velit tempore doloribus nulla quaerat totam itaque.", "Boot",
                        new DateTimeOffset(new DateTime(2020, 12, 21, 18, 40, 55, 773, DateTimeKind.Unspecified).AddTicks(5350),
                            new TimeSpan(0, -3, 0, 0, 0)),
                        "eum", "Two", "https://picsum.photos/640/480/?image=414", 0.7562059467152082618192229605m,
                        new Guid("d3e13982-118b-4b99-ac5d-cd3da3b4cc35"), 432019376, -53133089, "Cowboy", -146467592
                    },
                    {
                        new Guid("efad398d-35ec-4e61-874f-78f38b7afc8b"), "Ut recusandae quidem voluptatem unde dolorem amet.", "Boot",
                        new DateTimeOffset(new DateTime(2020, 10, 12, 9, 52, 58, 951, DateTimeKind.Unspecified).AddTicks(1905),
                            new TimeSpan(0, -3, 0, 0, 0)),
                        "dolores", "One", "https://picsum.photos/640/480/?image=874", 0.4482935273583902181826025539m,
                        new Guid("d3e13982-118b-4b99-ac5d-cd3da3b4cc35"), 975011254, 1972910602, "Football", -1694172152
                    },
                    {
                        new Guid("6efa4585-5837-4ec1-88f1-c6bb01564a89"), "Quod deserunt ut dolores aut ducimus tenetur blanditiis earum autem.",
                        "Boot",
                        new DateTimeOffset(new DateTime(2021, 1, 29, 2, 7, 18, 23, DateTimeKind.Unspecified).AddTicks(3676),
                            new TimeSpan(0, -3, 0, 0, 0)),
                        "odio", "Three", "https://picsum.photos/640/480/?image=624", 0.7201140576370849213751508686m,
                        new Guid("d3e13982-118b-4b99-ac5d-cd3da3b4cc35"), -385759054, 38298879, "Drysuit", -153445088
                    },
                    {
                        new Guid("cfe3eeb3-c06e-4f16-b2fb-cf907dea60e9"),
                        "Dicta consequuntur dolorem magni dolores sit dignissimos magni dolore enim.", "Boot",
                        new DateTimeOffset(new DateTime(2021, 7, 21, 12, 35, 46, 885, DateTimeKind.Unspecified).AddTicks(8693),
                            new TimeSpan(0, -3, 0, 0, 0)),
                        "nulla", "Three", "https://picsum.photos/640/480/?image=221", 0.3286402514579596957140162723m,
                        new Guid("d3e13982-118b-4b99-ac5d-cd3da3b4cc35"), -82875185, 1923708400, "Harness", 1098533970
                    },
                    {
                        new Guid("504b88c3-5d0b-4010-a199-68fef2df5319"), "Et fugiat tempora.", "Boot",
                        new DateTimeOffset(new DateTime(2020, 12, 3, 0, 33, 48, 375, DateTimeKind.Unspecified).AddTicks(3115),
                            new TimeSpan(0, -3, 0, 0, 0)),
                        "perspiciatis", "Two", "https://picsum.photos/640/480/?image=403", 0.9751585051597289020973372669m,
                        new Guid("d3e13982-118b-4b99-ac5d-cd3da3b4cc35"), 1614454150, -299183028, "Harness", -983652474
                    },
                    {
                        new Guid("ff76914a-2211-421b-ba28-78be81174de4"), "Commodi necessitatibus et at.", "Boot",
                        new DateTimeOffset(new DateTime(2021, 5, 2, 22, 31, 30, 468, DateTimeKind.Unspecified).AddTicks(5502),
                            new TimeSpan(0, -3, 0, 0, 0)),
                        "maxime", "Three", "https://picsum.photos/640/480/?image=147", 0.3338431182456265777178037562m,
                        new Guid("d3e13982-118b-4b99-ac5d-cd3da3b4cc35"), 773803110, -1283890468, "Harness", 661334342
                    },
                    {
                        new Guid("5741ae25-d669-493c-8e3a-c88d72c50678"), "Officiis sapiente quae.", "Boot",
                        new DateTimeOffset(new DateTime(2020, 9, 17, 23, 39, 27, 534, DateTimeKind.Unspecified).AddTicks(3236),
                            new TimeSpan(0, -3, 0, 0, 0)),
                        "fuga", "One", "https://picsum.photos/640/480/?image=794", 0.634877001793648800181893596m,
                        new Guid("d3e13982-118b-4b99-ac5d-cd3da3b4cc35"), -848560961, -110324879, "Football", -1714231157
                    }
                });

            migrationBuilder.InsertData("Products",
                new[]
                {
                    "Id", "Description", "Discriminator", "IntroduceAt", "Name", "Option", "PhotoUrl", "Price", "ProductTypeId", "Rating", "Stock",
                    "AmountOfPerson", "KayakType"
                },
                new object[]
                {
                    new Guid("76bb39c3-04ae-44f0-8c91-575abbec989f"), "Aut sunt cumque quam in voluptatem sunt numquam.", "Kayak",
                    new DateTimeOffset(new DateTime(2021, 2, 26, 1, 34, 51, 829, DateTimeKind.Unspecified).AddTicks(3243),
                        new TimeSpan(0, -3, 0, 0, 0)),
                    "quam", "Two", "https://picsum.photos/640/480/?image=1001", 0.988066428119991789544491403m,
                    new Guid("d3e13982-118b-4b99-ac5d-cd3da3b4cc35"), -396349664, -1773007001, 1164033587, "Diving"
                });

            migrationBuilder.InsertData("Products",
                new[]
                {
                    "Id", "Description", "Discriminator", "IntroduceAt", "Name", "Option", "PhotoUrl", "Price", "ProductTypeId", "Rating", "Stock",
                    "BootType", "Size"
                },
                new object[,]
                {
                    {
                        new Guid("62845a7e-1398-4186-bf05-38515fe23929"), "Saepe dolorem voluptatem laudantium ea.", "Boot",
                        new DateTimeOffset(new DateTime(2020, 11, 24, 1, 20, 13, 499, DateTimeKind.Unspecified).AddTicks(6487),
                            new TimeSpan(0, -3, 0, 0, 0)),
                        "sequi", "One", "https://picsum.photos/640/480/?image=513", 0.6119934957024219239674205986m,
                        new Guid("95a5fa4a-41fb-44ee-8670-a9305d24fe94"), -368623228, -438115829, "Engineer", -1704590115
                    },
                    {
                        new Guid("b492ec0d-fe7e-472a-951d-8a3a97d82c68"), "Porro quia possimus sit id porro aut impedit.", "Boot",
                        new DateTimeOffset(new DateTime(2021, 6, 28, 0, 1, 29, 221, DateTimeKind.Unspecified).AddTicks(4114),
                            new TimeSpan(0, -3, 0, 0, 0)),
                        "aut", "Two", "https://picsum.photos/640/480/?image=258", 0.904292347561835677612800605m,
                        new Guid("95a5fa4a-41fb-44ee-8670-a9305d24fe94"), -96451128, 1793983115, "Harness", 1291393399
                    },
                    {
                        new Guid("94d6eb28-511d-44fd-bd67-0afa4adb2c03"), "Aspernatur quia recusandae cumque minima.", "Boot",
                        new DateTimeOffset(new DateTime(2020, 10, 5, 8, 34, 25, 268, DateTimeKind.Unspecified).AddTicks(9696),
                            new TimeSpan(0, -3, 0, 0, 0)),
                        "at", "One", "https://picsum.photos/640/480/?image=113", 0.8236710753673823850733386141m,
                        new Guid("95a5fa4a-41fb-44ee-8670-a9305d24fe94"), -1728488116, -1934823018, "Drysuit", -1632123298
                    },
                    {
                        new Guid("d3a38609-8084-434c-94ad-f638404212aa"),
                        "Assumenda velit vel est iusto consequatur numquam consequatur explicabo numquam.", "Boot",
                        new DateTimeOffset(new DateTime(2021, 3, 21, 14, 10, 42, 919, DateTimeKind.Unspecified).AddTicks(6040),
                            new TimeSpan(0, -3, 0, 0, 0)),
                        "quasi", "One", "https://picsum.photos/640/480/?image=458", 0.5343688834011158338014895092m,
                        new Guid("c814a26e-6e82-43ed-8e08-6eaa45d741ff"), -1686689532, -1516367318, "Chelsea", 395865133
                    },
                    {
                        new Guid("ae51139b-84cd-4da5-aa51-fd6ac214c068"), "Dignissimos animi illo quidem omnis laudantium reiciendis.", "Boot",
                        new DateTimeOffset(new DateTime(2020, 10, 8, 19, 27, 51, 159, DateTimeKind.Unspecified).AddTicks(1193),
                            new TimeSpan(0, -3, 0, 0, 0)),
                        "quibusdam", "Two", "https://picsum.photos/640/480/?image=203", 0.5723973668078197896908187589m,
                        new Guid("c814a26e-6e82-43ed-8e08-6eaa45d741ff"), -2079194216, 1121109602, "Chelsea", -727700889
                    },
                    {
                        new Guid("d7b9b561-5f50-4f08-9321-2bd87506a527"), "Quis quae tempore.", "Boot",
                        new DateTimeOffset(new DateTime(2021, 2, 20, 2, 8, 51, 941, DateTimeKind.Unspecified).AddTicks(6065),
                            new TimeSpan(0, -3, 0, 0, 0)),
                        "reiciendis", "Two", "https://picsum.photos/640/480/?image=820", 0.2834701896208822232822059093m,
                        new Guid("c814a26e-6e82-43ed-8e08-6eaa45d741ff"), 668762314, -1421453815, "Harness", -2029159059
                    },
                    {
                        new Guid("bbe3e615-8386-4874-91f2-54d87edb843e"), "Fugiat qui quis ipsa perspiciatis voluptas error.", "Boot",
                        new DateTimeOffset(new DateTime(2020, 11, 28, 4, 54, 55, 758, DateTimeKind.Unspecified).AddTicks(3580),
                            new TimeSpan(0, -3, 0, 0, 0)),
                        "qui", "Two", "https://picsum.photos/640/480/?image=336", 0.7832651056919147034748621278m,
                        new Guid("c814a26e-6e82-43ed-8e08-6eaa45d741ff"), -1515404921, 288416647, "Chelsea", 1614919044
                    },
                    {
                        new Guid("628f270f-cbb8-4f35-a448-cdf18942cb83"), "Perspiciatis dolorum qui doloremque vero.", "Boot",
                        new DateTimeOffset(new DateTime(2021, 7, 27, 17, 6, 4, 692, DateTimeKind.Unspecified).AddTicks(29),
                            new TimeSpan(0, -3, 0, 0, 0)),
                        "dignissimos", "One", "https://picsum.photos/640/480/?image=309", 0.9503753260413711372063918037m,
                        new Guid("c814a26e-6e82-43ed-8e08-6eaa45d741ff"), -546294253, 682213087, "Harness", 2140676644
                    },
                    {
                        new Guid("31a14d59-a65c-4c7d-921c-d071e2c21bcc"), "Voluptatem totam non.", "Boot",
                        new DateTimeOffset(new DateTime(2020, 8, 4, 4, 22, 38, 597, DateTimeKind.Unspecified).AddTicks(2129),
                            new TimeSpan(0, -3, 0, 0, 0)),
                        "corrupti", "Two", "https://picsum.photos/640/480/?image=367", 0.236606163908968657228197705m,
                        new Guid("c814a26e-6e82-43ed-8e08-6eaa45d741ff"), -793747962, 411938534, "Harness", 2071933917
                    },
                    {
                        new Guid("6f16c858-6d47-4c4c-b09a-96a6a3bc3309"), "Sunt hic qui quos voluptatum molestiae earum autem voluptatem.", "Boot",
                        new DateTimeOffset(new DateTime(2020, 9, 22, 10, 53, 12, 964, DateTimeKind.Unspecified).AddTicks(8815),
                            new TimeSpan(0, -3, 0, 0, 0)),
                        "officiis", "Two", "https://picsum.photos/640/480/?image=382", 0.8517853125401703613523729885m,
                        new Guid("c814a26e-6e82-43ed-8e08-6eaa45d741ff"), -2044291300, 1366505568, "Engineer", -1824894999
                    },
                    {
                        new Guid("49b6c9dc-f3cd-4151-9b59-043ade1b272e"), "Voluptas at ab sunt.", "Boot",
                        new DateTimeOffset(new DateTime(2021, 4, 29, 5, 39, 59, 506, DateTimeKind.Unspecified).AddTicks(8580),
                            new TimeSpan(0, -3, 0, 0, 0)),
                        "quis", "Three", "https://picsum.photos/640/480/?image=931", 0.1707977273615642654184441422m,
                        new Guid("c814a26e-6e82-43ed-8e08-6eaa45d741ff"), -818857273, -698881956, "Harness", 1191262978
                    }
                });

            migrationBuilder.InsertData("Products",
                new[]
                {
                    "Id", "Description", "Discriminator", "IntroduceAt", "Name", "Option", "PhotoUrl", "Price", "ProductTypeId", "Rating", "Stock",
                    "BootType", "Size"
                },
                new object[,]
                {
                    {
                        new Guid("f857160b-bc87-4b9a-b72f-b32d5bde3967"), "Deserunt reprehenderit aspernatur.", "Boot",
                        new DateTimeOffset(new DateTime(2021, 4, 20, 16, 32, 3, 940, DateTimeKind.Unspecified).AddTicks(1345),
                            new TimeSpan(0, -3, 0, 0, 0)),
                        "dolores", "One", "https://picsum.photos/640/480/?image=345", 0.3580105795070785559403622293m,
                        new Guid("c814a26e-6e82-43ed-8e08-6eaa45d741ff"), 644738107, -656765861, "Chelsea", 1586101908
                    },
                    {
                        new Guid("97db1c78-aa59-40d3-a610-6178686f75fd"), "Tenetur sed necessitatibus fuga est illum nisi.", "Boot",
                        new DateTimeOffset(new DateTime(2020, 10, 5, 11, 8, 58, 348, DateTimeKind.Unspecified).AddTicks(2206),
                            new TimeSpan(0, -3, 0, 0, 0)),
                        "illum", "One", "https://picsum.photos/640/480/?image=1079", 0.6636073096676749974007514204m,
                        new Guid("c814a26e-6e82-43ed-8e08-6eaa45d741ff"), 1380442398, -1529451518, "Engineer", 880162587
                    },
                    {
                        new Guid("5de55aa5-acd1-4c91-ae1c-200b3c8c25cb"), "Qui sit nostrum.", "Boot",
                        new DateTimeOffset(new DateTime(2021, 3, 10, 23, 33, 35, 747, DateTimeKind.Unspecified).AddTicks(5582),
                            new TimeSpan(0, -3, 0, 0, 0)),
                        "nobis", "Two", "https://picsum.photos/640/480/?image=233", 0.7908887352436406724781954592m,
                        new Guid("c814a26e-6e82-43ed-8e08-6eaa45d741ff"), -1762920615, -1215015360, "Cowboy", 833302165
                    },
                    {
                        new Guid("6797e621-4461-4e19-baa8-d4664566bded"), "Consequatur nihil et dolorum impedit placeat aut nihil.", "Boot",
                        new DateTimeOffset(new DateTime(2020, 11, 9, 2, 15, 5, 907, DateTimeKind.Unspecified).AddTicks(40),
                            new TimeSpan(0, -3, 0, 0, 0)),
                        "quae", "One", "https://picsum.photos/640/480/?image=16", 0.2966869378186310564425539149m,
                        new Guid("c814a26e-6e82-43ed-8e08-6eaa45d741ff"), -631325475, -1077632976, "Harness", -1783637712
                    },
                    {
                        new Guid("08a93355-3f0e-4439-85ab-2a8fa2b664cf"), "Fugiat quo dolores qui illum consequatur necessitatibus.", "Boot",
                        new DateTimeOffset(new DateTime(2020, 8, 20, 4, 1, 48, 536, DateTimeKind.Unspecified).AddTicks(6294),
                            new TimeSpan(0, -3, 0, 0, 0)),
                        "quisquam", "Three", "https://picsum.photos/640/480/?image=715", 0.5541095041492093816413899591m,
                        new Guid("c814a26e-6e82-43ed-8e08-6eaa45d741ff"), 132276869, -1398547804, "Chelsea", -359087701
                    },
                    {
                        new Guid("33b0796f-e73b-41f6-a27c-5b1cc3adc0b9"), "Et culpa doloribus.", "Boot",
                        new DateTimeOffset(new DateTime(2020, 9, 12, 4, 53, 29, 729, DateTimeKind.Unspecified).AddTicks(8070),
                            new TimeSpan(0, -3, 0, 0, 0)),
                        "possimus", "Two", "https://picsum.photos/640/480/?image=1074", 0.0644687741893178090184903855m,
                        new Guid("c814a26e-6e82-43ed-8e08-6eaa45d741ff"), 861327444, 1968367444, "Engineer", 178205428
                    },
                    {
                        new Guid("301d56ee-6c23-478b-b6cf-10d591dcaaf9"), "Inventore exercitationem iure laborum cumque ipsam consequatur iusto.",
                        "Boot",
                        new DateTimeOffset(new DateTime(2021, 4, 18, 2, 52, 53, 879, DateTimeKind.Unspecified).AddTicks(2842),
                            new TimeSpan(0, -3, 0, 0, 0)),
                        "similique", "Three", "https://picsum.photos/640/480/?image=825", 0.4705432069201605730078945799m,
                        new Guid("c814a26e-6e82-43ed-8e08-6eaa45d741ff"), -915051377, 1246835026, "Drysuit", 340550880
                    },
                    {
                        new Guid("aafd0f62-58bf-433d-910c-be7dfcc765e3"), "Id non et harum consectetur quas.", "Boot",
                        new DateTimeOffset(new DateTime(2021, 7, 9, 15, 46, 56, 944, DateTimeKind.Unspecified).AddTicks(2022),
                            new TimeSpan(0, -3, 0, 0, 0)),
                        "quia", "Three", "https://picsum.photos/640/480/?image=399", 0.3757448062796132347935656768m,
                        new Guid("c814a26e-6e82-43ed-8e08-6eaa45d741ff"), 1011199658, -211044534, "Engineer", 104208390
                    },
                    {
                        new Guid("47d199c8-a2fa-4c76-949a-04603e25817b"), "Est dolorum ullam voluptatum quia id doloribus ea.", "Boot",
                        new DateTimeOffset(new DateTime(2020, 10, 22, 4, 36, 27, 784, DateTimeKind.Unspecified).AddTicks(6840),
                            new TimeSpan(0, -3, 0, 0, 0)),
                        "soluta", "One", "https://picsum.photos/640/480/?image=391", 0.2841231594549997594734752624m,
                        new Guid("c814a26e-6e82-43ed-8e08-6eaa45d741ff"), 1745108829, -535760899, "Cowboy", -1068959262
                    },
                    {
                        new Guid("1ffa6214-fd7a-4e59-b9ca-de5e0cbdf828"), "Dolorem alias nisi ut suscipit et fugit voluptas quam quidem.", "Boot",
                        new DateTimeOffset(new DateTime(2021, 6, 13, 0, 3, 4, 110, DateTimeKind.Unspecified).AddTicks(7922),
                            new TimeSpan(0, -3, 0, 0, 0)),
                        "consectetur", "One", "https://picsum.photos/640/480/?image=156", 0.0742728038480234909499884843m,
                        new Guid("c814a26e-6e82-43ed-8e08-6eaa45d741ff"), 1306771619, 1972094084, "Drysuit", -1860161043
                    }
                });

            migrationBuilder.InsertData("Products",
                new[]
                {
                    "Id", "Description", "Discriminator", "IntroduceAt", "Name", "Option", "PhotoUrl", "Price", "ProductTypeId", "Rating", "Stock",
                    "BackpackType"
                },
                new object[,]
                {
                    {
                        new Guid("d937f183-e800-4cd2-8d9c-40d042f52de7"), "Rerum voluptatem corporis voluptatem voluptatum ex eos.", "Backpack",
                        new DateTimeOffset(new DateTime(2021, 3, 25, 18, 41, 12, 292, DateTimeKind.Unspecified).AddTicks(9956),
                            new TimeSpan(0, -3, 0, 0, 0)),
                        "libero", "One", "https://picsum.photos/640/480/?image=269", 0.0640520983219103087968770862m,
                        new Guid("c814a26e-6e82-43ed-8e08-6eaa45d741ff"), 706046774, -499623745, "DayPack"
                    },
                    {
                        new Guid("04d3c9f3-3e4c-4552-a053-16fa31489dd7"), "Rerum aut quis qui ad asperiores.", "Backpack",
                        new DateTimeOffset(new DateTime(2020, 10, 16, 5, 26, 16, 744, DateTimeKind.Unspecified).AddTicks(5293),
                            new TimeSpan(0, -3, 0, 0, 0)),
                        "ab", "Three", "https://picsum.photos/640/480/?image=583", 0.9320690611446014975694315032m,
                        new Guid("c814a26e-6e82-43ed-8e08-6eaa45d741ff"), 1311982267, -1676445095, "Hiking"
                    },
                    {
                        new Guid("6775d02c-54bc-449a-83e9-8f2b5c9caf36"), "Labore ut blanditiis dolorem cum consequatur mollitia.", "Backpack",
                        new DateTimeOffset(new DateTime(2020, 8, 4, 8, 37, 11, 623, DateTimeKind.Unspecified).AddTicks(3672),
                            new TimeSpan(0, -3, 0, 0, 0)),
                        "adipisci", "Two", "https://picsum.photos/640/480/?image=866", 0.3312730165285348650984462412m,
                        new Guid("c814a26e-6e82-43ed-8e08-6eaa45d741ff"), 1153743911, -1603941974, "DayPack"
                    },
                    {
                        new Guid("de29b664-3dab-4f3e-833e-a72fd5562ff6"), "Debitis quod harum corrupti.", "Backpack",
                        new DateTimeOffset(new DateTime(2020, 11, 20, 23, 36, 58, 188, DateTimeKind.Unspecified).AddTicks(5135),
                            new TimeSpan(0, -3, 0, 0, 0)),
                        "non", "One", "https://picsum.photos/640/480/?image=297", 0.5963928495398696269335946846m,
                        new Guid("c814a26e-6e82-43ed-8e08-6eaa45d741ff"), 1142558218, -1160445461, "Overnight"
                    },
                    {
                        new Guid("088e0904-c1b5-4a59-b28b-b48e0943f158"), "Odit autem doloribus excepturi enim voluptatum facere sed velit.",
                        "Backpack",
                        new DateTimeOffset(new DateTime(2021, 5, 5, 16, 49, 38, 261, DateTimeKind.Unspecified).AddTicks(5513),
                            new TimeSpan(0, -3, 0, 0, 0)),
                        "magni", "Two", "https://picsum.photos/640/480/?image=680", 0.6193180593981379967182860887m,
                        new Guid("c814a26e-6e82-43ed-8e08-6eaa45d741ff"), 1030795207, -1578367708, "DayPack"
                    },
                    {
                        new Guid("1b268a85-e0e1-46b5-9055-fca9ee5ce135"), "Eum veritatis nam.", "Backpack",
                        new DateTimeOffset(new DateTime(2020, 10, 30, 2, 3, 39, 751, DateTimeKind.Unspecified).AddTicks(4168),
                            new TimeSpan(0, -3, 0, 0, 0)),
                        "dolore", "Three", "https://picsum.photos/640/480/?image=544", 0.7175523163492923631050676445m,
                        new Guid("c814a26e-6e82-43ed-8e08-6eaa45d741ff"), -1441815048, 1190340457, "Snowsports"
                    },
                    {
                        new Guid("0cd30e2b-92d8-473b-89e9-221ea879e3c8"), "Vero non neque dignissimos quaerat.", "Backpack",
                        new DateTimeOffset(new DateTime(2021, 1, 8, 6, 17, 54, 115, DateTimeKind.Unspecified).AddTicks(2955),
                            new TimeSpan(0, -3, 0, 0, 0)),
                        "consequatur", "Three", "https://picsum.photos/640/480/?image=1064", 0.9013933949794800391383712172m,
                        new Guid("c814a26e-6e82-43ed-8e08-6eaa45d741ff"), 230393241, 854558802, "Hiking"
                    },
                    {
                        new Guid("48d31a4c-6687-40cf-ab65-1ee76f14b866"), "Quas sed voluptatum.", "Backpack",
                        new DateTimeOffset(new DateTime(2021, 7, 3, 7, 48, 53, 151, DateTimeKind.Unspecified).AddTicks(8377),
                            new TimeSpan(0, -3, 0, 0, 0)),
                        "at", "Three", "https://picsum.photos/640/480/?image=300", 0.94406172402606941235102874m,
                        new Guid("c814a26e-6e82-43ed-8e08-6eaa45d741ff"), -2135568754, -73387369, "Hiking"
                    },
                    {
                        new Guid("09c33d90-045c-45e4-8bc9-93a2e282c9f8"), "Quae alias blanditiis suscipit a officiis laborum.", "Backpack",
                        new DateTimeOffset(new DateTime(2021, 6, 22, 21, 27, 13, 47, DateTimeKind.Unspecified).AddTicks(5763),
                            new TimeSpan(0, -3, 0, 0, 0)),
                        "non", "One", "https://picsum.photos/640/480/?image=305", 0.6628817489167739095965518023m,
                        new Guid("c814a26e-6e82-43ed-8e08-6eaa45d741ff"), 1052766480, 2051886730, "DayPack"
                    },
                    {
                        new Guid("e22a8984-1f34-4536-b120-0eea72e9d197"), "Aut rem aliquam eum molestias omnis et quibusdam nihil.", "Backpack",
                        new DateTimeOffset(new DateTime(2020, 8, 27, 20, 44, 2, 2, DateTimeKind.Unspecified).AddTicks(248),
                            new TimeSpan(0, -3, 0, 0, 0)),
                        "numquam", "Two", "https://picsum.photos/640/480/?image=347", 0.643044354995347956064952403m,
                        new Guid("c814a26e-6e82-43ed-8e08-6eaa45d741ff"), -344664329, 467248854, "Climbing"
                    },
                    {
                        new Guid("97fc6b4b-c680-43fa-ab2e-cb53986c5d27"), "Ex similique aut aperiam molestiae id voluptates excepturi maiores.",
                        "Backpack",
                        new DateTimeOffset(new DateTime(2021, 6, 29, 2, 33, 33, 777, DateTimeKind.Unspecified).AddTicks(4486),
                            new TimeSpan(0, -3, 0, 0, 0)),
                        "tenetur", "Three", "https://picsum.photos/640/480/?image=507", 0.185763792865097024896441555m,
                        new Guid("c814a26e-6e82-43ed-8e08-6eaa45d741ff"), -441829196, -565843375, "Hiking"
                    },
                    {
                        new Guid("8c2316fb-91c8-4178-b850-61d08e9ae961"),
                        "Eveniet dignissimos delectus cum sequi asperiores enim voluptatem eius sed.", "Backpack",
                        new DateTimeOffset(new DateTime(2020, 11, 28, 11, 2, 12, 680, DateTimeKind.Unspecified).AddTicks(5735),
                            new TimeSpan(0, -3, 0, 0, 0)),
                        "laudantium", "Three", "https://picsum.photos/640/480/?image=332", 0.7430688626816698596619112309m,
                        new Guid("c814a26e-6e82-43ed-8e08-6eaa45d741ff"), -457253484, -1803903063, "Snowsports"
                    },
                    {
                        new Guid("7c118d3f-fa6c-4e2f-ae29-bdb75b67bcca"), "Molestiae autem voluptatem quia est aliquam inventore et eligendi.",
                        "Backpack",
                        new DateTimeOffset(new DateTime(2021, 6, 22, 22, 3, 30, 142, DateTimeKind.Unspecified).AddTicks(2625),
                            new TimeSpan(0, -3, 0, 0, 0)),
                        "beatae", "Three", "https://picsum.photos/640/480/?image=767", 0.755224933270630898865875987m,
                        new Guid("c814a26e-6e82-43ed-8e08-6eaa45d741ff"), -1551880589, -45011175, "Climbing"
                    },
                    {
                        new Guid("806049ab-d1dd-43f6-8f8d-5dea6e0ce737"), "Aliquam odio est repellat et.", "Backpack",
                        new DateTimeOffset(new DateTime(2021, 7, 2, 20, 50, 26, 753, DateTimeKind.Unspecified).AddTicks(552),
                            new TimeSpan(0, -3, 0, 0, 0)),
                        "error", "One", "https://picsum.photos/640/480/?image=638", 0.9729027788944088721610383847m,
                        new Guid("c814a26e-6e82-43ed-8e08-6eaa45d741ff"), 1178579590, -1409763124, "Cycling"
                    },
                    {
                        new Guid("51914a05-d8f1-43ce-ba3c-a4ac9c123f5d"), "Aperiam eius ratione odit asperiores enim commodi eum quaerat esse.",
                        "Backpack",
                        new DateTimeOffset(new DateTime(2021, 6, 9, 3, 37, 23, 882, DateTimeKind.Unspecified).AddTicks(5033),
                            new TimeSpan(0, -3, 0, 0, 0)),
                        "voluptas", "Two", "https://picsum.photos/640/480/?image=168", 0.0321023644230593708908540067m,
                        new Guid("c814a26e-6e82-43ed-8e08-6eaa45d741ff"), -611395981, 2036189084, "Cycling"
                    },
                    {
                        new Guid("30d11008-aa26-42ce-8ba7-21c40a04a36d"), "Numquam ea vel voluptate expedita laborum consequatur.", "Backpack",
                        new DateTimeOffset(new DateTime(2020, 12, 31, 21, 13, 4, 491, DateTimeKind.Unspecified).AddTicks(7256),
                            new TimeSpan(0, -3, 0, 0, 0)),
                        "voluptas", "Two", "https://picsum.photos/640/480/?image=363", 0.1315726673184179787381271677m,
                        new Guid("c814a26e-6e82-43ed-8e08-6eaa45d741ff"), 244917988, -1318188380, "Overnight"
                    },
                    {
                        new Guid("b8f1a660-7251-422f-9162-96f122594166"), "Autem et aut.", "Backpack",
                        new DateTimeOffset(new DateTime(2021, 4, 26, 19, 42, 37, 709, DateTimeKind.Unspecified).AddTicks(5867),
                            new TimeSpan(0, -3, 0, 0, 0)),
                        "optio", "Three", "https://picsum.photos/640/480/?image=756", 0.334908360024987840703362037m,
                        new Guid("c814a26e-6e82-43ed-8e08-6eaa45d741ff"), 1388051443, -293585076, "Climbing"
                    }
                });

            migrationBuilder.InsertData("Products",
                new[]
                {
                    "Id", "Description", "Discriminator", "IntroduceAt", "Name", "Option", "PhotoUrl", "Price", "ProductTypeId", "Rating", "Stock",
                    "AmountOfPerson", "KayakType"
                },
                new object[]
                {
                    new Guid("e56a1014-0651-4ed3-8a4f-d44595f983f7"), "Et esse harum sequi exercitationem aut enim.", "Kayak",
                    new DateTimeOffset(new DateTime(2020, 12, 20, 5, 24, 22, 765, DateTimeKind.Unspecified).AddTicks(2119),
                        new TimeSpan(0, -3, 0, 0, 0)),
                    "quia", "Three", "https://picsum.photos/640/480/?image=350", 0.35791370114420569733321556m,
                    new Guid("d3e13982-118b-4b99-ac5d-cd3da3b4cc35"), -1740270310, 210559691, -954460240, "Family"
                });

            migrationBuilder.InsertData("Products",
                new[]
                {
                    "Id", "Description", "Discriminator", "IntroduceAt", "Name", "Option", "PhotoUrl", "Price", "ProductTypeId", "Rating", "Stock",
                    "BootType", "Size"
                },
                new object[]
                {
                    new Guid("212e25d0-df60-48ea-9a96-b00407e89ccb"), "Minus voluptatem a.", "Boot",
                    new DateTimeOffset(new DateTime(2021, 8, 3, 20, 55, 59, 989, DateTimeKind.Unspecified).AddTicks(519),
                        new TimeSpan(0, -3, 0, 0, 0)),
                    "accusantium", "One", "https://picsum.photos/640/480/?image=7", 0.3748286025692046052526205236m,
                    new Guid("c814a26e-6e82-43ed-8e08-6eaa45d741ff"), -294836913, -390743591, "Chelsea", 394618044
                });

            migrationBuilder.InsertData("Products",
                new[]
                {
                    "Id", "Description", "Discriminator", "IntroduceAt", "Name", "Option", "PhotoUrl", "Price", "ProductTypeId", "Rating", "Stock",
                    "AmountOfPerson", "KayakType"
                },
                new object[]
                {
                    new Guid("e7305dc6-94b5-482b-a6ea-a8d55ee38886"), "Ut itaque quasi ipsa tenetur.", "Kayak",
                    new DateTimeOffset(new DateTime(2021, 7, 22, 17, 52, 18, 695, DateTimeKind.Unspecified).AddTicks(477),
                        new TimeSpan(0, -3, 0, 0, 0)),
                    "qui", "One", "https://picsum.photos/640/480/?image=246", 0.7613004511594577861764058069m,
                    new Guid("c814a26e-6e82-43ed-8e08-6eaa45d741ff"), 1128007690, 2140022293, 1664374545, "Camping"
                });

            migrationBuilder.InsertData("Products",
                new[]
                {
                    "Id", "Description", "Discriminator", "IntroduceAt", "Name", "Option", "PhotoUrl", "Price", "ProductTypeId", "Rating", "Stock",
                    "BackpackType"
                },
                new object[,]
                {
                    {
                        new Guid("0bb3c44a-66ff-4b3d-8ba3-88a7be83850b"), "Repudiandae autem doloribus quo expedita in qui dolor.", "Backpack",
                        new DateTimeOffset(new DateTime(2021, 5, 28, 3, 22, 30, 530, DateTimeKind.Unspecified).AddTicks(5553),
                            new TimeSpan(0, -3, 0, 0, 0)),
                        "nobis", "One", "https://picsum.photos/640/480/?image=209", 0.1439448385313710873030593107m,
                        new Guid("95a5fa4a-41fb-44ee-8670-a9305d24fe94"), 490468463, -480894060, "DayPack"
                    },
                    {
                        new Guid("ec37d47b-8cca-434c-969e-d3ef92779da3"), "Accusantium quo cum quisquam consequatur atque repellendus.", "Backpack",
                        new DateTimeOffset(new DateTime(2021, 4, 18, 18, 41, 41, 513, DateTimeKind.Unspecified).AddTicks(2827),
                            new TimeSpan(0, -3, 0, 0, 0)),
                        "porro", "Three", "https://picsum.photos/640/480/?image=177", 0.246328524242266103464441302m,
                        new Guid("95a5fa4a-41fb-44ee-8670-a9305d24fe94"), 206029046, -2016626977, "Snowsports"
                    },
                    {
                        new Guid("34778a1a-fd32-4e50-a0ef-798adee7c810"), "Beatae quia itaque vitae dolorem ea eum.", "Backpack",
                        new DateTimeOffset(new DateTime(2020, 11, 12, 21, 56, 48, 662, DateTimeKind.Unspecified).AddTicks(1882),
                            new TimeSpan(0, -3, 0, 0, 0)),
                        "odio", "One", "https://picsum.photos/640/480/?image=129", 0.2735659429236748034076905615m,
                        new Guid("95a5fa4a-41fb-44ee-8670-a9305d24fe94"), -801651084, -2128656395, "Cycling"
                    },
                    {
                        new Guid("b9ce9c8b-7303-410d-a90a-f9f46ab629a1"), "Nisi harum corporis.", "Backpack",
                        new DateTimeOffset(new DateTime(2021, 5, 25, 9, 7, 58, 813, DateTimeKind.Unspecified).AddTicks(3446),
                            new TimeSpan(0, -3, 0, 0, 0)),
                        "voluptatibus", "Three", "https://picsum.photos/640/480/?image=1007", 0.1830744520393139514801388345m,
                        new Guid("95a5fa4a-41fb-44ee-8670-a9305d24fe94"), -1162947832, 1873452016, "Hiking"
                    },
                    {
                        new Guid("84591fda-06e8-43d7-ac34-653a110b27af"), "Aliquid ipsum aut quos repudiandae nam minus soluta.", "Backpack",
                        new DateTimeOffset(new DateTime(2021, 5, 21, 2, 12, 37, 200, DateTimeKind.Unspecified).AddTicks(3313),
                            new TimeSpan(0, -3, 0, 0, 0)),
                        "in", "Three", "https://picsum.photos/640/480/?image=661", 0.4123996099085381147045291558m,
                        new Guid("95a5fa4a-41fb-44ee-8670-a9305d24fe94"), -315373692, 1614523125, "Cycling"
                    },
                    {
                        new Guid("31078c1a-f3fd-41c7-b42d-3ac33bf339fd"), "Qui maiores temporibus dignissimos ut eum beatae asperiores.", "Backpack",
                        new DateTimeOffset(new DateTime(2020, 9, 30, 17, 31, 0, 505, DateTimeKind.Unspecified).AddTicks(4604),
                            new TimeSpan(0, -3, 0, 0, 0)),
                        "vel", "Two", "https://picsum.photos/640/480/?image=83", 0.290650054698809717840135576m,
                        new Guid("95a5fa4a-41fb-44ee-8670-a9305d24fe94"), 1618560888, -1676111233, "Snowsports"
                    },
                    {
                        new Guid("61c74e72-f6ab-43c3-8697-5bf642355786"), "Occaecati aut autem quia voluptas.", "Backpack",
                        new DateTimeOffset(new DateTime(2020, 10, 15, 12, 59, 13, 36, DateTimeKind.Unspecified).AddTicks(9274),
                            new TimeSpan(0, -3, 0, 0, 0)),
                        "voluptatem", "Two", "https://picsum.photos/640/480/?image=949", 0.1589347035051377930642799446m,
                        new Guid("95a5fa4a-41fb-44ee-8670-a9305d24fe94"), 1664926164, -902689858, "DayPack"
                    },
                    {
                        new Guid("23461481-18cd-406b-9208-360c2b8b7bf3"), "Tenetur natus rem illum.", "Backpack",
                        new DateTimeOffset(new DateTime(2021, 1, 11, 0, 48, 24, 960, DateTimeKind.Unspecified).AddTicks(2845),
                            new TimeSpan(0, -3, 0, 0, 0)),
                        "corporis", "Three", "https://picsum.photos/640/480/?image=126", 0.8917820185893048140463651574m,
                        new Guid("95a5fa4a-41fb-44ee-8670-a9305d24fe94"), -150764334, -158683822, "Overnight"
                    },
                    {
                        new Guid("bdec72b1-e31e-4d16-9ffa-1e770a55fbfe"), "Adipisci veniam vel molestiae cumque repellendus.", "Backpack",
                        new DateTimeOffset(new DateTime(2021, 1, 16, 4, 13, 8, 275, DateTimeKind.Unspecified).AddTicks(1082),
                            new TimeSpan(0, -3, 0, 0, 0)),
                        "dicta", "Three", "https://picsum.photos/640/480/?image=167", 0.7725874024881922784864508034m,
                        new Guid("95a5fa4a-41fb-44ee-8670-a9305d24fe94"), 1934946659, 169572605, "Cycling"
                    },
                    {
                        new Guid("8a9a9c62-dade-42ea-83b4-3049272d20b1"), "Nobis voluptatem hic sed dolor.", "Backpack",
                        new DateTimeOffset(new DateTime(2020, 12, 26, 1, 13, 48, 824, DateTimeKind.Unspecified).AddTicks(5989),
                            new TimeSpan(0, -3, 0, 0, 0)),
                        "temporibus", "Three", "https://picsum.photos/640/480/?image=424", 0.9915078103710690873123207772m,
                        new Guid("95a5fa4a-41fb-44ee-8670-a9305d24fe94"), 890813381, 644647986, "Overnight"
                    },
                    {
                        new Guid("d863b949-7022-4ce1-b393-1f1a5124222c"), "Veniam veritatis officiis perferendis qui aut rem voluptatibus.",
                        "Backpack",
                        new DateTimeOffset(new DateTime(2020, 9, 4, 11, 39, 30, 314, DateTimeKind.Unspecified).AddTicks(4640),
                            new TimeSpan(0, -3, 0, 0, 0)),
                        "est", "One", "https://picsum.photos/640/480/?image=195", 0.192394518470792778788641164m,
                        new Guid("95a5fa4a-41fb-44ee-8670-a9305d24fe94"), -1266093261, 1125244209, "DayPack"
                    },
                    {
                        new Guid("8f3a86ff-bda9-494e-9fda-4df0ca354613"), "Illum et magnam iusto quis suscipit iure expedita officiis.", "Backpack",
                        new DateTimeOffset(new DateTime(2021, 3, 8, 12, 29, 32, 629, DateTimeKind.Unspecified).AddTicks(1635),
                            new TimeSpan(0, -3, 0, 0, 0)),
                        "quo", "One", "https://picsum.photos/640/480/?image=1078", 0.7000880651778670495079987112m,
                        new Guid("95a5fa4a-41fb-44ee-8670-a9305d24fe94"), -891691790, -626330894, "Climbing"
                    }
                });

            migrationBuilder.InsertData("Products",
                new[]
                {
                    "Id", "Description", "Discriminator", "IntroduceAt", "Name", "Option", "PhotoUrl", "Price", "ProductTypeId", "Rating", "Stock",
                    "BackpackType"
                },
                new object[,]
                {
                    {
                        new Guid("84129002-c5c8-49fd-9aa2-0156b2c71763"), "Qui aperiam aut officiis rerum.", "Backpack",
                        new DateTimeOffset(new DateTime(2020, 9, 29, 13, 55, 14, 491, DateTimeKind.Unspecified).AddTicks(2571),
                            new TimeSpan(0, -3, 0, 0, 0)),
                        "quod", "One", "https://picsum.photos/640/480/?image=524", 0.1404408299498189277224400293m,
                        new Guid("95a5fa4a-41fb-44ee-8670-a9305d24fe94"), 1323167380, 674977312, "Climbing"
                    },
                    {
                        new Guid("2a9456f4-2e3e-4f85-9184-8fce63a8d62f"), "Molestiae provident veniam molestiae et inventore qui impedit facilis.",
                        "Backpack",
                        new DateTimeOffset(new DateTime(2020, 11, 25, 6, 35, 38, 212, DateTimeKind.Unspecified).AddTicks(3117),
                            new TimeSpan(0, -3, 0, 0, 0)),
                        "doloribus", "Two", "https://picsum.photos/640/480/?image=437", 0.7620706780811261680831888266m,
                        new Guid("95a5fa4a-41fb-44ee-8670-a9305d24fe94"), 850551374, 72119809, "Cycling"
                    }
                });

            migrationBuilder.InsertData("Products",
                new[]
                {
                    "Id", "Description", "Discriminator", "IntroduceAt", "Name", "Option", "PhotoUrl", "Price", "ProductTypeId", "Rating", "Stock",
                    "BootType", "Size"
                },
                new object[]
                {
                    new Guid("bea1b5ba-7219-4727-b10a-8c57752257ce"), "Et molestiae iste est soluta possimus similique fugiat.", "Boot",
                    new DateTimeOffset(new DateTime(2021, 1, 18, 22, 55, 4, 723, DateTimeKind.Unspecified).AddTicks(1270),
                        new TimeSpan(0, -3, 0, 0, 0)),
                    "maiores", "Two", "https://picsum.photos/640/480/?image=538", 0.1926805769819139180184991502m,
                    new Guid("95a5fa4a-41fb-44ee-8670-a9305d24fe94"), -598340413, -224653747, "Football", 787907924
                });

            migrationBuilder.InsertData("Products",
                new[]
                {
                    "Id", "Description", "Discriminator", "IntroduceAt", "Name", "Option", "PhotoUrl", "Price", "ProductTypeId", "Rating", "Stock",
                    "BackpackType"
                },
                new object[]
                {
                    new Guid("21b737e9-934b-411d-baf8-b9a6902ccef5"),
                    "Eaque voluptatum aut adipisci delectus veniam similique perspiciatis unde voluptates.", "Backpack",
                    new DateTimeOffset(new DateTime(2021, 1, 6, 16, 37, 19, 117, DateTimeKind.Unspecified).AddTicks(9660),
                        new TimeSpan(0, -3, 0, 0, 0)),
                    "ut", "Two", "https://picsum.photos/640/480/?image=688", 0.9115940562406004645412355782m,
                    new Guid("95a5fa4a-41fb-44ee-8670-a9305d24fe94"), -176073860, -605270024, "Snowsports"
                });

            migrationBuilder.InsertData("Products",
                new[]
                {
                    "Id", "Description", "Discriminator", "IntroduceAt", "Name", "Option", "PhotoUrl", "Price", "ProductTypeId", "Rating", "Stock",
                    "BootType", "Size"
                },
                new object[]
                {
                    new Guid("c01a3e51-aa67-423c-b1bb-69fd6d466422"), "Ut a ipsa iure provident quaerat.", "Boot",
                    new DateTimeOffset(new DateTime(2021, 7, 24, 20, 42, 59, 834, DateTimeKind.Unspecified).AddTicks(8285),
                        new TimeSpan(0, -3, 0, 0, 0)),
                    "hic", "One", "https://picsum.photos/640/480/?image=703", 0.9309430439847802270904473776m,
                    new Guid("c814a26e-6e82-43ed-8e08-6eaa45d741ff"), -2058064254, -43176768, "Drysuit", 1138226478
                });

            migrationBuilder.InsertData("Products",
                new[]
                {
                    "Id", "Description", "Discriminator", "IntroduceAt", "Name", "Option", "PhotoUrl", "Price", "ProductTypeId", "Rating", "Stock",
                    "BackpackType"
                },
                new object[]
                {
                    new Guid("c183c713-1ac8-4115-8f2b-40f7c204dbea"), "Non inventore et enim cupiditate.", "Backpack",
                    new DateTimeOffset(new DateTime(2020, 12, 10, 3, 7, 25, 828, DateTimeKind.Unspecified).AddTicks(479),
                        new TimeSpan(0, -3, 0, 0, 0)),
                    "placeat", "One", "https://picsum.photos/640/480/?image=312", 0.0263726245759876642618385029m,
                    new Guid("95a5fa4a-41fb-44ee-8670-a9305d24fe94"), 1511954773, -1904422001, "DayPack"
                });

            migrationBuilder.InsertData("Products",
                new[]
                {
                    "Id", "Description", "Discriminator", "IntroduceAt", "Name", "Option", "PhotoUrl", "Price", "ProductTypeId", "Rating", "Stock",
                    "AmountOfPerson", "KayakType"
                },
                new object[,]
                {
                    {
                        new Guid("e273c720-07de-4597-a000-6157621c7614"), "Non saepe sit magnam quasi nostrum sequi magnam excepturi dolor.", "Kayak",
                        new DateTimeOffset(new DateTime(2021, 6, 20, 10, 29, 26, 662, DateTimeKind.Unspecified).AddTicks(1379),
                            new TimeSpan(0, -3, 0, 0, 0)),
                        "ducimus", "One", "https://picsum.photos/640/480/?image=135", 0.2412590343664832745286479729m,
                        new Guid("c814a26e-6e82-43ed-8e08-6eaa45d741ff"), -199810745, 332659574, 1886086435, "Racing"
                    },
                    {
                        new Guid("ff2c5c17-7451-4f0e-aa90-559abbfdb2b4"),
                        "Quasi temporibus accusamus voluptas dicta dolorum dignissimos veritatis nam.", "Kayak",
                        new DateTimeOffset(new DateTime(2021, 1, 14, 1, 6, 11, 854, DateTimeKind.Unspecified).AddTicks(8558),
                            new TimeSpan(0, -3, 0, 0, 0)),
                        "amet", "Two", "https://picsum.photos/640/480/?image=212", 0.7559933078721816078831723911m,
                        new Guid("c814a26e-6e82-43ed-8e08-6eaa45d741ff"), 151021028, -1823896105, 891920624, "Diving"
                    },
                    {
                        new Guid("adc47289-327d-4cf2-800f-5e8211abfb72"), "Neque laborum voluptas impedit quis.", "Kayak",
                        new DateTimeOffset(new DateTime(2021, 6, 22, 4, 35, 12, 136, DateTimeKind.Unspecified).AddTicks(3786),
                            new TimeSpan(0, -3, 0, 0, 0)),
                        "maxime", "One", "https://picsum.photos/640/480/?image=325", 0.0204955100327869791598713373m,
                        new Guid("c814a26e-6e82-43ed-8e08-6eaa45d741ff"), -2104183317, -1105518697, 697452447, "Camping"
                    },
                    {
                        new Guid("bd84a1ef-5ef5-471c-884b-d18045654f22"), "Accusantium eligendi ut fuga ea dolor qui nostrum itaque quisquam.",
                        "Kayak",
                        new DateTimeOffset(new DateTime(2021, 7, 26, 18, 59, 24, 138, DateTimeKind.Unspecified).AddTicks(4986),
                            new TimeSpan(0, -3, 0, 0, 0)),
                        "iusto", "Two", "https://picsum.photos/640/480/?image=239", 0.7935514295437046512202818943m,
                        new Guid("c814a26e-6e82-43ed-8e08-6eaa45d741ff"), -1110990160, -396090529, -870652741, "Diving"
                    },
                    {
                        new Guid("fadaf0cd-ebcf-4c82-bc1e-e63aa22ef926"),
                        "Voluptatibus dolore explicabo sed accusamus et laboriosam aut nihil magnam.", "Kayak",
                        new DateTimeOffset(new DateTime(2021, 2, 11, 3, 18, 31, 534, DateTimeKind.Unspecified).AddTicks(20),
                            new TimeSpan(0, -3, 0, 0, 0)),
                        "similique", "Three", "https://picsum.photos/640/480/?image=262", 0.091650442877499340823270493m,
                        new Guid("c814a26e-6e82-43ed-8e08-6eaa45d741ff"), 1343194689, -2115255496, -1565071228, "Camping"
                    },
                    {
                        new Guid("06624cff-c4f7-41cd-a14e-2a4984cb97e5"), "Excepturi labore cumque praesentium tempora tempora.", "Kayak",
                        new DateTimeOffset(new DateTime(2020, 9, 12, 15, 46, 20, 883, DateTimeKind.Unspecified).AddTicks(532),
                            new TimeSpan(0, -3, 0, 0, 0)),
                        "voluptatibus", "One", "https://picsum.photos/640/480/?image=292", 0.456649499676118748841932279m,
                        new Guid("c814a26e-6e82-43ed-8e08-6eaa45d741ff"), 303684859, 609480070, -274314856, "Fishing"
                    },
                    {
                        new Guid("c93d3aed-5fd9-4fef-8545-e9961fa80214"), "Eveniet consequatur soluta sunt accusantium nesciunt tenetur blanditiis.",
                        "Kayak",
                        new DateTimeOffset(new DateTime(2020, 8, 16, 10, 35, 23, 774, DateTimeKind.Unspecified).AddTicks(8150),
                            new TimeSpan(0, -3, 0, 0, 0)),
                        "natus", "Three", "https://picsum.photos/640/480/?image=472", 0.2674213274445749246067876033m,
                        new Guid("c814a26e-6e82-43ed-8e08-6eaa45d741ff"), 449158857, -572280276, 384118682, "Fishing"
                    },
                    {
                        new Guid("d9fead66-9c90-4b8e-9e27-acdd149f9cb2"), "Nostrum commodi aut tempore a minima.", "Kayak",
                        new DateTimeOffset(new DateTime(2020, 11, 16, 4, 25, 3, 517, DateTimeKind.Unspecified).AddTicks(9995),
                            new TimeSpan(0, -3, 0, 0, 0)),
                        "numquam", "Three", "https://picsum.photos/640/480/?image=211", 0.1933153045513026202770697384m,
                        new Guid("c814a26e-6e82-43ed-8e08-6eaa45d741ff"), -672538997, 883343104, 471577560, "Family"
                    },
                    {
                        new Guid("de44314e-49d9-4a34-9a6e-f3171880bb14"), "Iusto nisi consequatur.", "Kayak",
                        new DateTimeOffset(new DateTime(2020, 8, 26, 14, 36, 25, 972, DateTimeKind.Unspecified).AddTicks(8179),
                            new TimeSpan(0, -3, 0, 0, 0)),
                        "officia", "Three", "https://picsum.photos/640/480/?image=341", 0.682094765011370267942824863m,
                        new Guid("c814a26e-6e82-43ed-8e08-6eaa45d741ff"), -1780778947, -1167733038, 1192129652, "Family"
                    },
                    {
                        new Guid("f39824d2-7792-40c7-b4b2-e966650454e1"), "Amet dolores molestiae ipsum voluptas omnis ad iusto.", "Kayak",
                        new DateTimeOffset(new DateTime(2021, 5, 22, 4, 43, 46, 394, DateTimeKind.Unspecified).AddTicks(9101),
                            new TimeSpan(0, -3, 0, 0, 0)),
                        "ullam", "Three", "https://picsum.photos/640/480/?image=683", 0.3578949807054828704117183138m,
                        new Guid("c814a26e-6e82-43ed-8e08-6eaa45d741ff"), -865107132, 1250509495, 725408269, "Diving"
                    },
                    {
                        new Guid("e33818b1-97a5-47cb-a5e3-367168114114"), "Quibusdam deserunt esse quia quidem facere.", "Kayak",
                        new DateTimeOffset(new DateTime(2020, 12, 2, 7, 22, 33, 229, DateTimeKind.Unspecified).AddTicks(9578),
                            new TimeSpan(0, -3, 0, 0, 0)),
                        "officiis", "One", "https://picsum.photos/640/480/?image=653", 0.7129447945621129406327654963m,
                        new Guid("c814a26e-6e82-43ed-8e08-6eaa45d741ff"), -1345198957, -1583056703, -1461448767, "Diving"
                    },
                    {
                        new Guid("21106a06-7f7d-42e9-96f0-da5627777e19"), "Exercitationem atque perspiciatis mollitia iure sunt.", "Kayak",
                        new DateTimeOffset(new DateTime(2021, 1, 10, 11, 29, 1, 475, DateTimeKind.Unspecified).AddTicks(3302),
                            new TimeSpan(0, -3, 0, 0, 0)),
                        "quia", "One", "https://picsum.photos/640/480/?image=995", 0.9551791093043519468539070788m,
                        new Guid("c814a26e-6e82-43ed-8e08-6eaa45d741ff"), 1424371355, -1173099647, -2059298830, "Racing"
                    },
                    {
                        new Guid("eb9aad9b-6313-4933-a1b2-d380fef4a6a1"), "Et nostrum at dicta.", "Kayak",
                        new DateTimeOffset(new DateTime(2021, 6, 18, 9, 44, 41, 943, DateTimeKind.Unspecified).AddTicks(1031),
                            new TimeSpan(0, -3, 0, 0, 0)),
                        "sint", "One", "https://picsum.photos/640/480/?image=850", 0.7622977905951333665355867656m,
                        new Guid("c814a26e-6e82-43ed-8e08-6eaa45d741ff"), 45509208, -164439576, -309446720, "Fishing"
                    },
                    {
                        new Guid("3e663442-4a87-4632-93c3-542366d8569c"), "Ut quas exercitationem voluptas tempora odio molestiae repudiandae.",
                        "Kayak",
                        new DateTimeOffset(new DateTime(2020, 11, 22, 1, 4, 27, 731, DateTimeKind.Unspecified).AddTicks(6371),
                            new TimeSpan(0, -3, 0, 0, 0)),
                        "ipsa", "One", "https://picsum.photos/640/480/?image=961", 0.0031294108122969413221848419m,
                        new Guid("c814a26e-6e82-43ed-8e08-6eaa45d741ff"), 1729985560, -2013484093, -267827876, "Fishing"
                    },
                    {
                        new Guid("ac684f52-2cf9-433f-84a1-221140e93f3a"), "Libero provident qui culpa officiis ut.", "Kayak",
                        new DateTimeOffset(new DateTime(2021, 4, 12, 14, 29, 59, 716, DateTimeKind.Unspecified).AddTicks(6859),
                            new TimeSpan(0, -3, 0, 0, 0)),
                        "rerum", "One", "https://picsum.photos/640/480/?image=230", 0.8445867760240015884730352195m,
                        new Guid("c814a26e-6e82-43ed-8e08-6eaa45d741ff"), 1132769053, 123295504, -1596642045, "Diving"
                    },
                    {
                        new Guid("3b4c6cfb-5906-4567-a508-40a3799ae8a3"), "Sunt quis ab sit repudiandae esse neque ut optio.", "Kayak",
                        new DateTimeOffset(new DateTime(2020, 12, 9, 14, 33, 32, 170, DateTimeKind.Unspecified).AddTicks(3458),
                            new TimeSpan(0, -3, 0, 0, 0)),
                        "et", "Three", "https://picsum.photos/640/480/?image=576", 0.2055755199877413780609159414m,
                        new Guid("c814a26e-6e82-43ed-8e08-6eaa45d741ff"), -736054542, 1463063347, -966278405, "Camping"
                    },
                    {
                        new Guid("491eaf4a-2d9a-49bc-86a9-23951109d9e5"), "Hic consequatur autem.", "Kayak",
                        new DateTimeOffset(new DateTime(2020, 12, 6, 9, 49, 20, 521, DateTimeKind.Unspecified).AddTicks(9900),
                            new TimeSpan(0, -3, 0, 0, 0)),
                        "et", "Two", "https://picsum.photos/640/480/?image=553", 0.4950246161590198397522231497m,
                        new Guid("c814a26e-6e82-43ed-8e08-6eaa45d741ff"), -1492460672, -1643754746, -1701608620, "Fishing"
                    },
                    {
                        new Guid("1ea6522e-4dc0-44bb-a4c5-d374b438e05f"), "Aut vel qui aut id vel.", "Kayak",
                        new DateTimeOffset(new DateTime(2021, 7, 17, 11, 46, 37, 934, DateTimeKind.Unspecified).AddTicks(99),
                            new TimeSpan(0, -3, 0, 0, 0)),
                        "omnis", "One", "https://picsum.photos/640/480/?image=218", 0.4610139093285580344780870623m,
                        new Guid("d3e13982-118b-4b99-ac5d-cd3da3b4cc35"), -522660318, 1056065498, -1668532573, "Family"
                    }
                });

            migrationBuilder.InsertData("Reviews",
                new[] {"Id", "Comment", "ProductId", "Title"},
                new object[,]
                {
                    {
                        new Guid("e7d9841e-5f6b-459a-82ba-4ad0c4651022"), "Quia doloribus saepe molestias eum ullam aut officia.",
                        new Guid("a0569d82-471c-4687-a203-154ae511d1f2"), "voluptatem"
                    },
                    {
                        new Guid("55a33d3a-8dc8-446e-b151-0473ddee8d98"), "Et ut harum amet voluptatem fuga repudiandae enim ut.",
                        new Guid("23461481-18cd-406b-9208-360c2b8b7bf3"), "et"
                    },
                    {
                        new Guid("201411e7-fb8d-4148-b2a0-21c7d607ad43"), "Et sit reprehenderit ut molestiae numquam repellendus.",
                        new Guid("bdec72b1-e31e-4d16-9ffa-1e770a55fbfe"), "ut"
                    },
                    {new Guid("5633a6d6-716b-4e7c-a626-bd65f7c83a97"), "Dolore illo unde.", new Guid("8a9a9c62-dade-42ea-83b4-3049272d20b1"), "aut"},
                    {
                        new Guid("4cd20896-4755-4767-be1d-a32dcca78484"),
                        "Ullam accusantium temporibus eos ullam voluptatem totam eos nemo aspernatur.",
                        new Guid("d863b949-7022-4ce1-b393-1f1a5124222c"), "eum"
                    },
                    {
                        new Guid("38010e71-bf2f-4552-b973-e35ff2b3cc2b"), "Et facere voluptas nostrum aut voluptate quisquam.",
                        new Guid("8f3a86ff-bda9-494e-9fda-4df0ca354613"), "consequatur"
                    },
                    {
                        new Guid("f3a9a1d8-a4b1-4854-b71b-887a2cefc180"), "Consequatur delectus aut.",
                        new Guid("84129002-c5c8-49fd-9aa2-0156b2c71763"), "ea"
                    },
                    {
                        new Guid("f2cbccac-dc32-4642-a9fe-b6dbb271209e"), "Illum dolor iusto porro quia sequi in.",
                        new Guid("2a9456f4-2e3e-4f85-9184-8fce63a8d62f"), "sapiente"
                    },
                    {
                        new Guid("212ad627-b8a3-43c8-864e-4cac3da510fa"), "Maxime est voluptas consequuntur ea consequatur ipsa fuga.",
                        new Guid("fbf6db5c-dc78-4bc5-a4a7-b562768481e7"), "molestiae"
                    },
                    {
                        new Guid("f8ea1a01-38d2-400a-9b72-8907c94763b8"), "Tenetur commodi expedita id ipsam.",
                        new Guid("bd53a01a-8c2f-4ed5-bef2-d33dc7c37305"), "sed"
                    },
                    {
                        new Guid("301b16a5-62d7-4d67-b99b-22d2cab92a69"), "Similique qui aliquid eveniet.",
                        new Guid("104f0c1c-ed80-4a61-906d-ae2d03102096"), "id"
                    },
                    {
                        new Guid("d7bbdc87-d73b-4aef-be96-438140aee64d"), "Harum voluptatibus voluptatem nostrum.",
                        new Guid("50a2a3c6-40fb-4c62-894a-a70d34b88d9a"), "culpa"
                    },
                    {
                        new Guid("929448ce-dd15-42ff-8679-e5b53dbbe3b1"), "Aut eos possimus minus reprehenderit qui facere cum et.",
                        new Guid("f848ba17-4891-4524-b134-fe9345f2fe9d"), "et"
                    },
                    {
                        new Guid("63f85efa-d4a0-46fe-a9be-2dda992de62c"), "Possimus nam est nemo cupiditate tenetur debitis quos impedit.",
                        new Guid("060ca68b-f04c-442a-8eaa-ba6153149907"), "eius"
                    },
                    {
                        new Guid("a8cbf601-3e4b-4c3a-b79c-8485489ed41e"), "Porro quia rem qui.", new Guid("4c46b3f0-0790-40af-8c08-5f398c4bba7b"),
                        "error"
                    },
                    {
                        new Guid("e21e1579-b618-4b90-b01b-da1071debabe"), "Quos qui non odio rerum quaerat.",
                        new Guid("06bb8e47-68f9-4505-a789-659bf40e6536"), "delectus"
                    },
                    {
                        new Guid("9f8041ee-f282-4bc9-92c1-bd7b0479a929"), "Quia deserunt repudiandae qui repellendus velit accusamus enim.",
                        new Guid("cd2b29fd-242d-4832-8fb4-3be6e7e41a36"), "dolores"
                    },
                    {
                        new Guid("f85ebee8-8b99-4023-ab80-183719a52b7c"), "Hic ut dolores eum a quasi odit numquam.",
                        new Guid("8f2dd25a-e7a7-4713-9c3a-7c8e39998797"), "doloribus"
                    },
                    {
                        new Guid("25a50dc7-6023-4547-956f-c4e426e6fb65"), "Molestiae inventore consectetur assumenda nulla in.",
                        new Guid("5b81751f-59c0-4829-aeaf-23804cb7c758"), "illo"
                    },
                    {
                        new Guid("e1f87e90-6b36-4d46-98c9-a7b31a35755b"), "Dolor quae ea facere officiis laboriosam maiores dolor.",
                        new Guid("a0ed7a52-4782-46f0-b8b3-4d57f15d1e23"), "vero"
                    },
                    {
                        new Guid("2a198cf6-2008-49dd-9854-e2a329c614c7"), "Deserunt non suscipit sit.",
                        new Guid("38a5ec97-bf15-47b3-ad05-f7d5b10220be"), "est"
                    },
                    {
                        new Guid("784b6f88-0f48-4cb2-b015-47ce48eeaae2"), "Eum saepe sint quidem odio tempora maiores ea expedita.",
                        new Guid("43be72a4-2691-4a91-94e6-3762ab5228a5"), "eum"
                    },
                    {
                        new Guid("9398645a-8ff4-44e4-bb8a-9edd73fa6f8c"), "Sunt commodi error itaque voluptates cumque beatae quis.",
                        new Guid("61c74e72-f6ab-43c3-8697-5bf642355786"), "quis"
                    },
                    {
                        new Guid("61b3d6bc-fe5d-488b-82af-c67613c02059"), "Quis accusantium nulla nemo.",
                        new Guid("31078c1a-f3fd-41c7-b42d-3ac33bf339fd"), "laborum"
                    },
                    {
                        new Guid("d4529aa1-0b21-4a76-9516-b839a064172e"),
                        "Vero laudantium tempora voluptatem architecto similique voluptatibus alias nihil.",
                        new Guid("84591fda-06e8-43d7-ac34-653a110b27af"), "ex"
                    },
                    {
                        new Guid("5aea8b5a-3b81-4a7c-909a-1e771b0a4795"), "Ut consequatur dolor numquam totam quaerat vel dolorem.",
                        new Guid("b9ce9c8b-7303-410d-a90a-f9f46ab629a1"), "sunt"
                    },
                    {
                        new Guid("91b5064a-19a7-4e0f-84de-ac3de2efcb4c"), "Libero hic doloribus non fugit.",
                        new Guid("04d3c9f3-3e4c-4552-a053-16fa31489dd7"), "qui"
                    },
                    {
                        new Guid("f699f26d-7ac6-4e0c-9328-dafa8048cfe7"), "Blanditiis qui expedita nihil vero quo.",
                        new Guid("6775d02c-54bc-449a-83e9-8f2b5c9caf36"), "quia"
                    },
                    {new Guid("d63cfe5d-2ad6-49ff-b414-86449bc08f78"), "Doloremque ea qui.", new Guid("de29b664-3dab-4f3e-833e-a72fd5562ff6"), "at"},
                    {
                        new Guid("e078e488-bec6-4614-9867-d8ada9776291"), "Quos aperiam in eaque esse sint omnis.",
                        new Guid("088e0904-c1b5-4a59-b28b-b48e0943f158"), "deleniti"
                    },
                    {
                        new Guid("87872eee-1cc2-4e1a-b74b-c4b28b9f42d4"), "Nihil et quisquam sed et architecto minus.",
                        new Guid("1b268a85-e0e1-46b5-9055-fca9ee5ce135"), "repudiandae"
                    },
                    {
                        new Guid("c85558b9-2da7-4f35-b427-81d2b5004521"), "Quo voluptas dolorem natus consequatur voluptatum vero sunt sit.",
                        new Guid("0cd30e2b-92d8-473b-89e9-221ea879e3c8"), "possimus"
                    },
                    {
                        new Guid("aebbfcf1-93ef-450d-966b-63d3305e0df8"), "Accusantium beatae rerum rem aspernatur omnis.",
                        new Guid("48d31a4c-6687-40cf-ab65-1ee76f14b866"), "itaque"
                    },
                    {
                        new Guid("c15fc475-07f0-49de-8def-d79d4c53677a"), "Necessitatibus quia eius et et.",
                        new Guid("09c33d90-045c-45e4-8bc9-93a2e282c9f8"), "est"
                    },
                    {
                        new Guid("fea97a92-1e83-4a5d-87d6-7b3611ebf53b"), "Dolores ab autem.", new Guid("e22a8984-1f34-4536-b120-0eea72e9d197"),
                        "delectus"
                    },
                    {
                        new Guid("47b5f1be-8887-49ca-8f35-08771513d15c"), "Voluptates asperiores magni quaerat eos eveniet aut tenetur.",
                        new Guid("97fc6b4b-c680-43fa-ab2e-cb53986c5d27"), "ullam"
                    },
                    {
                        new Guid("f024cf42-0fcf-40ea-81af-90795331ce73"), "Assumenda impedit ea amet perspiciatis officiis perspiciatis tempora qui.",
                        new Guid("49d4e24d-57c2-442e-9979-aa44d677acbc"), "et"
                    },
                    {
                        new Guid("0a07f4d3-0973-427c-9ef1-65cb5a9e5f1d"), "Quas qui architecto voluptate voluptates atque nobis.",
                        new Guid("8c2316fb-91c8-4178-b850-61d08e9ae961"), "minus"
                    },
                    {
                        new Guid("127fb4cf-eaf0-443a-be98-3eb77c9e8a03"), "Atque sunt nam ea cupiditate.",
                        new Guid("806049ab-d1dd-43f6-8f8d-5dea6e0ce737"), "quae"
                    },
                    {
                        new Guid("6d6d520c-05c9-4364-bc74-b54655d6bb2c"), "Repellat et ullam velit fugiat odit.",
                        new Guid("51914a05-d8f1-43ce-ba3c-a4ac9c123f5d"), "eos"
                    },
                    {
                        new Guid("bda589c0-a1f8-4237-89a7-b95182e7d6ad"), "Impedit nostrum occaecati itaque numquam voluptatibus.",
                        new Guid("30d11008-aa26-42ce-8ba7-21c40a04a36d"), "et"
                    },
                    {
                        new Guid("07c9ccf0-b91d-4969-91ae-e6a93ed5881a"), "Esse rerum voluptate explicabo qui ea aut sequi quam.",
                        new Guid("d937f183-e800-4cd2-8d9c-40d042f52de7"), "architecto"
                    }
                });

            migrationBuilder.InsertData("Reviews",
                new[] {"Id", "Comment", "ProductId", "Title"},
                new object[,]
                {
                    {
                        new Guid("f804d231-4b8b-4699-beba-155665b854a6"), "Odit quia molestiae ut laborum.",
                        new Guid("b8f1a660-7251-422f-9162-96f122594166"), "dolor"
                    },
                    {
                        new Guid("c0b5922c-9344-4aaa-bbdd-cc47c56595ab"), "Voluptates dignissimos sed corrupti et odit blanditiis sit.",
                        new Guid("c183c713-1ac8-4115-8f2b-40f7c204dbea"), "voluptatem"
                    },
                    {
                        new Guid("f16a4b75-37a8-425c-be9a-8469aa38ecf0"), "Tempore qui voluptatem fuga et aut corporis omnis.",
                        new Guid("21b737e9-934b-411d-baf8-b9a6902ccef5"), "facere"
                    },
                    {
                        new Guid("300bb2e5-a863-4ad4-83dc-a6581fb22b78"), "Veniam nihil laboriosam velit incidunt aut et.",
                        new Guid("0bb3c44a-66ff-4b3d-8ba3-88a7be83850b"), "voluptatem"
                    },
                    {
                        new Guid("1e19f693-746c-4942-9783-20f091beac18"), "Cumque ipsam nesciunt qui perspiciatis accusamus.",
                        new Guid("ec37d47b-8cca-434c-969e-d3ef92779da3"), "aut"
                    },
                    {
                        new Guid("d8f341c1-5618-4029-adfc-acfa05241150"), "Expedita rem tempora sunt.",
                        new Guid("34778a1a-fd32-4e50-a0ef-798adee7c810"), "voluptate"
                    },
                    {
                        new Guid("95719279-55bb-4a75-971b-c22c04b86893"), "Est eveniet cumque et consequatur voluptatem.",
                        new Guid("7c118d3f-fa6c-4e2f-ae29-bdb75b67bcca"), "deserunt"
                    },
                    {
                        new Guid("dcff2c53-d661-4402-b1a7-2f2598438996"), "Fuga fugit et aut.", new Guid("95a57bad-66c8-49c1-8c21-ec4b44fe4668"),
                        "alias"
                    }
                });

            migrationBuilder.CreateIndex("IX_Products_ProductTypeId",
                "Products",
                "ProductTypeId");

            migrationBuilder.CreateIndex("IX_ProductTypes_Discriminator",
                "ProductTypes",
                "Discriminator",
                unique: true);

            migrationBuilder.CreateIndex("IX_Reviews_ProductId",
                "Reviews",
                "ProductId");
        }
    }
}