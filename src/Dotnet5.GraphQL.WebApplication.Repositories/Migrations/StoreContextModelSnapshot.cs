using System;
using Dotnet5.GraphQL.WebApplication.Repositories.Contexts;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;

namespace Dotnet5.GraphQL.WebApplication.Repositories.Migrations
{
    [DbContext(typeof(StoreContext))]
    internal class StoreContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
               .UseIdentityColumns()
               .HasAnnotation("Relational:Collation", "SQL_Latin1_General_CP1_CS_AS")
               .HasAnnotation("Relational:MaxIdentifierLength", 128)
               .HasAnnotation("ProductVersion", "5.0.0-rc.1.20372.13");

            modelBuilder.Entity("Dotnet5.GraphQL.WebApplication.Domain.Entities.Product", b =>
            {
                b.Property<Guid>("Id")
                   .ValueGeneratedOnAdd()
                   .HasColumnType("uniqueidentifier");

                b.Property<string>("Description")
                   .HasMaxLength(100)
                   .HasColumnType("nvarchar(100)");

                b.Property<DateTimeOffset>("IntroduceAt")
                   .HasColumnType("datetimeoffset");

                b.Property<string>("Name")
                   .IsRequired()
                   .HasMaxLength(50)
                   .HasColumnType("nvarchar(50)");

                b.Property<string>("PhotoFileName")
                   .HasMaxLength(100)
                   .HasColumnType("nvarchar(100)");

                b.Property<decimal>("Price")
                   .HasPrecision(18, 2)
                   .HasColumnType("decimal(18,2)");

                b.Property<Guid?>("ProductTypeId")
                   .HasColumnType("uniqueidentifier");

                b.Property<int>("Rating")
                   .HasColumnType("int");

                b.Property<int>("Stock")
                   .HasColumnType("int");

                b.HasKey("Id");

                b.HasIndex("ProductTypeId");

                b.ToTable("Products");

                b.HasData(new
                    {
                        Id = new Guid("be315b78-6d02-403e-9165-a6a2067605c9"),
                        Description = "Sequi quo ad minus rem ut ratione quo.",
                        IntroduceAt = new DateTimeOffset(new DateTime(2021, 1, 20, 8, 30, 32, 63, DateTimeKind.Unspecified).AddTicks(2145),
                            new TimeSpan(0, -3, 0, 0, 0)),
                        Name = "assumenda",
                        PhotoFileName = "savings_account_producer_junction.dxp",
                        Price = 0.6068225355158987537107710481m,
                        ProductTypeId = new Guid("971c1e36-643b-41c7-9c09-049462bda664"),
                        Rating = -859267479,
                        Stock = 228098146
                    },
                    new
                    {
                        Id = new Guid("fdf0b3fb-6c65-48b1-aae1-fcbdf30df2e7"),
                        Description = "Aut quaerat provident praesentium officia.",
                        IntroduceAt = new DateTimeOffset(new DateTime(2021, 4, 21, 0, 34, 14, 324, DateTimeKind.Unspecified).AddTicks(2008),
                            new TimeSpan(0, -3, 0, 0, 0)),
                        Name = "molestiae",
                        PhotoFileName = "pakistan_business_focused_purple.eml",
                        Price = 0.6285392153328352800353194224m,
                        ProductTypeId = new Guid("ff19a5a8-d64c-44dd-b39f-0c189b6af015"),
                        Rating = 1242200820,
                        Stock = 1368050970
                    },
                    new
                    {
                        Id = new Guid("eb965082-a859-43db-84ed-9616a274c78a"),
                        Description = "Velit est consequatur error consequatur.",
                        IntroduceAt = new DateTimeOffset(new DateTime(2021, 4, 13, 0, 18, 16, 705, DateTimeKind.Unspecified).AddTicks(4820),
                            new TimeSpan(0, -3, 0, 0, 0)),
                        Name = "eius",
                        PhotoFileName = "barbados_jamaican_dollar.exi",
                        Price = 0.477300401453137375607324303m,
                        ProductTypeId = new Guid("ff19a5a8-d64c-44dd-b39f-0c189b6af015"),
                        Rating = 1186261203,
                        Stock = -1154290413
                    },
                    new
                    {
                        Id = new Guid("c97024c7-4f1e-4b95-8155-1c25960734a2"),
                        Description = "Maiores similique autem quia officiis corrupti occaecati id voluptate excepturi.",
                        IntroduceAt = new DateTimeOffset(new DateTime(2020, 11, 17, 13, 13, 38, 536, DateTimeKind.Unspecified).AddTicks(1638),
                            new TimeSpan(0, -3, 0, 0, 0)),
                        Name = "dolorem",
                        PhotoFileName = "action_items.mng",
                        Price = 0.9815548049306890259469166815m,
                        ProductTypeId = new Guid("ff19a5a8-d64c-44dd-b39f-0c189b6af015"),
                        Rating = 2050551896,
                        Stock = -1343422269
                    },
                    new
                    {
                        Id = new Guid("4cfb66f2-8104-4384-a73a-52e8b95104b9"),
                        Description = "Voluptatem dicta vel sint iusto.",
                        IntroduceAt = new DateTimeOffset(new DateTime(2021, 3, 8, 17, 44, 35, 238, DateTimeKind.Unspecified).AddTicks(7709),
                            new TimeSpan(0, -3, 0, 0, 0)),
                        Name = "qui",
                        PhotoFileName = "vortals.p7b",
                        Price = 0.1748034255269259084765575476m,
                        ProductTypeId = new Guid("ff19a5a8-d64c-44dd-b39f-0c189b6af015"),
                        Rating = 1182544974,
                        Stock = 493121065
                    },
                    new
                    {
                        Id = new Guid("89ddf9e9-c71e-4915-af5a-b38747fd627e"),
                        Description = "Qui blanditiis iusto quas expedita dolor facere dolore.",
                        IntroduceAt = new DateTimeOffset(new DateTime(2021, 5, 6, 7, 47, 9, 340, DateTimeKind.Unspecified).AddTicks(1390),
                            new TimeSpan(0, -3, 0, 0, 0)),
                        Name = "odit",
                        PhotoFileName = "haven.shf",
                        Price = 0.2040882366204963644997544192m,
                        ProductTypeId = new Guid("971c1e36-643b-41c7-9c09-049462bda664"),
                        Rating = -424788367,
                        Stock = -680911527
                    },
                    new
                    {
                        Id = new Guid("5203065a-5aa1-470a-9e96-c9e91121dc61"),
                        Description = "Et molestiae amet molestiae ratione a ab nisi.",
                        IntroduceAt = new DateTimeOffset(new DateTime(2021, 3, 22, 11, 43, 11, 202, DateTimeKind.Unspecified).AddTicks(3854),
                            new TimeSpan(0, -3, 0, 0, 0)),
                        Name = "praesentium",
                        PhotoFileName = "wooden.xla",
                        Price = 0.9626982271390947205771029652m,
                        ProductTypeId = new Guid("971c1e36-643b-41c7-9c09-049462bda664"),
                        Rating = 1062381992,
                        Stock = -1784381965
                    },
                    new
                    {
                        Id = new Guid("d8b6adab-f8cf-442e-a511-92c2ee6f0773"),
                        Description = "Aut voluptate optio sunt voluptas aut nulla itaque.",
                        IntroduceAt = new DateTimeOffset(new DateTime(2020, 9, 13, 2, 54, 57, 638, DateTimeKind.Unspecified).AddTicks(729),
                            new TimeSpan(0, -3, 0, 0, 0)),
                        Name = "dolorem",
                        PhotoFileName = "parsing.afp",
                        Price = 0.4644587590737617690510497256m,
                        ProductTypeId = new Guid("222bded7-7ab9-403d-8507-00e9823a4702"),
                        Rating = 1357443794,
                        Stock = -964072472
                    },
                    new
                    {
                        Id = new Guid("86ffc828-7e2e-48ca-85ec-2e6247bb1ea5"),
                        Description = "Ea qui molestiae et.",
                        IntroduceAt = new DateTimeOffset(new DateTime(2020, 10, 9, 14, 47, 19, 928, DateTimeKind.Unspecified).AddTicks(8824),
                            new TimeSpan(0, -3, 0, 0, 0)),
                        Name = "qui",
                        PhotoFileName = "sweden.m13",
                        Price = 0.5995465419013371671599191763m,
                        ProductTypeId = new Guid("971c1e36-643b-41c7-9c09-049462bda664"),
                        Rating = 1958022412,
                        Stock = -845175422
                    },
                    new
                    {
                        Id = new Guid("712c8c6c-9ad0-4f28-8498-07b41c72b926"),
                        Description = "Tempore ipsam occaecati autem ipsam quis velit dolore.",
                        IntroduceAt = new DateTimeOffset(new DateTime(2021, 2, 1, 23, 36, 47, 859, DateTimeKind.Unspecified).AddTicks(8033),
                            new TimeSpan(0, -3, 0, 0, 0)),
                        Name = "vero",
                        PhotoFileName = "oklahoma_relationships.sdd",
                        Price = 0.604035536236239779807292004m,
                        ProductTypeId = new Guid("971c1e36-643b-41c7-9c09-049462bda664"),
                        Rating = -1129160119,
                        Stock = 1046555505
                    });
            });

