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
                values: new object[] { new Guid("971c1e36-643b-41c7-9c09-049462bda664"), "TypeOne" });

            migrationBuilder.InsertData(
                table: "ProductTypes",
                columns: new[] { "Id", "Discriminator" },
                values: new object[] { new Guid("ff19a5a8-d64c-44dd-b39f-0c189b6af015"), "TypeThree" });

            migrationBuilder.InsertData(
                table: "ProductTypes",
                columns: new[] { "Id", "Discriminator" },
                values: new object[] { new Guid("222bded7-7ab9-403d-8507-00e9823a4702"), "TypeTwo" });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "Description", "IntroduceAt", "Name", "PhotoFileName", "Price", "ProductTypeId", "Rating", "Stock" },
                values: new object[,]
                {
                    { new Guid("be315b78-6d02-403e-9165-a6a2067605c9"), "Sequi quo ad minus rem ut ratione quo.", new DateTimeOffset(new DateTime(2021, 1, 20, 8, 30, 32, 63, DateTimeKind.Unspecified).AddTicks(2145), new TimeSpan(0, -3, 0, 0, 0)), "assumenda", "savings_account_producer_junction.dxp", 0.6068225355158987537107710481m, new Guid("971c1e36-643b-41c7-9c09-049462bda664"), -859267479, 228098146 },
                    { new Guid("89ddf9e9-c71e-4915-af5a-b38747fd627e"), "Qui blanditiis iusto quas expedita dolor facere dolore.", new DateTimeOffset(new DateTime(2021, 5, 6, 7, 47, 9, 340, DateTimeKind.Unspecified).AddTicks(1390), new TimeSpan(0, -3, 0, 0, 0)), "odit", "haven.shf", 0.2040882366204963644997544192m, new Guid("971c1e36-643b-41c7-9c09-049462bda664"), -424788367, -680911527 },
                    { new Guid("5203065a-5aa1-470a-9e96-c9e91121dc61"), "Et molestiae amet molestiae ratione a ab nisi.", new DateTimeOffset(new DateTime(2021, 3, 22, 11, 43, 11, 202, DateTimeKind.Unspecified).AddTicks(3854), new TimeSpan(0, -3, 0, 0, 0)), "praesentium", "wooden.xla", 0.9626982271390947205771029652m, new Guid("971c1e36-643b-41c7-9c09-049462bda664"), 1062381992, -1784381965 },
                    { new Guid("86ffc828-7e2e-48ca-85ec-2e6247bb1ea5"), "Ea qui molestiae et.", new DateTimeOffset(new DateTime(2020, 10, 9, 14, 47, 19, 928, DateTimeKind.Unspecified).AddTicks(8824), new TimeSpan(0, -3, 0, 0, 0)), "qui", "sweden.m13", 0.5995465419013371671599191763m, new Guid("971c1e36-643b-41c7-9c09-049462bda664"), 1958022412, -845175422 },
                    { new Guid("712c8c6c-9ad0-4f28-8498-07b41c72b926"), "Tempore ipsam occaecati autem ipsam quis velit dolore.", new DateTimeOffset(new DateTime(2021, 2, 1, 23, 36, 47, 859, DateTimeKind.Unspecified).AddTicks(8033), new TimeSpan(0, -3, 0, 0, 0)), "vero", "oklahoma_relationships.sdd", 0.604035536236239779807292004m, new Guid("971c1e36-643b-41c7-9c09-049462bda664"), -1129160119, 1046555505 },
                    { new Guid("fdf0b3fb-6c65-48b1-aae1-fcbdf30df2e7"), "Aut quaerat provident praesentium officia.", new DateTimeOffset(new DateTime(2021, 4, 21, 0, 34, 14, 324, DateTimeKind.Unspecified).AddTicks(2008), new TimeSpan(0, -3, 0, 0, 0)), "molestiae", "pakistan_business_focused_purple.eml", 0.6285392153328352800353194224m, new Guid("ff19a5a8-d64c-44dd-b39f-0c189b6af015"), 1242200820, 1368050970 },
                    { new Guid("eb965082-a859-43db-84ed-9616a274c78a"), "Velit est consequatur error consequatur.", new DateTimeOffset(new DateTime(2021, 4, 13, 0, 18, 16, 705, DateTimeKind.Unspecified).AddTicks(4820), new TimeSpan(0, -3, 0, 0, 0)), "eius", "barbados_jamaican_dollar.exi", 0.477300401453137375607324303m, new Guid("ff19a5a8-d64c-44dd-b39f-0c189b6af015"), 1186261203, -1154290413 },
                    { new Guid("c97024c7-4f1e-4b95-8155-1c25960734a2"), "Maiores similique autem quia officiis corrupti occaecati id voluptate excepturi.", new DateTimeOffset(new DateTime(2020, 11, 17, 13, 13, 38, 536, DateTimeKind.Unspecified).AddTicks(1638), new TimeSpan(0, -3, 0, 0, 0)), "dolorem", "action_items.mng", 0.9815548049306890259469166815m, new Guid("ff19a5a8-d64c-44dd-b39f-0c189b6af015"), 2050551896, -1343422269 },
                    { new Guid("4cfb66f2-8104-4384-a73a-52e8b95104b9"), "Voluptatem dicta vel sint iusto.", new DateTimeOffset(new DateTime(2021, 3, 8, 17, 44, 35, 238, DateTimeKind.Unspecified).AddTicks(7709), new TimeSpan(0, -3, 0, 0, 0)), "qui", "vortals.p7b", 0.1748034255269259084765575476m, new Guid("ff19a5a8-d64c-44dd-b39f-0c189b6af015"), 1182544974, 493121065 },
                    { new Guid("d8b6adab-f8cf-442e-a511-92c2ee6f0773"), "Aut voluptate optio sunt voluptas aut nulla itaque.", new DateTimeOffset(new DateTime(2020, 9, 13, 2, 54, 57, 638, DateTimeKind.Unspecified).AddTicks(729), new TimeSpan(0, -3, 0, 0, 0)), "dolorem", "parsing.afp", 0.4644587590737617690510497256m, new Guid("222bded7-7ab9-403d-8507-00e9823a4702"), 1357443794, -964072472 }
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
