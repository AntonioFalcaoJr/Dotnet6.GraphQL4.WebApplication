using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Dotnet5.GraphQL.WebApplication.Repositories.Migrations
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
                    Discriminator = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: false)
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
                    Description = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    IntroduceAt = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Option = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PhotoFileName = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    Price = table.Column<decimal>(type: "decimal(18,2)", precision: 18, scale: 2, nullable: false),
                    ProductTypeId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    Rating = table.Column<int>(type: "int", nullable: false),
                    Stock = table.Column<int>(type: "int", nullable: false)
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
                    Comment = table.Column<string>(type: "nvarchar(300)", maxLength: 300, nullable: true),
                    ProductId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    Title = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Reviews", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Reviews_Products_ProductId",
                        column: x => x.ProductId,
                        principalTable: "Products",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.InsertData(
                table: "ProductTypes",
                columns: new[] { "Id", "Discriminator" },
                values: new object[] { new Guid("77563075-6e97-4fa6-b927-e7467fca1eef"), "TypeOne" });

            migrationBuilder.InsertData(
                table: "ProductTypes",
                columns: new[] { "Id", "Discriminator" },
                values: new object[] { new Guid("adcbcdc3-cb25-44d0-aa77-89cf7a9c7153"), "TypeThree" });

            migrationBuilder.InsertData(
                table: "ProductTypes",
                columns: new[] { "Id", "Discriminator" },
                values: new object[] { new Guid("059b00ff-5821-4a9a-95b6-36f42c6d9849"), "TypeTwo" });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "Description", "IntroduceAt", "Name", "Option", "PhotoFileName", "Price", "ProductTypeId", "Rating", "Stock" },
                values: new object[,]
                {
                    { new Guid("574dd632-4bbd-468b-b985-5b6b8fbfa32d"), "Incidunt perspiciatis ducimus facilis soluta.", new DateTimeOffset(new DateTime(2021, 1, 11, 10, 20, 19, 649, DateTimeKind.Unspecified).AddTicks(5375), new TimeSpan(0, -3, 0, 0, 0)), "consequuntur", "Two", "plum_administrator.shtml", 0.5803605953381957007074037228m, new Guid("77563075-6e97-4fa6-b927-e7467fca1eef"), 368462929, -2139112908 },
                    { new Guid("1713f998-d79b-48a5-a000-caee10c14393"), "Atque et sint.", new DateTimeOffset(new DateTime(2021, 6, 15, 3, 31, 31, 617, DateTimeKind.Unspecified).AddTicks(3781), new TimeSpan(0, -3, 0, 0, 0)), "architecto", "Three", "palladium_projection.mpe", 0.2156243798339802708969603336m, new Guid("adcbcdc3-cb25-44d0-aa77-89cf7a9c7153"), 294889473, -130299938 },
                    { new Guid("6c48fed6-fba7-49fb-9244-c5dd17585cb1"), "A odio hic quia ut animi qui.", new DateTimeOffset(new DateTime(2020, 9, 11, 12, 56, 45, 799, DateTimeKind.Unspecified).AddTicks(9643), new TimeSpan(0, -3, 0, 0, 0)), "iste", "One", "director.mp4", 0.0068997858436220081788350754m, new Guid("adcbcdc3-cb25-44d0-aa77-89cf7a9c7153"), -264924909, 1096837419 },
                    { new Guid("a3c1ee5c-d5c1-4b81-958a-a2f1555f2e7e"), "Possimus pariatur sint pariatur consectetur qui.", new DateTimeOffset(new DateTime(2020, 10, 23, 5, 32, 57, 989, DateTimeKind.Unspecified).AddTicks(916), new TimeSpan(0, -3, 0, 0, 0)), "numquam", "One", "sports__sports_&_electronics_haptic_payment.m2v", 0.2439516595311122363023317212m, new Guid("adcbcdc3-cb25-44d0-aa77-89cf7a9c7153"), 1541779640, -199414292 },
                    { new Guid("997e50b0-07db-4a50-a52c-4696fb765b91"), "Quia eligendi enim rerum laboriosam aut accusamus non.", new DateTimeOffset(new DateTime(2020, 8, 20, 14, 37, 41, 367, DateTimeKind.Unspecified).AddTicks(5846), new TimeSpan(0, -3, 0, 0, 0)), "delectus", "Two", "invoice_tcp.pdf", 0.273518793226343753745186262m, new Guid("adcbcdc3-cb25-44d0-aa77-89cf7a9c7153"), -1136102131, -1939776400 },
                    { new Guid("148ce96e-0d75-4b70-90e1-c13fefe1454b"), "Cumque velit nihil dolores.", new DateTimeOffset(new DateTime(2021, 3, 21, 10, 24, 57, 199, DateTimeKind.Unspecified).AddTicks(1417), new TimeSpan(0, -3, 0, 0, 0)), "non", "Two", "sql_parsing.png", 0.4253667136990974870382060198m, new Guid("adcbcdc3-cb25-44d0-aa77-89cf7a9c7153"), 552688278, -1303441614 },
                    { new Guid("5836cfbb-c041-42c4-8a26-4e071a5e9c92"), "Sed necessitatibus ad consequatur ut.", new DateTimeOffset(new DateTime(2021, 2, 15, 11, 16, 19, 330, DateTimeKind.Unspecified).AddTicks(2372), new TimeSpan(0, -3, 0, 0, 0)), "et", "Two", "burgs_maroon.png", 0.5710242712362338944943044674m, new Guid("adcbcdc3-cb25-44d0-aa77-89cf7a9c7153"), -1855730441, 52303286 },
                    { new Guid("d062c082-351d-405c-ae53-dcb3b356a825"), "Porro eum est.", new DateTimeOffset(new DateTime(2021, 6, 4, 5, 13, 41, 208, DateTimeKind.Unspecified).AddTicks(9589), new TimeSpan(0, -3, 0, 0, 0)), "nobis", "Three", "engage_swedish_krona.pdf", 0.130864308737824824277087829m, new Guid("adcbcdc3-cb25-44d0-aa77-89cf7a9c7153"), 758030498, 2087013529 },
                    { new Guid("cddc1e4b-b11a-4354-bd1d-38c347b73924"), "Libero neque eos ut et sequi vel ea qui sequi.", new DateTimeOffset(new DateTime(2021, 6, 5, 6, 23, 45, 818, DateTimeKind.Unspecified).AddTicks(1854), new TimeSpan(0, -3, 0, 0, 0)), "quo", "Two", "fantastic_cotton_fish_product_panel.mp2a", 0.9427912890614097235584126396m, new Guid("adcbcdc3-cb25-44d0-aa77-89cf7a9c7153"), -2024878207, 516270272 },
                    { new Guid("adb244f4-93b0-46cc-9ca3-f689ddec33d5"), "Ut aut eveniet nam et dolor.", new DateTimeOffset(new DateTime(2021, 6, 4, 19, 23, 53, 398, DateTimeKind.Unspecified).AddTicks(4731), new TimeSpan(0, -3, 0, 0, 0)), "rerum", "One", "generic.pdf", 0.4267536017734210019142732227m, new Guid("059b00ff-5821-4a9a-95b6-36f42c6d9849"), 55682484, -718836233 },
                    { new Guid("3c7f4fa0-f12c-4f36-923b-a77d646b0c96"), "Est expedita qui et molestiae corrupti.", new DateTimeOffset(new DateTime(2021, 2, 24, 16, 34, 32, 70, DateTimeKind.Unspecified).AddTicks(8610), new TimeSpan(0, -3, 0, 0, 0)), "id", "Two", "upgradable_facilitator_home__garden_&_jewelery.pdf", 0.1190131917541015199038455598m, new Guid("059b00ff-5821-4a9a-95b6-36f42c6d9849"), -1752806857, -1522499283 },
                    { new Guid("2dc40f32-394d-4d00-a11b-8f3f3e682199"), "Aut debitis sit voluptatem quis dolores.", new DateTimeOffset(new DateTime(2021, 3, 15, 19, 34, 48, 349, DateTimeKind.Unspecified).AddTicks(60), new TimeSpan(0, -3, 0, 0, 0)), "nobis", "One", "primary_budgetary_management.shtml", 0.4655323607678552017440346688m, new Guid("059b00ff-5821-4a9a-95b6-36f42c6d9849"), -1835792590, 548468186 },
                    { new Guid("a76ef158-d563-4b19-9eda-44e2cf61c257"), "Porro est dolor ad quibusdam laborum quod.", new DateTimeOffset(new DateTime(2021, 3, 18, 3, 57, 8, 614, DateTimeKind.Unspecified).AddTicks(7276), new TimeSpan(0, -3, 0, 0, 0)), "sapiente", "Three", "violet_liaison_regional.wav", 0.7099313188565726639114294545m, new Guid("059b00ff-5821-4a9a-95b6-36f42c6d9849"), 1120328551, 422856575 },
                    { new Guid("b6df6e39-e89e-47a6-86ba-e1c1731153ca"), "Consequatur qui fugiat odio enim voluptatum libero reprehenderit rerum quia.", new DateTimeOffset(new DateTime(2021, 1, 8, 17, 51, 30, 601, DateTimeKind.Unspecified).AddTicks(4979), new TimeSpan(0, -3, 0, 0, 0)), "asperiores", "Three", "invoice.mpg4", 0.8969866252591404898682960543m, new Guid("059b00ff-5821-4a9a-95b6-36f42c6d9849"), -1680015234, 1654909226 },
                    { new Guid("8264de00-7e7a-4077-895e-2822d7c604a4"), "Amet sed officiis dolorem incidunt cumque omnis dolor.", new DateTimeOffset(new DateTime(2021, 5, 11, 19, 48, 54, 917, DateTimeKind.Unspecified).AddTicks(1907), new TimeSpan(0, -3, 0, 0, 0)), "assumenda", "One", "ethiopian_birr_consultant_violet.mp2a", 0.3436509478710859041515680574m, new Guid("059b00ff-5821-4a9a-95b6-36f42c6d9849"), -862880450, -1144127978 },
                    { new Guid("38fc9e49-cfb5-486e-99f5-609d06602cad"), "At aperiam deserunt eos totam.", new DateTimeOffset(new DateTime(2021, 4, 12, 13, 31, 28, 760, DateTimeKind.Unspecified).AddTicks(2705), new TimeSpan(0, -3, 0, 0, 0)), "dignissimos", "Three", "clear_thinking_supervisor_suriname.mpg4", 0.464845846656858661007957371m, new Guid("059b00ff-5821-4a9a-95b6-36f42c6d9849"), -1920588801, -1338718242 },
                    { new Guid("b5e1223e-98bd-48d6-9380-11d0ccecec0c"), "Eligendi enim illum perspiciatis consequuntur.", new DateTimeOffset(new DateTime(2021, 2, 5, 20, 29, 34, 271, DateTimeKind.Unspecified).AddTicks(8790), new TimeSpan(0, -3, 0, 0, 0)), "pariatur", "Three", "bedfordshire_cotton_arizona.pdf", 0.6358834562785836513110541414m, new Guid("059b00ff-5821-4a9a-95b6-36f42c6d9849"), -161005178, -945024895 },
                    { new Guid("b281d7fe-2b2b-4a59-8a89-16b4d02d6002"), "Mollitia nulla voluptate nostrum iusto omnis rem totam asperiores.", new DateTimeOffset(new DateTime(2020, 11, 24, 12, 14, 41, 369, DateTimeKind.Unspecified).AddTicks(6741), new TimeSpan(0, -3, 0, 0, 0)), "odio", "Three", "trinidad_and_tobago_compressing_online.pdf", 0.1861921032243692505812523007m, new Guid("059b00ff-5821-4a9a-95b6-36f42c6d9849"), 1896739424, 1915661590 },
                    { new Guid("a8096e8f-18bc-44fa-8f29-3cbd794c37ec"), "Natus perspiciatis placeat est nostrum quibusdam quod beatae.", new DateTimeOffset(new DateTime(2020, 12, 16, 12, 36, 48, 351, DateTimeKind.Unspecified).AddTicks(6898), new TimeSpan(0, -3, 0, 0, 0)), "et", "Three", "generic_steel_salad_purple.png", 0.6500673113313861777176379225m, new Guid("059b00ff-5821-4a9a-95b6-36f42c6d9849"), -366350451, 1211178931 },
                    { new Guid("3ba124b1-742c-4163-9723-7af194041109"), "Laudantium quia consequatur dicta eveniet nemo perferendis et.", new DateTimeOffset(new DateTime(2020, 11, 3, 12, 32, 25, 94, DateTimeKind.Unspecified).AddTicks(5442), new TimeSpan(0, -3, 0, 0, 0)), "esse", "Three", "nakfa_borders_berkshire.gif", 0.5908617181141403752872951538m, new Guid("059b00ff-5821-4a9a-95b6-36f42c6d9849"), -2026685433, -1238681101 },
                    { new Guid("c21ad3f5-7f95-4e56-a825-29012f934fa4"), "Quod doloribus veritatis non occaecati modi rerum expedita.", new DateTimeOffset(new DateTime(2020, 12, 6, 18, 24, 11, 264, DateTimeKind.Unspecified).AddTicks(6978), new TimeSpan(0, -3, 0, 0, 0)), "et", "Two", "http.pdf", 0.7289801896870299517778267633m, new Guid("059b00ff-5821-4a9a-95b6-36f42c6d9849"), -354825905, 1756986064 },
                    { new Guid("47634ffa-53a4-43f4-bf1b-fd5a8184fc2c"), "Quis iure aut corrupti quae et.", new DateTimeOffset(new DateTime(2021, 1, 15, 17, 44, 32, 240, DateTimeKind.Unspecified).AddTicks(6310), new TimeSpan(0, -3, 0, 0, 0)), "et", "Three", "withdrawal_bedfordshire.pdf", 0.4647725638118447993996490177m, new Guid("059b00ff-5821-4a9a-95b6-36f42c6d9849"), 1304587724, -1299933335 },
                    { new Guid("4248fe54-51a9-481b-8973-5903747cc571"), "Eos autem consequuntur iusto in illo.", new DateTimeOffset(new DateTime(2020, 11, 9, 16, 52, 58, 375, DateTimeKind.Unspecified).AddTicks(3179), new TimeSpan(0, -3, 0, 0, 0)), "ut", "One", "invoice.m2v", 0.689707826189577230017495704m, new Guid("adcbcdc3-cb25-44d0-aa77-89cf7a9c7153"), 1364827724, -1484623805 },
                    { new Guid("1fd3e239-b3bb-43ee-8c51-a773835e50a8"), "Id est vero consequuntur voluptatum ipsa.", new DateTimeOffset(new DateTime(2021, 5, 11, 16, 2, 24, 333, DateTimeKind.Unspecified).AddTicks(1706), new TimeSpan(0, -3, 0, 0, 0)), "quibusdam", "Three", "lesotho_loti_refined_rubber_chair.shtml", 0.5429116419536869687929384788m, new Guid("adcbcdc3-cb25-44d0-aa77-89cf7a9c7153"), 156219475, 969777779 },
                    { new Guid("084d5a10-1875-4bca-9ff4-08b37379893e"), "Non perspiciatis autem pariatur quasi et dolore.", new DateTimeOffset(new DateTime(2021, 2, 28, 17, 59, 38, 163, DateTimeKind.Unspecified).AddTicks(6651), new TimeSpan(0, -3, 0, 0, 0)), "dolorum", "Three", "primary.m2v", 0.2919590241926060138769408534m, new Guid("adcbcdc3-cb25-44d0-aa77-89cf7a9c7153"), -1393934895, -497168835 },
                    { new Guid("20d45f52-12a9-49b3-9fa4-7c6bf582f8f0"), "Iure amet quas eligendi occaecati deleniti placeat dolorem aut aliquam.", new DateTimeOffset(new DateTime(2021, 4, 21, 14, 43, 11, 411, DateTimeKind.Unspecified).AddTicks(4229), new TimeSpan(0, -3, 0, 0, 0)), "qui", "Three", "executive_ameliorated.pdf", 0.0765260349020219327594337257m, new Guid("adcbcdc3-cb25-44d0-aa77-89cf7a9c7153"), -1900717496, -1108303290 },
                    { new Guid("da1df08c-b5e9-4588-96d2-9e08ed995e19"), "Excepturi earum dicta.", new DateTimeOffset(new DateTime(2021, 2, 17, 23, 58, 58, 57, DateTimeKind.Unspecified).AddTicks(9611), new TimeSpan(0, -3, 0, 0, 0)), "autem", "One", "response_mill_smtp.jpe", 0.6771927152106310208833630834m, new Guid("77563075-6e97-4fa6-b927-e7467fca1eef"), 1848555460, 1911637293 },
                    { new Guid("41562997-1443-42a4-bd8c-5a480f0dae4e"), "Ut quisquam reiciendis veritatis error itaque quo blanditiis minima repellat.", new DateTimeOffset(new DateTime(2020, 8, 2, 23, 23, 25, 670, DateTimeKind.Unspecified).AddTicks(6365), new TimeSpan(0, -3, 0, 0, 0)), "provident", "Two", "initiatives_books.png", 0.5239162225942858735071443871m, new Guid("77563075-6e97-4fa6-b927-e7467fca1eef"), 804636033, -1758208480 },
                    { new Guid("ba1d27ed-41e0-4132-973c-b28fde1ba278"), "Est aut repellendus ratione iusto aperiam dolor dicta quam placeat.", new DateTimeOffset(new DateTime(2021, 6, 30, 2, 12, 46, 620, DateTimeKind.Unspecified).AddTicks(599), new TimeSpan(0, -3, 0, 0, 0)), "mollitia", "Three", "website_metal_sleek_soft_salad.shtml", 0.2131732951416561108068106515m, new Guid("77563075-6e97-4fa6-b927-e7467fca1eef"), 2077971103, 821979656 },
                    { new Guid("5910a0c0-20ab-4d72-a537-ec16682afa78"), "Ut tempora consequuntur consequatur.", new DateTimeOffset(new DateTime(2021, 5, 24, 16, 9, 35, 33, DateTimeKind.Unspecified).AddTicks(117), new TimeSpan(0, -3, 0, 0, 0)), "rerum", "One", "iraqi_dinar.mpe", 0.5913438407511906258312537591m, new Guid("77563075-6e97-4fa6-b927-e7467fca1eef"), 1431810734, 826072615 },
                    { new Guid("9a162721-a44d-4a0b-b411-c13cc1a65bf3"), "Ipsam corporis laudantium esse et commodi est.", new DateTimeOffset(new DateTime(2021, 6, 1, 2, 50, 23, 460, DateTimeKind.Unspecified).AddTicks(6280), new TimeSpan(0, -3, 0, 0, 0)), "sed", "Three", "online_applications_representative.mp4", 0.5447053174956262790993096593m, new Guid("77563075-6e97-4fa6-b927-e7467fca1eef"), -461831353, -1495460688 },
                    { new Guid("6026f4c3-0740-4b17-b734-f2b09e8e4fbc"), "Aliquid temporibus aut et expedita.", new DateTimeOffset(new DateTime(2021, 4, 22, 15, 42, 1, 886, DateTimeKind.Unspecified).AddTicks(7497), new TimeSpan(0, -3, 0, 0, 0)), "ea", "Three", "integrate_row.mpg4", 0.6992173207954006432008399465m, new Guid("77563075-6e97-4fa6-b927-e7467fca1eef"), 44266166, 1148834060 },
                    { new Guid("82e965de-7bbe-4170-8e28-d2da22e5045d"), "Dolor beatae illum facere voluptatem neque.", new DateTimeOffset(new DateTime(2021, 1, 21, 22, 24, 7, 125, DateTimeKind.Unspecified).AddTicks(8155), new TimeSpan(0, -3, 0, 0, 0)), "saepe", "One", "hard_drive_incredible_cotton_gloves_music__clothing_&_books.jpg", 0.2609297952621578049124692442m, new Guid("77563075-6e97-4fa6-b927-e7467fca1eef"), 1710069284, 256678717 },
                    { new Guid("3b32d8d8-9e06-4780-b041-d08024da5b7b"), "Et ut veniam qui sunt sit eveniet.", new DateTimeOffset(new DateTime(2021, 1, 21, 9, 7, 27, 980, DateTimeKind.Unspecified).AddTicks(7623), new TimeSpan(0, -3, 0, 0, 0)), "mollitia", "Three", "rss.m3a", 0.8863683489000210023310920522m, new Guid("77563075-6e97-4fa6-b927-e7467fca1eef"), 1504446395, 1455542705 },
                    { new Guid("363720ba-f91b-49bd-a8ff-e05ce856a905"), "Inventore labore temporibus enim in ut sed magnam exercitationem.", new DateTimeOffset(new DateTime(2021, 2, 22, 4, 11, 28, 34, DateTimeKind.Unspecified).AddTicks(5278), new TimeSpan(0, -3, 0, 0, 0)), "commodi", "One", "leverage_blue_smtp.mpe", 0.0777496753127967719569267763m, new Guid("77563075-6e97-4fa6-b927-e7467fca1eef"), -1475959454, 1509031842 },
                    { new Guid("3bfe07ab-4ec3-4914-829e-0aa19bb1b713"), "Sed perferendis consequatur et harum impedit sed est.", new DateTimeOffset(new DateTime(2020, 10, 14, 14, 30, 9, 914, DateTimeKind.Unspecified).AddTicks(5552), new TimeSpan(0, -3, 0, 0, 0)), "corrupti", "One", "port_unbranded_rubber_table.htm", 0.6886681380208842648336936335m, new Guid("77563075-6e97-4fa6-b927-e7467fca1eef"), 1930270419, 1127582787 },
                    { new Guid("ce36b9da-d092-4b62-80bb-66bc0d84c5ec"), "Exercitationem neque sed.", new DateTimeOffset(new DateTime(2021, 6, 13, 2, 48, 12, 688, DateTimeKind.Unspecified).AddTicks(9038), new TimeSpan(0, -3, 0, 0, 0)), "et", "Three", "collaboration_evolve.gif", 0.1485792720557672015226105759m, new Guid("059b00ff-5821-4a9a-95b6-36f42c6d9849"), -455209136, -300774856 },
                    { new Guid("007e2615-76fb-4797-a6b7-153776205474"), "Amet explicabo dolor similique illum quia.", new DateTimeOffset(new DateTime(2020, 10, 19, 13, 4, 8, 174, DateTimeKind.Unspecified).AddTicks(3031), new TimeSpan(0, -3, 0, 0, 0)), "reiciendis", "One", "system.mpg4", 0.1956164609161283548890878113m, new Guid("77563075-6e97-4fa6-b927-e7467fca1eef"), 576536332, 1128111987 },
                    { new Guid("023dfe5b-bc0a-4726-949a-a1f9a0cc4d9e"), "Vero ut maiores laboriosam voluptatum suscipit id blanditiis qui.", new DateTimeOffset(new DateTime(2021, 3, 29, 5, 54, 15, 92, DateTimeKind.Unspecified).AddTicks(3043), new TimeSpan(0, -3, 0, 0, 0)), "dolore", "Two", "generate.gif", 0.4229931449968600322070115301m, new Guid("77563075-6e97-4fa6-b927-e7467fca1eef"), 155629802, 366800226 },
                    { new Guid("5f4795fe-505c-4304-892c-3ad05b3a5775"), "Omnis ea doloremque quia.", new DateTimeOffset(new DateTime(2020, 12, 13, 8, 43, 39, 984, DateTimeKind.Unspecified).AddTicks(7981), new TimeSpan(0, -3, 0, 0, 0)), "mollitia", "Three", "sleek_intelligent_concrete_salad_bi_directional.mpe", 0.9737382135148176511833727316m, new Guid("77563075-6e97-4fa6-b927-e7467fca1eef"), -1254690841, -903867649 },
                    { new Guid("1130bbbd-15d8-4ee2-8370-97d4d21f3b9b"), "Sit non adipisci amet illo.", new DateTimeOffset(new DateTime(2021, 3, 31, 16, 45, 56, 243, DateTimeKind.Unspecified).AddTicks(8382), new TimeSpan(0, -3, 0, 0, 0)), "consequuntur", "One", "ghana_sleek.mpg4", 0.5442267046919565054556412204m, new Guid("adcbcdc3-cb25-44d0-aa77-89cf7a9c7153"), 3060078, -1074365527 },
                    { new Guid("45726199-36c4-454f-9c4a-0f0439c928b1"), "Laboriosam exercitationem quia odit rerum quia dolore.", new DateTimeOffset(new DateTime(2021, 3, 9, 7, 47, 17, 927, DateTimeKind.Unspecified).AddTicks(2870), new TimeSpan(0, -3, 0, 0, 0)), "laboriosam", "One", "auxiliary.mpga", 0.5255873025223053229954595736m, new Guid("adcbcdc3-cb25-44d0-aa77-89cf7a9c7153"), 1819392340, 95534002 }
                });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "Description", "IntroduceAt", "Name", "Option", "PhotoFileName", "Price", "ProductTypeId", "Rating", "Stock" },
                values: new object[,]
                {
                    { new Guid("169e465d-df20-479e-a3d5-4dfb96ed688a"), "Deserunt error nesciunt est eveniet nulla voluptates.", new DateTimeOffset(new DateTime(2020, 8, 4, 2, 3, 2, 600, DateTimeKind.Unspecified).AddTicks(8123), new TimeSpan(0, -3, 0, 0, 0)), "et", "Three", "burkina_faso_alabama_copy.htm", 0.300687550351743267145390609m, new Guid("adcbcdc3-cb25-44d0-aa77-89cf7a9c7153"), 656449355, -1130075871 },
                    { new Guid("b660a2bf-b13d-43ee-bb2c-43f455a4fe95"), "Doloremque enim accusamus provident dolor.", new DateTimeOffset(new DateTime(2020, 8, 6, 17, 50, 7, 92, DateTimeKind.Unspecified).AddTicks(2153), new TimeSpan(0, -3, 0, 0, 0)), "vel", "Three", "brooks.mp4", 0.5797581981148521017109817486m, new Guid("adcbcdc3-cb25-44d0-aa77-89cf7a9c7153"), -1967378993, 138844267 },
                    { new Guid("7f04598e-0596-4141-ba04-30ef378be2fb"), "Dolor consequatur repellendus necessitatibus consequuntur eaque occaecati ut vitae qui.", new DateTimeOffset(new DateTime(2021, 2, 6, 21, 49, 51, 175, DateTimeKind.Unspecified).AddTicks(2149), new TimeSpan(0, -3, 0, 0, 0)), "dolor", "One", "matrix_tertiary.mp4v", 0.2598383265850689116039089721m, new Guid("adcbcdc3-cb25-44d0-aa77-89cf7a9c7153"), -1268733365, 1241428926 },
                    { new Guid("f77cfc0b-9305-4ca7-b001-a1f4a13c6dbd"), "Quod numquam quisquam perferendis.", new DateTimeOffset(new DateTime(2020, 8, 18, 14, 52, 9, 456, DateTimeKind.Unspecified).AddTicks(3906), new TimeSpan(0, -3, 0, 0, 0)), "suscipit", "Three", "home_loan_account_withdrawal.png", 0.5886914423167658677396645519m, new Guid("adcbcdc3-cb25-44d0-aa77-89cf7a9c7153"), 627888246, -23767516 },
                    { new Guid("9a569985-5140-442b-97f3-7c2528e53d29"), "Molestiae nam tempora.", new DateTimeOffset(new DateTime(2020, 9, 11, 11, 23, 30, 895, DateTimeKind.Unspecified).AddTicks(4580), new TimeSpan(0, -3, 0, 0, 0)), "ut", "One", "bypass_user_centric_payment.pdf", 0.244840821171713247378281287m, new Guid("adcbcdc3-cb25-44d0-aa77-89cf7a9c7153"), -175384519, 1987519711 },
                    { new Guid("66e9ee47-38f6-4825-a5a6-088aa05d2c78"), "Totam et et atque cum nulla eius iure.", new DateTimeOffset(new DateTime(2021, 6, 23, 9, 37, 16, 56, DateTimeKind.Unspecified).AddTicks(6160), new TimeSpan(0, -3, 0, 0, 0)), "quo", "Two", "system_principal_adp.jpe", 0.9198906801305100433233638206m, new Guid("adcbcdc3-cb25-44d0-aa77-89cf7a9c7153"), -283516392, 1323255039 },
                    { new Guid("e0f5f2c4-3930-4353-b3d9-ee049d4bd0e3"), "Dolorum dolorem quas rerum sunt.", new DateTimeOffset(new DateTime(2020, 11, 9, 0, 56, 36, 574, DateTimeKind.Unspecified).AddTicks(7832), new TimeSpan(0, -3, 0, 0, 0)), "earum", "One", "e_tailers.html", 0.496222962922515735870755214m, new Guid("77563075-6e97-4fa6-b927-e7467fca1eef"), 1390622677, -117659637 },
                    { new Guid("88508671-2e52-446b-b5fb-147ccf10528b"), "Distinctio sunt porro veniam enim dolorum officia aut eum.", new DateTimeOffset(new DateTime(2021, 5, 6, 1, 29, 59, 405, DateTimeKind.Unspecified).AddTicks(6157), new TimeSpan(0, -3, 0, 0, 0)), "quia", "One", "e_commerce_synthesizing.mpg4", 0.7041807970348114000786665057m, new Guid("059b00ff-5821-4a9a-95b6-36f42c6d9849"), 1203988474, -1355882952 }
                });

            migrationBuilder.InsertData(
                table: "Reviews",
                columns: new[] { "Id", "Comment", "ProductId", "Title" },
                values: new object[,]
                {
                    { new Guid("b32026d6-bcd4-4395-b604-e1668cc16fcf"), "Ipsam perferendis a ipsam rerum.", new Guid("574dd632-4bbd-468b-b985-5b6b8fbfa32d"), "dignissimos" },
                    { new Guid("36fe5727-aa65-486d-966d-56535bc0a6be"), "Ratione culpa animi maiores excepturi.", new Guid("1713f998-d79b-48a5-a000-caee10c14393"), "suscipit" },
                    { new Guid("a87cf7b8-7949-46ab-8b99-031617462e54"), "Qui expedita voluptas.", new Guid("6c48fed6-fba7-49fb-9244-c5dd17585cb1"), "consequatur" },
                    { new Guid("d1066d03-06a4-43bf-a7f3-1ed7f7c6bc55"), "Et beatae quidem explicabo.", new Guid("a3c1ee5c-d5c1-4b81-958a-a2f1555f2e7e"), "nesciunt" },
                    { new Guid("8de30d4a-83e1-4ce4-a517-a0ab17ca80e3"), "Est ducimus aspernatur cumque ut a totam in.", new Guid("997e50b0-07db-4a50-a52c-4696fb765b91"), "rerum" },
                    { new Guid("7815f66e-75de-49c2-a70d-17fba4aa241a"), "Harum corporis magni molestias laudantium nulla omnis facere error amet.", new Guid("148ce96e-0d75-4b70-90e1-c13fefe1454b"), "impedit" },
                    { new Guid("ba20a3be-457f-42a5-a9e1-0cdd0fa82e87"), "Aut animi neque.", new Guid("5836cfbb-c041-42c4-8a26-4e071a5e9c92"), "consectetur" },
                    { new Guid("67bd16f3-2720-4224-9d06-cc81079a4162"), "Aut asperiores optio autem atque sequi velit.", new Guid("d062c082-351d-405c-ae53-dcb3b356a825"), "quis" },
                    { new Guid("a191efda-7ec0-4860-8015-d188fa6acd47"), "Consequatur voluptatem labore eos voluptate eius dicta pariatur iure modi.", new Guid("cddc1e4b-b11a-4354-bd1d-38c347b73924"), "totam" },
                    { new Guid("0a2cde97-22a5-4c7c-b96b-309db65ecf93"), "Explicabo consequatur fugiat.", new Guid("adb244f4-93b0-46cc-9ca3-f689ddec33d5"), "reiciendis" },
                    { new Guid("2e6ba3de-5264-4771-8e84-7c21b32d0b35"), "Qui aliquam consequuntur modi sed asperiores.", new Guid("3c7f4fa0-f12c-4f36-923b-a77d646b0c96"), "nemo" },
                    { new Guid("c2bea636-c8ad-44bc-a4d3-2bb40e2d16da"), "Dolorum tempora omnis explicabo.", new Guid("2dc40f32-394d-4d00-a11b-8f3f3e682199"), "illum" },
                    { new Guid("b85af1d4-8ef9-4cb3-b1fb-74335845c3c0"), "Fuga voluptas cum quam expedita commodi asperiores mollitia vero.", new Guid("a76ef158-d563-4b19-9eda-44e2cf61c257"), "perferendis" },
                    { new Guid("fa2ac92b-d305-4575-887d-74e89f3d89e5"), "Impedit ut dolorem tempore.", new Guid("b6df6e39-e89e-47a6-86ba-e1c1731153ca"), "inventore" },
                    { new Guid("d7b14a11-0dab-40e2-b74a-60e522156340"), "Quis ipsa consectetur repellat distinctio.", new Guid("8264de00-7e7a-4077-895e-2822d7c604a4"), "iste" },
                    { new Guid("ff0bb057-10e4-4a6d-ae76-da350296b04e"), "Saepe soluta est dolorem.", new Guid("38fc9e49-cfb5-486e-99f5-609d06602cad"), "est" },
                    { new Guid("e389be72-e948-49a2-88e7-258ddf3e79f2"), "Qui impedit facere velit quia sed.", new Guid("b5e1223e-98bd-48d6-9380-11d0ccecec0c"), "molestiae" },
                    { new Guid("4eecddcb-c45e-4993-ae0b-19dea6bf9e31"), "Quasi veritatis enim quis soluta autem.", new Guid("b281d7fe-2b2b-4a59-8a89-16b4d02d6002"), "ad" },
                    { new Guid("36442e9b-c307-42a8-8c6c-cffefc169a02"), "Nihil cum dicta sunt illo suscipit doloribus odit dolorum.", new Guid("a8096e8f-18bc-44fa-8f29-3cbd794c37ec"), "architecto" },
                    { new Guid("0eb32d5b-ab7e-4e32-b3d1-20b1357ba73b"), "Quasi et unde.", new Guid("3ba124b1-742c-4163-9723-7af194041109"), "vero" },
                    { new Guid("00b7a9ac-4731-436d-a1dd-7d8116da992f"), "Sed enim quidem dignissimos repellendus accusamus earum.", new Guid("c21ad3f5-7f95-4e56-a825-29012f934fa4"), "non" },
                    { new Guid("d0a33148-7aac-4619-97d4-d25b42afcdcc"), "Dicta dolore laudantium nulla et consectetur reiciendis odio aut saepe.", new Guid("47634ffa-53a4-43f4-bf1b-fd5a8184fc2c"), "distinctio" },
                    { new Guid("f1670d72-02ce-4c61-a770-1088965694d9"), "Odio placeat minus debitis sint suscipit officia sed et.", new Guid("4248fe54-51a9-481b-8973-5903747cc571"), "qui" },
                    { new Guid("bb219472-baf2-4b7f-b372-8540343d8e65"), "Hic sequi eum et voluptates natus quidem inventore mollitia.", new Guid("1fd3e239-b3bb-43ee-8c51-a773835e50a8"), "corrupti" },
                    { new Guid("291810ee-01e0-42db-8d35-cb51ef6f507a"), "Maiores repellendus enim aut.", new Guid("084d5a10-1875-4bca-9ff4-08b37379893e"), "maxime" },
                    { new Guid("410bd3ef-86da-48a0-ad5b-e9f7d4de2d14"), "Et officia iste autem sunt et nulla accusamus praesentium.", new Guid("20d45f52-12a9-49b3-9fa4-7c6bf582f8f0"), "ut" },
                    { new Guid("66ed4e3f-8685-4405-b1a2-33366f0b0dac"), "Doloremque voluptate amet mollitia occaecati similique quia nihil.", new Guid("da1df08c-b5e9-4588-96d2-9e08ed995e19"), "sed" },
                    { new Guid("ed30172a-a2e6-4bf3-ac57-326c6ed30e62"), "Provident vero natus occaecati.", new Guid("41562997-1443-42a4-bd8c-5a480f0dae4e"), "explicabo" },
                    { new Guid("d8eb5936-7cfd-4d66-ace3-ed87ded26ab5"), "Architecto fugiat voluptate.", new Guid("ba1d27ed-41e0-4132-973c-b28fde1ba278"), "odio" },
                    { new Guid("15528ec9-d969-4b47-89d7-a33cd645a1a7"), "At ut repudiandae dolores et ut.", new Guid("5910a0c0-20ab-4d72-a537-ec16682afa78"), "et" },
                    { new Guid("dd47c92a-a0df-4b74-a4b1-37099bab36a7"), "Vitae vel modi odio molestias velit sit omnis.", new Guid("9a162721-a44d-4a0b-b411-c13cc1a65bf3"), "fuga" },
                    { new Guid("2850b744-9f4e-4f9d-bbe3-481723e220a8"), "Eveniet provident possimus vel consequuntur.", new Guid("6026f4c3-0740-4b17-b734-f2b09e8e4fbc"), "et" },
                    { new Guid("486a5421-2a35-4704-b3a6-af330d0a94a4"), "Ducimus doloribus et pariatur non.", new Guid("82e965de-7bbe-4170-8e28-d2da22e5045d"), "veritatis" },
                    { new Guid("9d2ffd0b-6300-485b-a844-0ab5a6aeb5ae"), "Exercitationem et velit est adipisci nostrum.", new Guid("3b32d8d8-9e06-4780-b041-d08024da5b7b"), "perferendis" },
                    { new Guid("d83964f1-6afb-440e-a4a5-68e26814d190"), "Vel non et ea fugit quidem quisquam non error.", new Guid("363720ba-f91b-49bd-a8ff-e05ce856a905"), "qui" },
                    { new Guid("0594a6af-bb03-4fab-9464-73476fa49168"), "Sed amet qui cum dolor porro.", new Guid("3bfe07ab-4ec3-4914-829e-0aa19bb1b713"), "beatae" },
                    { new Guid("f4b3cb38-bdfd-4f73-8ea5-5b4dc4cc455b"), "Quia id voluptatum et nihil adipisci.", new Guid("ce36b9da-d092-4b62-80bb-66bc0d84c5ec"), "distinctio" },
                    { new Guid("4ec0f6bd-12fc-4090-a5c1-69181b38d39a"), "Doloremque facilis corporis totam inventore qui ea architecto provident quas.", new Guid("007e2615-76fb-4797-a6b7-153776205474"), "corrupti" },
                    { new Guid("19c3f464-c4cb-419f-a73c-827de685c1b4"), "Velit ullam soluta voluptatem corporis.", new Guid("023dfe5b-bc0a-4726-949a-a1f9a0cc4d9e"), "aut" },
                    { new Guid("9814e6ba-8cb8-42ee-a1bf-650162c8c635"), "Fugiat est deleniti qui soluta maxime magni perferendis aliquid cumque.", new Guid("5f4795fe-505c-4304-892c-3ad05b3a5775"), "ut" },
                    { new Guid("db7383dc-a66f-45d5-9702-8348e5e509a3"), "Et assumenda dolorum officia alias possimus blanditiis est delectus iste.", new Guid("1130bbbd-15d8-4ee2-8370-97d4d21f3b9b"), "est" },
                    { new Guid("ee7e389e-fe4f-4c62-aa30-9667b08448d6"), "In temporibus sit nemo nisi.", new Guid("45726199-36c4-454f-9c4a-0f0439c928b1"), "vitae" }
                });

            migrationBuilder.InsertData(
                table: "Reviews",
                columns: new[] { "Id", "Comment", "ProductId", "Title" },
                values: new object[,]
                {
                    { new Guid("dcb0be34-1e5f-4731-a2fe-18cb53e84e75"), "Laborum vero unde dolores odio qui ea et non.", new Guid("169e465d-df20-479e-a3d5-4dfb96ed688a"), "ipsam" },
                    { new Guid("b869f231-fc4a-4190-83d9-41e90527d699"), "Consequatur tempora maxime quibusdam.", new Guid("b660a2bf-b13d-43ee-bb2c-43f455a4fe95"), "sint" },
                    { new Guid("5f4ae97d-7b18-4fd0-a773-0d09372df007"), "Nobis maxime et velit voluptatem.", new Guid("7f04598e-0596-4141-ba04-30ef378be2fb"), "fugit" },
                    { new Guid("e7fb674f-b59d-40b4-a716-39926cdf3239"), "Veniam ut quaerat ut sunt.", new Guid("f77cfc0b-9305-4ca7-b001-a1f4a13c6dbd"), "quis" },
                    { new Guid("8033c9a1-4e09-494c-8b84-e84182ed8c30"), "Ut odit optio ducimus quia aperiam.", new Guid("9a569985-5140-442b-97f3-7c2528e53d29"), "et" },
                    { new Guid("4e8cf4a1-8fde-4e46-b1bc-b5ea84a2f5d6"), "Consequuntur atque at perspiciatis.", new Guid("66e9ee47-38f6-4825-a5a6-088aa05d2c78"), "provident" },
                    { new Guid("84dfa1cf-2211-40a5-ac70-7b5219dd6a64"), "Sapiente aut explicabo.", new Guid("e0f5f2c4-3930-4353-b3d9-ee049d4bd0e3"), "sed" },
                    { new Guid("0944c5cb-f9b0-4747-b60d-09f5a45a6908"), "At nostrum suscipit error aliquam.", new Guid("88508671-2e52-446b-b5fb-147ccf10528b"), "eveniet" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Products_ProductTypeId",
                table: "Products",
                column: "ProductTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_ProductTypes_Discriminator",
                table: "ProductTypes",
                column: "Discriminator",
                unique: true);

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
