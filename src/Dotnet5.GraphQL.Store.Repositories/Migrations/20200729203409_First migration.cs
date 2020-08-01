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
                    PhotoFileName = table.Column<string>("nvarchar(100)", maxLength: 100, nullable: true),
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
                new object[] {new Guid("b80d9a45-67b7-4184-a27e-768e73920b1c"), "TypeOne"});

            migrationBuilder.InsertData("ProductTypes",
                new[] {"Id", "Discriminator"},
                new object[] {new Guid("815954b2-93b4-4e30-9e30-c2d3a5074f40"), "TypeThree"});

            migrationBuilder.InsertData("ProductTypes",
                new[] {"Id", "Discriminator"},
                new object[] {new Guid("b7e06be6-60a4-4bcb-830b-160736d3f806"), "TypeTwo"});

            migrationBuilder.InsertData("Products",
                new[]
                {
                    "Id", "Description", "Discriminator", "IntroduceAt", "Name", "Option", "PhotoFileName", "Price", "ProductTypeId", "Rating",
                    "Stock", "BackpackType"
                },
                new object[]
                {
                    new Guid("10f4a184-61c1-41a8-881a-155575182923"), "Facere sed autem odio odit vero similique.", "Backpack",
                    new DateTimeOffset(new DateTime(2021, 3, 26, 9, 2, 1, 567, DateTimeKind.Unspecified).AddTicks(4449),
                        new TimeSpan(0, -3, 0, 0, 0)),
                    "asperiores", "Three", "montana.png", 0.0074774677576684747979257021m, new Guid("b80d9a45-67b7-4184-a27e-768e73920b1c"),
                    -1923363915, 1349857194, "DayPack"
                });

            migrationBuilder.InsertData("Products",
                new[]
                {
                    "Id", "Description", "Discriminator", "IntroduceAt", "Name", "Option", "PhotoFileName", "Price", "ProductTypeId", "Rating",
                    "Stock", "AmountOfPerson", "KayakType"
                },
                new object[,]
                {
                    {
                        new Guid("3dd6940c-0ef6-4a7b-9828-2bd547f4ef63"), "Voluptatem et sit perferendis eum quia quos.", "Kayak",
                        new DateTimeOffset(new DateTime(2021, 2, 17, 20, 37, 50, 195, DateTimeKind.Unspecified).AddTicks(5633),
                            new TimeSpan(0, -3, 0, 0, 0)),
                        "commodi", "Two", "metal_tasty_soft_car_well_modulated.mp2", 0.0071423201977937362390715658m,
                        new Guid("815954b2-93b4-4e30-9e30-c2d3a5074f40"), 959520674, 1167260873, 1421235444, "Diving"
                    },
                    {
                        new Guid("0a1d3eb7-a402-4dfa-9111-a0578399602a"), "Dicta et cumque quidem tenetur.", "Kayak",
                        new DateTimeOffset(new DateTime(2020, 12, 18, 3, 10, 43, 827, DateTimeKind.Unspecified).AddTicks(2923),
                            new TimeSpan(0, -3, 0, 0, 0)),
                        "maiores", "Two", "deposit_web_services_input.jpe", 0.6047768889989517234993308153m,
                        new Guid("815954b2-93b4-4e30-9e30-c2d3a5074f40"), 1090276397, 1509817141, 550084079, "Fishing"
                    },
                    {
                        new Guid("f722234b-630e-45fb-b98f-f5fa7090e295"), "Vero blanditiis sequi ea velit in.", "Kayak",
                        new DateTimeOffset(new DateTime(2021, 1, 27, 1, 34, 28, 596, DateTimeKind.Unspecified).AddTicks(1129),
                            new TimeSpan(0, -3, 0, 0, 0)),
                        "laudantium", "Three", "sleek_fresh_cheese_books__clothing_&_health.pdf", 0.0603431855455038323371633823m,
                        new Guid("815954b2-93b4-4e30-9e30-c2d3a5074f40"), 2041124470, 458849584, 1943095001, "Family"
                    },
                    {
                        new Guid("a1066d49-6f28-45b0-974a-6eba986b7fe6"), "Neque consequatur soluta enim velit sunt maxime ut voluptates est.",
                        "Kayak",
                        new DateTimeOffset(new DateTime(2020, 10, 8, 23, 17, 28, 460, DateTimeKind.Unspecified).AddTicks(6674),
                            new TimeSpan(0, -3, 0, 0, 0)),
                        "laudantium", "Three", "fantastic_handmade_concrete_chair_neural_net.mpg", 0.3781487497438183630310599363m,
                        new Guid("815954b2-93b4-4e30-9e30-c2d3a5074f40"), -1210240922, -1353186641, -1721306815, "Family"
                    },
                    {
                        new Guid("2c05b59b-8fb3-4cba-8698-01d55a0284e5"), "Deleniti voluptas quidem accusamus est debitis quisquam enim.", "Kayak",
                        new DateTimeOffset(new DateTime(2020, 11, 4, 16, 6, 44, 784, DateTimeKind.Unspecified).AddTicks(1480),
                            new TimeSpan(0, -3, 0, 0, 0)),
                        "libero", "Three", "focused_neural.mp3", 0.0683409603672507719601089492m, new Guid("815954b2-93b4-4e30-9e30-c2d3a5074f40"),
                        -1864067132, 1918868593, -1181711469, "Diving"
                    },
                    {
                        new Guid("58493329-dbb8-44a9-bfea-0579371d222a"), "Enim aspernatur laborum.", "Kayak",
                        new DateTimeOffset(new DateTime(2021, 5, 2, 1, 22, 43, 66, DateTimeKind.Unspecified).AddTicks(9424),
                            new TimeSpan(0, -3, 0, 0, 0)),
                        "amet", "Three", "copying.png", 0.8148728042354251714332925288m, new Guid("815954b2-93b4-4e30-9e30-c2d3a5074f40"), 1209674041,
                        -962260873, -1801358254, "Camping"
                    },
                    {
                        new Guid("80e2d467-97e3-441f-b706-854dc03f3abc"), "Quibusdam aut provident omnis mollitia accusamus sed iste minima.",
                        "Kayak",
                        new DateTimeOffset(new DateTime(2020, 8, 3, 3, 50, 21, 905, DateTimeKind.Unspecified).AddTicks(4564),
                            new TimeSpan(0, -3, 0, 0, 0)),
                        "vel", "Three", "uganda.mp2", 0.1889454524169042147015520895m, new Guid("815954b2-93b4-4e30-9e30-c2d3a5074f40"), 1065464601,
                        561613094, 2058513890, "Family"
                    },
                    {
                        new Guid("420328ec-d741-4e70-b790-ed90c40e6bc7"), "Nihil tempore recusandae iusto sunt eum laudantium rerum.", "Kayak",
                        new DateTimeOffset(new DateTime(2020, 12, 12, 13, 9, 49, 106, DateTimeKind.Unspecified).AddTicks(2929),
                            new TimeSpan(0, -3, 0, 0, 0)),
                        "fuga", "One", "balanced_handmade_cotton_chips_orchid.wav", 0.1569143055587204359658550854m,
                        new Guid("815954b2-93b4-4e30-9e30-c2d3a5074f40"), 1927418208, -2138511333, -265109205, "Family"
                    },
                    {
                        new Guid("d2c02466-61b7-47c6-874f-9bbc7c218671"), "Id dolores quia esse sunt occaecati molestiae eos commodi.", "Kayak",
                        new DateTimeOffset(new DateTime(2021, 1, 30, 21, 43, 24, 907, DateTimeKind.Unspecified).AddTicks(2917),
                            new TimeSpan(0, -3, 0, 0, 0)),
                        "debitis", "Three", "bandwidth_pink.gif", 0.3103994834884257120203480145m, new Guid("815954b2-93b4-4e30-9e30-c2d3a5074f40"),
                        -809805859, -427706335, 617151944, "Racing"
                    },
                    {
                        new Guid("ccc4e556-f26c-43d3-9d4b-5c106017518a"), "Culpa et ipsum.", "Kayak",
                        new DateTimeOffset(new DateTime(2021, 4, 29, 5, 4, 51, 134, DateTimeKind.Unspecified).AddTicks(1587),
                            new TimeSpan(0, -3, 0, 0, 0)),
                        "delectus", "Three", "white.pdf", 0.2081374304192098983340432957m, new Guid("815954b2-93b4-4e30-9e30-c2d3a5074f40"),
                        1045218399, 469672924, -2119227045, "Family"
                    }
                });

            migrationBuilder.InsertData("Products",
                new[]
                {
                    "Id", "Description", "Discriminator", "IntroduceAt", "Name", "Option", "PhotoFileName", "Price", "ProductTypeId", "Rating",
                    "Stock", "BackpackType"
                },
                new object[,]
                {
                    {
                        new Guid("9cc428ee-e751-4491-a737-d395ef38f669"), "Consequatur nisi velit qui rem et.", "Backpack",
                        new DateTimeOffset(new DateTime(2020, 11, 20, 22, 29, 4, 435, DateTimeKind.Unspecified).AddTicks(9452),
                            new TimeSpan(0, -3, 0, 0, 0)),
                        "voluptas", "Two", "array.mpg4", 0.805731310409395150543069026m, new Guid("b7e06be6-60a4-4bcb-830b-160736d3f806"), 417829900,
                        -547463305, "Overnight"
                    },
                    {
                        new Guid("870ddee1-65ad-4843-b2df-0327d0fa54c6"), "Occaecati et et odio illo aut molestiae ea magni quod.", "Backpack",
                        new DateTimeOffset(new DateTime(2021, 5, 27, 22, 21, 49, 238, DateTimeKind.Unspecified).AddTicks(6067),
                            new TimeSpan(0, -3, 0, 0, 0)),
                        "nam", "Three", "capacitor.html", 0.5867061265606466947919191587m, new Guid("b7e06be6-60a4-4bcb-830b-160736d3f806"),
                        -939907543, 747120937, "DayPack"
                    },
                    {
                        new Guid("3020569d-2be5-4442-a779-5e97a1740de6"), "Qui delectus totam earum suscipit.", "Backpack",
                        new DateTimeOffset(new DateTime(2020, 10, 10, 20, 0, 3, 553, DateTimeKind.Unspecified).AddTicks(6994),
                            new TimeSpan(0, -3, 0, 0, 0)),
                        "est", "Two", "wireless_latvia.wav", 0.3007829675821408120913286988m, new Guid("b7e06be6-60a4-4bcb-830b-160736d3f806"),
                        1052748516, -121301066, "Cycling"
                    },
                    {
                        new Guid("5fc8e291-4d46-4c8b-a4a1-d1a77c9416a5"), "Vitae magni laudantium beatae.", "Backpack",
                        new DateTimeOffset(new DateTime(2021, 3, 13, 2, 26, 18, 282, DateTimeKind.Unspecified).AddTicks(1265),
                            new TimeSpan(0, -3, 0, 0, 0)),
                        "quo", "Three", "mindshare_http.png", 0.1224779395182611014971816429m, new Guid("b7e06be6-60a4-4bcb-830b-160736d3f806"),
                        1761527068, 163117207, "Climbing"
                    }
                });

            migrationBuilder.InsertData("Products",
                new[]
                {
                    "Id", "Description", "Discriminator", "IntroduceAt", "Name", "Option", "PhotoFileName", "Price", "ProductTypeId", "Rating",
                    "Stock", "AmountOfPerson", "KayakType"
                },
                new object[,]
                {
                    {
                        new Guid("7588bc9b-c666-4a6a-9fee-a0529141dba5"), "Non ipsam veritatis ipsum animi ab quo quia omnis qui.", "Kayak",
                        new DateTimeOffset(new DateTime(2021, 2, 12, 19, 52, 33, 984, DateTimeKind.Unspecified).AddTicks(9536),
                            new TimeSpan(0, -3, 0, 0, 0)),
                        "inventore", "Two", "strategist_haptic_complexity.jpe", 0.5931622725976657329548495888m,
                        new Guid("815954b2-93b4-4e30-9e30-c2d3a5074f40"), 580070474, -1795151752, 2127981441, "Racing"
                    },
                    {
                        new Guid("468a7997-8f90-4c86-95f0-c2326491caee"), "Sunt quo nulla similique ut iste aut.", "Kayak",
                        new DateTimeOffset(new DateTime(2021, 6, 6, 1, 16, 35, 51, DateTimeKind.Unspecified).AddTicks(8872),
                            new TimeSpan(0, -3, 0, 0, 0)),
                        "quo", "Three", "background_scalable_transmit.mpg4", 0.1771523967890245337412355306m,
                        new Guid("815954b2-93b4-4e30-9e30-c2d3a5074f40"), -1785280163, 193559004, -1692664358, "Family"
                    },
                    {
                        new Guid("47936001-bc70-4353-a72a-915c1895bef8"), "Quibusdam et animi.", "Kayak",
                        new DateTimeOffset(new DateTime(2020, 10, 20, 7, 49, 44, 976, DateTimeKind.Unspecified).AddTicks(1460),
                            new TimeSpan(0, -3, 0, 0, 0)),
                        "maiores", "Two", "credit_card_account_money_market_account.gif", 0.4312770143238726008739507009m,
                        new Guid("815954b2-93b4-4e30-9e30-c2d3a5074f40"), 1613111836, 1583438951, -1962795588, "Fishing"
                    },
                    {
                        new Guid("b1be7cd7-1cd3-40fa-baa2-cfb30f19b2ef"), "Dolorem cum perspiciatis et eos ipsum et.", "Kayak",
                        new DateTimeOffset(new DateTime(2020, 8, 25, 21, 1, 53, 329, DateTimeKind.Unspecified).AddTicks(5271),
                            new TimeSpan(0, -3, 0, 0, 0)),
                        "beatae", "One", "applications.png", 0.089373685453496465931671455m, new Guid("815954b2-93b4-4e30-9e30-c2d3a5074f40"),
                        -1231283889, -1016863508, 1231631390, "Family"
                    }
                });

            migrationBuilder.InsertData("Products",
                new[]
                {
                    "Id", "Description", "Discriminator", "IntroduceAt", "Name", "Option", "PhotoFileName", "Price", "ProductTypeId", "Rating",
                    "Stock", "BootType", "Size"
                },
                new object[,]
                {
                    {
                        new Guid("3ad49212-7a1f-4868-b259-ce9a25f0f5f4"), "A nemo odit dolorem qui aut illum iste blanditiis minus.", "Boot",
                        new DateTimeOffset(new DateTime(2021, 2, 17, 15, 25, 0, 324, DateTimeKind.Unspecified).AddTicks(401),
                            new TimeSpan(0, -3, 0, 0, 0)),
                        "eius", "Three", "light_small_fresh_chicken_communications.jpe", 0.3953095647450832685464935435m,
                        new Guid("815954b2-93b4-4e30-9e30-c2d3a5074f40"), -373003139, 2020498167, "Chelsea", -1560753026
                    },
                    {
                        new Guid("7db64887-7947-4574-bddf-e815a4558c89"), "Rerum magnam tempora quia minima officiis blanditiis.", "Boot",
                        new DateTimeOffset(new DateTime(2020, 10, 27, 18, 29, 52, 519, DateTimeKind.Unspecified).AddTicks(8542),
                            new TimeSpan(0, -3, 0, 0, 0)),
                        "illum", "Three", "coves_optimization_credit_card_account.gif", 0.8753436224232801417491696025m,
                        new Guid("815954b2-93b4-4e30-9e30-c2d3a5074f40"), -633747374, 1816056496, "Chelsea", -483403543
                    },
                    {
                        new Guid("963bf001-b8d5-4db6-a3c5-097ffe709bcd"), "Nihil tempora pariatur.", "Boot",
                        new DateTimeOffset(new DateTime(2020, 12, 14, 7, 8, 11, 956, DateTimeKind.Unspecified).AddTicks(7261),
                            new TimeSpan(0, -3, 0, 0, 0)),
                        "aut", "One", "enterprise_wide_transition_adp.gif", 0.4889210799302349187207790048m,
                        new Guid("815954b2-93b4-4e30-9e30-c2d3a5074f40"), 661697511, 1668447432, "Cowboy", -319681229
                    },
                    {
                        new Guid("accf45d7-9dfa-4a47-8a2e-3280ea53ac1e"), "Omnis nesciunt veniam voluptatem adipisci tempora deleniti molestiae.",
                        "Boot",
                        new DateTimeOffset(new DateTime(2021, 2, 1, 14, 13, 34, 926, DateTimeKind.Unspecified).AddTicks(6196),
                            new TimeSpan(0, -3, 0, 0, 0)),
                        "rerum", "One", "puerto_rico.jpg", 0.2672254405367814205406479135m, new Guid("815954b2-93b4-4e30-9e30-c2d3a5074f40"),
                        1226793641, -1053738576, "Cowboy", 1893768481
                    },
                    {
                        new Guid("ac88c83b-f507-408a-b428-c66cf0a0ea7b"), "Voluptatem odit praesentium est soluta maxime qui quia.", "Boot",
                        new DateTimeOffset(new DateTime(2020, 8, 25, 22, 10, 25, 228, DateTimeKind.Unspecified).AddTicks(9148),
                            new TimeSpan(0, -3, 0, 0, 0)),
                        "voluptas", "Three", "azure_bluetooth.gif", 0.823329701934461163194148559m, new Guid("815954b2-93b4-4e30-9e30-c2d3a5074f40"),
                        -1226845796, -769477351, "Cowboy", 1866087496
                    },
                    {
                        new Guid("7f08c64f-b25c-4d45-9a93-a8a728974333"), "Reprehenderit corporis exercitationem quaerat blanditiis debitis quo.",
                        "Boot",
                        new DateTimeOffset(new DateTime(2020, 8, 22, 14, 21, 33, 118, DateTimeKind.Unspecified).AddTicks(8993),
                            new TimeSpan(0, -3, 0, 0, 0)),
                        "ex", "One", "open_system.jpg", 0.7863564004408879802530849493m, new Guid("815954b2-93b4-4e30-9e30-c2d3a5074f40"), -793578508,
                        1761520138, "Football", -436479110
                    },
                    {
                        new Guid("81f1ee35-7b14-41e7-a723-1a7c624f50b5"), "Molestiae est beatae pariatur fuga ratione est.", "Boot",
                        new DateTimeOffset(new DateTime(2021, 2, 20, 11, 52, 59, 353, DateTimeKind.Unspecified).AddTicks(5960),
                            new TimeSpan(0, -3, 0, 0, 0)),
                        "ut", "Two", "customer.mpe", 0.0998117897824655219426820504m, new Guid("815954b2-93b4-4e30-9e30-c2d3a5074f40"), -309620312,
                        606800873, "Engineer", 273085531
                    }
                });

            migrationBuilder.InsertData("Products",
                new[]
                {
                    "Id", "Description", "Discriminator", "IntroduceAt", "Name", "Option", "PhotoFileName", "Price", "ProductTypeId", "Rating",
                    "Stock", "AmountOfPerson", "KayakType"
                },
                new object[,]
                {
                    {
                        new Guid("34b24abd-da31-47c4-bc66-df1498645e3d"), "Praesentium ut aut eveniet dolor non placeat sequi.", "Kayak",
                        new DateTimeOffset(new DateTime(2021, 1, 16, 0, 44, 23, 661, DateTimeKind.Unspecified).AddTicks(9949),
                            new TimeSpan(0, -3, 0, 0, 0)),
                        "atque", "One", "outdoors_&_garden.mp2", 0.5380570507384617282447168083m, new Guid("815954b2-93b4-4e30-9e30-c2d3a5074f40"),
                        1496708420, -253203513, -224012786, "Racing"
                    },
                    {
                        new Guid("e503878c-dbae-4fe3-9db9-0e61bcbe4012"), "Debitis maxime commodi natus quae harum magni eveniet quia suscipit.",
                        "Kayak",
                        new DateTimeOffset(new DateTime(2021, 1, 21, 7, 29, 37, 108, DateTimeKind.Unspecified).AddTicks(9170),
                            new TimeSpan(0, -3, 0, 0, 0)),
                        "nobis", "Two", "engineer_incredible.gif", 0.147924039035111919421330072m, new Guid("815954b2-93b4-4e30-9e30-c2d3a5074f40"),
                        1444926902, -945258728, -754852914, "Diving"
                    },
                    {
                        new Guid("7501b5c5-f02f-4f3a-84e4-dbcaec010ab8"), "Ut nostrum in.", "Kayak",
                        new DateTimeOffset(new DateTime(2021, 5, 15, 13, 54, 44, 370, DateTimeKind.Unspecified).AddTicks(9286),
                            new TimeSpan(0, -3, 0, 0, 0)),
                        "explicabo", "Two", "monetize_focus_group.jpg", 0.2323808919521099154450620665m,
                        new Guid("815954b2-93b4-4e30-9e30-c2d3a5074f40"), 1695546675, -1550603300, -1845234319, "Camping"
                    },
                    {
                        new Guid("937ad58b-2796-49ae-b43b-28cc74ea23d4"), "Facilis recusandae id doloribus qui dolore quia tempora sed.", "Kayak",
                        new DateTimeOffset(new DateTime(2021, 7, 4, 18, 55, 44, 304, DateTimeKind.Unspecified).AddTicks(8740),
                            new TimeSpan(0, -3, 0, 0, 0)),
                        "necessitatibus", "Two", "wooden_cotton_alabama.m2a", 0.2287082914910064479599396598m,
                        new Guid("815954b2-93b4-4e30-9e30-c2d3a5074f40"), 1693352735, 1270180147, 812531602, "Family"
                    },
                    {
                        new Guid("7581446d-f191-444a-abf8-c7116a21dc05"), "Veniam aspernatur voluptatum adipisci.", "Kayak",
                        new DateTimeOffset(new DateTime(2021, 2, 12, 0, 57, 50, 421, DateTimeKind.Unspecified).AddTicks(4500),
                            new TimeSpan(0, -3, 0, 0, 0)),
                        "non", "One", "program_rustic_metal_pizza_prairie.m1v", 0.0170198377231181630921202924m,
                        new Guid("815954b2-93b4-4e30-9e30-c2d3a5074f40"), -679466786, 12064749, -214804139, "Fishing"
                    },
                    {
                        new Guid("6cf1b685-b3d4-4a11-9e73-70e3486399d2"), "Dolorum iusto quibusdam molestiae.", "Kayak",
                        new DateTimeOffset(new DateTime(2020, 8, 30, 16, 46, 37, 551, DateTimeKind.Unspecified).AddTicks(3477),
                            new TimeSpan(0, -3, 0, 0, 0)),
                        "rerum", "Two", "practical_granite_hat_awesome_program.gif", 0.040144714201421927296765917m,
                        new Guid("815954b2-93b4-4e30-9e30-c2d3a5074f40"), -1127752412, -786759175, -244842366, "Family"
                    },
                    {
                        new Guid("eeb57f79-1319-45f6-a4b0-b3a3c2918245"), "Iusto vel doloribus consequatur vero nesciunt.", "Kayak",
                        new DateTimeOffset(new DateTime(2021, 7, 26, 10, 9, 2, 341, DateTimeKind.Unspecified).AddTicks(5927),
                            new TimeSpan(0, -3, 0, 0, 0)),
                        "velit", "Two", "withdrawal_multi_tasking_cultivate.mp4", 0.2763297074430425124634020766m,
                        new Guid("815954b2-93b4-4e30-9e30-c2d3a5074f40"), -284222065, 761418322, -785778540, "Racing"
                    },
                    {
                        new Guid("65af82e8-27f6-44f3-af4a-029b73f14530"), "Est veniam unde.", "Kayak",
                        new DateTimeOffset(new DateTime(2021, 4, 17, 1, 14, 29, 333, DateTimeKind.Unspecified).AddTicks(4978),
                            new TimeSpan(0, -3, 0, 0, 0)),
                        "debitis", "Two", "payment_payment.m1v", 0.9021107455881482847021374521m, new Guid("815954b2-93b4-4e30-9e30-c2d3a5074f40"),
                        1764562021, 372403795, 1128959420, "Racing"
                    }
                });

            migrationBuilder.InsertData("Products",
                new[]
                {
                    "Id", "Description", "Discriminator", "IntroduceAt", "Name", "Option", "PhotoFileName", "Price", "ProductTypeId", "Rating",
                    "Stock", "BackpackType"
                },
                new object[,]
                {
                    {
                        new Guid("d3c14755-e161-4325-9509-add643864e95"), "Sit aut excepturi aut sit eum doloribus.", "Backpack",
                        new DateTimeOffset(new DateTime(2021, 2, 6, 11, 49, 25, 151, DateTimeKind.Unspecified).AddTicks(6119),
                            new TimeSpan(0, -3, 0, 0, 0)),
                        "omnis", "Two", "24_7_feed_generating.mp2a", 0.2914973413731705583230969579m,
                        new Guid("b7e06be6-60a4-4bcb-830b-160736d3f806"), -285876816, 566271027, "Overnight"
                    },
                    {
                        new Guid("9dbacce0-c183-4545-a462-1af55ea88932"), "Est autem quo maiores harum iste ab dolores doloribus voluptatum.",
                        "Backpack",
                        new DateTimeOffset(new DateTime(2021, 1, 24, 2, 1, 34, 872, DateTimeKind.Unspecified).AddTicks(8370),
                            new TimeSpan(0, -3, 0, 0, 0)),
                        "assumenda", "Three", "assurance_e_enable_connect.gif", 0.6201540322895184132582351111m,
                        new Guid("b7e06be6-60a4-4bcb-830b-160736d3f806"), -171883210, -918030404, "DayPack"
                    },
                    {
                        new Guid("18a5e72b-49c6-47e7-9f72-1ee0a3205c00"), "Et omnis non corporis nobis doloribus ea.", "Backpack",
                        new DateTimeOffset(new DateTime(2021, 7, 26, 18, 31, 40, 412, DateTimeKind.Unspecified).AddTicks(9234),
                            new TimeSpan(0, -3, 0, 0, 0)),
                        "quos", "Three", "fresh_web_enabled_unbranded.gif", 0.3021549138082857100520235949m,
                        new Guid("b7e06be6-60a4-4bcb-830b-160736d3f806"), -955887104, 419591638, "Climbing"
                    },
                    {
                        new Guid("a9966c74-f188-4d55-b33e-a3aca71ca319"), "Nisi mollitia quia temporibus sit quo dolorum officiis facere vel.",
                        "Backpack",
                        new DateTimeOffset(new DateTime(2021, 1, 12, 7, 3, 14, 76, DateTimeKind.Unspecified).AddTicks(9385),
                            new TimeSpan(0, -3, 0, 0, 0)),
                        "soluta", "Three", "money_market_account.jpeg", 0.7852507143342017968260247995m,
                        new Guid("b7e06be6-60a4-4bcb-830b-160736d3f806"), -2140367550, 2029663639, "Cycling"
                    }
                });

            migrationBuilder.InsertData("Products",
                new[]
                {
                    "Id", "Description", "Discriminator", "IntroduceAt", "Name", "Option", "PhotoFileName", "Price", "ProductTypeId", "Rating",
                    "Stock", "AmountOfPerson", "KayakType"
                },
                new object[,]
                {
                    {
                        new Guid("2d0e8ba0-2073-48c6-bab8-3f1820b66c9f"), "Dolores aut praesentium.", "Kayak",
                        new DateTimeOffset(new DateTime(2021, 2, 17, 14, 14, 27, 199, DateTimeKind.Unspecified).AddTicks(623),
                            new TimeSpan(0, -3, 0, 0, 0)),
                        "qui", "Three", "invoice_plum.htm", 0.8332443035925770613623657599m, new Guid("b7e06be6-60a4-4bcb-830b-160736d3f806"),
                        1327607078, -1663767952, -1143798560, "Diving"
                    },
                    {
                        new Guid("7a886c4d-4f91-4abe-8184-6eb49a30115a"), "Aliquid omnis delectus enim est aut natus impedit at earum.", "Kayak",
                        new DateTimeOffset(new DateTime(2021, 4, 15, 15, 45, 49, 321, DateTimeKind.Unspecified).AddTicks(9258),
                            new TimeSpan(0, -3, 0, 0, 0)),
                        "aspernatur", "Two", "integration_coordinator_egyptian_pound.jpeg", 0.7355260631792380494858505917m,
                        new Guid("b7e06be6-60a4-4bcb-830b-160736d3f806"), 709295406, 72717916, -1970983091, "Family"
                    },
                    {
                        new Guid("7cda996b-838f-4c0c-8a45-f0d362c08dc0"), "Unde quis quae aspernatur a animi dolor dolorum quo et.", "Kayak",
                        new DateTimeOffset(new DateTime(2020, 9, 26, 14, 28, 17, 760, DateTimeKind.Unspecified).AddTicks(4470),
                            new TimeSpan(0, -3, 0, 0, 0)),
                        "vero", "Three", "ftp_officer_russian_ruble.jpeg", 0.3950647224190453398657234161m,
                        new Guid("b7e06be6-60a4-4bcb-830b-160736d3f806"), 1108140386, 635198224, 560275642, "Diving"
                    },
                    {
                        new Guid("26a973fe-5c97-49db-89f4-d8e8b9ae66c0"), "Et illo qui laborum iste tenetur magni ipsa maiores.", "Kayak",
                        new DateTimeOffset(new DateTime(2020, 10, 27, 7, 13, 38, 705, DateTimeKind.Unspecified).AddTicks(8835),
                            new TimeSpan(0, -3, 0, 0, 0)),
                        "inventore", "Three", "sri_lanka_cove.m1v", 0.3897068193187782709314684125m, new Guid("b7e06be6-60a4-4bcb-830b-160736d3f806"),
                        366220388, -981278588, -2051193179, "Camping"
                    }
                });

            migrationBuilder.InsertData("Products",
                new[]
                {
                    "Id", "Description", "Discriminator", "IntroduceAt", "Name", "Option", "PhotoFileName", "Price", "ProductTypeId", "Rating",
                    "Stock", "AmountOfPerson", "KayakType"
                },
                new object[,]
                {
                    {
                        new Guid("78cbd578-f842-4f12-88a6-11aca9e518f1"), "Maxime ut maxime perspiciatis ut ipsam natus.", "Kayak",
                        new DateTimeOffset(new DateTime(2020, 10, 28, 7, 12, 28, 395, DateTimeKind.Unspecified).AddTicks(9980),
                            new TimeSpan(0, -3, 0, 0, 0)),
                        "facere", "Three", "web_programming.pdf", 0.0823496739625262422847264467m, new Guid("b7e06be6-60a4-4bcb-830b-160736d3f806"),
                        137144513, 1301918562, -929806972, "Fishing"
                    },
                    {
                        new Guid("1959b410-7dd7-4a6b-b78d-ca86a74524ef"), "Voluptatibus et aspernatur fugiat est.", "Kayak",
                        new DateTimeOffset(new DateTime(2020, 11, 10, 21, 29, 18, 34, DateTimeKind.Unspecified).AddTicks(611),
                            new TimeSpan(0, -3, 0, 0, 0)),
                        "voluptas", "Three", "collaborative_systems_games_&_outdoors.shtml", 0.0260611328490658644815231439m,
                        new Guid("b7e06be6-60a4-4bcb-830b-160736d3f806"), 1613459758, 1913832931, 1659394302, "Camping"
                    },
                    {
                        new Guid("d697517c-98c6-456b-9b55-bdb6e43a8cf5"), "Aut voluptatem nisi alias qui.", "Kayak",
                        new DateTimeOffset(new DateTime(2021, 1, 26, 6, 14, 42, 424, DateTimeKind.Unspecified).AddTicks(5265),
                            new TimeSpan(0, -3, 0, 0, 0)),
                        "dolorem", "One", "grow.mpg", 0.00169570714242787665960381m, new Guid("b7e06be6-60a4-4bcb-830b-160736d3f806"), 166667752,
                        35653769, -587220263, "Family"
                    },
                    {
                        new Guid("b4f5db19-645b-49e9-aa72-50d72275a650"), "Dignissimos illum quae.", "Kayak",
                        new DateTimeOffset(new DateTime(2021, 7, 24, 12, 25, 35, 679, DateTimeKind.Unspecified).AddTicks(7134),
                            new TimeSpan(0, -3, 0, 0, 0)),
                        "et", "One", "secured_product.m2v", 0.9040184666245619438437376309m, new Guid("b7e06be6-60a4-4bcb-830b-160736d3f806"),
                        -392784745, -212510540, 557856058, "Family"
                    },
                    {
                        new Guid("2f7b033c-f279-4f82-b9ea-43ca405074d9"), "Atque recusandae natus quia vero.", "Kayak",
                        new DateTimeOffset(new DateTime(2020, 9, 22, 8, 57, 33, 959, DateTimeKind.Unspecified).AddTicks(4879),
                            new TimeSpan(0, -3, 0, 0, 0)),
                        "similique", "Two", "jewelery__electronics_&_toys_bricks_and_clicks_beauty__computers_&_jewelery.mp4v",
                        0.6173544423926818371749368141m, new Guid("b7e06be6-60a4-4bcb-830b-160736d3f806"), -1875730459, 1511888505, -1715834157,
                        "Camping"
                    },
                    {
                        new Guid("f94887b9-b361-43c5-993e-c813f1da65f1"),
                        "Libero adipisci aut ea vitae eaque asperiores voluptate excepturi aspernatur.", "Kayak",
                        new DateTimeOffset(new DateTime(2021, 5, 27, 17, 42, 43, 549, DateTimeKind.Unspecified).AddTicks(8652),
                            new TimeSpan(0, -3, 0, 0, 0)),
                        "quia", "Three", "manager_product.gif", 0.2488905281693736930337196107m, new Guid("b7e06be6-60a4-4bcb-830b-160736d3f806"),
                        -1088836768, -1316793636, -1241978338, "Diving"
                    },
                    {
                        new Guid("067f119f-7483-4d72-aed5-2c6c2fc223bc"), "Et quas provident nemo qui libero recusandae.", "Kayak",
                        new DateTimeOffset(new DateTime(2021, 5, 18, 8, 4, 44, 913, DateTimeKind.Unspecified).AddTicks(5205),
                            new TimeSpan(0, -3, 0, 0, 0)),
                        "molestias", "One", "home_loan_account_com_copy.pdf", 0.4316541080039625133505840214m,
                        new Guid("b7e06be6-60a4-4bcb-830b-160736d3f806"), 400581836, -1544953230, -1799529560, "Family"
                    },
                    {
                        new Guid("aabc40e3-c0f5-4ca5-a727-99e70a944117"),
                        "Iure voluptatem alias dicta laudantium quod unde eum tempore necessitatibus.", "Kayak",
                        new DateTimeOffset(new DateTime(2020, 11, 27, 1, 9, 18, 884, DateTimeKind.Unspecified).AddTicks(7380),
                            new TimeSpan(0, -3, 0, 0, 0)),
                        "nulla", "One", "concrete.jpg", 0.1367542966043783972279005119m, new Guid("b7e06be6-60a4-4bcb-830b-160736d3f806"), 1329206501,
                        1018267976, -880232562, "Family"
                    },
                    {
                        new Guid("4cd09b1d-37ba-44e7-8daa-35e457f92546"), "Voluptas sint sunt ea et dolor sit dolorum.", "Kayak",
                        new DateTimeOffset(new DateTime(2020, 11, 15, 15, 26, 10, 79, DateTimeKind.Unspecified).AddTicks(8733),
                            new TimeSpan(0, -3, 0, 0, 0)),
                        "velit", "Three", "balanced_cape_intranet.gif", 0.5307557022824415931784704151m,
                        new Guid("b7e06be6-60a4-4bcb-830b-160736d3f806"), 875352586, 46539286, -364643613, "Family"
                    },
                    {
                        new Guid("65344f10-b8e7-40b0-9751-1b44e189d4f2"), "Voluptatibus dolor quidem voluptas modi quia et aut ut.", "Kayak",
                        new DateTimeOffset(new DateTime(2021, 1, 31, 20, 58, 11, 148, DateTimeKind.Unspecified).AddTicks(1581),
                            new TimeSpan(0, -3, 0, 0, 0)),
                        "incidunt", "Three", "investment_account_engage.mp4", 0.0974629020548714511830649633m,
                        new Guid("b7e06be6-60a4-4bcb-830b-160736d3f806"), 362600992, -923396809, 837835994, "Camping"
                    },
                    {
                        new Guid("ee3c878e-2dde-4ff5-b005-3fc1c9f61d3c"), "A voluptate eligendi quae.", "Kayak",
                        new DateTimeOffset(new DateTime(2020, 12, 24, 13, 41, 42, 925, DateTimeKind.Unspecified).AddTicks(1241),
                            new TimeSpan(0, -3, 0, 0, 0)),
                        "qui", "Three", "connecting.gif", 0.6298231094405011058412803268m, new Guid("b7e06be6-60a4-4bcb-830b-160736d3f806"),
                        -365564294, 385063832, -1487121181, "Family"
                    }
                });

            migrationBuilder.InsertData("Products",
                new[]
                {
                    "Id", "Description", "Discriminator", "IntroduceAt", "Name", "Option", "PhotoFileName", "Price", "ProductTypeId", "Rating",
                    "Stock", "BootType", "Size"
                },
                new object[,]
                {
                    {
                        new Guid("d0496cd0-03dc-463c-8464-b1da9637ebab"), "Similique vel aspernatur.", "Boot",
                        new DateTimeOffset(new DateTime(2020, 8, 11, 0, 34, 17, 503, DateTimeKind.Unspecified).AddTicks(6923),
                            new TimeSpan(0, -3, 0, 0, 0)),
                        "molestias", "One", "books__home_&_baby_reboot_home_loan_account.jpeg", 0.6283779686743236279492588681m,
                        new Guid("b7e06be6-60a4-4bcb-830b-160736d3f806"), -1364914195, -1459044759, "Harness", 1476240976
                    },
                    {
                        new Guid("919a2623-dd26-4ef4-ab1b-8bcba666aa63"), "Quasi eum hic eaque alias porro.", "Boot",
                        new DateTimeOffset(new DateTime(2020, 9, 18, 0, 3, 45, 435, DateTimeKind.Unspecified).AddTicks(6490),
                            new TimeSpan(0, -3, 0, 0, 0)),
                        "sint", "One", "hierarchy_new_hampshire.mpg", 0.8155428191039471735176289475m,
                        new Guid("815954b2-93b4-4e30-9e30-c2d3a5074f40"), -844021217, 1398470410, "Harness", 2122968033
                    },
                    {
                        new Guid("b430c451-8c60-4245-bbeb-e18bfb0921a9"), "Distinctio distinctio ipsa.", "Boot",
                        new DateTimeOffset(new DateTime(2020, 11, 5, 23, 40, 47, 897, DateTimeKind.Unspecified).AddTicks(5058),
                            new TimeSpan(0, -3, 0, 0, 0)),
                        "commodi", "Three", "azure.gif", 0.37243783521449139812700042m, new Guid("b7e06be6-60a4-4bcb-830b-160736d3f806"), 961607046,
                        -228161800, "Engineer", 1450101984
                    },
                    {
                        new Guid("529589e4-9746-4de6-b1ba-600f8d740ed4"), "Nihil praesentium quod qui ullam in illo.", "Boot",
                        new DateTimeOffset(new DateTime(2020, 11, 8, 12, 48, 37, 972, DateTimeKind.Unspecified).AddTicks(6508),
                            new TimeSpan(0, -3, 0, 0, 0)),
                        "fugiat", "Three", "islands.gif", 0.690320528687447373591483399m, new Guid("b7e06be6-60a4-4bcb-830b-160736d3f806"),
                        -513598176, -264130876, "Football", -346277146
                    }
                });

            migrationBuilder.InsertData("Products",
                new[]
                {
                    "Id", "Description", "Discriminator", "IntroduceAt", "Name", "Option", "PhotoFileName", "Price", "ProductTypeId", "Rating",
                    "Stock", "BackpackType"
                },
                new object[,]
                {
                    {
                        new Guid("b5de4d13-daa3-4f75-87eb-69a5e0c33046"), "Natus autem sed et ipsam et.", "Backpack",
                        new DateTimeOffset(new DateTime(2021, 7, 6, 22, 44, 11, 36, DateTimeKind.Unspecified).AddTicks(9071),
                            new TimeSpan(0, -3, 0, 0, 0)),
                        "sit", "Three", "teal_transmitting_practical_plastic_table.gif", 0.1068484521939120683314920908m,
                        new Guid("b7e06be6-60a4-4bcb-830b-160736d3f806"), 1962929980, 306295959, "Climbing"
                    },
                    {
                        new Guid("b51af9f9-4bd1-40cc-8f8b-f0c9751e9e16"), "Ducimus non consequatur amet voluptas est voluptatem dolor laboriosam.",
                        "Backpack",
                        new DateTimeOffset(new DateTime(2021, 1, 31, 1, 23, 0, 695, DateTimeKind.Unspecified).AddTicks(4913),
                            new TimeSpan(0, -3, 0, 0, 0)),
                        "et", "One", "transmitting.mpeg", 0.4788861717470013144117491847m, new Guid("b7e06be6-60a4-4bcb-830b-160736d3f806"),
                        -1948388119, 1550951268, "Hiking"
                    }
                });

            migrationBuilder.InsertData("Products",
                new[]
                {
                    "Id", "Description", "Discriminator", "IntroduceAt", "Name", "Option", "PhotoFileName", "Price", "ProductTypeId", "Rating",
                    "Stock", "BootType", "Size"
                },
                new object[,]
                {
                    {
                        new Guid("6c864210-d0f8-4d30-b6e7-31b1790f5af4"), "Eaque atque earum molestias veritatis.", "Boot",
                        new DateTimeOffset(new DateTime(2021, 4, 17, 17, 0, 50, 879, DateTimeKind.Unspecified).AddTicks(7497),
                            new TimeSpan(0, -3, 0, 0, 0)),
                        "unde", "One", "canyon_incredible_granite_salad.m2v", 0.3819959838413905571539356937m,
                        new Guid("b7e06be6-60a4-4bcb-830b-160736d3f806"), -289804409, 1281420914, "Drysuit", 1962373436
                    },
                    {
                        new Guid("f3902b80-4572-471d-b81e-7bafed25b7a6"), "Dolorem ipsum et reprehenderit nam pariatur cum qui provident id.", "Boot",
                        new DateTimeOffset(new DateTime(2021, 6, 14, 16, 55, 21, 481, DateTimeKind.Unspecified).AddTicks(6042),
                            new TimeSpan(0, -3, 0, 0, 0)),
                        "iure", "Two", "forges.mpeg", 0.8710672135111785549982616194m, new Guid("b7e06be6-60a4-4bcb-830b-160736d3f806"), 579765985,
                        2056478316, "Harness", -1984756227
                    },
                    {
                        new Guid("49055f57-c03b-463b-8013-3d4cf3be404c"), "Nihil ut laudantium dolorem ipsa.", "Boot",
                        new DateTimeOffset(new DateTime(2021, 4, 16, 13, 41, 5, 358, DateTimeKind.Unspecified).AddTicks(9568),
                            new TimeSpan(0, -3, 0, 0, 0)),
                        "quia", "Three", "orchestrate_generate_credit_card_account.mpg4", 0.0408924509562494267169895841m,
                        new Guid("b7e06be6-60a4-4bcb-830b-160736d3f806"), -2036390279, 1861141424, "Chelsea", 646016143
                    },
                    {
                        new Guid("fb48d460-86e5-4612-acd1-2a59d415a449"), "Animi quis consectetur possimus adipisci modi natus dolores aut.", "Boot",
                        new DateTimeOffset(new DateTime(2021, 3, 9, 9, 16, 32, 225, DateTimeKind.Unspecified).AddTicks(2592),
                            new TimeSpan(0, -3, 0, 0, 0)),
                        "labore", "One", "licensed.m2v", 0.2551535101489137649236788836m, new Guid("b7e06be6-60a4-4bcb-830b-160736d3f806"), 503742235,
                        -1439658454, "Engineer", 1851868132
                    },
                    {
                        new Guid("3646e095-837a-471e-ad57-7a3f1b92eb56"),
                        "Laborum tempora itaque ea consequuntur corrupti illum assumenda sunt officia.", "Boot",
                        new DateTimeOffset(new DateTime(2021, 1, 5, 1, 23, 30, 225, DateTimeKind.Unspecified).AddTicks(7970),
                            new TimeSpan(0, -3, 0, 0, 0)),
                        "enim", "One", "small.mpeg", 0.6645616698462666722609527626m, new Guid("b7e06be6-60a4-4bcb-830b-160736d3f806"), 41768480,
                        404818629, "Chelsea", -1150674576
                    },
                    {
                        new Guid("72a3b76c-389a-4957-942a-0f65e8ae4117"), "Modi magni facere.", "Boot",
                        new DateTimeOffset(new DateTime(2021, 3, 28, 22, 26, 31, 216, DateTimeKind.Unspecified).AddTicks(5946),
                            new TimeSpan(0, -3, 0, 0, 0)),
                        "alias", "Three", "optimized.gif", 0.1629283203058939335425262976m, new Guid("b7e06be6-60a4-4bcb-830b-160736d3f806"),
                        969657887, 2142835925, "Drysuit", -553713764
                    },
                    {
                        new Guid("75fc6060-805a-4fbb-bebb-df473742e907"), "In est reiciendis architecto eos ratione possimus sint.", "Boot",
                        new DateTimeOffset(new DateTime(2021, 1, 29, 8, 26, 54, 334, DateTimeKind.Unspecified).AddTicks(9849),
                            new TimeSpan(0, -3, 0, 0, 0)),
                        "rerum", "Three", "navigate.shtml", 0.6698224148618680292723176144m, new Guid("b7e06be6-60a4-4bcb-830b-160736d3f806"),
                        -886311217, -1003590575, "Cowboy", -427894925
                    },
                    {
                        new Guid("d8d9c768-d8d7-4be3-9e5d-7c3c981a3c4c"), "Et voluptatem animi aliquam ipsum veritatis necessitatibus atque.", "Boot",
                        new DateTimeOffset(new DateTime(2020, 8, 28, 19, 59, 11, 117, DateTimeKind.Unspecified).AddTicks(4908),
                            new TimeSpan(0, -3, 0, 0, 0)),
                        "eos", "One", "practical_rubber_tuna.pdf", 0.3184088099253520886878684929m, new Guid("b7e06be6-60a4-4bcb-830b-160736d3f806"),
                        -1188237506, -771812510, "Chelsea", -341227399
                    },
                    {
                        new Guid("843b594f-53e8-4301-9d07-f850ef29c345"), "Quo ut ea molestiae.", "Boot",
                        new DateTimeOffset(new DateTime(2020, 8, 8, 9, 2, 21, 799, DateTimeKind.Unspecified).AddTicks(1554),
                            new TimeSpan(0, -3, 0, 0, 0)),
                        "dolor", "One", "enable_loaf_chief.gif", 0.5379909280746160685322260205m, new Guid("b7e06be6-60a4-4bcb-830b-160736d3f806"),
                        -1463810588, -1830220162, "Harness", 1171460706
                    },
                    {
                        new Guid("74f01638-fcd2-4450-a107-4664472f0cda"), "Quia facere dolorem esse quod itaque quas iure.", "Boot",
                        new DateTimeOffset(new DateTime(2020, 8, 11, 8, 14, 58, 507, DateTimeKind.Unspecified).AddTicks(6625),
                            new TimeSpan(0, -3, 0, 0, 0)),
                        "dolorum", "Two", "interactive.png", 0.0130505117635600804763010467m, new Guid("b7e06be6-60a4-4bcb-830b-160736d3f806"),
                        -1143306726, -781100725, "Cowboy", -1409854471
                    },
                    {
                        new Guid("7e43aa4d-8300-42d2-908e-86d56c43eb02"), "Occaecati commodi ipsum sint et unde id porro ullam.", "Boot",
                        new DateTimeOffset(new DateTime(2021, 6, 7, 2, 14, 31, 382, DateTimeKind.Unspecified).AddTicks(5983),
                            new TimeSpan(0, -3, 0, 0, 0)),
                        "et", "One", "human_sleek_fresh_keyboard.mp4", 0.7522110906778148752784400732m,
                        new Guid("b7e06be6-60a4-4bcb-830b-160736d3f806"), 1504104500, -1331032687, "Football", 1487488874
                    },
                    {
                        new Guid("1d7c2d29-06ad-484b-8008-53ddf6cb471e"), "Quod velit provident sed tempore commodi temporibus.", "Boot",
                        new DateTimeOffset(new DateTime(2021, 6, 21, 12, 12, 31, 109, DateTimeKind.Unspecified).AddTicks(8839),
                            new TimeSpan(0, -3, 0, 0, 0)),
                        "repudiandae", "One", "paradigm_card.jpg", 0.659704841218468550220881082m, new Guid("b7e06be6-60a4-4bcb-830b-160736d3f806"),
                        -1505453786, -2089068084, "Cowboy", 348704708
                    },
                    {
                        new Guid("16d816a2-61ac-4360-9270-49cbc50a73c1"), "Tempora modi ut eligendi qui nisi.", "Boot",
                        new DateTimeOffset(new DateTime(2020, 8, 30, 9, 5, 54, 520, DateTimeKind.Unspecified).AddTicks(2534),
                            new TimeSpan(0, -3, 0, 0, 0)),
                        "dicta", "Two", "designer_scalable_colombia.png", 0.5481518424290541967023572565m,
                        new Guid("b7e06be6-60a4-4bcb-830b-160736d3f806"), 1029778501, -927431327, "Chelsea", 484458540
                    },
                    {
                        new Guid("79a67c64-3d3c-4c56-a817-541103bf2d62"), "Quis ipsum officiis accusantium expedita eos quasi beatae distinctio.",
                        "Boot",
                        new DateTimeOffset(new DateTime(2020, 10, 9, 10, 29, 17, 61, DateTimeKind.Unspecified).AddTicks(6818),
                            new TimeSpan(0, -3, 0, 0, 0)),
                        "suscipit", "One", "practical_fresh_soap_partnerships.mpg", 0.4067717394710307365299575509m,
                        new Guid("b7e06be6-60a4-4bcb-830b-160736d3f806"), -368420525, -413522130, "Engineer", -385647993
                    },
                    {
                        new Guid("f34c7adc-c3c8-4c3f-a475-41a6a3e82904"), "Veniam quia dolores saepe laudantium occaecati.", "Boot",
                        new DateTimeOffset(new DateTime(2021, 3, 4, 22, 40, 41, 221, DateTimeKind.Unspecified).AddTicks(9748),
                            new TimeSpan(0, -3, 0, 0, 0)),
                        "esse", "Three", "games__home_&_tools.pdf", 0.4286576119428487911526725166m, new Guid("815954b2-93b4-4e30-9e30-c2d3a5074f40"),
                        1588815485, -1597593213, "Chelsea", 433144593
                    },
                    {
                        new Guid("510d94ff-80c0-4895-814c-fa41e1b97a5d"), "Quidem eum ut nobis.", "Boot",
                        new DateTimeOffset(new DateTime(2021, 5, 11, 10, 24, 57, 238, DateTimeKind.Unspecified).AddTicks(372),
                            new TimeSpan(0, -3, 0, 0, 0)),
                        "sit", "Three", "ib.pdf", 0.7332541910231422450065177546m, new Guid("815954b2-93b4-4e30-9e30-c2d3a5074f40"), 2026207803,
                        861312765, "Football", -2140813549
                    },
                    {
                        new Guid("93c26021-c409-4bbe-81a9-02d55aba452b"), "Debitis aperiam aut officiis error excepturi nostrum dolorem.", "Boot",
                        new DateTimeOffset(new DateTime(2021, 2, 24, 19, 0, 28, 480, DateTimeKind.Unspecified).AddTicks(5262),
                            new TimeSpan(0, -3, 0, 0, 0)),
                        "sint", "Two", "aruba_outdoors__grocery_&_computers.html", 0.3502597026261455223026602683m,
                        new Guid("815954b2-93b4-4e30-9e30-c2d3a5074f40"), -605422765, -484425594, "Chelsea", 1940199611
                    },
                    {
                        new Guid("ab59d3ee-199e-4385-8d65-6ac971ed67a0"), "Nihil vero dolores.", "Boot",
                        new DateTimeOffset(new DateTime(2020, 10, 10, 17, 9, 12, 243, DateTimeKind.Unspecified).AddTicks(505),
                            new TimeSpan(0, -3, 0, 0, 0)),
                        "aspernatur", "Two", "program_compressing.jpg", 0.6619496377903954615703699913m,
                        new Guid("b80d9a45-67b7-4184-a27e-768e73920b1c"), 1334341297, -1992305173, "Cowboy", 768653876
                    },
                    {
                        new Guid("34c08f0a-3079-434d-8834-13f8fd8f8c94"), "Fuga optio magni nihil et.", "Boot",
                        new DateTimeOffset(new DateTime(2021, 3, 3, 17, 9, 4, 47, DateTimeKind.Unspecified).AddTicks(717),
                            new TimeSpan(0, -3, 0, 0, 0)),
                        "dolorem", "One", "sleek_steel_gloves_auto_loan_account.html", 0.2331295696533624385064129702m,
                        new Guid("b80d9a45-67b7-4184-a27e-768e73920b1c"), -1547374434, -508562143, "Engineer", 158830887
                    },
                    {
                        new Guid("4e46adae-19f7-4542-ab8f-42a41b2be986"), "Occaecati molestiae omnis modi rerum quam rerum aut.", "Boot",
                        new DateTimeOffset(new DateTime(2020, 9, 21, 9, 27, 56, 787, DateTimeKind.Unspecified).AddTicks(6815),
                            new TimeSpan(0, -3, 0, 0, 0)),
                        "rem", "Three", "grid_enabled_intranet_automotive_&_beauty.gif", 0.3500349991850909345065888283m,
                        new Guid("b80d9a45-67b7-4184-a27e-768e73920b1c"), 876818966, -79745040, "Cowboy", 1228996003
                    },
                    {
                        new Guid("5b1da6c5-3c74-429c-b9da-473e1d776ed1"), "Quis nostrum voluptas voluptas sunt placeat.", "Boot",
                        new DateTimeOffset(new DateTime(2021, 7, 19, 5, 3, 52, 537, DateTimeKind.Unspecified).AddTicks(6403),
                            new TimeSpan(0, -3, 0, 0, 0)),
                        "quibusdam", "One", "navigate_handmade_tasty.jpe", 0.7830323072662879830477123483m,
                        new Guid("b80d9a45-67b7-4184-a27e-768e73920b1c"), 1424743708, -313470883, "Harness", 1823266886
                    },
                    {
                        new Guid("96b92eea-9c1f-4bc6-b4aa-f1af08e2c33c"), "Voluptas consequatur sequi.", "Boot",
                        new DateTimeOffset(new DateTime(2021, 4, 8, 1, 56, 29, 905, DateTimeKind.Unspecified).AddTicks(4083),
                            new TimeSpan(0, -3, 0, 0, 0)),
                        "voluptas", "One", "integrate_tasty_rubber_chicken.m2v", 0.9610780999768154765940303023m,
                        new Guid("b80d9a45-67b7-4184-a27e-768e73920b1c"), -2087988728, 1531149367, "Engineer", 1583726617
                    },
                    {
                        new Guid("d8af8bf8-efcc-4e6f-8753-19a0c7c15320"),
                        "Ut voluptatibus fuga facilis necessitatibus rerum beatae atque doloribus vitae.", "Boot",
                        new DateTimeOffset(new DateTime(2021, 1, 14, 20, 14, 53, 167, DateTimeKind.Unspecified).AddTicks(6576),
                            new TimeSpan(0, -3, 0, 0, 0)),
                        "vel", "Two", "uniform.gif", 0.2388961368651812802344540388m, new Guid("b80d9a45-67b7-4184-a27e-768e73920b1c"), 496709100,
                        -1255397815, "Chelsea", 1429984809
                    },
                    {
                        new Guid("cce9c9c7-6d95-4b34-a525-ed588e755a2b"), "Aut non saepe quasi omnis eum mollitia quia.", "Boot",
                        new DateTimeOffset(new DateTime(2020, 12, 2, 15, 40, 18, 799, DateTimeKind.Unspecified).AddTicks(8471),
                            new TimeSpan(0, -3, 0, 0, 0)),
                        "est", "Two", "zero_administration.wav", 0.7072945934418315183720794821m, new Guid("b80d9a45-67b7-4184-a27e-768e73920b1c"),
                        -1582999711, -2137383924, "Football", 1776324680
                    },
                    {
                        new Guid("c2f140ad-21f3-4025-8849-38d7ad42aa9b"), "Non non eveniet nobis dolores adipisci maiores et ut iure.", "Boot",
                        new DateTimeOffset(new DateTime(2020, 11, 10, 22, 30, 42, 773, DateTimeKind.Unspecified).AddTicks(5598),
                            new TimeSpan(0, -3, 0, 0, 0)),
                        "similique", "Three", "calculate_berkshire_isle.gif", 0.1903274582411226162641076332m,
                        new Guid("b80d9a45-67b7-4184-a27e-768e73920b1c"), -665429201, -121638407, "Engineer", 435977791
                    }
                });

            migrationBuilder.InsertData("Products",
                new[]
                {
                    "Id", "Description", "Discriminator", "IntroduceAt", "Name", "Option", "PhotoFileName", "Price", "ProductTypeId", "Rating",
                    "Stock", "BootType", "Size"
                },
                new object[,]
                {
                    {
                        new Guid("207647fe-edad-4fb0-bf21-0858f64f3680"), "Maxime hic ea reiciendis reprehenderit animi deserunt porro itaque id.",
                        "Boot",
                        new DateTimeOffset(new DateTime(2020, 9, 26, 5, 31, 13, 229, DateTimeKind.Unspecified).AddTicks(6784),
                            new TimeSpan(0, -3, 0, 0, 0)),
                        "perspiciatis", "Three", "smtp.wav", 0.3600139347184227381213324671m, new Guid("b80d9a45-67b7-4184-a27e-768e73920b1c"),
                        -1816207948, 1951671123, "Drysuit", -972240935
                    },
                    {
                        new Guid("1928a7fa-4e18-40f3-a445-e95b20ee67ea"), "Optio voluptas qui earum nobis tempora.", "Boot",
                        new DateTimeOffset(new DateTime(2021, 5, 7, 20, 55, 53, 566, DateTimeKind.Unspecified).AddTicks(6445),
                            new TimeSpan(0, -3, 0, 0, 0)),
                        "et", "Three", "ireland_grow.mp2", 0.5301714233540021098456819485m, new Guid("b80d9a45-67b7-4184-a27e-768e73920b1c"),
                        989953391, -853340246, "Engineer", 1159050835
                    },
                    {
                        new Guid("65fc03dd-3520-4471-bf9b-3444ec326a57"), "Rerum porro et laboriosam et voluptatem incidunt temporibus.", "Boot",
                        new DateTimeOffset(new DateTime(2020, 10, 16, 4, 20, 44, 541, DateTimeKind.Unspecified).AddTicks(9224),
                            new TimeSpan(0, -3, 0, 0, 0)),
                        "sunt", "One", "jamaica.png", 0.7552890988152548980849567875m, new Guid("b80d9a45-67b7-4184-a27e-768e73920b1c"), -227276124,
                        1044529244, "Football", -1284738506
                    },
                    {
                        new Guid("ace9c148-364c-43dd-81f7-bba250ddd0ab"), "Quidem quidem quidem ut consectetur ut illum aut.", "Boot",
                        new DateTimeOffset(new DateTime(2021, 6, 25, 8, 42, 53, 938, DateTimeKind.Unspecified).AddTicks(1066),
                            new TimeSpan(0, -3, 0, 0, 0)),
                        "et", "Two", "plum_avon_payment.png", 0.097368249350303114434338078m, new Guid("b80d9a45-67b7-4184-a27e-768e73920b1c"),
                        -1775563760, -933384690, "Drysuit", 77102041
                    },
                    {
                        new Guid("de33f547-3b2c-4bcb-bc68-60b436ea62ed"), "Amet fugiat vel enim deserunt quidem.", "Boot",
                        new DateTimeOffset(new DateTime(2021, 4, 23, 20, 50, 20, 652, DateTimeKind.Unspecified).AddTicks(3561),
                            new TimeSpan(0, -3, 0, 0, 0)),
                        "itaque", "Three", "generic.jpeg", 0.4823798341567415521600115935m, new Guid("b80d9a45-67b7-4184-a27e-768e73920b1c"),
                        536091363, 1923035471, "Engineer", 1148614553
                    },
                    {
                        new Guid("84d8a526-e901-456e-9ac2-f3622da47bb3"), "Doloremque nulla voluptas tempore qui quaerat cumque autem nemo sed.",
                        "Boot",
                        new DateTimeOffset(new DateTime(2020, 9, 3, 15, 10, 27, 272, DateTimeKind.Unspecified).AddTicks(8891),
                            new TimeSpan(0, -3, 0, 0, 0)),
                        "temporibus", "One", "transmitting.mpe", 0.8594945024995735019175789658m, new Guid("b80d9a45-67b7-4184-a27e-768e73920b1c"),
                        -1396148310, 472040266, "Chelsea", 504263405
                    }
                });

            migrationBuilder.InsertData("Products",
                new[]
                {
                    "Id", "Description", "Discriminator", "IntroduceAt", "Name", "Option", "PhotoFileName", "Price", "ProductTypeId", "Rating",
                    "Stock", "AmountOfPerson", "KayakType"
                },
                new object[]
                {
                    new Guid("622ab9c1-d816-4b5a-8591-abab46ea2234"), "Provident adipisci cupiditate animi eos quidem.", "Kayak",
                    new DateTimeOffset(new DateTime(2021, 5, 2, 10, 45, 32, 953, DateTimeKind.Unspecified).AddTicks(4851),
                        new TimeSpan(0, -3, 0, 0, 0)),
                    "sed", "Three", "senior_square.wav", 0.3593948220652328947986654897m, new Guid("b80d9a45-67b7-4184-a27e-768e73920b1c"),
                    1829583477, -580453870, -812063578, "Camping"
                });

            migrationBuilder.InsertData("Products",
                new[]
                {
                    "Id", "Description", "Discriminator", "IntroduceAt", "Name", "Option", "PhotoFileName", "Price", "ProductTypeId", "Rating",
                    "Stock", "BackpackType"
                },
                new object[]
                {
                    new Guid("13705ca3-66f0-4081-840c-40b84b1e6730"), "Aut cum tempora ducimus.", "Backpack",
                    new DateTimeOffset(new DateTime(2020, 8, 6, 20, 40, 50, 997, DateTimeKind.Unspecified).AddTicks(2656),
                        new TimeSpan(0, -3, 0, 0, 0)),
                    "et", "One", "licensed_metal_soap.jpe", 0.3793710678855582434860622489m, new Guid("b80d9a45-67b7-4184-a27e-768e73920b1c"),
                    1779456415, -2042332758, "Overnight"
                });

            migrationBuilder.InsertData("Products",
                new[]
                {
                    "Id", "Description", "Discriminator", "IntroduceAt", "Name", "Option", "PhotoFileName", "Price", "ProductTypeId", "Rating",
                    "Stock", "AmountOfPerson", "KayakType"
                },
                new object[]
                {
                    new Guid("72237f7a-8887-4a31-b5ed-fe85ac5885c1"), "Omnis exercitationem sequi.", "Kayak",
                    new DateTimeOffset(new DateTime(2021, 7, 20, 19, 10, 9, 705, DateTimeKind.Unspecified).AddTicks(3091),
                        new TimeSpan(0, -3, 0, 0, 0)),
                    "ut", "Three", "index_factors_bandwidth.gif", 0.0733480821999891794495010655m, new Guid("b80d9a45-67b7-4184-a27e-768e73920b1c"),
                    -1470567878, 173684192, -50455932, "Racing"
                });

            migrationBuilder.InsertData("Products",
                new[]
                {
                    "Id", "Description", "Discriminator", "IntroduceAt", "Name", "Option", "PhotoFileName", "Price", "ProductTypeId", "Rating",
                    "Stock", "BackpackType"
                },
                new object[,]
                {
                    {
                        new Guid("16adb77a-c07a-468b-b974-ee4210fae715"), "Odit expedita deserunt.", "Backpack",
                        new DateTimeOffset(new DateTime(2021, 2, 1, 23, 18, 34, 621, DateTimeKind.Unspecified).AddTicks(8640),
                            new TimeSpan(0, -3, 0, 0, 0)),
                        "libero", "Two", "manager_reinvent_cambridgeshire.png", 0.7555454853296319557085637946m,
                        new Guid("b80d9a45-67b7-4184-a27e-768e73920b1c"), 945154444, 1631688324, "Cycling"
                    },
                    {
                        new Guid("0bd972fa-a6dc-4555-b300-af551a1cb27f"), "Accusantium fuga et.", "Backpack",
                        new DateTimeOffset(new DateTime(2021, 4, 17, 15, 14, 51, 102, DateTimeKind.Unspecified).AddTicks(8452),
                            new TimeSpan(0, -3, 0, 0, 0)),
                        "id", "Three", "mobile.mpe", 0.8531062218356876383296665457m, new Guid("b80d9a45-67b7-4184-a27e-768e73920b1c"), -721185924,
                        -2008109061, "Hiking"
                    },
                    {
                        new Guid("6a8155e2-a0a5-451f-a8f7-94b55e8af5ec"), "Molestiae eaque nihil hic.", "Backpack",
                        new DateTimeOffset(new DateTime(2021, 3, 18, 10, 59, 46, 180, DateTimeKind.Unspecified).AddTicks(7199),
                            new TimeSpan(0, -3, 0, 0, 0)),
                        "quasi", "One", "auxiliary_handmade_cotton_bacon_black.png", 0.8208352940983218875182232299m,
                        new Guid("b80d9a45-67b7-4184-a27e-768e73920b1c"), -514543144, 330686392, "Overnight"
                    },
                    {
                        new Guid("9408d841-b036-426e-b9f5-c691ab4afe5d"), "Quasi eum fuga suscipit voluptatem ea est commodi.", "Backpack",
                        new DateTimeOffset(new DateTime(2021, 6, 7, 3, 42, 17, 556, DateTimeKind.Unspecified).AddTicks(9581),
                            new TimeSpan(0, -3, 0, 0, 0)),
                        "culpa", "Two", "sleek_concrete_bacon_manager.gif", 0.1509859826473898470970483776m,
                        new Guid("b80d9a45-67b7-4184-a27e-768e73920b1c"), -1552732222, 1560080460, "Snowsports"
                    },
                    {
                        new Guid("59f77a64-e564-4951-8480-6fc2203bf915"), "Et earum itaque nemo voluptatem.", "Backpack",
                        new DateTimeOffset(new DateTime(2021, 5, 15, 6, 13, 28, 823, DateTimeKind.Unspecified).AddTicks(9158),
                            new TimeSpan(0, -3, 0, 0, 0)),
                        "consectetur", "Three", "gorgeous_rubber_car.gif", 0.6285268360157395196044437391m,
                        new Guid("b80d9a45-67b7-4184-a27e-768e73920b1c"), 702256751, 1485152133, "Snowsports"
                    },
                    {
                        new Guid("e0547840-310d-4d9a-9a06-43020d0e9abd"), "Impedit unde dolor deleniti placeat.", "Backpack",
                        new DateTimeOffset(new DateTime(2020, 8, 20, 10, 56, 2, 844, DateTimeKind.Unspecified).AddTicks(8934),
                            new TimeSpan(0, -3, 0, 0, 0)),
                        "qui", "One", "monitor_arizona_adp.mpga", 0.8800331927670095952309140666m, new Guid("b80d9a45-67b7-4184-a27e-768e73920b1c"),
                        -782454276, -1913924633, "Hiking"
                    },
                    {
                        new Guid("3027141d-f3d7-4f45-b48b-a5c071054506"), "Vel aut qui quo ex.", "Backpack",
                        new DateTimeOffset(new DateTime(2021, 2, 2, 13, 18, 0, 43, DateTimeKind.Unspecified).AddTicks(7810),
                            new TimeSpan(0, -3, 0, 0, 0)),
                        "et", "Three", "payment_sleek_frozen_fish_myanmar.shtml", 0.6113059149242560620403604429m,
                        new Guid("b80d9a45-67b7-4184-a27e-768e73920b1c"), 218070626, -1980959732, "Cycling"
                    },
                    {
                        new Guid("3b3e4b62-fd3d-4a06-b0a8-bc7d343fe0e8"), "Inventore saepe ut magni.", "Backpack",
                        new DateTimeOffset(new DateTime(2021, 3, 23, 22, 17, 12, 449, DateTimeKind.Unspecified).AddTicks(3589),
                            new TimeSpan(0, -3, 0, 0, 0)),
                        "debitis", "One", "mission_critical.mpg4", 0.6622302614670385191336992427m, new Guid("b80d9a45-67b7-4184-a27e-768e73920b1c"),
                        1758910782, -1030750781, "Hiking"
                    },
                    {
                        new Guid("99fa66f6-41a0-4519-868a-e2fead8cb551"), "Ab suscipit et esse.", "Backpack",
                        new DateTimeOffset(new DateTime(2020, 8, 28, 11, 31, 43, 613, DateTimeKind.Unspecified).AddTicks(1689),
                            new TimeSpan(0, -3, 0, 0, 0)),
                        "magni", "Two", "executive_navigating_program.gif", 0.4981093505958939748705256731m,
                        new Guid("b80d9a45-67b7-4184-a27e-768e73920b1c"), -1340579628, 1836256318, "DayPack"
                    },
                    {
                        new Guid("8b934af2-720f-4cdf-bca2-1ee654d8b46c"), "Atque quia debitis et ratione iure ducimus ex.", "Backpack",
                        new DateTimeOffset(new DateTime(2020, 12, 9, 0, 16, 24, 168, DateTimeKind.Unspecified).AddTicks(9314),
                            new TimeSpan(0, -3, 0, 0, 0)),
                        "qui", "Three", "bond_markets_units_european_composite_unit_(eurco).pdf", 0.4290288836515254352561816583m,
                        new Guid("b80d9a45-67b7-4184-a27e-768e73920b1c"), 475301237, 1094590934, "Cycling"
                    },
                    {
                        new Guid("d8cec59b-31a6-416a-8885-f7dbf46630f4"), "Eos occaecati ea voluptate.", "Backpack",
                        new DateTimeOffset(new DateTime(2020, 8, 11, 22, 3, 43, 762, DateTimeKind.Unspecified).AddTicks(6091),
                            new TimeSpan(0, -3, 0, 0, 0)),
                        "pariatur", "Two", "black_monetize_tasty_steel_chicken.mpga", 0.9165688367498492334936169326m,
                        new Guid("b80d9a45-67b7-4184-a27e-768e73920b1c"), 1449104938, -2055055167, "Overnight"
                    },
                    {
                        new Guid("f68b11cc-35ca-4f58-81b5-0a975e47d7f3"), "Est facilis nisi rerum omnis consequatur.", "Backpack",
                        new DateTimeOffset(new DateTime(2021, 7, 25, 22, 11, 34, 644, DateTimeKind.Unspecified).AddTicks(8529),
                            new TimeSpan(0, -3, 0, 0, 0)),
                        "quas", "Two", "zero_tolerance_definition.gif", 0.3207988788421447531747823566m,
                        new Guid("b80d9a45-67b7-4184-a27e-768e73920b1c"), -1917393661, 1520901273, "Cycling"
                    },
                    {
                        new Guid("4b17c044-a7c2-40a2-be26-db0059711168"), "Aliquid quibusdam eos qui ullam necessitatibus non eum dolor officia.",
                        "Backpack",
                        new DateTimeOffset(new DateTime(2020, 12, 24, 11, 13, 54, 550, DateTimeKind.Unspecified).AddTicks(3401),
                            new TimeSpan(0, -3, 0, 0, 0)),
                        "alias", "Three", "practical_soft_pizza.jpe", 0.1550092958074425383801000958m,
                        new Guid("b80d9a45-67b7-4184-a27e-768e73920b1c"), -482052297, 250104312, "Snowsports"
                    },
                    {
                        new Guid("ac3f5151-780d-4d4f-8844-439a07f59f48"), "Quo corrupti ipsa quia temporibus nisi.", "Backpack",
                        new DateTimeOffset(new DateTime(2020, 12, 23, 16, 47, 45, 340, DateTimeKind.Unspecified).AddTicks(1324),
                            new TimeSpan(0, -3, 0, 0, 0)),
                        "nulla", "Three", "engineer_intelligent_developer.shtml", 0.1573923348384465497089767032m,
                        new Guid("b80d9a45-67b7-4184-a27e-768e73920b1c"), 1404298559, 1922743469, "Climbing"
                    },
                    {
                        new Guid("3ec8e386-f57c-4aac-a499-167719009a5c"), "Aut qui placeat eos.", "Backpack",
                        new DateTimeOffset(new DateTime(2021, 2, 13, 15, 57, 35, 281, DateTimeKind.Unspecified).AddTicks(6200),
                            new TimeSpan(0, -3, 0, 0, 0)),
                        "dolore", "Three", "rustic_wooden_soap_georgia_monitor.wav", 0.2218937124712883931854359134m,
                        new Guid("b80d9a45-67b7-4184-a27e-768e73920b1c"), -1883481274, 2145762953, "Snowsports"
                    },
                    {
                        new Guid("b838ed84-5f61-46ad-b9b6-e3bde7102eb8"), "Iusto odio ad amet et est praesentium provident.", "Backpack",
                        new DateTimeOffset(new DateTime(2021, 4, 17, 3, 53, 9, 443, DateTimeKind.Unspecified).AddTicks(7116),
                            new TimeSpan(0, -3, 0, 0, 0)),
                        "eveniet", "Three", "cross_platform_stream.pdf", 0.4284272193602512822108917515m,
                        new Guid("b80d9a45-67b7-4184-a27e-768e73920b1c"), 1882331424, -715634942, "Climbing"
                    },
                    {
                        new Guid("08a7c665-f616-41fc-b3a2-09e84cef2496"), "Veritatis sunt pariatur.", "Backpack",
                        new DateTimeOffset(new DateTime(2021, 1, 20, 12, 3, 11, 384, DateTimeKind.Unspecified).AddTicks(2364),
                            new TimeSpan(0, -3, 0, 0, 0)),
                        "beatae", "One", "ability_capacitor_index.htm", 0.945258776082552498859410728m,
                        new Guid("b80d9a45-67b7-4184-a27e-768e73920b1c"), -725282922, -1742127344, "Overnight"
                    },
                    {
                        new Guid("968b61fd-a0b3-4a53-a977-c3ff4b4734dd"), "Praesentium ut ipsa consequuntur earum quis error inventore incidunt.",
                        "Backpack",
                        new DateTimeOffset(new DateTime(2021, 3, 21, 5, 30, 16, 984, DateTimeKind.Unspecified).AddTicks(3341),
                            new TimeSpan(0, -3, 0, 0, 0)),
                        "excepturi", "One", "cayman_islands_deposit_matrix.wav", 0.4458216890447771965809257994m,
                        new Guid("b80d9a45-67b7-4184-a27e-768e73920b1c"), -933193982, 388605327, "Overnight"
                    }
                });

            migrationBuilder.InsertData("Products",
                new[]
                {
                    "Id", "Description", "Discriminator", "IntroduceAt", "Name", "Option", "PhotoFileName", "Price", "ProductTypeId", "Rating",
                    "Stock", "AmountOfPerson", "KayakType"
                },
                new object[,]
                {
                    {
                        new Guid("fbd4315c-6731-4a0a-869e-ef2263eee171"), "Ut reprehenderit et voluptatem.", "Kayak",
                        new DateTimeOffset(new DateTime(2021, 4, 18, 22, 43, 58, 842, DateTimeKind.Unspecified).AddTicks(4148),
                            new TimeSpan(0, -3, 0, 0, 0)),
                        "voluptatem", "Two", "ergonomic_serbian_dinar.gif", 0.2012135754440516725053311953m,
                        new Guid("b7e06be6-60a4-4bcb-830b-160736d3f806"), -1161992328, -1752731623, 1829994510, "Family"
                    },
                    {
                        new Guid("40d2a0e2-30db-4e0c-be21-8f6ff090e625"), "Est aut praesentium.", "Kayak",
                        new DateTimeOffset(new DateTime(2021, 6, 1, 2, 16, 0, 228, DateTimeKind.Unspecified).AddTicks(3805),
                            new TimeSpan(0, -3, 0, 0, 0)),
                        "sunt", "Three", "director.wav", 0.0181226179682340174782668359m, new Guid("b80d9a45-67b7-4184-a27e-768e73920b1c"), 629340508,
                        -1579798588, -810506207, "Fishing"
                    },
                    {
                        new Guid("db10bc37-cdec-4ceb-a802-2de0f33b15b4"), "Aut autem sed.", "Kayak",
                        new DateTimeOffset(new DateTime(2021, 6, 16, 21, 41, 51, 51, DateTimeKind.Unspecified).AddTicks(701),
                            new TimeSpan(0, -3, 0, 0, 0)),
                        "et", "Two", "leading_edge_baby__toys_&_shoes.shtml", 0.7516044719594649273644379067m,
                        new Guid("b80d9a45-67b7-4184-a27e-768e73920b1c"), 371026202, 1125737528, 2100007169, "Family"
                    }
                });

            migrationBuilder.InsertData("Products",
                new[]
                {
                    "Id", "Description", "Discriminator", "IntroduceAt", "Name", "Option", "PhotoFileName", "Price", "ProductTypeId", "Rating",
                    "Stock", "BackpackType"
                },
                new object[,]
                {
                    {
                        new Guid("68c6b4ea-b9fc-4c7f-bbd7-763831eb3c8e"), "Sequi corporis praesentium architecto illo.", "Backpack",
                        new DateTimeOffset(new DateTime(2020, 11, 17, 14, 15, 21, 317, DateTimeKind.Unspecified).AddTicks(8373),
                            new TimeSpan(0, -3, 0, 0, 0)),
                        "consequatur", "One", "orchid_proactive.gif", 0.2696597334912325453242666465m,
                        new Guid("815954b2-93b4-4e30-9e30-c2d3a5074f40"), -1750537882, 2051132776, "Cycling"
                    },
                    {
                        new Guid("a5a3d20a-63c5-4513-aa25-a750debc8c92"), "Sunt totam qui accusantium laboriosam dolores quis.", "Backpack",
                        new DateTimeOffset(new DateTime(2021, 2, 25, 10, 1, 55, 371, DateTimeKind.Unspecified).AddTicks(356),
                            new TimeSpan(0, -3, 0, 0, 0)),
                        "dolorum", "One", "grove_impactful.pdf", 0.6059426555283746332882500354m, new Guid("815954b2-93b4-4e30-9e30-c2d3a5074f40"),
                        1479309508, -1582057502, "Cycling"
                    },
                    {
                        new Guid("63636706-3b1f-43c5-84f3-f75a006acee7"), "Non sequi aut a expedita neque exercitationem quas magnam.", "Backpack",
                        new DateTimeOffset(new DateTime(2021, 7, 12, 1, 51, 54, 648, DateTimeKind.Unspecified).AddTicks(6853),
                            new TimeSpan(0, -3, 0, 0, 0)),
                        "possimus", "One", "soft_iowa_marketing.mpga", 0.4018455241189306709941988063m,
                        new Guid("815954b2-93b4-4e30-9e30-c2d3a5074f40"), -826040102, 1584107523, "DayPack"
                    },
                    {
                        new Guid("ee04be6c-e6aa-444e-a138-b44068c34324"), "Placeat necessitatibus amet at ea tenetur.", "Backpack",
                        new DateTimeOffset(new DateTime(2020, 10, 8, 22, 59, 44, 347, DateTimeKind.Unspecified).AddTicks(7548),
                            new TimeSpan(0, -3, 0, 0, 0)),
                        "labore", "One", "handmade_concrete_bacon_station.pdf", 0.5533066749613350331816039173m,
                        new Guid("815954b2-93b4-4e30-9e30-c2d3a5074f40"), 401763747, -450161457, "Hiking"
                    },
                    {
                        new Guid("298a831e-ed75-484b-bc99-2905a0886f52"), "Est est minus eos voluptatem magnam recusandae.", "Backpack",
                        new DateTimeOffset(new DateTime(2021, 3, 3, 3, 57, 3, 991, DateTimeKind.Unspecified).AddTicks(9077),
                            new TimeSpan(0, -3, 0, 0, 0)),
                        "fuga", "Three", "regional_arkansas.pdf", 0.0066283429894732388894851247m, new Guid("815954b2-93b4-4e30-9e30-c2d3a5074f40"),
                        862643594, -500766730, "Snowsports"
                    },
                    {
                        new Guid("04c1a4ba-7f50-4d42-8ac3-c4175e3254a6"), "Sint labore voluptatem consectetur.", "Backpack",
                        new DateTimeOffset(new DateTime(2020, 10, 2, 3, 27, 19, 60, DateTimeKind.Unspecified).AddTicks(6395),
                            new TimeSpan(0, -3, 0, 0, 0)),
                        "accusamus", "Three", "movies_new_york.gif", 0.4095457731278315737463384669m,
                        new Guid("815954b2-93b4-4e30-9e30-c2d3a5074f40"), 739839427, 1505497842, "Hiking"
                    },
                    {
                        new Guid("9769497f-5a57-423a-a667-29950e671f5b"), "Rem et harum doloribus explicabo beatae sed.", "Backpack",
                        new DateTimeOffset(new DateTime(2021, 2, 9, 22, 34, 16, 124, DateTimeKind.Unspecified).AddTicks(5631),
                            new TimeSpan(0, -3, 0, 0, 0)),
                        "repudiandae", "Three", "soft.html", 0.7645563238610370532153311999m, new Guid("815954b2-93b4-4e30-9e30-c2d3a5074f40"),
                        903262031, 913821201, "Climbing"
                    }
                });

            migrationBuilder.InsertData("Products",
                new[]
                {
                    "Id", "Description", "Discriminator", "IntroduceAt", "Name", "Option", "PhotoFileName", "Price", "ProductTypeId", "Rating",
                    "Stock", "BootType", "Size"
                },
                new object[,]
                {
                    {
                        new Guid("9beab515-44dc-4418-aa10-565ac8a46947"), "Ullam ducimus sed voluptatibus.", "Boot",
                        new DateTimeOffset(new DateTime(2021, 4, 19, 8, 17, 21, 259, DateTimeKind.Unspecified).AddTicks(1202),
                            new TimeSpan(0, -3, 0, 0, 0)),
                        "earum", "Three", "auxiliary_fuchsia.m2a", 0.8149319276952651564687080803m, new Guid("815954b2-93b4-4e30-9e30-c2d3a5074f40"),
                        -985383122, -434926967, "Football", -1743945383
                    },
                    {
                        new Guid("92ec7e44-43aa-41ba-bf62-524e0d4f582b"), "Aspernatur eaque fugit sed fugit aut.", "Boot",
                        new DateTimeOffset(new DateTime(2021, 5, 31, 5, 23, 13, 206, DateTimeKind.Unspecified).AddTicks(2157),
                            new TimeSpan(0, -3, 0, 0, 0)),
                        "porro", "Two", "indexing.mp4", 0.0721702512917710551183172008m, new Guid("815954b2-93b4-4e30-9e30-c2d3a5074f40"), 1879180017,
                        41323002, "Football", -1407127743
                    },
                    {
                        new Guid("da1b9a03-afb6-44f2-9f57-65e30ffc87ff"), "Ut perspiciatis amet molestiae non et sed neque.", "Boot",
                        new DateTimeOffset(new DateTime(2021, 5, 12, 14, 47, 4, 271, DateTimeKind.Unspecified).AddTicks(1383),
                            new TimeSpan(0, -3, 0, 0, 0)),
                        "sunt", "One", "turkish_lira.pdf", 0.3404021015955623026772874207m, new Guid("815954b2-93b4-4e30-9e30-c2d3a5074f40"),
                        1709642195, 1444938060, "Engineer", -689281811
                    },
                    {
                        new Guid("faa3a010-a280-4b91-ab5b-c4a6fb7154b7"), "Magnam dolores explicabo.", "Boot",
                        new DateTimeOffset(new DateTime(2021, 6, 26, 21, 57, 9, 214, DateTimeKind.Unspecified).AddTicks(8777),
                            new TimeSpan(0, -3, 0, 0, 0)),
                        "possimus", "Three", "points_hack_belize.html", 0.9822212495922639275778942644m,
                        new Guid("815954b2-93b4-4e30-9e30-c2d3a5074f40"), 537501044, 1450737969, "Cowboy", -269457469
                    },
                    {
                        new Guid("b95a9491-b14c-4fea-bab6-c6b0c77dbf5f"), "Nulla illo harum et qui similique modi sit ipsa iste.", "Boot",
                        new DateTimeOffset(new DateTime(2021, 6, 30, 17, 16, 56, 847, DateTimeKind.Unspecified).AddTicks(903),
                            new TimeSpan(0, -3, 0, 0, 0)),
                        "maxime", "Three", "sas_automotive__games_&_games.pdf", 0.0559919315825153668141506914m,
                        new Guid("815954b2-93b4-4e30-9e30-c2d3a5074f40"), 1379102728, 1415286747, "Harness", 1703548289
                    }
                });

            migrationBuilder.InsertData("Products",
                new[]
                {
                    "Id", "Description", "Discriminator", "IntroduceAt", "Name", "Option", "PhotoFileName", "Price", "ProductTypeId", "Rating",
                    "Stock", "BootType", "Size"
                },
                new object[,]
                {
                    {
                        new Guid("10af2fd5-67cc-459a-a3c2-baece9276747"), "Optio recusandae ab rerum qui nesciunt deserunt sint.", "Boot",
                        new DateTimeOffset(new DateTime(2021, 5, 10, 13, 12, 26, 583, DateTimeKind.Unspecified).AddTicks(3718),
                            new TimeSpan(0, -3, 0, 0, 0)),
                        "et", "Three", "cambridgeshire_best_of_breed_italy.png", 0.4964147060811030673175014419m,
                        new Guid("815954b2-93b4-4e30-9e30-c2d3a5074f40"), -177078525, -1783502030, "Cowboy", 975804304
                    },
                    {
                        new Guid("c0e69278-5d52-4202-9545-37e7e15d5721"), "Consectetur repudiandae dignissimos possimus vel sit magni.", "Boot",
                        new DateTimeOffset(new DateTime(2020, 12, 2, 17, 34, 15, 401, DateTimeKind.Unspecified).AddTicks(1871),
                            new TimeSpan(0, -3, 0, 0, 0)),
                        "recusandae", "Three", "angola_checking_account_ergonomic_rubber_pants.jpeg", 0.7075982906615606038445367383m,
                        new Guid("815954b2-93b4-4e30-9e30-c2d3a5074f40"), -805674613, 561626899, "Football", 938855177
                    },
                    {
                        new Guid("79354342-c4f9-46eb-b8f1-8d1cfaa9242c"), "Dolorum saepe ratione est.", "Boot",
                        new DateTimeOffset(new DateTime(2021, 1, 14, 6, 2, 20, 637, DateTimeKind.Unspecified).AddTicks(220),
                            new TimeSpan(0, -3, 0, 0, 0)),
                        "mollitia", "Two", "michigan_incredible_rubber_chips_tactics.htm", 0.5460259188628524198825606199m,
                        new Guid("815954b2-93b4-4e30-9e30-c2d3a5074f40"), -614512929, -111033695, "Chelsea", 1775601073
                    }
                });

            migrationBuilder.InsertData("Products",
                new[]
                {
                    "Id", "Description", "Discriminator", "IntroduceAt", "Name", "Option", "PhotoFileName", "Price", "ProductTypeId", "Rating",
                    "Stock", "BackpackType"
                },
                new object[]
                {
                    new Guid("e40682d0-6af8-4f02-ad10-a2aea4eb0777"), "Dolores aut sint ullam.", "Backpack",
                    new DateTimeOffset(new DateTime(2021, 2, 7, 7, 40, 39, 929, DateTimeKind.Unspecified).AddTicks(4578),
                        new TimeSpan(0, -3, 0, 0, 0)),
                    "nulla", "One", "home_loan_account.pdf", 0.7472200546343002416268358924m, new Guid("815954b2-93b4-4e30-9e30-c2d3a5074f40"),
                    884344646, 972680634, "Hiking"
                });

            migrationBuilder.InsertData("Products",
                new[]
                {
                    "Id", "Description", "Discriminator", "IntroduceAt", "Name", "Option", "PhotoFileName", "Price", "ProductTypeId", "Rating",
                    "Stock", "AmountOfPerson", "KayakType"
                },
                new object[]
                {
                    new Guid("0188b7c4-e533-4514-848e-17fbd754c8b5"), "Omnis officia soluta iste.", "Kayak",
                    new DateTimeOffset(new DateTime(2020, 11, 7, 17, 47, 42, 260, DateTimeKind.Unspecified).AddTicks(436),
                        new TimeSpan(0, -3, 0, 0, 0)),
                    "quaerat", "One", "investor_bosnia_and_herzegovina.shtml", 0.2518809551449218795045925721m,
                    new Guid("b80d9a45-67b7-4184-a27e-768e73920b1c"), -65840605, -633575587, -1544730671, "Camping"
                });

            migrationBuilder.InsertData("Products",
                new[]
                {
                    "Id", "Description", "Discriminator", "IntroduceAt", "Name", "Option", "PhotoFileName", "Price", "ProductTypeId", "Rating",
                    "Stock", "BackpackType"
                },
                new object[,]
                {
                    {
                        new Guid("d9350f7b-8abe-4aed-9484-5bb0664b4a2f"), "Necessitatibus et dolor ad officiis reprehenderit fugiat.", "Backpack",
                        new DateTimeOffset(new DateTime(2021, 6, 25, 3, 5, 56, 497, DateTimeKind.Unspecified).AddTicks(783),
                            new TimeSpan(0, -3, 0, 0, 0)),
                        "vitae", "Two", "transition_grocery_licensed_plastic_shoes.mp2", 0.5060307942231429723939955531m,
                        new Guid("815954b2-93b4-4e30-9e30-c2d3a5074f40"), -272109206, -1904413283, "Overnight"
                    },
                    {
                        new Guid("266ea095-da4f-4f11-9486-53a1bdb9fae9"), "Corrupti officia dolor quod provident.", "Backpack",
                        new DateTimeOffset(new DateTime(2021, 2, 11, 12, 59, 25, 599, DateTimeKind.Unspecified).AddTicks(6469),
                            new TimeSpan(0, -3, 0, 0, 0)),
                        "optio", "Two", "fantastic_personal_loan_account.png", 0.1910235821263402060222870091m,
                        new Guid("815954b2-93b4-4e30-9e30-c2d3a5074f40"), 1458398813, 74159081, "Cycling"
                    }
                });

            migrationBuilder.InsertData("Products",
                new[]
                {
                    "Id", "Description", "Discriminator", "IntroduceAt", "Name", "Option", "PhotoFileName", "Price", "ProductTypeId", "Rating",
                    "Stock", "AmountOfPerson", "KayakType"
                },
                new object[,]
                {
                    {
                        new Guid("8b1dee16-e447-4587-b8b7-de0a7b1940c2"), "Nobis libero accusamus voluptate error non praesentium sint nostrum quis.",
                        "Kayak",
                        new DateTimeOffset(new DateTime(2021, 2, 22, 6, 19, 31, 328, DateTimeKind.Unspecified).AddTicks(6109),
                            new TimeSpan(0, -3, 0, 0, 0)),
                        "excepturi", "Three", "mexican_peso_metal_integrated.m1v", 0.6694473069437714099628277473m,
                        new Guid("b80d9a45-67b7-4184-a27e-768e73920b1c"), -2042750379, 104565929, 873860461, "Camping"
                    },
                    {
                        new Guid("2a76b096-034a-469a-93ed-e1df7a7ed897"), "Alias natus molestias.", "Kayak",
                        new DateTimeOffset(new DateTime(2021, 1, 21, 9, 19, 22, 301, DateTimeKind.Unspecified).AddTicks(8988),
                            new TimeSpan(0, -3, 0, 0, 0)),
                        "numquam", "One", "integrated_e_business.png", 0.8104321355629973013412497622m,
                        new Guid("b80d9a45-67b7-4184-a27e-768e73920b1c"), 408829285, -1706770187, 1548105857, "Camping"
                    },
                    {
                        new Guid("9ec2829b-b886-4cea-b043-d83a2ed6dda9"), "Possimus temporibus tempora enim.", "Kayak",
                        new DateTimeOffset(new DateTime(2021, 2, 19, 9, 56, 48, 792, DateTimeKind.Unspecified).AddTicks(5775),
                            new TimeSpan(0, -3, 0, 0, 0)),
                        "ipsa", "Three", "nebraska.wav", 0.7322938051966443495786153203m, new Guid("b80d9a45-67b7-4184-a27e-768e73920b1c"),
                        -371803610, -208656596, 1630936127, "Fishing"
                    },
                    {
                        new Guid("974aec2b-8af8-4e99-9fa7-83fd0b8f6ac4"), "Qui id atque animi repellat accusantium rerum omnis.", "Kayak",
                        new DateTimeOffset(new DateTime(2021, 6, 16, 9, 43, 4, 615, DateTimeKind.Unspecified).AddTicks(412),
                            new TimeSpan(0, -3, 0, 0, 0)),
                        "rem", "One", "time_frame_fundamental_dominican_peso.mpeg", 0.4251337406622304121239440878m,
                        new Guid("b80d9a45-67b7-4184-a27e-768e73920b1c"), -491160855, -1422928677, -210380339, "Camping"
                    },
                    {
                        new Guid("938ab1da-b683-4cfe-9b17-189a8c4b44ae"), "Est voluptate expedita odio molestiae quaerat.", "Kayak",
                        new DateTimeOffset(new DateTime(2020, 12, 12, 23, 34, 11, 736, DateTimeKind.Unspecified).AddTicks(4790),
                            new TimeSpan(0, -3, 0, 0, 0)),
                        "nesciunt", "Three", "context_sensitive_extended_gorgeous_frozen_computer.jpeg", 0.6950905659417237985335122352m,
                        new Guid("b80d9a45-67b7-4184-a27e-768e73920b1c"), 2078191345, -338771637, -348050752, "Camping"
                    },
                    {
                        new Guid("7f2a0173-c8b6-48d0-b876-07d01bc1adc3"), "Repudiandae et facere.", "Kayak",
                        new DateTimeOffset(new DateTime(2020, 12, 29, 3, 27, 40, 737, DateTimeKind.Unspecified).AddTicks(1403),
                            new TimeSpan(0, -3, 0, 0, 0)),
                        "illum", "One", "beauty_program_value_added.mpeg", 0.5126598415108057877490054231m,
                        new Guid("b80d9a45-67b7-4184-a27e-768e73920b1c"), -1885905060, 1806682452, 85976659, "Fishing"
                    }
                });

            migrationBuilder.InsertData("Products",
                new[]
                {
                    "Id", "Description", "Discriminator", "IntroduceAt", "Name", "Option", "PhotoFileName", "Price", "ProductTypeId", "Rating",
                    "Stock", "BackpackType"
                },
                new object[,]
                {
                    {
                        new Guid("34a31f6a-7798-4147-8847-53fc5b9f79d2"), "Autem voluptate doloremque est est quia non qui aut et.", "Backpack",
                        new DateTimeOffset(new DateTime(2021, 6, 15, 9, 33, 35, 767, DateTimeKind.Unspecified).AddTicks(5180),
                            new TimeSpan(0, -3, 0, 0, 0)),
                        "nobis", "One", "transmitting.jpg", 0.3843342982327879819717501206m, new Guid("815954b2-93b4-4e30-9e30-c2d3a5074f40"),
                        2059096711, -805081845, "Snowsports"
                    },
                    {
                        new Guid("c267e5b3-eac5-4ccf-ab9f-d389bd9c4b33"), "Aliquid possimus officiis porro accusamus est est quia debitis.",
                        "Backpack",
                        new DateTimeOffset(new DateTime(2020, 11, 20, 23, 52, 7, 585, DateTimeKind.Unspecified).AddTicks(1269),
                            new TimeSpan(0, -3, 0, 0, 0)),
                        "labore", "Two", "investment_account.gif", 0.1192081426040254361533236298m, new Guid("815954b2-93b4-4e30-9e30-c2d3a5074f40"),
                        -1053005277, -382205705, "Overnight"
                    },
                    {
                        new Guid("53b733c2-8bc7-4b8c-9267-2ed367efec53"), "Deserunt ut odit quam suscipit qui atque tempore.", "Backpack",
                        new DateTimeOffset(new DateTime(2021, 5, 19, 15, 10, 51, 691, DateTimeKind.Unspecified).AddTicks(2557),
                            new TimeSpan(0, -3, 0, 0, 0)),
                        "qui", "Three", "executive.mp4v", 0.6117584317567815709768591124m, new Guid("815954b2-93b4-4e30-9e30-c2d3a5074f40"),
                        504792879, -969293737, "Snowsports"
                    },
                    {
                        new Guid("fd72c248-93a2-44e4-aa3e-106556ce3005"), "Temporibus doloribus qui quasi doloribus ex doloremque aut quibusdam.",
                        "Backpack",
                        new DateTimeOffset(new DateTime(2021, 1, 3, 2, 12, 52, 980, DateTimeKind.Unspecified).AddTicks(6742),
                            new TimeSpan(0, -3, 0, 0, 0)),
                        "vero", "One", "conglomeration_bhutan_port.mp2", 0.3844516406184173814497040534m,
                        new Guid("815954b2-93b4-4e30-9e30-c2d3a5074f40"), -820897287, 1367543061, "Hiking"
                    },
                    {
                        new Guid("5b000c2b-124c-4423-bd19-bd6b8f88852b"), "Recusandae ut sunt accusamus.", "Backpack",
                        new DateTimeOffset(new DateTime(2021, 3, 5, 15, 49, 47, 724, DateTimeKind.Unspecified).AddTicks(1219),
                            new TimeSpan(0, -3, 0, 0, 0)),
                        "non", "One", "iceland_krona.jpeg", 0.9401470996684185300105355549m, new Guid("815954b2-93b4-4e30-9e30-c2d3a5074f40"),
                        2078366352, -1574173716, "Hiking"
                    },
                    {
                        new Guid("4bc37616-ec86-4a1e-a9af-0e62e98d6849"), "Reprehenderit rem quia laborum odio incidunt esse esse.", "Backpack",
                        new DateTimeOffset(new DateTime(2021, 4, 7, 22, 6, 16, 17, DateTimeKind.Unspecified).AddTicks(1682),
                            new TimeSpan(0, -3, 0, 0, 0)),
                        "vitae", "Two", "generate.png", 0.4437501159167800435586039594m, new Guid("815954b2-93b4-4e30-9e30-c2d3a5074f40"), 174312085,
                        1690053177, "Climbing"
                    },
                    {
                        new Guid("8f302d3c-630e-467d-ade6-2c73047fd46d"), "Numquam aut ut.", "Backpack",
                        new DateTimeOffset(new DateTime(2021, 4, 3, 9, 29, 12, 499, DateTimeKind.Unspecified).AddTicks(8965),
                            new TimeSpan(0, -3, 0, 0, 0)),
                        "quis", "One", "gabon_salmon_functionalities.jpe", 0.0309428269023770472693583329m,
                        new Guid("815954b2-93b4-4e30-9e30-c2d3a5074f40"), 1698682812, -61701202, "DayPack"
                    },
                    {
                        new Guid("b95929f8-de35-4f5d-ac51-85b680cc0ca6"), "Doloribus itaque reprehenderit repudiandae.", "Backpack",
                        new DateTimeOffset(new DateTime(2020, 9, 11, 1, 59, 36, 78, DateTimeKind.Unspecified).AddTicks(4346),
                            new TimeSpan(0, -3, 0, 0, 0)),
                        "dolorum", "One", "route_handcrafted_metal_keyboard.htm", 0.5646208215371352322410467832m,
                        new Guid("815954b2-93b4-4e30-9e30-c2d3a5074f40"), -1227634980, -1858481736, "DayPack"
                    },
                    {
                        new Guid("c5779eed-81fc-4227-b116-71b0319abf68"), "Repellat error explicabo esse repudiandae minus.", "Backpack",
                        new DateTimeOffset(new DateTime(2020, 8, 10, 21, 48, 43, 108, DateTimeKind.Unspecified).AddTicks(8845),
                            new TimeSpan(0, -3, 0, 0, 0)),
                        "dignissimos", "One", "invoice.pdf", 0.855817324494265285553204151m, new Guid("815954b2-93b4-4e30-9e30-c2d3a5074f40"),
                        394441469, 1143775360, "Hiking"
                    },
                    {
                        new Guid("ac299c95-d2d7-49e3-88eb-550d991446f7"), "Ipsum quaerat dolorem mollitia voluptatem.", "Backpack",
                        new DateTimeOffset(new DateTime(2020, 12, 21, 0, 39, 6, 269, DateTimeKind.Unspecified).AddTicks(2449),
                            new TimeSpan(0, -3, 0, 0, 0)),
                        "officia", "Three", "solomon_islands_grey_invoice.png", 0.0227259283996609376448389122m,
                        new Guid("815954b2-93b4-4e30-9e30-c2d3a5074f40"), -522247010, 1796633501, "Cycling"
                    }
                });

            migrationBuilder.InsertData("Products",
                new[]
                {
                    "Id", "Description", "Discriminator", "IntroduceAt", "Name", "Option", "PhotoFileName", "Price", "ProductTypeId", "Rating",
                    "Stock", "AmountOfPerson", "KayakType"
                },
                new object[]
                {
                    new Guid("cbcb7930-6bd5-4334-bfa8-3c57cb74456d"), "Voluptas itaque omnis error odit cumque vel.", "Kayak",
                    new DateTimeOffset(new DateTime(2020, 8, 5, 9, 52, 27, 405, DateTimeKind.Unspecified).AddTicks(9862),
                        new TimeSpan(0, -3, 0, 0, 0)),
                    "quis", "Two", "metal.jpg", 0.3875231454819833773544141473m, new Guid("b7e06be6-60a4-4bcb-830b-160736d3f806"), 1039789038,
                    -1604669546, -599441755, "Racing"
                });

            migrationBuilder.InsertData("Reviews",
                new[] {"Id", "Comment", "ProductId", "Title"},
                new object[,]
                {
                    {
                        new Guid("a4abe2e8-6c37-41c3-91d3-c3928bb5daa8"),
                        "Labore omnis velit doloremque necessitatibus nisi mollitia magni dolores qui.",
                        new Guid("10f4a184-61c1-41a8-881a-155575182923"), "omnis"
                    },
                    {
                        new Guid("3b9e010e-01ab-489a-ba46-e98c4b26e6bb"), "Consequatur corporis sed voluptatibus possimus commodi quod.",
                        new Guid("b95929f8-de35-4f5d-ac51-85b680cc0ca6"), "quia"
                    },
                    {
                        new Guid("a5e29ccc-e0bb-4ccb-b051-4fbca42b041e"), "Ut laudantium placeat eum earum consequuntur officia.",
                        new Guid("c5779eed-81fc-4227-b116-71b0319abf68"), "quae"
                    },
                    {
                        new Guid("92af0622-c658-4dbe-8afc-b40ce319a96e"), "Omnis minima quia necessitatibus deleniti et.",
                        new Guid("266ea095-da4f-4f11-9486-53a1bdb9fae9"), "magni"
                    },
                    {
                        new Guid("0a1a9ebb-8e78-4de6-a9df-77f32a4d5d1c"), "Consequuntur qui expedita inventore libero sint.",
                        new Guid("ac299c95-d2d7-49e3-88eb-550d991446f7"), "sequi"
                    },
                    {
                        new Guid("5310619d-0224-4b26-9c37-3bc55b2acdd0"), "Expedita iusto ad perferendis pariatur repellat ipsum earum quia.",
                        new Guid("d9350f7b-8abe-4aed-9484-5bb0664b4a2f"), "asperiores"
                    },
                    {
                        new Guid("bba83b6a-b70d-411d-8bbe-63e9573d95da"), "Suscipit dignissimos perspiciatis.",
                        new Guid("e40682d0-6af8-4f02-ad10-a2aea4eb0777"), "sint"
                    },
                    {
                        new Guid("de29a31f-ba76-4f6f-9b00-8adab4f6bd94"), "Cumque quibusdam officiis laudantium.",
                        new Guid("68c6b4ea-b9fc-4c7f-bbd7-763831eb3c8e"), "voluptate"
                    },
                    {
                        new Guid("53773617-bb07-421e-b652-21c23708e86f"), "Consequatur officiis omnis odio soluta.",
                        new Guid("a5a3d20a-63c5-4513-aa25-a750debc8c92"), "vel"
                    },
                    {
                        new Guid("146a977a-c0b4-44bc-8ae5-f1b835404c07"), "Quam voluptas mollitia est cum a quidem in.",
                        new Guid("63636706-3b1f-43c5-84f3-f75a006acee7"), "unde"
                    },
                    {
                        new Guid("c9756477-6688-4506-86a8-4872052d9499"), "Dignissimos et hic eveniet porro voluptatem cupiditate natus.",
                        new Guid("ee04be6c-e6aa-444e-a138-b44068c34324"), "est"
                    },
                    {
                        new Guid("235aa6ce-1639-48ff-b291-c77bbbcc6b98"), "Laboriosam aut dicta quia.",
                        new Guid("298a831e-ed75-484b-bc99-2905a0886f52"), "perspiciatis"
                    },
                    {
                        new Guid("003120a8-9db7-4bb0-9dbc-4398430a83e8"), "Quis debitis qui et eveniet.",
                        new Guid("04c1a4ba-7f50-4d42-8ac3-c4175e3254a6"), "dolore"
                    },
                    {
                        new Guid("8afee5a1-84be-4a94-9bec-c476cc9cf954"), "Aut impedit itaque modi dignissimos enim qui nobis exercitationem totam.",
                        new Guid("9769497f-5a57-423a-a667-29950e671f5b"), "sit"
                    },
                    {
                        new Guid("e7a763f9-fda9-4609-b81d-f58975631e93"), "Maiores fuga animi.", new Guid("9cc428ee-e751-4491-a737-d395ef38f669"),
                        "iste"
                    },
                    {
                        new Guid("13e9910b-a1e5-4caf-9ba3-eec67682d9c0"), "Eveniet dolor necessitatibus consequatur.",
                        new Guid("870ddee1-65ad-4843-b2df-0327d0fa54c6"), "aut"
                    },
                    {
                        new Guid("979d38e6-3155-4554-b994-89f9d1139359"), "A laudantium qui pariatur ut omnis voluptatem officia nihil.",
                        new Guid("3020569d-2be5-4442-a779-5e97a1740de6"), "dolor"
                    },
                    {
                        new Guid("27ed43e1-a780-45b1-a4d6-9aea29a98cfa"), "Nesciunt itaque nihil aut atque deserunt expedita unde illo quos.",
                        new Guid("5fc8e291-4d46-4c8b-a4a1-d1a77c9416a5"), "aut"
                    },
                    {
                        new Guid("fcdbc034-d3a3-4beb-9528-faf3a27d095b"), "Sunt minima commodi numquam ut odio debitis omnis perspiciatis.",
                        new Guid("d3c14755-e161-4325-9509-add643864e95"), "consectetur"
                    },
                    {
                        new Guid("527d2c40-b2ec-45c0-940b-2abf1092c271"), "Est quo fuga.", new Guid("9dbacce0-c183-4545-a462-1af55ea88932"),
                        "voluptatum"
                    },
                    {
                        new Guid("d3214255-6129-4558-968a-3373c3f6162a"), "Repellat molestias corporis in harum nisi iste sequi ipsa.",
                        new Guid("18a5e72b-49c6-47e7-9f72-1ee0a3205c00"), "harum"
                    },
                    {
                        new Guid("46329f91-3a82-4aae-adba-eb7e1cea9a30"), "Eligendi aut fugit minus expedita necessitatibus qui consectetur neque.",
                        new Guid("a9966c74-f188-4d55-b33e-a3aca71ca319"), "cumque"
                    },
                    {
                        new Guid("994bb424-2a16-40ae-ad57-5dfb828aea6e"),
                        "Atque voluptate aliquid et voluptatem commodi aut architecto rerum libero.",
                        new Guid("8f302d3c-630e-467d-ade6-2c73047fd46d"), "adipisci"
                    },
                    {
                        new Guid("de1a69b6-e4d0-4ec9-8104-1363da18737c"), "Voluptatum quos rerum nesciunt non vero ut assumenda odio.",
                        new Guid("4bc37616-ec86-4a1e-a9af-0e62e98d6849"), "eum"
                    },
                    {
                        new Guid("f05da3b0-60d8-45c0-9d9e-5c7d981a4f82"), "Temporibus similique modi consequatur incidunt aliquam ullam nulla.",
                        new Guid("5b000c2b-124c-4423-bd19-bd6b8f88852b"), "dolorum"
                    },
                    {
                        new Guid("3d3ccc16-6dae-4c63-b4a9-58d778c4e1ee"), "Repudiandae ipsum est deserunt reiciendis.",
                        new Guid("fd72c248-93a2-44e4-aa3e-106556ce3005"), "delectus"
                    },
                    {
                        new Guid("5621b03c-8dee-4aa2-a5bc-f2212152f9ee"), "Rem corporis eligendi at consequatur cupiditate architecto deleniti.",
                        new Guid("6a8155e2-a0a5-451f-a8f7-94b55e8af5ec"), "porro"
                    },
                    {
                        new Guid("17b907ee-3f38-433d-ab51-daaadf2b0eed"), "Repellat enim voluptatem sint provident.",
                        new Guid("9408d841-b036-426e-b9f5-c691ab4afe5d"), "ad"
                    },
                    {
                        new Guid("5d2e6432-1d94-4a97-92c5-1a585e48d489"), "Illum qui laboriosam.", new Guid("59f77a64-e564-4951-8480-6fc2203bf915"),
                        "incidunt"
                    },
                    {
                        new Guid("9848d22b-adfe-43a9-9e67-99b13c5ab600"), "Nobis repellat fuga porro ipsum suscipit aut minus dignissimos.",
                        new Guid("e0547840-310d-4d9a-9a06-43020d0e9abd"), "ducimus"
                    },
                    {
                        new Guid("841bd161-1c22-4120-8b76-5690b2a005ae"), "Ipsam autem nisi quis quia et aspernatur non.",
                        new Guid("3027141d-f3d7-4f45-b48b-a5c071054506"), "architecto"
                    },
                    {
                        new Guid("b858ed39-79db-43ac-953f-8c46cb97766f"), "Facilis repellendus numquam id.",
                        new Guid("3b3e4b62-fd3d-4a06-b0a8-bc7d343fe0e8"), "impedit"
                    },
                    {
                        new Guid("0fd126c0-8e01-4431-86fb-8441aa7da14d"), "Non et quidem consequuntur.",
                        new Guid("99fa66f6-41a0-4519-868a-e2fead8cb551"), "aut"
                    },
                    {
                        new Guid("3c54f15e-b003-4bf2-a882-72567dd91a90"), "Enim sed eaque laborum et.",
                        new Guid("8b934af2-720f-4cdf-bca2-1ee654d8b46c"), "aut"
                    },
                    {
                        new Guid("34dedce7-6acf-42c0-8cca-fd3d2affe83c"), "Fugit atque voluptatem qui culpa quo officiis ut autem officiis.",
                        new Guid("d8cec59b-31a6-416a-8885-f7dbf46630f4"), "quas"
                    },
                    {
                        new Guid("f26b8ef5-2f0a-4180-8993-bd0690b80029"), "Et possimus deleniti occaecati suscipit neque qui aut.",
                        new Guid("f68b11cc-35ca-4f58-81b5-0a975e47d7f3"), "praesentium"
                    },
                    {new Guid("56942119-3ee1-44e5-aac4-a7fa513df403"), "Saepe ut est.", new Guid("b5de4d13-daa3-4f75-87eb-69a5e0c33046"), "voluptas"},
                    {
                        new Guid("104335ff-d7ec-4833-a1dc-b70ef18556ee"), "Beatae at et quisquam voluptatem.",
                        new Guid("4b17c044-a7c2-40a2-be26-db0059711168"), "pariatur"
                    },
                    {
                        new Guid("1b60b384-a81c-44ef-9a11-e8bfb141a00e"), "Aut ipsa dolore voluptatem.",
                        new Guid("3ec8e386-f57c-4aac-a499-167719009a5c"), "enim"
                    },
                    {
                        new Guid("1686f8e9-85d4-413a-8e92-fccc5947a734"), "Quo occaecati placeat ut nesciunt ipsam aut omnis.",
                        new Guid("b838ed84-5f61-46ad-b9b6-e3bde7102eb8"), "nesciunt"
                    },
                    {
                        new Guid("9646adbb-c1ab-42d1-a9fd-05dcfda83924"), "Distinctio ea et error omnis qui.",
                        new Guid("08a7c665-f616-41fc-b3a2-09e84cef2496"), "occaecati"
                    },
                    {
                        new Guid("0ceb5f6c-dc6f-4e9f-83c7-13b3b746b586"), "Odio officiis et est.", new Guid("0bd972fa-a6dc-4555-b300-af551a1cb27f"),
                        "vitae"
                    }
                });

            migrationBuilder.InsertData("Reviews",
                new[] {"Id", "Comment", "ProductId", "Title"},
                new object[,]
                {
                    {
                        new Guid("8fe54316-1a59-434d-8835-07ef1297efb3"), "Voluptate pariatur est et.",
                        new Guid("968b61fd-a0b3-4a53-a977-c3ff4b4734dd"), "et"
                    },
                    {
                        new Guid("9fc136f1-a729-4c55-a545-c3b1fd2052d9"), "Qui amet ut omnis autem.",
                        new Guid("16adb77a-c07a-468b-b974-ee4210fae715"), "expedita"
                    },
                    {
                        new Guid("13ef1302-8aba-44b6-900b-4393be68e9c2"), "Consequatur quod nobis.", new Guid("13705ca3-66f0-4081-840c-40b84b1e6730"),
                        "in"
                    },
                    {
                        new Guid("76d63d86-7304-4ed6-a310-c36468aee415"),
                        "Voluptatem aspernatur voluptatem suscipit nihil in dolorum dolorum eligendi.",
                        new Guid("34a31f6a-7798-4147-8847-53fc5b9f79d2"), "incidunt"
                    },
                    {
                        new Guid("487ab561-fd1f-4355-b6c7-3a194cd160bc"), "Ex id molestias voluptatibus saepe unde harum impedit.",
                        new Guid("c267e5b3-eac5-4ccf-ab9f-d389bd9c4b33"), "consequuntur"
                    },
                    {
                        new Guid("b425919f-0f4b-462b-9b16-b68f03c2eff4"), "Doloribus dolorem velit exercitationem.",
                        new Guid("53b733c2-8bc7-4b8c-9267-2ed367efec53"), "vel"
                    },
                    {
                        new Guid("cd403763-5ad8-460d-892f-9f61d2084736"), "Aut qui molestiae.", new Guid("ac3f5151-780d-4d4f-8844-439a07f59f48"),
                        "nesciunt"
                    },
                    {
                        new Guid("feee492d-ea2e-40ce-9121-30253218ba09"), "Eius et sunt velit voluptas unde tenetur ex accusamus modi.",
                        new Guid("b51af9f9-4bd1-40cc-8f8b-f0c9751e9e16"), "commodi"
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