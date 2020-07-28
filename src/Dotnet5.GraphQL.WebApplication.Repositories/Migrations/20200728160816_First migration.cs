using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Dotnet5.GraphQL.WebApplication.Repositories.Migrations
{
    public partial class Firstmigration : Migration
    {
        protected override void Down(MigrationBuilder migrationBuilder)
        {
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
                    PhotoFileName = table.Column<string>("nvarchar(100)", maxLength: 100, nullable: true),
                    Price = table.Column<decimal>("decimal(18,2)", precision: 18, scale: 2, nullable: false),
                    ProductTypeId = table.Column<Guid>("uniqueidentifier", nullable: true),
                    Rating = table.Column<int>("int", nullable: false),
                    Stock = table.Column<int>("int", nullable: false),
                    Option = table.Column<string>("nvarchar(max)", nullable: false)
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

            migrationBuilder.InsertData("ProductTypes",
                new[] {"Id", "Discriminator"},
                new object[] {new Guid("ed0977bb-96c3-488f-9f8c-c235b22438c0"), "TypeOne"});

            migrationBuilder.InsertData("ProductTypes",
                new[] {"Id", "Discriminator"},
                new object[] {new Guid("4e3597c3-477d-4072-850c-fd3c7b158d8b"), "TypeThree"});

            migrationBuilder.InsertData("ProductTypes",
                new[] {"Id", "Discriminator"},
                new object[] {new Guid("31e136fe-1402-4c07-aa22-974d312167e1"), "TypeTwo"});

            migrationBuilder.InsertData("Products",
                new[] {"Id", "Description", "IntroduceAt", "Name", "Option", "PhotoFileName", "Price", "ProductTypeId", "Rating", "Stock"},
                new object[,]
                {
                    {
                        new Guid("85ec5364-6703-462b-a39d-da2c0ba42545"), "Nobis est aut.",
                        new DateTimeOffset(new DateTime(2021, 2, 16, 20, 20, 1, 44, DateTimeKind.Unspecified).AddTicks(4114),
                            new TimeSpan(0, -3, 0, 0, 0)),
                        "ut", "Three", "pixel_field_reboot.dtb", 0.0490742421857707234530115109m, new Guid("ed0977bb-96c3-488f-9f8c-c235b22438c0"),
                        574024004, 1583914797
                    },
                    {
                        new Guid("1236eae0-5901-4ce9-b7f8-88e4b21a9293"), "Sint error voluptas non.",
                        new DateTimeOffset(new DateTime(2021, 7, 22, 5, 3, 15, 582, DateTimeKind.Unspecified).AddTicks(9477),
                            new TimeSpan(0, -3, 0, 0, 0)),
                        "qui", "Three", "primary_monitor_distributed.wav", 0.1451224545510112508240414015m,
                        new Guid("ed0977bb-96c3-488f-9f8c-c235b22438c0"), -921827531, 1143516661
                    },
                    {
                        new Guid("fa7ebfa7-7d73-4257-95a3-16210d3d79c4"), "Sed quia sed consequatur rerum sed unde voluptates.",
                        new DateTimeOffset(new DateTime(2021, 6, 7, 5, 28, 51, 348, DateTimeKind.Unspecified).AddTicks(1974),
                            new TimeSpan(0, -3, 0, 0, 0)),
                        "nulla", "Two", "bandwidth.tga", 0.0477278506685921013802591011m, new Guid("ed0977bb-96c3-488f-9f8c-c235b22438c0"), 479280076,
                        -1326289163
                    },
                    {
                        new Guid("23957437-e9d4-44cd-84e4-f1edb4ee952b"), "Perspiciatis ipsam sunt quia asperiores.",
                        new DateTimeOffset(new DateTime(2020, 10, 28, 12, 47, 49, 545, DateTimeKind.Unspecified).AddTicks(6679),
                            new TimeSpan(0, -3, 0, 0, 0)),
                        "modi", "Two", "tasty_rubber_mouse_synchronised_future.qxb", 0.1357320844746785288751837685m,
                        new Guid("ed0977bb-96c3-488f-9f8c-c235b22438c0"), 1957327341, 171787702
                    },
                    {
                        new Guid("a7c7a9d8-6b19-430a-8a90-20d5af6d4ca5"), "Labore atque facere fugiat iusto.",
                        new DateTimeOffset(new DateTime(2021, 4, 15, 20, 0, 50, 603, DateTimeKind.Unspecified).AddTicks(6074),
                            new TimeSpan(0, -3, 0, 0, 0)),
                        "excepturi", "Three", "united_states_minor_outlying_islands_pixel_corners.rip", 0.8135563347166839716383547874m,
                        new Guid("ed0977bb-96c3-488f-9f8c-c235b22438c0"), -1353319871, 1272533798
                    },
                    {
                        new Guid("ec324de5-3e6a-49df-bae4-2419a7970d68"), "Excepturi quis aperiam consequatur.",
                        new DateTimeOffset(new DateTime(2021, 4, 30, 16, 33, 19, 198, DateTimeKind.Unspecified).AddTicks(1290),
                            new TimeSpan(0, -3, 0, 0, 0)),
                        "ducimus", "One", "xml_auto_loan_account.nnd", 0.9674595037583389299498768888m,
                        new Guid("4e3597c3-477d-4072-850c-fd3c7b158d8b"), -2018142710, -733726170
                    },
                    {
                        new Guid("ada2c9ee-82aa-40e9-b48c-a67b3e9317d2"), "Est cum aperiam recusandae rerum maxime cumque dolores et iure.",
                        new DateTimeOffset(new DateTime(2020, 12, 27, 12, 48, 59, 895, DateTimeKind.Unspecified).AddTicks(4039),
                            new TimeSpan(0, -3, 0, 0, 0)),
                        "quia", "One", "payment_intranet_sudanese_pound.xlm", 0.993976680948442415176617418m,
                        new Guid("4e3597c3-477d-4072-850c-fd3c7b158d8b"), 168896327, -1600823244
                    },
                    {
                        new Guid("6b6d31ab-01ea-4028-8730-3a933c1e28c3"), "Molestiae recusandae tempora non.",
                        new DateTimeOffset(new DateTime(2020, 11, 21, 14, 6, 58, 202, DateTimeKind.Unspecified).AddTicks(8077),
                            new TimeSpan(0, -3, 0, 0, 0)),
                        "nobis", "Three", "leverage_overriding_automated.ai", 0.2510580882283329373681090672m,
                        new Guid("31e136fe-1402-4c07-aa22-974d312167e1"), 808312964, -1291239875
                    },
                    {
                        new Guid("72235d5b-dab9-49e3-8fcc-4ba3bd36d982"), "Iste expedita quidem eos dolores deleniti doloremque facilis neque.",
                        new DateTimeOffset(new DateTime(2021, 7, 20, 10, 3, 35, 628, DateTimeKind.Unspecified).AddTicks(5637),
                            new TimeSpan(0, -3, 0, 0, 0)),
                        "doloremque", "Three", "granite_lavender.wad", 0.8457649264692008070893955937m,
                        new Guid("31e136fe-1402-4c07-aa22-974d312167e1"), 301675014, -1785659415
                    },
                    {
                        new Guid("25aedbe9-9958-4c1a-83e3-aeaa808f26cd"), "Animi sit eum repudiandae repellendus sapiente cumque qui et.",
                        new DateTimeOffset(new DateTime(2021, 3, 12, 19, 43, 21, 612, DateTimeKind.Unspecified).AddTicks(5060),
                            new TimeSpan(0, -3, 0, 0, 0)),
                        "quidem", "Two", "optimized.xsl", 0.3166981746517214305278070353m, new Guid("31e136fe-1402-4c07-aa22-974d312167e1"),
                        -1339100037, 1029984585
                    }
                });

            migrationBuilder.CreateIndex("IX_Products_ProductTypeId",
                "Products",
                "ProductTypeId");

            migrationBuilder.CreateIndex("IX_ProductTypes_Discriminator",
                "ProductTypes",
                "Discriminator",
                unique: true);
        }
    }
}