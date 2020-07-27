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

            migrationBuilder.InsertData(
                table: "ProductTypes",
                columns: new[] { "Id", "Discriminator" },
                values: new object[] { new Guid("06bb4b7f-9e8b-4376-bb6b-a794f7cfcd1c"), "TypeOne" });

            migrationBuilder.InsertData(
                table: "ProductTypes",
                columns: new[] { "Id", "Discriminator" },
                values: new object[] { new Guid("dd9205e8-a3cd-45b8-8c3d-230640f646cd"), "TypeThree" });

            migrationBuilder.InsertData(
                table: "ProductTypes",
                columns: new[] { "Id", "Discriminator" },
                values: new object[] { new Guid("739f36aa-a68d-4403-880e-decb2043d028"), "TypeTwo" });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "Description", "IntroduceAt", "Name", "PhotoFileName", "Price", "ProductTypeId", "Rating", "Stock" },
                values: new object[,]
                {
                    { new Guid("9b4d3cde-f490-4420-8ca9-80d1026e5b93"), "Aut aperiam sint cupiditate suscipit doloremque velit ab.", new DateTimeOffset(new DateTime(2020, 9, 16, 10, 10, 1, 496, DateTimeKind.Unspecified).AddTicks(4632), new TimeSpan(0, -3, 0, 0, 0)), "molestias", "collaboration.img", 0.559778675943896841887785444m, new Guid("06bb4b7f-9e8b-4376-bb6b-a794f7cfcd1c"), -408755436, -747845058 },
                    { new Guid("7d4b1d9f-dc56-464c-9350-a5f47d4f020d"), "Commodi sit id dolorem accusamus aperiam qui illum beatae.", new DateTimeOffset(new DateTime(2021, 2, 13, 10, 15, 31, 665, DateTimeKind.Unspecified).AddTicks(5931), new TimeSpan(0, -3, 0, 0, 0)), "amet", "personal_loan_account_incredible_rubber_bacon_metal.xer", 0.1762598164836307889609111607m, new Guid("06bb4b7f-9e8b-4376-bb6b-a794f7cfcd1c"), 357652983, -836434968 },
                    { new Guid("a0c38446-a65c-474e-861a-61e8ba609dcf"), "Fugiat voluptatem perspiciatis.", new DateTimeOffset(new DateTime(2021, 4, 14, 5, 28, 2, 958, DateTimeKind.Unspecified).AddTicks(3746), new TimeSpan(0, -3, 0, 0, 0)), "occaecati", "islands_parks_handmade.mods", 0.0007336392685616688979054662m, new Guid("06bb4b7f-9e8b-4376-bb6b-a794f7cfcd1c"), -35964742, 1140036655 },
                    { new Guid("a2bbc65c-2e42-4d02-809b-e466f4ed52b3"), "Aut esse architecto ea saepe inventore perferendis.", new DateTimeOffset(new DateTime(2021, 4, 2, 19, 21, 12, 430, DateTimeKind.Unspecified).AddTicks(7779), new TimeSpan(0, -3, 0, 0, 0)), "modi", "investment_account_personal_loan_account_instruction_set.gram", 0.435011263194153713064890736m, new Guid("06bb4b7f-9e8b-4376-bb6b-a794f7cfcd1c"), 1120963780, -230307100 },
                    { new Guid("d4ca001c-8f84-4693-9469-ee72f27eae2a"), "Illo omnis eligendi consequuntur vero officiis enim.", new DateTimeOffset(new DateTime(2020, 9, 20, 14, 39, 19, 801, DateTimeKind.Unspecified).AddTicks(1884), new TimeSpan(0, -3, 0, 0, 0)), "eveniet", "sas_administrator_shoal.teacher", 0.7117798803194497755033325904m, new Guid("06bb4b7f-9e8b-4376-bb6b-a794f7cfcd1c"), 214128880, 334966245 },
                    { new Guid("2f36f2b0-ae94-4077-ac87-cb76270768c3"), "Aut consequatur voluptas qui.", new DateTimeOffset(new DateTime(2020, 9, 5, 1, 24, 6, 807, DateTimeKind.Unspecified).AddTicks(7892), new TimeSpan(0, -3, 0, 0, 0)), "autem", "navigate_pennsylvania_website.3ds", 0.1834971273247461196075446211m, new Guid("dd9205e8-a3cd-45b8-8c3d-230640f646cd"), 366097674, -1545964952 },
                    { new Guid("de037ed8-ab6f-4ac8-bf0d-db691d81edbb"), "Quia aut commodi blanditiis harum omnis et in dignissimos qui.", new DateTimeOffset(new DateTime(2020, 9, 11, 5, 12, 53, 66, DateTimeKind.Unspecified).AddTicks(5479), new TimeSpan(0, -3, 0, 0, 0)), "consequuntur", "home_deposit_copy.pfm", 0.7653658067932682214549310765m, new Guid("739f36aa-a68d-4403-880e-decb2043d028"), 1150695667, -1610454430 },
                    { new Guid("d5933fac-b6e4-499b-9d43-883f7cceaaee"), "Velit dolorem corporis.", new DateTimeOffset(new DateTime(2021, 4, 4, 11, 20, 55, 330, DateTimeKind.Unspecified).AddTicks(9586), new TimeSpan(0, -3, 0, 0, 0)), "nobis", "rapids_calculate_practical.m14", 0.8591262005794074655010761927m, new Guid("739f36aa-a68d-4403-880e-decb2043d028"), -785711901, -818658148 },
                    { new Guid("bed79659-9343-4626-a092-9d38531e7906"), "Molestias ut autem sed delectus sit blanditiis temporibus.", new DateTimeOffset(new DateTime(2021, 4, 24, 19, 49, 8, 712, DateTimeKind.Unspecified).AddTicks(2003), new TimeSpan(0, -3, 0, 0, 0)), "omnis", "home_loan_account_fresh.zaz", 0.8965646536099783821875351411m, new Guid("739f36aa-a68d-4403-880e-decb2043d028"), 296633292, -1439540794 },
                    { new Guid("bec7ca9b-d4df-4baf-9733-5c83b24ffe1b"), "Et et voluptatem vel et cum voluptas cumque et minus.", new DateTimeOffset(new DateTime(2021, 2, 6, 21, 15, 34, 647, DateTimeKind.Unspecified).AddTicks(408), new TimeSpan(0, -3, 0, 0, 0)), "aspernatur", "instruction_set.x3db", 0.668648240505590161632829141m, new Guid("739f36aa-a68d-4403-880e-decb2043d028"), -774862265, 1123145941 }
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
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Products");

            migrationBuilder.DropTable(
                name: "ProductTypes");
        }
    }
}