            modelBuilder.Entity("Dotnet5.GraphQL.WebApplication.Domain.ValueObjects.ProductTypes.ProductType", b =>
            {
                b.Property<Guid>("Id")
                   .ValueGeneratedOnAdd()
                   .HasColumnType("uniqueidentifier");

                b.Property<string>("Discriminator")
                   .IsRequired()
                   .HasMaxLength(30)
                   .HasColumnType("nvarchar(30)");

                b.HasKey("Id");

                b.HasIndex("Discriminator")
                   .IsUnique();

                b.ToTable("ProductTypes");

                b.HasDiscriminator<string>("Discriminator").HasValue("ProductType");
            });

            modelBuilder.Entity("Dotnet5.GraphQL.WebApplication.Domain.ValueObjects.ProductTypes.TypeOne", b =>
            {
                b.HasBaseType("Dotnet5.GraphQL.WebApplication.Domain.ValueObjects.ProductTypes.ProductType");

                b.HasDiscriminator().HasValue("TypeOne");

                b.HasData(new
                {
                    Id = new Guid("971c1e36-643b-41c7-9c09-049462bda664")
                });
            });

            modelBuilder.Entity("Dotnet5.GraphQL.WebApplication.Domain.ValueObjects.ProductTypes.TypeThree", b =>
            {
                b.HasBaseType("Dotnet5.GraphQL.WebApplication.Domain.ValueObjects.ProductTypes.ProductType");

                b.HasDiscriminator().HasValue("TypeThree");

                b.HasData(new
                {
                    Id = new Guid("ff19a5a8-d64c-44dd-b39f-0c189b6af015")
                });
            });

            modelBuilder.Entity("Dotnet5.GraphQL.WebApplication.Domain.ValueObjects.ProductTypes.TypeTwo", b =>
            {
                b.HasBaseType("Dotnet5.GraphQL.WebApplication.Domain.ValueObjects.ProductTypes.ProductType");

                b.HasDiscriminator().HasValue("TypeTwo");

                b.HasData(new
                {
                    Id = new Guid("222bded7-7ab9-403d-8507-00e9823a4702")
                });
            });

            modelBuilder.Entity("Dotnet5.GraphQL.WebApplication.Domain.Entities.Product", b =>
            {
                b.HasOne("Dotnet5.GraphQL.WebApplication.Domain.ValueObjects.ProductTypes.ProductType", "ProductType")
                   .WithMany()
                   .HasForeignKey("ProductTypeId");
            });
#pragma warning restore 612, 618
        }
    }
}