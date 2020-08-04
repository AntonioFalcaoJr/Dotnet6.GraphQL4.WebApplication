using System;
using Dotnet5.GraphQL.Store.Repositories.Contexts;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;

namespace Dotnet5.GraphQL.Store.Repositories.Migrations
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

            modelBuilder.Entity("Dotnet5.GraphQL.Store.Domain.Entities.Products.Product", b =>
            {
                b.Property<Guid>("Id")
                   .ValueGeneratedOnAdd()
                   .HasColumnType("uniqueidentifier");

                b.Property<string>("Description")
                   .HasMaxLength(100)
                   .HasColumnType("nvarchar(100)");

                b.Property<string>("Discriminator")
                   .IsRequired()
                   .HasColumnType("nvarchar(max)");

                b.Property<DateTimeOffset>("IntroduceAt")
                   .HasColumnType("datetimeoffset");

                b.Property<string>("Name")
                   .IsRequired()
                   .HasMaxLength(50)
                   .HasColumnType("nvarchar(50)");

                b.Property<string>("Option")
                   .IsRequired()
                   .HasColumnType("nvarchar(max)");

                b.Property<string>("PhotoUrl")
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

                b.HasDiscriminator<string>("Discriminator").HasValue("Product");
            });

            modelBuilder.Entity("Dotnet5.GraphQL.Store.Domain.Entities.Review", b =>
            {
                b.Property<Guid>("Id")
                   .ValueGeneratedOnAdd()
                   .HasColumnType("uniqueidentifier");

                b.Property<string>("Comment")
                   .HasMaxLength(300)
                   .HasColumnType("nvarchar(300)");

                b.Property<Guid?>("ProductId")
                   .HasColumnType("uniqueidentifier");

                b.Property<string>("Title")
                   .HasMaxLength(50)
                   .HasColumnType("nvarchar(50)");

                b.HasKey("Id");

                b.HasIndex("ProductId");

                b.ToTable("Reviews");

                b.HasData(new
                    {
                        Id = new Guid("e7d9841e-5f6b-459a-82ba-4ad0c4651022"),
                        Comment = "Quia doloribus saepe molestias eum ullam aut officia.",
                        ProductId = new Guid("a0569d82-471c-4687-a203-154ae511d1f2"),
                        Title = "voluptatem"
                    },
                    new
                    {
                        Id = new Guid("91b5064a-19a7-4e0f-84de-ac3de2efcb4c"),
                        Comment = "Libero hic doloribus non fugit.",
                        ProductId = new Guid("04d3c9f3-3e4c-4552-a053-16fa31489dd7"),
                        Title = "qui"
                    },
                    new
                    {
                        Id = new Guid("f699f26d-7ac6-4e0c-9328-dafa8048cfe7"),
                        Comment = "Blanditiis qui expedita nihil vero quo.",
                        ProductId = new Guid("6775d02c-54bc-449a-83e9-8f2b5c9caf36"),
                        Title = "quia"
                    },
                    new
                    {
                        Id = new Guid("d63cfe5d-2ad6-49ff-b414-86449bc08f78"),
                        Comment = "Doloremque ea qui.",
                        ProductId = new Guid("de29b664-3dab-4f3e-833e-a72fd5562ff6"),
                        Title = "at"
                    },
                    new
                    {
                        Id = new Guid("212ad627-b8a3-43c8-864e-4cac3da510fa"),
                        Comment = "Maxime est voluptas consequuntur ea consequatur ipsa fuga.",
                        ProductId = new Guid("fbf6db5c-dc78-4bc5-a4a7-b562768481e7"),
                        Title = "molestiae"
                    },
                    new
                    {
                        Id = new Guid("f8ea1a01-38d2-400a-9b72-8907c94763b8"),
                        Comment = "Tenetur commodi expedita id ipsam.",
                        ProductId = new Guid("bd53a01a-8c2f-4ed5-bef2-d33dc7c37305"),
                        Title = "sed"
                    },
                    new
                    {
                        Id = new Guid("c0b5922c-9344-4aaa-bbdd-cc47c56595ab"),
                        Comment = "Voluptates dignissimos sed corrupti et odit blanditiis sit.",
                        ProductId = new Guid("c183c713-1ac8-4115-8f2b-40f7c204dbea"),
                        Title = "voluptatem"
                    },
                    new
                    {
                        Id = new Guid("301b16a5-62d7-4d67-b99b-22d2cab92a69"),
                        Comment = "Similique qui aliquid eveniet.",
                        ProductId = new Guid("104f0c1c-ed80-4a61-906d-ae2d03102096"),
                        Title = "id"
                    },
                    new
                    {
                        Id = new Guid("f16a4b75-37a8-425c-be9a-8469aa38ecf0"),
                        Comment = "Tempore qui voluptatem fuga et aut corporis omnis.",
                        ProductId = new Guid("21b737e9-934b-411d-baf8-b9a6902ccef5"),
                        Title = "facere"
                    },
                    new
                    {
                        Id = new Guid("300bb2e5-a863-4ad4-83dc-a6581fb22b78"),
                        Comment = "Veniam nihil laboriosam velit incidunt aut et.",
                        ProductId = new Guid("0bb3c44a-66ff-4b3d-8ba3-88a7be83850b"),
                        Title = "voluptatem"
                    },
                    new
                    {
                        Id = new Guid("1e19f693-746c-4942-9783-20f091beac18"),
                        Comment = "Cumque ipsam nesciunt qui perspiciatis accusamus.",
                        ProductId = new Guid("ec37d47b-8cca-434c-969e-d3ef92779da3"),
                        Title = "aut"
                    },
                    new
                    {
                        Id = new Guid("d8f341c1-5618-4029-adfc-acfa05241150"),
                        Comment = "Expedita rem tempora sunt.",
                        ProductId = new Guid("34778a1a-fd32-4e50-a0ef-798adee7c810"),
                        Title = "voluptate"
                    },
                    new
                    {
                        Id = new Guid("d7bbdc87-d73b-4aef-be96-438140aee64d"),
                        Comment = "Harum voluptatibus voluptatem nostrum.",
                        ProductId = new Guid("50a2a3c6-40fb-4c62-894a-a70d34b88d9a"),
                        Title = "culpa"
                    },
                    new
                    {
                        Id = new Guid("929448ce-dd15-42ff-8679-e5b53dbbe3b1"),
                        Comment = "Aut eos possimus minus reprehenderit qui facere cum et.",
                        ProductId = new Guid("f848ba17-4891-4524-b134-fe9345f2fe9d"),
                        Title = "et"
                    },
                    new
                    {
                        Id = new Guid("e078e488-bec6-4614-9867-d8ada9776291"),
                        Comment = "Quos aperiam in eaque esse sint omnis.",
                        ProductId = new Guid("088e0904-c1b5-4a59-b28b-b48e0943f158"),
                        Title = "deleniti"
                    },
                    new
                    {
                        Id = new Guid("63f85efa-d4a0-46fe-a9be-2dda992de62c"),
                        Comment = "Possimus nam est nemo cupiditate tenetur debitis quos impedit.",
                        ProductId = new Guid("060ca68b-f04c-442a-8eaa-ba6153149907"),
                        Title = "eius"
                    },
                    new
                    {
                        Id = new Guid("a8cbf601-3e4b-4c3a-b79c-8485489ed41e"),
                        Comment = "Porro quia rem qui.",
                        ProductId = new Guid("4c46b3f0-0790-40af-8c08-5f398c4bba7b"),
                        Title = "error"
                    },
                    new
                    {
                        Id = new Guid("87872eee-1cc2-4e1a-b74b-c4b28b9f42d4"),
                        Comment = "Nihil et quisquam sed et architecto minus.",
                        ProductId = new Guid("1b268a85-e0e1-46b5-9055-fca9ee5ce135"),
                        Title = "repudiandae"
                    },
                    new
                    {
                        Id = new Guid("5aea8b5a-3b81-4a7c-909a-1e771b0a4795"),
                        Comment = "Ut consequatur dolor numquam totam quaerat vel dolorem.",
                        ProductId = new Guid("b9ce9c8b-7303-410d-a90a-f9f46ab629a1"),
                        Title = "sunt"
                    },
                    new
                    {
                        Id = new Guid("e21e1579-b618-4b90-b01b-da1071debabe"),
                        Comment = "Quos qui non odio rerum quaerat.",
                        ProductId = new Guid("06bb8e47-68f9-4505-a789-659bf40e6536"),
                        Title = "delectus"
                    },
                    new
                    {
                        Id = new Guid("c85558b9-2da7-4f35-b427-81d2b5004521"),
                        Comment = "Quo voluptas dolorem natus consequatur voluptatum vero sunt sit.",
                        ProductId = new Guid("0cd30e2b-92d8-473b-89e9-221ea879e3c8"),
                        Title = "possimus"
                    },
                    new
                    {
                        Id = new Guid("9f8041ee-f282-4bc9-92c1-bd7b0479a929"),
                        Comment = "Quia deserunt repudiandae qui repellendus velit accusamus enim.",
                        ProductId = new Guid("cd2b29fd-242d-4832-8fb4-3be6e7e41a36"),
                        Title = "dolores"
                    },
                    new
                    {
                        Id = new Guid("f85ebee8-8b99-4023-ab80-183719a52b7c"),
                        Comment = "Hic ut dolores eum a quasi odit numquam.",
                        ProductId = new Guid("8f2dd25a-e7a7-4713-9c3a-7c8e39998797"),
                        Title = "doloribus"
                    },
                    new
                    {
                        Id = new Guid("d4529aa1-0b21-4a76-9516-b839a064172e"),
                        Comment = "Vero laudantium tempora voluptatem architecto similique voluptatibus alias nihil.",
                        ProductId = new Guid("84591fda-06e8-43d7-ac34-653a110b27af"),
                        Title = "ex"
                    },
                    new
                    {
                        Id = new Guid("25a50dc7-6023-4547-956f-c4e426e6fb65"),
                        Comment = "Molestiae inventore consectetur assumenda nulla in.",
                        ProductId = new Guid("5b81751f-59c0-4829-aeaf-23804cb7c758"),
                        Title = "illo"
                    },
                    new
                    {
                        Id = new Guid("aebbfcf1-93ef-450d-966b-63d3305e0df8"),
                        Comment = "Accusantium beatae rerum rem aspernatur omnis.",
                        ProductId = new Guid("48d31a4c-6687-40cf-ab65-1ee76f14b866"),
                        Title = "itaque"
                    },
                    new
                    {
                        Id = new Guid("e1f87e90-6b36-4d46-98c9-a7b31a35755b"),
                        Comment = "Dolor quae ea facere officiis laboriosam maiores dolor.",
                        ProductId = new Guid("a0ed7a52-4782-46f0-b8b3-4d57f15d1e23"),
                        Title = "vero"
                    },
                    new
                    {
                        Id = new Guid("c15fc475-07f0-49de-8def-d79d4c53677a"),
                        Comment = "Necessitatibus quia eius et et.",
                        ProductId = new Guid("09c33d90-045c-45e4-8bc9-93a2e282c9f8"),
                        Title = "est"
                    },
                    new
                    {
                        Id = new Guid("61b3d6bc-fe5d-488b-82af-c67613c02059"),
                        Comment = "Quis accusantium nulla nemo.",
                        ProductId = new Guid("31078c1a-f3fd-41c7-b42d-3ac33bf339fd"),
                        Title = "laborum"
                    },
                    new
                    {
                        Id = new Guid("fea97a92-1e83-4a5d-87d6-7b3611ebf53b"),
                        Comment = "Dolores ab autem.",
                        ProductId = new Guid("e22a8984-1f34-4536-b120-0eea72e9d197"),
                        Title = "delectus"
                    },
                    new
                    {
                        Id = new Guid("47b5f1be-8887-49ca-8f35-08771513d15c"),
                        Comment = "Voluptates asperiores magni quaerat eos eveniet aut tenetur.",
                        ProductId = new Guid("97fc6b4b-c680-43fa-ab2e-cb53986c5d27"),
                        Title = "ullam"
                    },
                    new
                    {
                        Id = new Guid("0a07f4d3-0973-427c-9ef1-65cb5a9e5f1d"),
                        Comment = "Quas qui architecto voluptate voluptates atque nobis.",
                        ProductId = new Guid("8c2316fb-91c8-4178-b850-61d08e9ae961"),
                        Title = "minus"
                    },
                    new
                    {
                        Id = new Guid("2a198cf6-2008-49dd-9854-e2a329c614c7"),
                        Comment = "Deserunt non suscipit sit.",
                        ProductId = new Guid("38a5ec97-bf15-47b3-ad05-f7d5b10220be"),
                        Title = "est"
                    },
                    new
                    {
                        Id = new Guid("9398645a-8ff4-44e4-bb8a-9edd73fa6f8c"),
                        Comment = "Sunt commodi error itaque voluptates cumque beatae quis.",
                        ProductId = new Guid("61c74e72-f6ab-43c3-8697-5bf642355786"),
                        Title = "quis"
                    },
                    new
                    {
                        Id = new Guid("55a33d3a-8dc8-446e-b151-0473ddee8d98"),
                        Comment = "Et ut harum amet voluptatem fuga repudiandae enim ut.",
                        ProductId = new Guid("23461481-18cd-406b-9208-360c2b8b7bf3"),
                        Title = "et"
                    },
                    new
                    {
                        Id = new Guid("95719279-55bb-4a75-971b-c22c04b86893"),
                        Comment = "Est eveniet cumque et consequatur voluptatem.",
                        ProductId = new Guid("7c118d3f-fa6c-4e2f-ae29-bdb75b67bcca"),
                        Title = "deserunt"
                    },
                    new
                    {
                        Id = new Guid("127fb4cf-eaf0-443a-be98-3eb77c9e8a03"),
                        Comment = "Atque sunt nam ea cupiditate.",
                        ProductId = new Guid("806049ab-d1dd-43f6-8f8d-5dea6e0ce737"),
                        Title = "quae"
                    },
                    new
                    {
                        Id = new Guid("201411e7-fb8d-4148-b2a0-21c7d607ad43"),
                        Comment = "Et sit reprehenderit ut molestiae numquam repellendus.",
                        ProductId = new Guid("bdec72b1-e31e-4d16-9ffa-1e770a55fbfe"),
                        Title = "ut"
                    },
                    new
                    {
                        Id = new Guid("5633a6d6-716b-4e7c-a626-bd65f7c83a97"),
                        Comment = "Dolore illo unde.",
                        ProductId = new Guid("8a9a9c62-dade-42ea-83b4-3049272d20b1"),
                        Title = "aut"
                    },
                    new
                    {
                        Id = new Guid("4cd20896-4755-4767-be1d-a32dcca78484"),
                        Comment = "Ullam accusantium temporibus eos ullam voluptatem totam eos nemo aspernatur.",
                        ProductId = new Guid("d863b949-7022-4ce1-b393-1f1a5124222c"),
                        Title = "eum"
                    },
                    new
                    {
                        Id = new Guid("6d6d520c-05c9-4364-bc74-b54655d6bb2c"),
                        Comment = "Repellat et ullam velit fugiat odit.",
                        ProductId = new Guid("51914a05-d8f1-43ce-ba3c-a4ac9c123f5d"),
                        Title = "eos"
                    },
                    new
                    {
                        Id = new Guid("784b6f88-0f48-4cb2-b015-47ce48eeaae2"),
                        Comment = "Eum saepe sint quidem odio tempora maiores ea expedita.",
                        ProductId = new Guid("43be72a4-2691-4a91-94e6-3762ab5228a5"),
                        Title = "eum"
                    },
                    new
                    {
                        Id = new Guid("f024cf42-0fcf-40ea-81af-90795331ce73"),
                        Comment = "Assumenda impedit ea amet perspiciatis officiis perspiciatis tempora qui.",
                        ProductId = new Guid("49d4e24d-57c2-442e-9979-aa44d677acbc"),
                        Title = "et"
                    },
                    new
                    {
                        Id = new Guid("bda589c0-a1f8-4237-89a7-b95182e7d6ad"),
                        Comment = "Impedit nostrum occaecati itaque numquam voluptatibus.",
                        ProductId = new Guid("30d11008-aa26-42ce-8ba7-21c40a04a36d"),
                        Title = "et"
                    },
                    new
                    {
                        Id = new Guid("07c9ccf0-b91d-4969-91ae-e6a93ed5881a"),
                        Comment = "Esse rerum voluptate explicabo qui ea aut sequi quam.",
                        ProductId = new Guid("d937f183-e800-4cd2-8d9c-40d042f52de7"),
                        Title = "architecto"
                    },
                    new
                    {
                        Id = new Guid("f804d231-4b8b-4699-beba-155665b854a6"),
                        Comment = "Odit quia molestiae ut laborum.",
                        ProductId = new Guid("b8f1a660-7251-422f-9162-96f122594166"),
                        Title = "dolor"
                    },
                    new
                    {
                        Id = new Guid("38010e71-bf2f-4552-b973-e35ff2b3cc2b"),
                        Comment = "Et facere voluptas nostrum aut voluptate quisquam.",
                        ProductId = new Guid("8f3a86ff-bda9-494e-9fda-4df0ca354613"),
                        Title = "consequatur"
                    },
                    new
                    {
                        Id = new Guid("dcff2c53-d661-4402-b1a7-2f2598438996"),
                        Comment = "Fuga fugit et aut.",
                        ProductId = new Guid("95a57bad-66c8-49c1-8c21-ec4b44fe4668"),
                        Title = "alias"
                    },
                    new
                    {
                        Id = new Guid("f3a9a1d8-a4b1-4854-b71b-887a2cefc180"),
                        Comment = "Consequatur delectus aut.",
                        ProductId = new Guid("84129002-c5c8-49fd-9aa2-0156b2c71763"),
                        Title = "ea"
                    },
                    new
                    {
                        Id = new Guid("f2cbccac-dc32-4642-a9fe-b6dbb271209e"),
                        Comment = "Illum dolor iusto porro quia sequi in.",
                        ProductId = new Guid("2a9456f4-2e3e-4f85-9184-8fce63a8d62f"),
                        Title = "sapiente"
                    });
            });

            modelBuilder.Entity("Dotnet5.GraphQL.Store.Domain.ValueObjects.ProductTypes.ProductType", b =>
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

            modelBuilder.Entity("Dotnet5.GraphQL.Store.Domain.Entities.Products.Backpack", b =>
            {
                b.HasBaseType("Dotnet5.GraphQL.Store.Domain.Entities.Products.Product");

                b.Property<string>("BackpackType")
                   .IsRequired()
                   .HasColumnType("nvarchar(max)");

                b.HasDiscriminator().HasValue("Backpack");

                b.HasData(new
                    {
                        Id = new Guid("a0569d82-471c-4687-a203-154ae511d1f2"),
                        Description = "Provident non non aperiam ex perspiciatis dignissimos.",
                        IntroduceAt = new DateTimeOffset(new DateTime(2021, 7, 17, 15, 9, 24, 390, DateTimeKind.Unspecified).AddTicks(5457),
                            new TimeSpan(0, -3, 0, 0, 0)),
                        Name = "vitae",
                        Option = "One",
                        PhotoUrl = "https://picsum.photos/640/480/?image=487",
                        Price = 0.3220846169413446663281397408m,
                        ProductTypeId = new Guid("c814a26e-6e82-43ed-8e08-6eaa45d741ff"),
                        Rating = -215932871,
                        Stock = -2095264362,
                        BackpackType = "Overnight"
                    },
                    new
                    {
                        Id = new Guid("04d3c9f3-3e4c-4552-a053-16fa31489dd7"),
                        Description = "Rerum aut quis qui ad asperiores.",
                        IntroduceAt = new DateTimeOffset(new DateTime(2020, 10, 16, 5, 26, 16, 744, DateTimeKind.Unspecified).AddTicks(5293),
                            new TimeSpan(0, -3, 0, 0, 0)),
                        Name = "ab",
                        Option = "Three",
                        PhotoUrl = "https://picsum.photos/640/480/?image=583",
                        Price = 0.9320690611446014975694315032m,
                        ProductTypeId = new Guid("c814a26e-6e82-43ed-8e08-6eaa45d741ff"),
                        Rating = 1311982267,
                        Stock = -1676445095,
                        BackpackType = "Hiking"
                    },
                    new
                    {
                        Id = new Guid("6775d02c-54bc-449a-83e9-8f2b5c9caf36"),
                        Description = "Labore ut blanditiis dolorem cum consequatur mollitia.",
                        IntroduceAt = new DateTimeOffset(new DateTime(2020, 8, 4, 8, 37, 11, 623, DateTimeKind.Unspecified).AddTicks(3672),
                            new TimeSpan(0, -3, 0, 0, 0)),
                        Name = "adipisci",
                        Option = "Two",
                        PhotoUrl = "https://picsum.photos/640/480/?image=866",
                        Price = 0.3312730165285348650984462412m,
                        ProductTypeId = new Guid("c814a26e-6e82-43ed-8e08-6eaa45d741ff"),
                        Rating = 1153743911,
                        Stock = -1603941974,
                        BackpackType = "DayPack"
                    },
                    new
                    {
                        Id = new Guid("de29b664-3dab-4f3e-833e-a72fd5562ff6"),
                        Description = "Debitis quod harum corrupti.",
                        IntroduceAt = new DateTimeOffset(new DateTime(2020, 11, 20, 23, 36, 58, 188, DateTimeKind.Unspecified).AddTicks(5135),
                            new TimeSpan(0, -3, 0, 0, 0)),
                        Name = "non",
                        Option = "One",
                        PhotoUrl = "https://picsum.photos/640/480/?image=297",
                        Price = 0.5963928495398696269335946846m,
                        ProductTypeId = new Guid("c814a26e-6e82-43ed-8e08-6eaa45d741ff"),
                        Rating = 1142558218,
                        Stock = -1160445461,
                        BackpackType = "Overnight"
                    },
                    new
                    {
                        Id = new Guid("fbf6db5c-dc78-4bc5-a4a7-b562768481e7"),
                        Description = "Dolor ut quia.",
                        IntroduceAt = new DateTimeOffset(new DateTime(2021, 4, 16, 21, 36, 53, 701, DateTimeKind.Unspecified).AddTicks(1821),
                            new TimeSpan(0, -3, 0, 0, 0)),
                        Name = "earum",
                        Option = "Three",
                        PhotoUrl = "https://picsum.photos/640/480/?image=636",
                        Price = 0.5709511922910926768723162954m,
                        ProductTypeId = new Guid("d3e13982-118b-4b99-ac5d-cd3da3b4cc35"),
                        Rating = 1155568876,
                        Stock = 816538778,
                        BackpackType = "Overnight"
                    },
                    new
                    {
                        Id = new Guid("bd53a01a-8c2f-4ed5-bef2-d33dc7c37305"),
                        Description = "Ullam iusto distinctio deleniti.",
                        IntroduceAt = new DateTimeOffset(new DateTime(2020, 12, 23, 7, 4, 27, 814, DateTimeKind.Unspecified).AddTicks(2219),
                            new TimeSpan(0, -3, 0, 0, 0)),
                        Name = "dolorem",
                        Option = "Two",
                        PhotoUrl = "https://picsum.photos/640/480/?image=46",
                        Price = 0.5665775113698985646554779331m,
                        ProductTypeId = new Guid("d3e13982-118b-4b99-ac5d-cd3da3b4cc35"),
                        Rating = 1144210711,
                        Stock = -1015449642,
                        BackpackType = "Overnight"
                    },
                    new
                    {
                        Id = new Guid("c183c713-1ac8-4115-8f2b-40f7c204dbea"),
                        Description = "Non inventore et enim cupiditate.",
                        IntroduceAt = new DateTimeOffset(new DateTime(2020, 12, 10, 3, 7, 25, 828, DateTimeKind.Unspecified).AddTicks(479),
                            new TimeSpan(0, -3, 0, 0, 0)),
                        Name = "placeat",
                        Option = "One",
                        PhotoUrl = "https://picsum.photos/640/480/?image=312",
                        Price = 0.0263726245759876642618385029m,
                        ProductTypeId = new Guid("95a5fa4a-41fb-44ee-8670-a9305d24fe94"),
                        Rating = 1511954773,
                        Stock = -1904422001,
                        BackpackType = "DayPack"
                    },
                    new
                    {
                        Id = new Guid("104f0c1c-ed80-4a61-906d-ae2d03102096"),
                        Description = "Maxime dicta aliquid qui.",
                        IntroduceAt = new DateTimeOffset(new DateTime(2021, 1, 8, 20, 16, 44, 985, DateTimeKind.Unspecified).AddTicks(2346),
                            new TimeSpan(0, -3, 0, 0, 0)),
                        Name = "vero",
                        Option = "One",
                        PhotoUrl = "https://picsum.photos/640/480/?image=901",
                        Price = 0.5983330563519496258287671449m,
                        ProductTypeId = new Guid("d3e13982-118b-4b99-ac5d-cd3da3b4cc35"),
                        Rating = 159646640,
                        Stock = -1288407205,
                        BackpackType = "Hiking"
                    },
                    new
                    {
                        Id = new Guid("21b737e9-934b-411d-baf8-b9a6902ccef5"),
                        Description = "Eaque voluptatum aut adipisci delectus veniam similique perspiciatis unde voluptates.",
                        IntroduceAt = new DateTimeOffset(new DateTime(2021, 1, 6, 16, 37, 19, 117, DateTimeKind.Unspecified).AddTicks(9660),
                            new TimeSpan(0, -3, 0, 0, 0)),
                        Name = "ut",
                        Option = "Two",
                        PhotoUrl = "https://picsum.photos/640/480/?image=688",
                        Price = 0.9115940562406004645412355782m,
                        ProductTypeId = new Guid("95a5fa4a-41fb-44ee-8670-a9305d24fe94"),
                        Rating = -176073860,
                        Stock = -605270024,
                        BackpackType = "Snowsports"
                    },
                    new
                    {
                        Id = new Guid("0bb3c44a-66ff-4b3d-8ba3-88a7be83850b"),
                        Description = "Repudiandae autem doloribus quo expedita in qui dolor.",
                        IntroduceAt = new DateTimeOffset(new DateTime(2021, 5, 28, 3, 22, 30, 530, DateTimeKind.Unspecified).AddTicks(5553),
                            new TimeSpan(0, -3, 0, 0, 0)),
                        Name = "nobis",
                        Option = "One",
                        PhotoUrl = "https://picsum.photos/640/480/?image=209",
                        Price = 0.1439448385313710873030593107m,
                        ProductTypeId = new Guid("95a5fa4a-41fb-44ee-8670-a9305d24fe94"),
                        Rating = 490468463,
                        Stock = -480894060,
                        BackpackType = "DayPack"
                    },
                    new
                    {
                        Id = new Guid("ec37d47b-8cca-434c-969e-d3ef92779da3"),
                        Description = "Accusantium quo cum quisquam consequatur atque repellendus.",
                        IntroduceAt = new DateTimeOffset(new DateTime(2021, 4, 18, 18, 41, 41, 513, DateTimeKind.Unspecified).AddTicks(2827),
                            new TimeSpan(0, -3, 0, 0, 0)),
                        Name = "porro",
                        Option = "Three",
                        PhotoUrl = "https://picsum.photos/640/480/?image=177",
                        Price = 0.246328524242266103464441302m,
                        ProductTypeId = new Guid("95a5fa4a-41fb-44ee-8670-a9305d24fe94"),
                        Rating = 206029046,
                        Stock = -2016626977,
                        BackpackType = "Snowsports"
                    },
                    new
                    {
                        Id = new Guid("34778a1a-fd32-4e50-a0ef-798adee7c810"),
                        Description = "Beatae quia itaque vitae dolorem ea eum.",
                        IntroduceAt = new DateTimeOffset(new DateTime(2020, 11, 12, 21, 56, 48, 662, DateTimeKind.Unspecified).AddTicks(1882),
                            new TimeSpan(0, -3, 0, 0, 0)),
                        Name = "odio",
                        Option = "One",
                        PhotoUrl = "https://picsum.photos/640/480/?image=129",
                        Price = 0.2735659429236748034076905615m,
                        ProductTypeId = new Guid("95a5fa4a-41fb-44ee-8670-a9305d24fe94"),
                        Rating = -801651084,
                        Stock = -2128656395,
                        BackpackType = "Cycling"
                    },
                    new
                    {
                        Id = new Guid("50a2a3c6-40fb-4c62-894a-a70d34b88d9a"),
                        Description = "Corrupti ut culpa.",
                        IntroduceAt = new DateTimeOffset(new DateTime(2020, 10, 9, 23, 54, 37, 120, DateTimeKind.Unspecified).AddTicks(8613),
                            new TimeSpan(0, -3, 0, 0, 0)),
                        Name = "dicta",
                        Option = "One",
                        PhotoUrl = "https://picsum.photos/640/480/?image=808",
                        Price = 0.1218234365050341506725397716m,
                        ProductTypeId = new Guid("d3e13982-118b-4b99-ac5d-cd3da3b4cc35"),
                        Rating = 1877836179,
                        Stock = 1368305839,
                        BackpackType = "Cycling"
                    },
                    new
                    {
                        Id = new Guid("f848ba17-4891-4524-b134-fe9345f2fe9d"),
                        Description = "Quis ut distinctio pariatur eligendi totam non sit harum ea.",
                        IntroduceAt = new DateTimeOffset(new DateTime(2021, 1, 27, 22, 47, 52, 576, DateTimeKind.Unspecified).AddTicks(1061),
                            new TimeSpan(0, -3, 0, 0, 0)),
                        Name = "enim",
                        Option = "One",
                        PhotoUrl = "https://picsum.photos/640/480/?image=499",
                        Price = 0.2076779566293578863157875422m,
                        ProductTypeId = new Guid("d3e13982-118b-4b99-ac5d-cd3da3b4cc35"),
                        Rating = -831166576,
                        Stock = 1287508878,
                        BackpackType = "Overnight"
                    },
                    new
                    {
                        Id = new Guid("088e0904-c1b5-4a59-b28b-b48e0943f158"),
                        Description = "Odit autem doloribus excepturi enim voluptatum facere sed velit.",
                        IntroduceAt = new DateTimeOffset(new DateTime(2021, 5, 5, 16, 49, 38, 261, DateTimeKind.Unspecified).AddTicks(5513),
                            new TimeSpan(0, -3, 0, 0, 0)),
                        Name = "magni",
                        Option = "Two",
                        PhotoUrl = "https://picsum.photos/640/480/?image=680",
                        Price = 0.6193180593981379967182860887m,
                        ProductTypeId = new Guid("c814a26e-6e82-43ed-8e08-6eaa45d741ff"),
                        Rating = 1030795207,
                        Stock = -1578367708,
                        BackpackType = "DayPack"
                    },
                    new
                    {
                        Id = new Guid("060ca68b-f04c-442a-8eaa-ba6153149907"),
                        Description = "Odit et ex est et nesciunt nemo aut tenetur aliquid.",
                        IntroduceAt = new DateTimeOffset(new DateTime(2020, 12, 17, 7, 43, 34, 507, DateTimeKind.Unspecified).AddTicks(7749),
                            new TimeSpan(0, -3, 0, 0, 0)),
                        Name = "vel",
                        Option = "One",
                        PhotoUrl = "https://picsum.photos/640/480/?image=4",
                        Price = 0.1976183341935696541941244703m,
                        ProductTypeId = new Guid("d3e13982-118b-4b99-ac5d-cd3da3b4cc35"),
                        Rating = -1472761390,
                        Stock = -1306261562,
                        BackpackType = "Overnight"
                    },
                    new
                    {
                        Id = new Guid("4c46b3f0-0790-40af-8c08-5f398c4bba7b"),
                        Description = "Tempora occaecati atque rerum dicta.",
                        IntroduceAt = new DateTimeOffset(new DateTime(2020, 10, 30, 9, 53, 27, 775, DateTimeKind.Unspecified).AddTicks(3519),
                            new TimeSpan(0, -3, 0, 0, 0)),
                        Name = "accusantium",
                        Option = "Three",
                        PhotoUrl = "https://picsum.photos/640/480/?image=442",
                        Price = 0.9839982161163161657217789559m,
                        ProductTypeId = new Guid("d3e13982-118b-4b99-ac5d-cd3da3b4cc35"),
                        Rating = 2140557451,
                        Stock = -1850110908,
                        BackpackType = "Climbing"
                    },
                    new
                    {
                        Id = new Guid("1b268a85-e0e1-46b5-9055-fca9ee5ce135"),
                        Description = "Eum veritatis nam.",
                        IntroduceAt = new DateTimeOffset(new DateTime(2020, 10, 30, 2, 3, 39, 751, DateTimeKind.Unspecified).AddTicks(4168),
                            new TimeSpan(0, -3, 0, 0, 0)),
                        Name = "dolore",
                        Option = "Three",
                        PhotoUrl = "https://picsum.photos/640/480/?image=544",
                        Price = 0.7175523163492923631050676445m,
                        ProductTypeId = new Guid("c814a26e-6e82-43ed-8e08-6eaa45d741ff"),
                        Rating = -1441815048,
                        Stock = 1190340457,
                        BackpackType = "Snowsports"
                    },
                    new
                    {
                        Id = new Guid("b9ce9c8b-7303-410d-a90a-f9f46ab629a1"),
                        Description = "Nisi harum corporis.",
                        IntroduceAt = new DateTimeOffset(new DateTime(2021, 5, 25, 9, 7, 58, 813, DateTimeKind.Unspecified).AddTicks(3446),
                            new TimeSpan(0, -3, 0, 0, 0)),
                        Name = "voluptatibus",
                        Option = "Three",
                        PhotoUrl = "https://picsum.photos/640/480/?image=1007",
                        Price = 0.1830744520393139514801388345m,
                        ProductTypeId = new Guid("95a5fa4a-41fb-44ee-8670-a9305d24fe94"),
                        Rating = -1162947832,
                        Stock = 1873452016,
                        BackpackType = "Hiking"
                    },
                    new
                    {
                        Id = new Guid("06bb8e47-68f9-4505-a789-659bf40e6536"),
                        Description = "Culpa voluptates quas.",
                        IntroduceAt = new DateTimeOffset(new DateTime(2020, 8, 26, 13, 53, 31, 175, DateTimeKind.Unspecified).AddTicks(4317),
                            new TimeSpan(0, -3, 0, 0, 0)),
                        Name = "adipisci",
                        Option = "One",
                        PhotoUrl = "https://picsum.photos/640/480/?image=699",
                        Price = 0.9036959764099123950651938396m,
                        ProductTypeId = new Guid("d3e13982-118b-4b99-ac5d-cd3da3b4cc35"),
                        Rating = -510344344,
                        Stock = -26842084,
                        BackpackType = "Hiking"
                    },
                    new
                    {
                        Id = new Guid("0cd30e2b-92d8-473b-89e9-221ea879e3c8"),
                        Description = "Vero non neque dignissimos quaerat.",
                        IntroduceAt = new DateTimeOffset(new DateTime(2021, 1, 8, 6, 17, 54, 115, DateTimeKind.Unspecified).AddTicks(2955),
                            new TimeSpan(0, -3, 0, 0, 0)),
                        Name = "consequatur",
                        Option = "Three",
                        PhotoUrl = "https://picsum.photos/640/480/?image=1064",
                        Price = 0.9013933949794800391383712172m,
                        ProductTypeId = new Guid("c814a26e-6e82-43ed-8e08-6eaa45d741ff"),
                        Rating = 230393241,
                        Stock = 854558802,
                        BackpackType = "Hiking"
                    },
                    new
                    {
                        Id = new Guid("cd2b29fd-242d-4832-8fb4-3be6e7e41a36"),
                        Description = "Eos quos non sint quam rerum temporibus.",
                        IntroduceAt = new DateTimeOffset(new DateTime(2020, 9, 23, 0, 1, 46, 194, DateTimeKind.Unspecified).AddTicks(4147),
                            new TimeSpan(0, -3, 0, 0, 0)),
                        Name = "delectus",
                        Option = "One",
                        PhotoUrl = "https://picsum.photos/640/480/?image=773",
                        Price = 0.2242025725414466871272419944m,
                        ProductTypeId = new Guid("d3e13982-118b-4b99-ac5d-cd3da3b4cc35"),
                        Rating = 572571228,
                        Stock = 1617347989,
                        BackpackType = "Hiking"
                    },
                    new
                    {
                        Id = new Guid("8f2dd25a-e7a7-4713-9c3a-7c8e39998797"),
                        Description = "Aperiam sunt accusantium consequatur.",
                        IntroduceAt = new DateTimeOffset(new DateTime(2021, 6, 7, 0, 19, 26, 705, DateTimeKind.Unspecified).AddTicks(5083),
                            new TimeSpan(0, -3, 0, 0, 0)),
                        Name = "vero",
                        Option = "Three",
                        PhotoUrl = "https://picsum.photos/640/480/?image=177",
                        Price = 0.8452549732110374208457383333m,
                        ProductTypeId = new Guid("d3e13982-118b-4b99-ac5d-cd3da3b4cc35"),
                        Rating = -296759244,
                        Stock = 1052486877,
                        BackpackType = "DayPack"
                    },
                    new
                    {
                        Id = new Guid("84591fda-06e8-43d7-ac34-653a110b27af"),
                        Description = "Aliquid ipsum aut quos repudiandae nam minus soluta.",
                        IntroduceAt = new DateTimeOffset(new DateTime(2021, 5, 21, 2, 12, 37, 200, DateTimeKind.Unspecified).AddTicks(3313),
                            new TimeSpan(0, -3, 0, 0, 0)),
                        Name = "in",
                        Option = "Three",
                        PhotoUrl = "https://picsum.photos/640/480/?image=661",
                        Price = 0.4123996099085381147045291558m,
                        ProductTypeId = new Guid("95a5fa4a-41fb-44ee-8670-a9305d24fe94"),
                        Rating = -315373692,
                        Stock = 1614523125,
                        BackpackType = "Cycling"
                    },
                    new
                    {
                        Id = new Guid("5b81751f-59c0-4829-aeaf-23804cb7c758"),
                        Description = "Dolores ut sed vel fugiat doloribus qui non sed.",
                        IntroduceAt = new DateTimeOffset(new DateTime(2021, 7, 22, 18, 45, 54, 906, DateTimeKind.Unspecified).AddTicks(1153),
                            new TimeSpan(0, -3, 0, 0, 0)),
                        Name = "earum",
                        Option = "Two",
                        PhotoUrl = "https://picsum.photos/640/480/?image=569",
                        Price = 0.495884585079388492636020127m,
                        ProductTypeId = new Guid("d3e13982-118b-4b99-ac5d-cd3da3b4cc35"),
                        Rating = 389333267,
                        Stock = -2105561645,
                        BackpackType = "Overnight"
                    },
                    new
                    {
                        Id = new Guid("48d31a4c-6687-40cf-ab65-1ee76f14b866"),
                        Description = "Quas sed voluptatum.",
                        IntroduceAt = new DateTimeOffset(new DateTime(2021, 7, 3, 7, 48, 53, 151, DateTimeKind.Unspecified).AddTicks(8377),
                            new TimeSpan(0, -3, 0, 0, 0)),
                        Name = "at",
                        Option = "Three",
                        PhotoUrl = "https://picsum.photos/640/480/?image=300",
                        Price = 0.94406172402606941235102874m,
                        ProductTypeId = new Guid("c814a26e-6e82-43ed-8e08-6eaa45d741ff"),
                        Rating = -2135568754,
                        Stock = -73387369,
                        BackpackType = "Hiking"
                    },
                    new
                    {
                        Id = new Guid("a0ed7a52-4782-46f0-b8b3-4d57f15d1e23"),
                        Description = "Voluptatem autem enim explicabo sit provident eaque.",
                        IntroduceAt = new DateTimeOffset(new DateTime(2021, 6, 11, 14, 33, 55, 419, DateTimeKind.Unspecified).AddTicks(1152),
                            new TimeSpan(0, -3, 0, 0, 0)),
                        Name = "voluptatem",
                        Option = "Two",
                        PhotoUrl = "https://picsum.photos/640/480/?image=304",
                        Price = 0.6328008607914129500125413989m,
                        ProductTypeId = new Guid("d3e13982-118b-4b99-ac5d-cd3da3b4cc35"),
                        Rating = 491491537,
                        Stock = -1503857048,
                        BackpackType = "DayPack"
                    },
                    new
                    {
                        Id = new Guid("09c33d90-045c-45e4-8bc9-93a2e282c9f8"),
                        Description = "Quae alias blanditiis suscipit a officiis laborum.",
                        IntroduceAt = new DateTimeOffset(new DateTime(2021, 6, 22, 21, 27, 13, 47, DateTimeKind.Unspecified).AddTicks(5763),
                            new TimeSpan(0, -3, 0, 0, 0)),
                        Name = "non",
                        Option = "One",
                        PhotoUrl = "https://picsum.photos/640/480/?image=305",
                        Price = 0.6628817489167739095965518023m,
                        ProductTypeId = new Guid("c814a26e-6e82-43ed-8e08-6eaa45d741ff"),
                        Rating = 1052766480,
                        Stock = 2051886730,
                        BackpackType = "DayPack"
                    },
                    new
                    {
                        Id = new Guid("31078c1a-f3fd-41c7-b42d-3ac33bf339fd"),
                        Description = "Qui maiores temporibus dignissimos ut eum beatae asperiores.",
                        IntroduceAt = new DateTimeOffset(new DateTime(2020, 9, 30, 17, 31, 0, 505, DateTimeKind.Unspecified).AddTicks(4604),
                            new TimeSpan(0, -3, 0, 0, 0)),
                        Name = "vel",
                        Option = "Two",
                        PhotoUrl = "https://picsum.photos/640/480/?image=83",
                        Price = 0.290650054698809717840135576m,
                        ProductTypeId = new Guid("95a5fa4a-41fb-44ee-8670-a9305d24fe94"),
                        Rating = 1618560888,
                        Stock = -1676111233,
                        BackpackType = "Snowsports"
                    },
                    new
                    {
                        Id = new Guid("e22a8984-1f34-4536-b120-0eea72e9d197"),
                        Description = "Aut rem aliquam eum molestias omnis et quibusdam nihil.",
                        IntroduceAt = new DateTimeOffset(new DateTime(2020, 8, 27, 20, 44, 2, 2, DateTimeKind.Unspecified).AddTicks(248),
                            new TimeSpan(0, -3, 0, 0, 0)),
                        Name = "numquam",
                        Option = "Two",
                        PhotoUrl = "https://picsum.photos/640/480/?image=347",
                        Price = 0.643044354995347956064952403m,
                        ProductTypeId = new Guid("c814a26e-6e82-43ed-8e08-6eaa45d741ff"),
                        Rating = -344664329,
                        Stock = 467248854,
                        BackpackType = "Climbing"
                    },
                    new
                    {
                        Id = new Guid("97fc6b4b-c680-43fa-ab2e-cb53986c5d27"),
                        Description = "Ex similique aut aperiam molestiae id voluptates excepturi maiores.",
                        IntroduceAt = new DateTimeOffset(new DateTime(2021, 6, 29, 2, 33, 33, 777, DateTimeKind.Unspecified).AddTicks(4486),
                            new TimeSpan(0, -3, 0, 0, 0)),
                        Name = "tenetur",
                        Option = "Three",
                        PhotoUrl = "https://picsum.photos/640/480/?image=507",
                        Price = 0.185763792865097024896441555m,
                        ProductTypeId = new Guid("c814a26e-6e82-43ed-8e08-6eaa45d741ff"),
                        Rating = -441829196,
                        Stock = -565843375,
                        BackpackType = "Hiking"
                    },
                    new
                    {
                        Id = new Guid("8c2316fb-91c8-4178-b850-61d08e9ae961"),
                        Description = "Eveniet dignissimos delectus cum sequi asperiores enim voluptatem eius sed.",
                        IntroduceAt = new DateTimeOffset(new DateTime(2020, 11, 28, 11, 2, 12, 680, DateTimeKind.Unspecified).AddTicks(5735),
                            new TimeSpan(0, -3, 0, 0, 0)),
                        Name = "laudantium",
                        Option = "Three",
                        PhotoUrl = "https://picsum.photos/640/480/?image=332",
                        Price = 0.7430688626816698596619112309m,
                        ProductTypeId = new Guid("c814a26e-6e82-43ed-8e08-6eaa45d741ff"),
                        Rating = -457253484,
                        Stock = -1803903063,
                        BackpackType = "Snowsports"
                    },
                    new
                    {
                        Id = new Guid("38a5ec97-bf15-47b3-ad05-f7d5b10220be"),
                        Description = "Voluptatibus sunt temporibus ipsam quas voluptas voluptatem velit.",
                        IntroduceAt = new DateTimeOffset(new DateTime(2021, 8, 1, 16, 0, 13, 443, DateTimeKind.Unspecified).AddTicks(7178),
                            new TimeSpan(0, -3, 0, 0, 0)),
                        Name = "natus",
                        Option = "Three",
                        PhotoUrl = "https://picsum.photos/640/480/?image=691",
                        Price = 0.3657773785626542568088694481m,
                        ProductTypeId = new Guid("d3e13982-118b-4b99-ac5d-cd3da3b4cc35"),
                        Rating = -291026361,
                        Stock = -1215210857,
                        BackpackType = "Climbing"
                    },
                    new
                    {
                        Id = new Guid("61c74e72-f6ab-43c3-8697-5bf642355786"),
                        Description = "Occaecati aut autem quia voluptas.",
                        IntroduceAt = new DateTimeOffset(new DateTime(2020, 10, 15, 12, 59, 13, 36, DateTimeKind.Unspecified).AddTicks(9274),
                            new TimeSpan(0, -3, 0, 0, 0)),
                        Name = "voluptatem",
                        Option = "Two",
                        PhotoUrl = "https://picsum.photos/640/480/?image=949",
                        Price = 0.1589347035051377930642799446m,
                        ProductTypeId = new Guid("95a5fa4a-41fb-44ee-8670-a9305d24fe94"),
                        Rating = 1664926164,
                        Stock = -902689858,
                        BackpackType = "DayPack"
                    },
                    new
                    {
                        Id = new Guid("23461481-18cd-406b-9208-360c2b8b7bf3"),
                        Description = "Tenetur natus rem illum.",
                        IntroduceAt = new DateTimeOffset(new DateTime(2021, 1, 11, 0, 48, 24, 960, DateTimeKind.Unspecified).AddTicks(2845),
                            new TimeSpan(0, -3, 0, 0, 0)),
                        Name = "corporis",
                        Option = "Three",
                        PhotoUrl = "https://picsum.photos/640/480/?image=126",
                        Price = 0.8917820185893048140463651574m,
                        ProductTypeId = new Guid("95a5fa4a-41fb-44ee-8670-a9305d24fe94"),
                        Rating = -150764334,
                        Stock = -158683822,
                        BackpackType = "Overnight"
                    },
                    new
                    {
                        Id = new Guid("7c118d3f-fa6c-4e2f-ae29-bdb75b67bcca"),
                        Description = "Molestiae autem voluptatem quia est aliquam inventore et eligendi.",
                        IntroduceAt = new DateTimeOffset(new DateTime(2021, 6, 22, 22, 3, 30, 142, DateTimeKind.Unspecified).AddTicks(2625),
                            new TimeSpan(0, -3, 0, 0, 0)),
                        Name = "beatae",
                        Option = "Three",
                        PhotoUrl = "https://picsum.photos/640/480/?image=767",
                        Price = 0.755224933270630898865875987m,
                        ProductTypeId = new Guid("c814a26e-6e82-43ed-8e08-6eaa45d741ff"),
                        Rating = -1551880589,
                        Stock = -45011175,
                        BackpackType = "Climbing"
                    },
                    new
                    {
                        Id = new Guid("806049ab-d1dd-43f6-8f8d-5dea6e0ce737"),
                        Description = "Aliquam odio est repellat et.",
                        IntroduceAt = new DateTimeOffset(new DateTime(2021, 7, 2, 20, 50, 26, 753, DateTimeKind.Unspecified).AddTicks(552),
                            new TimeSpan(0, -3, 0, 0, 0)),
                        Name = "error",
                        Option = "One",
                        PhotoUrl = "https://picsum.photos/640/480/?image=638",
                        Price = 0.9729027788944088721610383847m,
                        ProductTypeId = new Guid("c814a26e-6e82-43ed-8e08-6eaa45d741ff"),
                        Rating = 1178579590,
                        Stock = -1409763124,
                        BackpackType = "Cycling"
                    },
                    new
                    {
                        Id = new Guid("bdec72b1-e31e-4d16-9ffa-1e770a55fbfe"),
                        Description = "Adipisci veniam vel molestiae cumque repellendus.",
                        IntroduceAt = new DateTimeOffset(new DateTime(2021, 1, 16, 4, 13, 8, 275, DateTimeKind.Unspecified).AddTicks(1082),
                            new TimeSpan(0, -3, 0, 0, 0)),
                        Name = "dicta",
                        Option = "Three",
                        PhotoUrl = "https://picsum.photos/640/480/?image=167",
                        Price = 0.7725874024881922784864508034m,
                        ProductTypeId = new Guid("95a5fa4a-41fb-44ee-8670-a9305d24fe94"),
                        Rating = 1934946659,
                        Stock = 169572605,
                        BackpackType = "Cycling"
                    },
                    new
                    {
                        Id = new Guid("8a9a9c62-dade-42ea-83b4-3049272d20b1"),
                        Description = "Nobis voluptatem hic sed dolor.",
                        IntroduceAt = new DateTimeOffset(new DateTime(2020, 12, 26, 1, 13, 48, 824, DateTimeKind.Unspecified).AddTicks(5989),
                            new TimeSpan(0, -3, 0, 0, 0)),
                        Name = "temporibus",
                        Option = "Three",
                        PhotoUrl = "https://picsum.photos/640/480/?image=424",
                        Price = 0.9915078103710690873123207772m,
                        ProductTypeId = new Guid("95a5fa4a-41fb-44ee-8670-a9305d24fe94"),
                        Rating = 890813381,
                        Stock = 644647986,
                        BackpackType = "Overnight"
                    },
                    new
                    {
                        Id = new Guid("d863b949-7022-4ce1-b393-1f1a5124222c"),
                        Description = "Veniam veritatis officiis perferendis qui aut rem voluptatibus.",
                        IntroduceAt = new DateTimeOffset(new DateTime(2020, 9, 4, 11, 39, 30, 314, DateTimeKind.Unspecified).AddTicks(4640),
                            new TimeSpan(0, -3, 0, 0, 0)),
                        Name = "est",
                        Option = "One",
                        PhotoUrl = "https://picsum.photos/640/480/?image=195",
                        Price = 0.192394518470792778788641164m,
                        ProductTypeId = new Guid("95a5fa4a-41fb-44ee-8670-a9305d24fe94"),
                        Rating = -1266093261,
                        Stock = 1125244209,
                        BackpackType = "DayPack"
                    },
                    new
                    {
                        Id = new Guid("51914a05-d8f1-43ce-ba3c-a4ac9c123f5d"),
                        Description = "Aperiam eius ratione odit asperiores enim commodi eum quaerat esse.",
                        IntroduceAt = new DateTimeOffset(new DateTime(2021, 6, 9, 3, 37, 23, 882, DateTimeKind.Unspecified).AddTicks(5033),
                            new TimeSpan(0, -3, 0, 0, 0)),
                        Name = "voluptas",
                        Option = "Two",
                        PhotoUrl = "https://picsum.photos/640/480/?image=168",
                        Price = 0.0321023644230593708908540067m,
                        ProductTypeId = new Guid("c814a26e-6e82-43ed-8e08-6eaa45d741ff"),
                        Rating = -611395981,
                        Stock = 2036189084,
                        BackpackType = "Cycling"
                    },
                    new
                    {
                        Id = new Guid("43be72a4-2691-4a91-94e6-3762ab5228a5"),
                        Description = "Temporibus ratione aut incidunt iusto reprehenderit et eum culpa et.",
                        IntroduceAt = new DateTimeOffset(new DateTime(2021, 4, 22, 21, 29, 46, 952, DateTimeKind.Unspecified).AddTicks(89),
                            new TimeSpan(0, -3, 0, 0, 0)),
                        Name = "delectus",
                        Option = "One",
                        PhotoUrl = "https://picsum.photos/640/480/?image=379",
                        Price = 0.1066756842413618296509278576m,
                        ProductTypeId = new Guid("d3e13982-118b-4b99-ac5d-cd3da3b4cc35"),
                        Rating = -813814913,
                        Stock = -1434278080,
                        BackpackType = "Cycling"
                    },
                    new
                    {
                        Id = new Guid("49d4e24d-57c2-442e-9979-aa44d677acbc"),
                        Description = "Nisi consequatur cum ut ipsum.",
                        IntroduceAt = new DateTimeOffset(new DateTime(2020, 10, 30, 6, 18, 47, 978, DateTimeKind.Unspecified).AddTicks(6189),
                            new TimeSpan(0, -3, 0, 0, 0)),
                        Name = "temporibus",
                        Option = "One",
                        PhotoUrl = "https://picsum.photos/640/480/?image=749",
                        Price = 0.9672496342319568764927512616m,
                        ProductTypeId = new Guid("d3e13982-118b-4b99-ac5d-cd3da3b4cc35"),
                        Rating = 1485649644,
                        Stock = -835571664,
                        BackpackType = "Climbing"
                    },
                    new
                    {
                        Id = new Guid("30d11008-aa26-42ce-8ba7-21c40a04a36d"),
                        Description = "Numquam ea vel voluptate expedita laborum consequatur.",
                        IntroduceAt = new DateTimeOffset(new DateTime(2020, 12, 31, 21, 13, 4, 491, DateTimeKind.Unspecified).AddTicks(7256),
                            new TimeSpan(0, -3, 0, 0, 0)),
                        Name = "voluptas",
                        Option = "Two",
                        PhotoUrl = "https://picsum.photos/640/480/?image=363",
                        Price = 0.1315726673184179787381271677m,
                        ProductTypeId = new Guid("c814a26e-6e82-43ed-8e08-6eaa45d741ff"),
                        Rating = 244917988,
                        Stock = -1318188380,
                        BackpackType = "Overnight"
                    },
                    new
                    {
                        Id = new Guid("d937f183-e800-4cd2-8d9c-40d042f52de7"),
                        Description = "Rerum voluptatem corporis voluptatem voluptatum ex eos.",
                        IntroduceAt = new DateTimeOffset(new DateTime(2021, 3, 25, 18, 41, 12, 292, DateTimeKind.Unspecified).AddTicks(9956),
                            new TimeSpan(0, -3, 0, 0, 0)),
                        Name = "libero",
                        Option = "One",
                        PhotoUrl = "https://picsum.photos/640/480/?image=269",
                        Price = 0.0640520983219103087968770862m,
                        ProductTypeId = new Guid("c814a26e-6e82-43ed-8e08-6eaa45d741ff"),
                        Rating = 706046774,
                        Stock = -499623745,
                        BackpackType = "DayPack"
                    },
                    new
                    {
                        Id = new Guid("b8f1a660-7251-422f-9162-96f122594166"),
                        Description = "Autem et aut.",
                        IntroduceAt = new DateTimeOffset(new DateTime(2021, 4, 26, 19, 42, 37, 709, DateTimeKind.Unspecified).AddTicks(5867),
                            new TimeSpan(0, -3, 0, 0, 0)),
                        Name = "optio",
                        Option = "Three",
                        PhotoUrl = "https://picsum.photos/640/480/?image=756",
                        Price = 0.334908360024987840703362037m,
                        ProductTypeId = new Guid("c814a26e-6e82-43ed-8e08-6eaa45d741ff"),
                        Rating = 1388051443,
                        Stock = -293585076,
                        BackpackType = "Climbing"
                    },
                    new
                    {
                        Id = new Guid("8f3a86ff-bda9-494e-9fda-4df0ca354613"),
                        Description = "Illum et magnam iusto quis suscipit iure expedita officiis.",
                        IntroduceAt = new DateTimeOffset(new DateTime(2021, 3, 8, 12, 29, 32, 629, DateTimeKind.Unspecified).AddTicks(1635),
                            new TimeSpan(0, -3, 0, 0, 0)),
                        Name = "quo",
                        Option = "One",
                        PhotoUrl = "https://picsum.photos/640/480/?image=1078",
                        Price = 0.7000880651778670495079987112m,
                        ProductTypeId = new Guid("95a5fa4a-41fb-44ee-8670-a9305d24fe94"),
                        Rating = -891691790,
                        Stock = -626330894,
                        BackpackType = "Climbing"
                    },
                    new
                    {
                        Id = new Guid("95a57bad-66c8-49c1-8c21-ec4b44fe4668"),
                        Description = "Amet fugiat aut modi quidem voluptas rerum at asperiores.",
                        IntroduceAt = new DateTimeOffset(new DateTime(2021, 2, 12, 0, 58, 47, 697, DateTimeKind.Unspecified).AddTicks(7694),
                            new TimeSpan(0, -3, 0, 0, 0)),
                        Name = "nisi",
                        Option = "One",
                        PhotoUrl = "https://picsum.photos/640/480/?image=440",
                        Price = 0.5013937131458650005594303676m,
                        ProductTypeId = new Guid("d3e13982-118b-4b99-ac5d-cd3da3b4cc35"),
                        Rating = -732755160,
                        Stock = 1802341338,
                        BackpackType = "Climbing"
                    },
                    new
                    {
                        Id = new Guid("84129002-c5c8-49fd-9aa2-0156b2c71763"),
                        Description = "Qui aperiam aut officiis rerum.",
                        IntroduceAt = new DateTimeOffset(new DateTime(2020, 9, 29, 13, 55, 14, 491, DateTimeKind.Unspecified).AddTicks(2571),
                            new TimeSpan(0, -3, 0, 0, 0)),
                        Name = "quod",
                        Option = "One",
                        PhotoUrl = "https://picsum.photos/640/480/?image=524",
                        Price = 0.1404408299498189277224400293m,
                        ProductTypeId = new Guid("95a5fa4a-41fb-44ee-8670-a9305d24fe94"),
                        Rating = 1323167380,
                        Stock = 674977312,
                        BackpackType = "Climbing"
                    },
                    new
                    {
                        Id = new Guid("2a9456f4-2e3e-4f85-9184-8fce63a8d62f"),
                        Description = "Molestiae provident veniam molestiae et inventore qui impedit facilis.",
                        IntroduceAt = new DateTimeOffset(new DateTime(2020, 11, 25, 6, 35, 38, 212, DateTimeKind.Unspecified).AddTicks(3117),
                            new TimeSpan(0, -3, 0, 0, 0)),
                        Name = "doloribus",
                        Option = "Two",
                        PhotoUrl = "https://picsum.photos/640/480/?image=437",
                        Price = 0.7620706780811261680831888266m,
                        ProductTypeId = new Guid("95a5fa4a-41fb-44ee-8670-a9305d24fe94"),
                        Rating = 850551374,
                        Stock = 72119809,
                        BackpackType = "Cycling"
                    });
            });

            modelBuilder.Entity("Dotnet5.GraphQL.Store.Domain.Entities.Products.Boot", b =>
            {
                b.HasBaseType("Dotnet5.GraphQL.Store.Domain.Entities.Products.Product");

                b.Property<string>("BootType")
                   .IsRequired()
                   .HasColumnType("nvarchar(max)");

                b.Property<int>("Size")
                   .HasColumnType("int");

                b.HasDiscriminator().HasValue("Boot");

                b.HasData(new
                    {
                        Id = new Guid("bea1b5ba-7219-4727-b10a-8c57752257ce"),
                        Description = "Et molestiae iste est soluta possimus similique fugiat.",
                        IntroduceAt = new DateTimeOffset(new DateTime(2021, 1, 18, 22, 55, 4, 723, DateTimeKind.Unspecified).AddTicks(1270),
                            new TimeSpan(0, -3, 0, 0, 0)),
                        Name = "maiores",
                        Option = "Two",
                        PhotoUrl = "https://picsum.photos/640/480/?image=538",
                        Price = 0.1926805769819139180184991502m,
                        ProductTypeId = new Guid("95a5fa4a-41fb-44ee-8670-a9305d24fe94"),
                        Rating = -598340413,
                        Stock = -224653747,
                        BootType = "Football",
                        Size = 787907924
                    },
                    new
                    {
                        Id = new Guid("1ffa6214-fd7a-4e59-b9ca-de5e0cbdf828"),
                        Description = "Dolorem alias nisi ut suscipit et fugit voluptas quam quidem.",
                        IntroduceAt = new DateTimeOffset(new DateTime(2021, 6, 13, 0, 3, 4, 110, DateTimeKind.Unspecified).AddTicks(7922),
                            new TimeSpan(0, -3, 0, 0, 0)),
                        Name = "consectetur",
                        Option = "One",
                        PhotoUrl = "https://picsum.photos/640/480/?image=156",
                        Price = 0.0742728038480234909499884843m,
                        ProductTypeId = new Guid("c814a26e-6e82-43ed-8e08-6eaa45d741ff"),
                        Rating = 1306771619,
                        Stock = 1972094084,
                        BootType = "Drysuit",
                        Size = -1860161043
                    },
                    new
                    {
                        Id = new Guid("95f83460-696a-47f0-b470-291a13e92571"),
                        Description = "Asperiores sit est.",
                        IntroduceAt = new DateTimeOffset(new DateTime(2021, 2, 1, 4, 9, 47, 963, DateTimeKind.Unspecified).AddTicks(8839),
                            new TimeSpan(0, -3, 0, 0, 0)),
                        Name = "illum",
                        Option = "One",
                        PhotoUrl = "https://picsum.photos/640/480/?image=33",
                        Price = 0.51545940640843640420554552m,
                        ProductTypeId = new Guid("d3e13982-118b-4b99-ac5d-cd3da3b4cc35"),
                        Rating = -999877566,
                        Stock = -1720213698,
                        BootType = "Cowboy",
                        Size = -968305962
                    },
                    new
                    {
                        Id = new Guid("94d6eb28-511d-44fd-bd67-0afa4adb2c03"),
                        Description = "Aspernatur quia recusandae cumque minima.",
                        IntroduceAt = new DateTimeOffset(new DateTime(2020, 10, 5, 8, 34, 25, 268, DateTimeKind.Unspecified).AddTicks(9696),
                            new TimeSpan(0, -3, 0, 0, 0)),
                        Name = "at",
                        Option = "One",
                        PhotoUrl = "https://picsum.photos/640/480/?image=113",
                        Price = 0.8236710753673823850733386141m,
                        ProductTypeId = new Guid("95a5fa4a-41fb-44ee-8670-a9305d24fe94"),
                        Rating = -1728488116,
                        Stock = -1934823018,
                        BootType = "Drysuit",
                        Size = -1632123298
                    },
                    new
                    {
                        Id = new Guid("aafd0f62-58bf-433d-910c-be7dfcc765e3"),
                        Description = "Id non et harum consectetur quas.",
                        IntroduceAt = new DateTimeOffset(new DateTime(2021, 7, 9, 15, 46, 56, 944, DateTimeKind.Unspecified).AddTicks(2022),
                            new TimeSpan(0, -3, 0, 0, 0)),
                        Name = "quia",
                        Option = "Three",
                        PhotoUrl = "https://picsum.photos/640/480/?image=399",
                        Price = 0.3757448062796132347935656768m,
                        ProductTypeId = new Guid("c814a26e-6e82-43ed-8e08-6eaa45d741ff"),
                        Rating = 1011199658,
                        Stock = -211044534,
                        BootType = "Engineer",
                        Size = 104208390
                    },
                    new
                    {
                        Id = new Guid("d3a38609-8084-434c-94ad-f638404212aa"),
                        Description = "Assumenda velit vel est iusto consequatur numquam consequatur explicabo numquam.",
                        IntroduceAt = new DateTimeOffset(new DateTime(2021, 3, 21, 14, 10, 42, 919, DateTimeKind.Unspecified).AddTicks(6040),
                            new TimeSpan(0, -3, 0, 0, 0)),
                        Name = "quasi",
                        Option = "One",
                        PhotoUrl = "https://picsum.photos/640/480/?image=458",
                        Price = 0.5343688834011158338014895092m,
                        ProductTypeId = new Guid("c814a26e-6e82-43ed-8e08-6eaa45d741ff"),
                        Rating = -1686689532,
                        Stock = -1516367318,
                        BootType = "Chelsea",
                        Size = 395865133
                    },
                    new
                    {
                        Id = new Guid("ae51139b-84cd-4da5-aa51-fd6ac214c068"),
                        Description = "Dignissimos animi illo quidem omnis laudantium reiciendis.",
                        IntroduceAt = new DateTimeOffset(new DateTime(2020, 10, 8, 19, 27, 51, 159, DateTimeKind.Unspecified).AddTicks(1193),
                            new TimeSpan(0, -3, 0, 0, 0)),
                        Name = "quibusdam",
                        Option = "Two",
                        PhotoUrl = "https://picsum.photos/640/480/?image=203",
                        Price = 0.5723973668078197896908187589m,
                        ProductTypeId = new Guid("c814a26e-6e82-43ed-8e08-6eaa45d741ff"),
                        Rating = -2079194216,
                        Stock = 1121109602,
                        BootType = "Chelsea",
                        Size = -727700889
                    },
                    new
                    {
                        Id = new Guid("d7b9b561-5f50-4f08-9321-2bd87506a527"),
                        Description = "Quis quae tempore.",
                        IntroduceAt = new DateTimeOffset(new DateTime(2021, 2, 20, 2, 8, 51, 941, DateTimeKind.Unspecified).AddTicks(6065),
                            new TimeSpan(0, -3, 0, 0, 0)),
                        Name = "reiciendis",
                        Option = "Two",
                        PhotoUrl = "https://picsum.photos/640/480/?image=820",
                        Price = 0.2834701896208822232822059093m,
                        ProductTypeId = new Guid("c814a26e-6e82-43ed-8e08-6eaa45d741ff"),
                        Rating = 668762314,
                        Stock = -1421453815,
                        BootType = "Harness",
                        Size = -2029159059
                    },
                    new
                    {
                        Id = new Guid("b492ec0d-fe7e-472a-951d-8a3a97d82c68"),
                        Description = "Porro quia possimus sit id porro aut impedit.",
                        IntroduceAt = new DateTimeOffset(new DateTime(2021, 6, 28, 0, 1, 29, 221, DateTimeKind.Unspecified).AddTicks(4114),
                            new TimeSpan(0, -3, 0, 0, 0)),
                        Name = "aut",
                        Option = "Two",
                        PhotoUrl = "https://picsum.photos/640/480/?image=258",
                        Price = 0.904292347561835677612800605m,
                        ProductTypeId = new Guid("95a5fa4a-41fb-44ee-8670-a9305d24fe94"),
                        Rating = -96451128,
                        Stock = 1793983115,
                        BootType = "Harness",
                        Size = 1291393399
                    },
                    new
                    {
                        Id = new Guid("bbe3e615-8386-4874-91f2-54d87edb843e"),
                        Description = "Fugiat qui quis ipsa perspiciatis voluptas error.",
                        IntroduceAt = new DateTimeOffset(new DateTime(2020, 11, 28, 4, 54, 55, 758, DateTimeKind.Unspecified).AddTicks(3580),
                            new TimeSpan(0, -3, 0, 0, 0)),
                        Name = "qui",
                        Option = "Two",
                        PhotoUrl = "https://picsum.photos/640/480/?image=336",
                        Price = 0.7832651056919147034748621278m,
                        ProductTypeId = new Guid("c814a26e-6e82-43ed-8e08-6eaa45d741ff"),
                        Rating = -1515404921,
                        Stock = 288416647,
                        BootType = "Chelsea",
                        Size = 1614919044
                    },
                    new
                    {
                        Id = new Guid("62845a7e-1398-4186-bf05-38515fe23929"),
                        Description = "Saepe dolorem voluptatem laudantium ea.",
                        IntroduceAt = new DateTimeOffset(new DateTime(2020, 11, 24, 1, 20, 13, 499, DateTimeKind.Unspecified).AddTicks(6487),
                            new TimeSpan(0, -3, 0, 0, 0)),
                        Name = "sequi",
                        Option = "One",
                        PhotoUrl = "https://picsum.photos/640/480/?image=513",
                        Price = 0.6119934957024219239674205986m,
                        ProductTypeId = new Guid("95a5fa4a-41fb-44ee-8670-a9305d24fe94"),
                        Rating = -368623228,
                        Stock = -438115829,
                        BootType = "Engineer",
                        Size = -1704590115
                    },
                    new
                    {
                        Id = new Guid("549bc968-3a0b-40ff-97ca-ae5bab983197"),
                        Description = "Excepturi explicabo accusamus.",
                        IntroduceAt = new DateTimeOffset(new DateTime(2020, 12, 8, 15, 27, 4, 722, DateTimeKind.Unspecified).AddTicks(4573),
                            new TimeSpan(0, -3, 0, 0, 0)),
                        Name = "nihil",
                        Option = "One",
                        PhotoUrl = "https://picsum.photos/640/480/?image=467",
                        Price = 0.3147651993692776993324055604m,
                        ProductTypeId = new Guid("d3e13982-118b-4b99-ac5d-cd3da3b4cc35"),
                        Rating = 319166791,
                        Stock = -757094121,
                        BootType = "Football",
                        Size = -1181498474
                    },
                    new
                    {
                        Id = new Guid("8b0fb6dd-b2f7-48ca-8f26-00a52b0e92fc"),
                        Description = "Sed maxime id doloremque repellendus quod similique ratione sapiente et.",
                        IntroduceAt = new DateTimeOffset(new DateTime(2021, 7, 2, 9, 2, 21, 747, DateTimeKind.Unspecified).AddTicks(4026),
                            new TimeSpan(0, -3, 0, 0, 0)),
                        Name = "nisi",
                        Option = "Two",
                        PhotoUrl = "https://picsum.photos/640/480/?image=1051",
                        Price = 0.8228390992905499395794088524m,
                        ProductTypeId = new Guid("d3e13982-118b-4b99-ac5d-cd3da3b4cc35"),
                        Rating = 1917645271,
                        Stock = -1087216803,
                        BootType = "Cowboy",
                        Size = 1917598627
                    },
                    new
                    {
                        Id = new Guid("7c2b35a8-e1c7-4294-93e1-7dc282950d22"),
                        Description = "Cupiditate tempora libero adipisci quas.",
                        IntroduceAt = new DateTimeOffset(new DateTime(2020, 8, 14, 16, 15, 19, 265, DateTimeKind.Unspecified).AddTicks(7032),
                            new TimeSpan(0, -3, 0, 0, 0)),
                        Name = "quidem",
                        Option = "One",
                        PhotoUrl = "https://picsum.photos/640/480/?image=5",
                        Price = 0.7008931663668790765860305209m,
                        ProductTypeId = new Guid("95a5fa4a-41fb-44ee-8670-a9305d24fe94"),
                        Rating = -765555025,
                        Stock = -187988315,
                        BootType = "Engineer",
                        Size = 656967978
                    },
                    new
                    {
                        Id = new Guid("628f270f-cbb8-4f35-a448-cdf18942cb83"),
                        Description = "Perspiciatis dolorum qui doloremque vero.",
                        IntroduceAt = new DateTimeOffset(new DateTime(2021, 7, 27, 17, 6, 4, 692, DateTimeKind.Unspecified).AddTicks(29),
                            new TimeSpan(0, -3, 0, 0, 0)),
                        Name = "dignissimos",
                        Option = "One",
                        PhotoUrl = "https://picsum.photos/640/480/?image=309",
                        Price = 0.9503753260413711372063918037m,
                        ProductTypeId = new Guid("c814a26e-6e82-43ed-8e08-6eaa45d741ff"),
                        Rating = -546294253,
                        Stock = 682213087,
                        BootType = "Harness",
                        Size = 2140676644
                    },
                    new
                    {
                        Id = new Guid("31a14d59-a65c-4c7d-921c-d071e2c21bcc"),
                        Description = "Voluptatem totam non.",
                        IntroduceAt = new DateTimeOffset(new DateTime(2020, 8, 4, 4, 22, 38, 597, DateTimeKind.Unspecified).AddTicks(2129),
                            new TimeSpan(0, -3, 0, 0, 0)),
                        Name = "corrupti",
                        Option = "Two",
                        PhotoUrl = "https://picsum.photos/640/480/?image=367",
                        Price = 0.236606163908968657228197705m,
                        ProductTypeId = new Guid("c814a26e-6e82-43ed-8e08-6eaa45d741ff"),
                        Rating = -793747962,
                        Stock = 411938534,
                        BootType = "Harness",
                        Size = 2071933917
                    },
                    new
                    {
                        Id = new Guid("6f16c858-6d47-4c4c-b09a-96a6a3bc3309"),
                        Description = "Sunt hic qui quos voluptatum molestiae earum autem voluptatem.",
                        IntroduceAt = new DateTimeOffset(new DateTime(2020, 9, 22, 10, 53, 12, 964, DateTimeKind.Unspecified).AddTicks(8815),
                            new TimeSpan(0, -3, 0, 0, 0)),
                        Name = "officiis",
                        Option = "Two",
                        PhotoUrl = "https://picsum.photos/640/480/?image=382",
                        Price = 0.8517853125401703613523729885m,
                        ProductTypeId = new Guid("c814a26e-6e82-43ed-8e08-6eaa45d741ff"),
                        Rating = -2044291300,
                        Stock = 1366505568,
                        BootType = "Engineer",
                        Size = -1824894999
                    },
                    new
                    {
                        Id = new Guid("abaaa1a2-683b-4842-8783-daa59e98fbfb"),
                        Description = "Distinctio quisquam assumenda.",
                        IntroduceAt = new DateTimeOffset(new DateTime(2021, 2, 6, 9, 35, 6, 991, DateTimeKind.Unspecified).AddTicks(9544),
                            new TimeSpan(0, -3, 0, 0, 0)),
                        Name = "sed",
                        Option = "Two",
                        PhotoUrl = "https://picsum.photos/640/480/?image=881",
                        Price = 0.0408171039742295342521581281m,
                        ProductTypeId = new Guid("95a5fa4a-41fb-44ee-8670-a9305d24fe94"),
                        Rating = -2108568547,
                        Stock = -1529206194,
                        BootType = "Chelsea",
                        Size = 782075286
                    },
                    new
                    {
                        Id = new Guid("49b6c9dc-f3cd-4151-9b59-043ade1b272e"),
                        Description = "Voluptas at ab sunt.",
                        IntroduceAt = new DateTimeOffset(new DateTime(2021, 4, 29, 5, 39, 59, 506, DateTimeKind.Unspecified).AddTicks(8580),
                            new TimeSpan(0, -3, 0, 0, 0)),
                        Name = "quis",
                        Option = "Three",
                        PhotoUrl = "https://picsum.photos/640/480/?image=931",
                        Price = 0.1707977273615642654184441422m,
                        ProductTypeId = new Guid("c814a26e-6e82-43ed-8e08-6eaa45d741ff"),
                        Rating = -818857273,
                        Stock = -698881956,
                        BootType = "Harness",
                        Size = 1191262978
                    },
                    new
                    {
                        Id = new Guid("f857160b-bc87-4b9a-b72f-b32d5bde3967"),
                        Description = "Deserunt reprehenderit aspernatur.",
                        IntroduceAt = new DateTimeOffset(new DateTime(2021, 4, 20, 16, 32, 3, 940, DateTimeKind.Unspecified).AddTicks(1345),
                            new TimeSpan(0, -3, 0, 0, 0)),
                        Name = "dolores",
                        Option = "One",
                        PhotoUrl = "https://picsum.photos/640/480/?image=345",
                        Price = 0.3580105795070785559403622293m,
                        ProductTypeId = new Guid("c814a26e-6e82-43ed-8e08-6eaa45d741ff"),
                        Rating = 644738107,
                        Stock = -656765861,
                        BootType = "Chelsea",
                        Size = 1586101908
                    },
                    new
                    {
                        Id = new Guid("4da87289-ef28-4572-955a-dd44e762026c"),
                        Description = "Consequuntur nihil minus aut quas soluta.",
                        IntroduceAt = new DateTimeOffset(new DateTime(2020, 11, 12, 3, 48, 45, 928, DateTimeKind.Unspecified).AddTicks(9501),
                            new TimeSpan(0, -3, 0, 0, 0)),
                        Name = "quis",
                        Option = "One",
                        PhotoUrl = "https://picsum.photos/640/480/?image=290",
                        Price = 0.3700229984580395391467826165m,
                        ProductTypeId = new Guid("95a5fa4a-41fb-44ee-8670-a9305d24fe94"),
                        Rating = 878040505,
                        Stock = 2058441610,
                        BootType = "Cowboy",
                        Size = -1431759724
                    },
                    new
                    {
                        Id = new Guid("a4388e3d-de5e-4ad4-9764-74cf10ecde25"),
                        Description = "Vel dolorem accusamus consequatur sed consectetur quaerat facere quasi.",
                        IntroduceAt = new DateTimeOffset(new DateTime(2021, 3, 22, 0, 27, 9, 767, DateTimeKind.Unspecified).AddTicks(6478),
                            new TimeSpan(0, -3, 0, 0, 0)),
                        Name = "amet",
                        Option = "One",
                        PhotoUrl = "https://picsum.photos/640/480/?image=690",
                        Price = 0.403146194399833158420509228m,
                        ProductTypeId = new Guid("d3e13982-118b-4b99-ac5d-cd3da3b4cc35"),
                        Rating = -193267528,
                        Stock = -330966441,
                        BootType = "Harness",
                        Size = -1090381537
                    },
                    new
                    {
                        Id = new Guid("97db1c78-aa59-40d3-a610-6178686f75fd"),
                        Description = "Tenetur sed necessitatibus fuga est illum nisi.",
                        IntroduceAt = new DateTimeOffset(new DateTime(2020, 10, 5, 11, 8, 58, 348, DateTimeKind.Unspecified).AddTicks(2206),
                            new TimeSpan(0, -3, 0, 0, 0)),
                        Name = "illum",
                        Option = "One",
                        PhotoUrl = "https://picsum.photos/640/480/?image=1079",
                        Price = 0.6636073096676749974007514204m,
                        ProductTypeId = new Guid("c814a26e-6e82-43ed-8e08-6eaa45d741ff"),
                        Rating = 1380442398,
                        Stock = -1529451518,
                        BootType = "Engineer",
                        Size = 880162587
                    },
                    new
                    {
                        Id = new Guid("5de55aa5-acd1-4c91-ae1c-200b3c8c25cb"),
                        Description = "Qui sit nostrum.",
                        IntroduceAt = new DateTimeOffset(new DateTime(2021, 3, 10, 23, 33, 35, 747, DateTimeKind.Unspecified).AddTicks(5582),
                            new TimeSpan(0, -3, 0, 0, 0)),
                        Name = "nobis",
                        Option = "Two",
                        PhotoUrl = "https://picsum.photos/640/480/?image=233",
                        Price = 0.7908887352436406724781954592m,
                        ProductTypeId = new Guid("c814a26e-6e82-43ed-8e08-6eaa45d741ff"),
                        Rating = -1762920615,
                        Stock = -1215015360,
                        BootType = "Cowboy",
                        Size = 833302165
                    },
                    new
                    {
                        Id = new Guid("6797e621-4461-4e19-baa8-d4664566bded"),
                        Description = "Consequatur nihil et dolorum impedit placeat aut nihil.",
                        IntroduceAt = new DateTimeOffset(new DateTime(2020, 11, 9, 2, 15, 5, 907, DateTimeKind.Unspecified).AddTicks(40),
                            new TimeSpan(0, -3, 0, 0, 0)),
                        Name = "quae",
                        Option = "One",
                        PhotoUrl = "https://picsum.photos/640/480/?image=16",
                        Price = 0.2966869378186310564425539149m,
                        ProductTypeId = new Guid("c814a26e-6e82-43ed-8e08-6eaa45d741ff"),
                        Rating = -631325475,
                        Stock = -1077632976,
                        BootType = "Harness",
                        Size = -1783637712
                    },
                    new
                    {
                        Id = new Guid("4890996a-ffa2-48d6-913f-f40e7ecfb17d"),
                        Description = "Velit tempore doloribus nulla quaerat totam itaque.",
                        IntroduceAt = new DateTimeOffset(new DateTime(2020, 12, 21, 18, 40, 55, 773, DateTimeKind.Unspecified).AddTicks(5350),
                            new TimeSpan(0, -3, 0, 0, 0)),
                        Name = "eum",
                        Option = "Two",
                        PhotoUrl = "https://picsum.photos/640/480/?image=414",
                        Price = 0.7562059467152082618192229605m,
                        ProductTypeId = new Guid("d3e13982-118b-4b99-ac5d-cd3da3b4cc35"),
                        Rating = 432019376,
                        Stock = -53133089,
                        BootType = "Cowboy",
                        Size = -146467592
                    },
                    new
                    {
                        Id = new Guid("08a93355-3f0e-4439-85ab-2a8fa2b664cf"),
                        Description = "Fugiat quo dolores qui illum consequatur necessitatibus.",
                        IntroduceAt = new DateTimeOffset(new DateTime(2020, 8, 20, 4, 1, 48, 536, DateTimeKind.Unspecified).AddTicks(6294),
                            new TimeSpan(0, -3, 0, 0, 0)),
                        Name = "quisquam",
                        Option = "Three",
                        PhotoUrl = "https://picsum.photos/640/480/?image=715",
                        Price = 0.5541095041492093816413899591m,
                        ProductTypeId = new Guid("c814a26e-6e82-43ed-8e08-6eaa45d741ff"),
                        Rating = 132276869,
                        Stock = -1398547804,
                        BootType = "Chelsea",
                        Size = -359087701
                    },
                    new
                    {
                        Id = new Guid("efad398d-35ec-4e61-874f-78f38b7afc8b"),
                        Description = "Ut recusandae quidem voluptatem unde dolorem amet.",
                        IntroduceAt = new DateTimeOffset(new DateTime(2020, 10, 12, 9, 52, 58, 951, DateTimeKind.Unspecified).AddTicks(1905),
                            new TimeSpan(0, -3, 0, 0, 0)),
                        Name = "dolores",
                        Option = "One",
                        PhotoUrl = "https://picsum.photos/640/480/?image=874",
                        Price = 0.4482935273583902181826025539m,
                        ProductTypeId = new Guid("d3e13982-118b-4b99-ac5d-cd3da3b4cc35"),
                        Rating = 975011254,
                        Stock = 1972910602,
                        BootType = "Football",
                        Size = -1694172152
                    },
                    new
                    {
                        Id = new Guid("33b0796f-e73b-41f6-a27c-5b1cc3adc0b9"),
                        Description = "Et culpa doloribus.",
                        IntroduceAt = new DateTimeOffset(new DateTime(2020, 9, 12, 4, 53, 29, 729, DateTimeKind.Unspecified).AddTicks(8070),
                            new TimeSpan(0, -3, 0, 0, 0)),
                        Name = "possimus",
                        Option = "Two",
                        PhotoUrl = "https://picsum.photos/640/480/?image=1074",
                        Price = 0.0644687741893178090184903855m,
                        ProductTypeId = new Guid("c814a26e-6e82-43ed-8e08-6eaa45d741ff"),
                        Rating = 861327444,
                        Stock = 1968367444,
                        BootType = "Engineer",
                        Size = 178205428
                    },
                    new
                    {
                        Id = new Guid("6efa4585-5837-4ec1-88f1-c6bb01564a89"),
                        Description = "Quod deserunt ut dolores aut ducimus tenetur blanditiis earum autem.",
                        IntroduceAt = new DateTimeOffset(new DateTime(2021, 1, 29, 2, 7, 18, 23, DateTimeKind.Unspecified).AddTicks(3676),
                            new TimeSpan(0, -3, 0, 0, 0)),
                        Name = "odio",
                        Option = "Three",
                        PhotoUrl = "https://picsum.photos/640/480/?image=624",
                        Price = 0.7201140576370849213751508686m,
                        ProductTypeId = new Guid("d3e13982-118b-4b99-ac5d-cd3da3b4cc35"),
                        Rating = -385759054,
                        Stock = 38298879,
                        BootType = "Drysuit",
                        Size = -153445088
                    },
                    new
                    {
                        Id = new Guid("61a4fa3d-5d93-4195-b35a-2e2c4fe0006f"),
                        Description = "Accusamus magnam animi.",
                        IntroduceAt = new DateTimeOffset(new DateTime(2020, 10, 27, 16, 21, 23, 349, DateTimeKind.Unspecified).AddTicks(8675),
                            new TimeSpan(0, -3, 0, 0, 0)),
                        Name = "aut",
                        Option = "Three",
                        PhotoUrl = "https://picsum.photos/640/480/?image=581",
                        Price = 0.22196915359016835090767644m,
                        ProductTypeId = new Guid("95a5fa4a-41fb-44ee-8670-a9305d24fe94"),
                        Rating = 1808696842,
                        Stock = 1408124063,
                        BootType = "Harness",
                        Size = 984375126
                    },
                    new
                    {
                        Id = new Guid("301d56ee-6c23-478b-b6cf-10d591dcaaf9"),
                        Description = "Inventore exercitationem iure laborum cumque ipsam consequatur iusto.",
                        IntroduceAt = new DateTimeOffset(new DateTime(2021, 4, 18, 2, 52, 53, 879, DateTimeKind.Unspecified).AddTicks(2842),
                            new TimeSpan(0, -3, 0, 0, 0)),
                        Name = "similique",
                        Option = "Three",
                        PhotoUrl = "https://picsum.photos/640/480/?image=825",
                        Price = 0.4705432069201605730078945799m,
                        ProductTypeId = new Guid("c814a26e-6e82-43ed-8e08-6eaa45d741ff"),
                        Rating = -915051377,
                        Stock = 1246835026,
                        BootType = "Drysuit",
                        Size = 340550880
                    },
                    new
                    {
                        Id = new Guid("47d199c8-a2fa-4c76-949a-04603e25817b"),
                        Description = "Est dolorum ullam voluptatum quia id doloribus ea.",
                        IntroduceAt = new DateTimeOffset(new DateTime(2020, 10, 22, 4, 36, 27, 784, DateTimeKind.Unspecified).AddTicks(6840),
                            new TimeSpan(0, -3, 0, 0, 0)),
                        Name = "soluta",
                        Option = "One",
                        PhotoUrl = "https://picsum.photos/640/480/?image=391",
                        Price = 0.2841231594549997594734752624m,
                        ProductTypeId = new Guid("c814a26e-6e82-43ed-8e08-6eaa45d741ff"),
                        Rating = 1745108829,
                        Stock = -535760899,
                        BootType = "Cowboy",
                        Size = -1068959262
                    },
                    new
                    {
                        Id = new Guid("1affc620-c238-48bc-8d39-a519a7d6cc9a"),
                        Description = "Delectus assumenda et aperiam ratione omnis unde.",
                        IntroduceAt = new DateTimeOffset(new DateTime(2021, 2, 17, 20, 53, 52, 764, DateTimeKind.Unspecified).AddTicks(1134),
                            new TimeSpan(0, -3, 0, 0, 0)),
                        Name = "ut",
                        Option = "One",
                        PhotoUrl = "https://picsum.photos/640/480/?image=386",
                        Price = 0.9745825238923911402553216218m,
                        ProductTypeId = new Guid("95a5fa4a-41fb-44ee-8670-a9305d24fe94"),
                        Rating = 2126147209,
                        Stock = -2111224559,
                        BootType = "Drysuit",
                        Size = 1812293397
                    },
                    new
                    {
                        Id = new Guid("0f4ef39e-2351-4617-b060-1ecc9e273b53"),
                        Description = "Voluptatem sit quo quia qui et.",
                        IntroduceAt = new DateTimeOffset(new DateTime(2020, 12, 4, 22, 30, 6, 900, DateTimeKind.Unspecified).AddTicks(3775),
                            new TimeSpan(0, -3, 0, 0, 0)),
                        Name = "excepturi",
                        Option = "One",
                        PhotoUrl = "https://picsum.photos/640/480/?image=308",
                        Price = 0.6351595993463167151440433414m,
                        ProductTypeId = new Guid("95a5fa4a-41fb-44ee-8670-a9305d24fe94"),
                        Rating = 1632687569,
                        Stock = 1489655011,
                        BootType = "Drysuit",
                        Size = -1372688558
                    },
                    new
                    {
                        Id = new Guid("cfe3eeb3-c06e-4f16-b2fb-cf907dea60e9"),
                        Description = "Dicta consequuntur dolorem magni dolores sit dignissimos magni dolore enim.",
                        IntroduceAt = new DateTimeOffset(new DateTime(2021, 7, 21, 12, 35, 46, 885, DateTimeKind.Unspecified).AddTicks(8693),
                            new TimeSpan(0, -3, 0, 0, 0)),
                        Name = "nulla",
                        Option = "Three",
                        PhotoUrl = "https://picsum.photos/640/480/?image=221",
                        Price = 0.3286402514579596957140162723m,
                        ProductTypeId = new Guid("d3e13982-118b-4b99-ac5d-cd3da3b4cc35"),
                        Rating = -82875185,
                        Stock = 1923708400,
                        BootType = "Harness",
                        Size = 1098533970
                    },
                    new
                    {
                        Id = new Guid("94d4155a-728d-4a24-85d4-8e364f22dbf6"),
                        Description = "Excepturi velit officia aut quos et eveniet adipisci officia.",
                        IntroduceAt = new DateTimeOffset(new DateTime(2021, 7, 14, 7, 0, 7, 84, DateTimeKind.Unspecified).AddTicks(9897),
                            new TimeSpan(0, -3, 0, 0, 0)),
                        Name = "quo",
                        Option = "One",
                        PhotoUrl = "https://picsum.photos/640/480/?image=602",
                        Price = 0.9421948656311287103930497578m,
                        ProductTypeId = new Guid("95a5fa4a-41fb-44ee-8670-a9305d24fe94"),
                        Rating = 1643529896,
                        Stock = -1549767596,
                        BootType = "Chelsea",
                        Size = -194073079
                    },
                    new
                    {
                        Id = new Guid("f571c078-29b3-4aee-b784-f59597b772d4"),
                        Description = "Est vitae eligendi qui officiis.",
                        IntroduceAt = new DateTimeOffset(new DateTime(2021, 3, 25, 14, 21, 47, 106, DateTimeKind.Unspecified).AddTicks(7120),
                            new TimeSpan(0, -3, 0, 0, 0)),
                        Name = "dolorem",
                        Option = "Three",
                        PhotoUrl = "https://picsum.photos/640/480/?image=13",
                        Price = 0.3004214972746256229742939228m,
                        ProductTypeId = new Guid("95a5fa4a-41fb-44ee-8670-a9305d24fe94"),
                        Rating = -951962979,
                        Stock = 554640935,
                        BootType = "Cowboy",
                        Size = 263404461
                    },
                    new
                    {
                        Id = new Guid("504b88c3-5d0b-4010-a199-68fef2df5319"),
                        Description = "Et fugiat tempora.",
                        IntroduceAt = new DateTimeOffset(new DateTime(2020, 12, 3, 0, 33, 48, 375, DateTimeKind.Unspecified).AddTicks(3115),
                            new TimeSpan(0, -3, 0, 0, 0)),
                        Name = "perspiciatis",
                        Option = "Two",
                        PhotoUrl = "https://picsum.photos/640/480/?image=403",
                        Price = 0.9751585051597289020973372669m,
                        ProductTypeId = new Guid("d3e13982-118b-4b99-ac5d-cd3da3b4cc35"),
                        Rating = 1614454150,
                        Stock = -299183028,
                        BootType = "Harness",
                        Size = -983652474
                    },
                    new
                    {
                        Id = new Guid("ff76914a-2211-421b-ba28-78be81174de4"),
                        Description = "Commodi necessitatibus et at.",
                        IntroduceAt = new DateTimeOffset(new DateTime(2021, 5, 2, 22, 31, 30, 468, DateTimeKind.Unspecified).AddTicks(5502),
                            new TimeSpan(0, -3, 0, 0, 0)),
                        Name = "maxime",
                        Option = "Three",
                        PhotoUrl = "https://picsum.photos/640/480/?image=147",
                        Price = 0.3338431182456265777178037562m,
                        ProductTypeId = new Guid("d3e13982-118b-4b99-ac5d-cd3da3b4cc35"),
                        Rating = 773803110,
                        Stock = -1283890468,
                        BootType = "Harness",
                        Size = 661334342
                    },
                    new
                    {
                        Id = new Guid("580f7f61-0572-4325-b291-23b67201706c"),
                        Description = "Molestias reprehenderit dolores eius suscipit iusto eum.",
                        IntroduceAt = new DateTimeOffset(new DateTime(2020, 8, 7, 18, 52, 11, 983, DateTimeKind.Unspecified).AddTicks(9404),
                            new TimeSpan(0, -3, 0, 0, 0)),
                        Name = "saepe",
                        Option = "Two",
                        PhotoUrl = "https://picsum.photos/640/480/?image=606",
                        Price = 0.712059456989644560474989202m,
                        ProductTypeId = new Guid("95a5fa4a-41fb-44ee-8670-a9305d24fe94"),
                        Rating = 1770487509,
                        Stock = 121962005,
                        BootType = "Drysuit",
                        Size = 328156213
                    },
                    new
                    {
                        Id = new Guid("5741ae25-d669-493c-8e3a-c88d72c50678"),
                        Description = "Officiis sapiente quae.",
                        IntroduceAt = new DateTimeOffset(new DateTime(2020, 9, 17, 23, 39, 27, 534, DateTimeKind.Unspecified).AddTicks(3236),
                            new TimeSpan(0, -3, 0, 0, 0)),
                        Name = "fuga",
                        Option = "One",
                        PhotoUrl = "https://picsum.photos/640/480/?image=794",
                        Price = 0.634877001793648800181893596m,
                        ProductTypeId = new Guid("d3e13982-118b-4b99-ac5d-cd3da3b4cc35"),
                        Rating = -848560961,
                        Stock = -110324879,
                        BootType = "Football",
                        Size = -1714231157
                    },
                    new
                    {
                        Id = new Guid("212e25d0-df60-48ea-9a96-b00407e89ccb"),
                        Description = "Minus voluptatem a.",
                        IntroduceAt = new DateTimeOffset(new DateTime(2021, 8, 3, 20, 55, 59, 989, DateTimeKind.Unspecified).AddTicks(519),
                            new TimeSpan(0, -3, 0, 0, 0)),
                        Name = "accusantium",
                        Option = "One",
                        PhotoUrl = "https://picsum.photos/640/480/?image=7",
                        Price = 0.3748286025692046052526205236m,
                        ProductTypeId = new Guid("c814a26e-6e82-43ed-8e08-6eaa45d741ff"),
                        Rating = -294836913,
                        Stock = -390743591,
                        BootType = "Chelsea",
                        Size = 394618044
                    },
                    new
                    {
                        Id = new Guid("6ec4ac5a-8b96-4f0d-b7e6-1e74c81425d0"),
                        Description = "Sint veniam aut quod laborum aliquam nihil qui.",
                        IntroduceAt = new DateTimeOffset(new DateTime(2020, 8, 4, 4, 23, 12, 138, DateTimeKind.Unspecified).AddTicks(2474),
                            new TimeSpan(0, -3, 0, 0, 0)),
                        Name = "sit",
                        Option = "Three",
                        PhotoUrl = "https://picsum.photos/640/480/?image=223",
                        Price = 0.1630578964735937400757232495m,
                        ProductTypeId = new Guid("95a5fa4a-41fb-44ee-8670-a9305d24fe94"),
                        Rating = -1720201469,
                        Stock = 848558621,
                        BootType = "Chelsea",
                        Size = 785570351
                    },
                    new
                    {
                        Id = new Guid("77a44930-89e1-40e0-afbc-11b893886fc9"),
                        Description = "Nihil dignissimos commodi sunt ea temporibus earum dicta.",
                        IntroduceAt = new DateTimeOffset(new DateTime(2020, 8, 20, 1, 47, 27, 212, DateTimeKind.Unspecified).AddTicks(9990),
                            new TimeSpan(0, -3, 0, 0, 0)),
                        Name = "incidunt",
                        Option = "Two",
                        PhotoUrl = "https://picsum.photos/640/480/?image=571",
                        Price = 0.2340802744884805613465574588m,
                        ProductTypeId = new Guid("d3e13982-118b-4b99-ac5d-cd3da3b4cc35"),
                        Rating = 1349668158,
                        Stock = 783019855,
                        BootType = "Harness",
                        Size = 1963431434
                    },
                    new
                    {
                        Id = new Guid("21658814-c5ff-40b0-83bc-ad1cff5c9727"),
                        Description = "Eum quos totam.",
                        IntroduceAt = new DateTimeOffset(new DateTime(2021, 2, 3, 11, 4, 56, 62, DateTimeKind.Unspecified).AddTicks(4126),
                            new TimeSpan(0, -3, 0, 0, 0)),
                        Name = "qui",
                        Option = "One",
                        PhotoUrl = "https://picsum.photos/640/480/?image=619",
                        Price = 0.1469105135441545808322357284m,
                        ProductTypeId = new Guid("95a5fa4a-41fb-44ee-8670-a9305d24fe94"),
                        Rating = -1042012920,
                        Stock = -2094315238,
                        BootType = "Cowboy",
                        Size = 853831076
                    },
                    new
                    {
                        Id = new Guid("2278e5a5-b83b-42ee-b00d-4206d82e12fb"),
                        Description = "Suscipit ipsa et.",
                        IntroduceAt = new DateTimeOffset(new DateTime(2020, 11, 27, 10, 45, 45, 121, DateTimeKind.Unspecified).AddTicks(58),
                            new TimeSpan(0, -3, 0, 0, 0)),
                        Name = "asperiores",
                        Option = "Three",
                        PhotoUrl = "https://picsum.photos/640/480/?image=267",
                        Price = 0.5332518697701614164948450658m,
                        ProductTypeId = new Guid("95a5fa4a-41fb-44ee-8670-a9305d24fe94"),
                        Rating = 594256158,
                        Stock = -698993637,
                        BootType = "Engineer",
                        Size = -523040497
                    },
                    new
                    {
                        Id = new Guid("1d9b4775-89d4-4cfa-8696-4c540a125793"),
                        Description = "Quo velit amet adipisci qui voluptas ut.",
                        IntroduceAt = new DateTimeOffset(new DateTime(2021, 1, 12, 14, 20, 6, 243, DateTimeKind.Unspecified).AddTicks(1009),
                            new TimeSpan(0, -3, 0, 0, 0)),
                        Name = "ut",
                        Option = "Two",
                        PhotoUrl = "https://picsum.photos/640/480/?image=929",
                        Price = 0.0174106462759468304655334958m,
                        ProductTypeId = new Guid("95a5fa4a-41fb-44ee-8670-a9305d24fe94"),
                        Rating = 831847080,
                        Stock = 390931467,
                        BootType = "Chelsea",
                        Size = 1245225058
                    },
                    new
                    {
                        Id = new Guid("c01a3e51-aa67-423c-b1bb-69fd6d466422"),
                        Description = "Ut a ipsa iure provident quaerat.",
                        IntroduceAt = new DateTimeOffset(new DateTime(2021, 7, 24, 20, 42, 59, 834, DateTimeKind.Unspecified).AddTicks(8285),
                            new TimeSpan(0, -3, 0, 0, 0)),
                        Name = "hic",
                        Option = "One",
                        PhotoUrl = "https://picsum.photos/640/480/?image=703",
                        Price = 0.9309430439847802270904473776m,
                        ProductTypeId = new Guid("c814a26e-6e82-43ed-8e08-6eaa45d741ff"),
                        Rating = -2058064254,
                        Stock = -43176768,
                        BootType = "Drysuit",
                        Size = 1138226478
                    },
                    new
                    {
                        Id = new Guid("b69b58f3-3f6f-48a8-bafc-43d9505c8cf9"),
                        Description = "Beatae et architecto aut illum officia et soluta molestiae aut.",
                        IntroduceAt = new DateTimeOffset(new DateTime(2021, 4, 27, 20, 17, 19, 265, DateTimeKind.Unspecified).AddTicks(8872),
                            new TimeSpan(0, -3, 0, 0, 0)),
                        Name = "omnis",
                        Option = "One",
                        PhotoUrl = "https://picsum.photos/640/480/?image=18",
                        Price = 0.0712844171173358186290961395m,
                        ProductTypeId = new Guid("95a5fa4a-41fb-44ee-8670-a9305d24fe94"),
                        Rating = -1782086574,
                        Stock = -1337521737,
                        BootType = "Harness",
                        Size = -457763567
                    });
            });

            modelBuilder.Entity("Dotnet5.GraphQL.Store.Domain.Entities.Products.Kayak", b =>
            {
                b.HasBaseType("Dotnet5.GraphQL.Store.Domain.Entities.Products.Product");

                b.Property<int>("AmountOfPerson")
                   .HasColumnType("int");

                b.Property<string>("KayakType")
                   .IsRequired()
                   .HasColumnType("nvarchar(max)");

                b.HasDiscriminator().HasValue("Kayak");

                b.HasData(new
                    {
                        Id = new Guid("76bb39c3-04ae-44f0-8c91-575abbec989f"),
                        Description = "Aut sunt cumque quam in voluptatem sunt numquam.",
                        IntroduceAt = new DateTimeOffset(new DateTime(2021, 2, 26, 1, 34, 51, 829, DateTimeKind.Unspecified).AddTicks(3243),
                            new TimeSpan(0, -3, 0, 0, 0)),
                        Name = "quam",
                        Option = "Two",
                        PhotoUrl = "https://picsum.photos/640/480/?image=1001",
                        Price = 0.988066428119991789544491403m,
                        ProductTypeId = new Guid("d3e13982-118b-4b99-ac5d-cd3da3b4cc35"),
                        Rating = -396349664,
                        Stock = -1773007001,
                        AmountOfPerson = 1164033587,
                        KayakType = "Diving"
                    },
                    new
                    {
                        Id = new Guid("e7305dc6-94b5-482b-a6ea-a8d55ee38886"),
                        Description = "Ut itaque quasi ipsa tenetur.",
                        IntroduceAt = new DateTimeOffset(new DateTime(2021, 7, 22, 17, 52, 18, 695, DateTimeKind.Unspecified).AddTicks(477),
                            new TimeSpan(0, -3, 0, 0, 0)),
                        Name = "qui",
                        Option = "One",
                        PhotoUrl = "https://picsum.photos/640/480/?image=246",
                        Price = 0.7613004511594577861764058069m,
                        ProductTypeId = new Guid("c814a26e-6e82-43ed-8e08-6eaa45d741ff"),
                        Rating = 1128007690,
                        Stock = 2140022293,
                        AmountOfPerson = 1664374545,
                        KayakType = "Camping"
                    },
                    new
                    {
                        Id = new Guid("a2e07f87-062d-4fec-b583-104e3379bd9a"),
                        Description = "Ut nam est quo aut consequuntur est modi.",
                        IntroduceAt = new DateTimeOffset(new DateTime(2021, 7, 25, 0, 40, 29, 310, DateTimeKind.Unspecified).AddTicks(6114),
                            new TimeSpan(0, -3, 0, 0, 0)),
                        Name = "saepe",
                        Option = "Two",
                        PhotoUrl = "https://picsum.photos/640/480/?image=132",
                        Price = 0.9266727795999204981750910671m,
                        ProductTypeId = new Guid("d3e13982-118b-4b99-ac5d-cd3da3b4cc35"),
                        Rating = -1505192421,
                        Stock = -1677427977,
                        AmountOfPerson = -1220084004,
                        KayakType = "Family"
                    },
                    new
                    {
                        Id = new Guid("4a5a608a-e1c0-4cf0-9630-81850ec7fc49"),
                        Description = "Recusandae nihil quisquam.",
                        IntroduceAt = new DateTimeOffset(new DateTime(2021, 7, 20, 22, 2, 4, 241, DateTimeKind.Unspecified).AddTicks(7924),
                            new TimeSpan(0, -3, 0, 0, 0)),
                        Name = "provident",
                        Option = "Two",
                        PhotoUrl = "https://picsum.photos/640/480/?image=602",
                        Price = 0.3745532945059029770466319646m,
                        ProductTypeId = new Guid("d3e13982-118b-4b99-ac5d-cd3da3b4cc35"),
                        Rating = -434117158,
                        Stock = -162775804,
                        AmountOfPerson = 1875566261,
                        KayakType = "Diving"
                    },
                    new
                    {
                        Id = new Guid("53a17b32-9ad6-4dce-81ab-4c640868a4ea"),
                        Description = "Ipsam labore provident occaecati saepe iure explicabo dolorem amet.",
                        IntroduceAt = new DateTimeOffset(new DateTime(2020, 9, 4, 8, 34, 3, 991, DateTimeKind.Unspecified).AddTicks(8864),
                            new TimeSpan(0, -3, 0, 0, 0)),
                        Name = "officiis",
                        Option = "Two",
                        PhotoUrl = "https://picsum.photos/640/480/?image=282",
                        Price = 0.1376353147636336622039825451m,
                        ProductTypeId = new Guid("d3e13982-118b-4b99-ac5d-cd3da3b4cc35"),
                        Rating = -1049495574,
                        Stock = -654061204,
                        AmountOfPerson = -1108781576,
                        KayakType = "Camping"
                    },
                    new
                    {
                        Id = new Guid("da851927-a89d-47ad-bad6-d8cc5e5a0971"),
                        Description = "Iure cumque labore quos accusamus praesentium.",
                        IntroduceAt = new DateTimeOffset(new DateTime(2021, 7, 6, 15, 52, 38, 968, DateTimeKind.Unspecified).AddTicks(2649),
                            new TimeSpan(0, -3, 0, 0, 0)),
                        Name = "et",
                        Option = "Two",
                        PhotoUrl = "https://picsum.photos/640/480/?image=596",
                        Price = 0.8598738256531111277735163014m,
                        ProductTypeId = new Guid("95a5fa4a-41fb-44ee-8670-a9305d24fe94"),
                        Rating = -1064286490,
                        Stock = -602153730,
                        AmountOfPerson = -1163749038,
                        KayakType = "Camping"
                    },
                    new
                    {
                        Id = new Guid("67c43cb4-dc48-4561-a617-81aef0bdda12"),
                        Description = "Corrupti eos fugiat impedit.",
                        IntroduceAt = new DateTimeOffset(new DateTime(2021, 1, 2, 7, 0, 37, 238, DateTimeKind.Unspecified).AddTicks(5665),
                            new TimeSpan(0, -3, 0, 0, 0)),
                        Name = "officiis",
                        Option = "Two",
                        PhotoUrl = "https://picsum.photos/640/480/?image=5",
                        Price = 0.9709228231853227070595241402m,
                        ProductTypeId = new Guid("d3e13982-118b-4b99-ac5d-cd3da3b4cc35"),
                        Rating = 660081531,
                        Stock = -208083289,
                        AmountOfPerson = -923792834,
                        KayakType = "Racing"
                    },
                    new
                    {
                        Id = new Guid("ff2c5c17-7451-4f0e-aa90-559abbfdb2b4"),
                        Description = "Quasi temporibus accusamus voluptas dicta dolorum dignissimos veritatis nam.",
                        IntroduceAt = new DateTimeOffset(new DateTime(2021, 1, 14, 1, 6, 11, 854, DateTimeKind.Unspecified).AddTicks(8558),
                            new TimeSpan(0, -3, 0, 0, 0)),
                        Name = "amet",
                        Option = "Two",
                        PhotoUrl = "https://picsum.photos/640/480/?image=212",
                        Price = 0.7559933078721816078831723911m,
                        ProductTypeId = new Guid("c814a26e-6e82-43ed-8e08-6eaa45d741ff"),
                        Rating = 151021028,
                        Stock = -1823896105,
                        AmountOfPerson = 891920624,
                        KayakType = "Diving"
                    },
                    new
                    {
                        Id = new Guid("8a95a6cc-9623-4edf-a5eb-8d92078d8738"),
                        Description = "Possimus perferendis itaque ut fugiat repellat repudiandae.",
                        IntroduceAt = new DateTimeOffset(new DateTime(2021, 3, 1, 15, 25, 1, 18, DateTimeKind.Unspecified).AddTicks(4842),
                            new TimeSpan(0, -3, 0, 0, 0)),
                        Name = "ea",
                        Option = "Three",
                        PhotoUrl = "https://picsum.photos/640/480/?image=469",
                        Price = 0.610122713220316581279168424m,
                        ProductTypeId = new Guid("d3e13982-118b-4b99-ac5d-cd3da3b4cc35"),
                        Rating = -297798030,
                        Stock = -564164511,
                        AmountOfPerson = 1146975978,
                        KayakType = "Diving"
                    },
                    new
                    {
                        Id = new Guid("b3a3a5ff-a640-4d35-9161-2b2ae392eb14"),
                        Description = "Odit accusantium at est odio ipsam iste aut perspiciatis.",
                        IntroduceAt = new DateTimeOffset(new DateTime(2021, 6, 17, 2, 0, 16, 136, DateTimeKind.Unspecified).AddTicks(8988),
                            new TimeSpan(0, -3, 0, 0, 0)),
                        Name = "sed",
                        Option = "One",
                        PhotoUrl = "https://picsum.photos/640/480/?image=477",
                        Price = 0.1035204379717907908994243252m,
                        ProductTypeId = new Guid("95a5fa4a-41fb-44ee-8670-a9305d24fe94"),
                        Rating = -1603997663,
                        Stock = -1949368415,
                        AmountOfPerson = -2084081278,
                        KayakType = "Family"
                    },
                    new
                    {
                        Id = new Guid("adc47289-327d-4cf2-800f-5e8211abfb72"),
                        Description = "Neque laborum voluptas impedit quis.",
                        IntroduceAt = new DateTimeOffset(new DateTime(2021, 6, 22, 4, 35, 12, 136, DateTimeKind.Unspecified).AddTicks(3786),
                            new TimeSpan(0, -3, 0, 0, 0)),
                        Name = "maxime",
                        Option = "One",
                        PhotoUrl = "https://picsum.photos/640/480/?image=325",
                        Price = 0.0204955100327869791598713373m,
                        ProductTypeId = new Guid("c814a26e-6e82-43ed-8e08-6eaa45d741ff"),
                        Rating = -2104183317,
                        Stock = -1105518697,
                        AmountOfPerson = 697452447,
                        KayakType = "Camping"
                    },
                    new
                    {
                        Id = new Guid("a54eae56-8c95-4a68-ac86-eb6e499ed264"),
                        Description = "Quia praesentium consequuntur cum ipsa rerum.",
                        IntroduceAt = new DateTimeOffset(new DateTime(2020, 11, 13, 8, 14, 40, 993, DateTimeKind.Unspecified).AddTicks(270),
                            new TimeSpan(0, -3, 0, 0, 0)),
                        Name = "recusandae",
                        Option = "One",
                        PhotoUrl = "https://picsum.photos/640/480/?image=296",
                        Price = 0.1614055340366985283432684646m,
                        ProductTypeId = new Guid("95a5fa4a-41fb-44ee-8670-a9305d24fe94"),
                        Rating = 1032799336,
                        Stock = 236033897,
                        AmountOfPerson = -763230991,
                        KayakType = "Camping"
                    },
                    new
                    {
                        Id = new Guid("bd84a1ef-5ef5-471c-884b-d18045654f22"),
                        Description = "Accusantium eligendi ut fuga ea dolor qui nostrum itaque quisquam.",
                        IntroduceAt = new DateTimeOffset(new DateTime(2021, 7, 26, 18, 59, 24, 138, DateTimeKind.Unspecified).AddTicks(4986),
                            new TimeSpan(0, -3, 0, 0, 0)),
                        Name = "iusto",
                        Option = "Two",
                        PhotoUrl = "https://picsum.photos/640/480/?image=239",
                        Price = 0.7935514295437046512202818943m,
                        ProductTypeId = new Guid("c814a26e-6e82-43ed-8e08-6eaa45d741ff"),
                        Rating = -1110990160,
                        Stock = -396090529,
                        AmountOfPerson = -870652741,
                        KayakType = "Diving"
                    },
                    new
                    {
                        Id = new Guid("fadaf0cd-ebcf-4c82-bc1e-e63aa22ef926"),
                        Description = "Voluptatibus dolore explicabo sed accusamus et laboriosam aut nihil magnam.",
                        IntroduceAt = new DateTimeOffset(new DateTime(2021, 2, 11, 3, 18, 31, 534, DateTimeKind.Unspecified).AddTicks(20),
                            new TimeSpan(0, -3, 0, 0, 0)),
                        Name = "similique",
                        Option = "Three",
                        PhotoUrl = "https://picsum.photos/640/480/?image=262",
                        Price = 0.091650442877499340823270493m,
                        ProductTypeId = new Guid("c814a26e-6e82-43ed-8e08-6eaa45d741ff"),
                        Rating = 1343194689,
                        Stock = -2115255496,
                        AmountOfPerson = -1565071228,
                        KayakType = "Camping"
                    },
                    new
                    {
                        Id = new Guid("06624cff-c4f7-41cd-a14e-2a4984cb97e5"),
                        Description = "Excepturi labore cumque praesentium tempora tempora.",
                        IntroduceAt = new DateTimeOffset(new DateTime(2020, 9, 12, 15, 46, 20, 883, DateTimeKind.Unspecified).AddTicks(532),
                            new TimeSpan(0, -3, 0, 0, 0)),
                        Name = "voluptatibus",
                        Option = "One",
                        PhotoUrl = "https://picsum.photos/640/480/?image=292",
                        Price = 0.456649499676118748841932279m,
                        ProductTypeId = new Guid("c814a26e-6e82-43ed-8e08-6eaa45d741ff"),
                        Rating = 303684859,
                        Stock = 609480070,
                        AmountOfPerson = -274314856,
                        KayakType = "Fishing"
                    },
                    new
                    {
                        Id = new Guid("f452e639-5b00-4ce5-bbae-6fb76e069135"),
                        Description = "Sunt corrupti impedit eius sed.",
                        IntroduceAt = new DateTimeOffset(new DateTime(2021, 4, 27, 0, 34, 57, 43, DateTimeKind.Unspecified).AddTicks(6978),
                            new TimeSpan(0, -3, 0, 0, 0)),
                        Name = "et",
                        Option = "Two",
                        PhotoUrl = "https://picsum.photos/640/480/?image=344",
                        Price = 0.7189156932589123319564564411m,
                        ProductTypeId = new Guid("d3e13982-118b-4b99-ac5d-cd3da3b4cc35"),
                        Rating = 748940091,
                        Stock = -30859816,
                        AmountOfPerson = 315550632,
                        KayakType = "Racing"
                    },
                    new
                    {
                        Id = new Guid("d1e038b3-6094-4819-b0eb-3386b8833643"),
                        Description = "Commodi quis facere ea odit.",
                        IntroduceAt = new DateTimeOffset(new DateTime(2021, 4, 3, 19, 19, 30, 429, DateTimeKind.Unspecified).AddTicks(2373),
                            new TimeSpan(0, -3, 0, 0, 0)),
                        Name = "dolor",
                        Option = "Three",
                        PhotoUrl = "https://picsum.photos/640/480/?image=30",
                        Price = 0.5494056998912033798745192559m,
                        ProductTypeId = new Guid("95a5fa4a-41fb-44ee-8670-a9305d24fe94"),
                        Rating = 964428673,
                        Stock = 2003636048,
                        AmountOfPerson = 485776377,
                        KayakType = "Diving"
                    },
                    new
                    {
                        Id = new Guid("c93d3aed-5fd9-4fef-8545-e9961fa80214"),
                        Description = "Eveniet consequatur soluta sunt accusantium nesciunt tenetur blanditiis.",
                        IntroduceAt = new DateTimeOffset(new DateTime(2020, 8, 16, 10, 35, 23, 774, DateTimeKind.Unspecified).AddTicks(8150),
                            new TimeSpan(0, -3, 0, 0, 0)),
                        Name = "natus",
                        Option = "Three",
                        PhotoUrl = "https://picsum.photos/640/480/?image=472",
                        Price = 0.2674213274445749246067876033m,
                        ProductTypeId = new Guid("c814a26e-6e82-43ed-8e08-6eaa45d741ff"),
                        Rating = 449158857,
                        Stock = -572280276,
                        AmountOfPerson = 384118682,
                        KayakType = "Fishing"
                    },
                    new
                    {
                        Id = new Guid("0d28a1f0-8693-4db0-919b-0ccf0c085fa1"),
                        Description = "Voluptatem ut rem magni repellendus.",
                        IntroduceAt = new DateTimeOffset(new DateTime(2020, 12, 8, 12, 27, 36, 965, DateTimeKind.Unspecified).AddTicks(7042),
                            new TimeSpan(0, -3, 0, 0, 0)),
                        Name = "inventore",
                        Option = "One",
                        PhotoUrl = "https://picsum.photos/640/480/?image=633",
                        Price = 0.3432728792595114935102303476m,
                        ProductTypeId = new Guid("95a5fa4a-41fb-44ee-8670-a9305d24fe94"),
                        Rating = -1268575817,
                        Stock = -1400170620,
                        AmountOfPerson = 1964012673,
                        KayakType = "Camping"
                    },
                    new
                    {
                        Id = new Guid("d9fead66-9c90-4b8e-9e27-acdd149f9cb2"),
                        Description = "Nostrum commodi aut tempore a minima.",
                        IntroduceAt = new DateTimeOffset(new DateTime(2020, 11, 16, 4, 25, 3, 517, DateTimeKind.Unspecified).AddTicks(9995),
                            new TimeSpan(0, -3, 0, 0, 0)),
                        Name = "numquam",
                        Option = "Three",
                        PhotoUrl = "https://picsum.photos/640/480/?image=211",
                        Price = 0.1933153045513026202770697384m,
                        ProductTypeId = new Guid("c814a26e-6e82-43ed-8e08-6eaa45d741ff"),
                        Rating = -672538997,
                        Stock = 883343104,
                        AmountOfPerson = 471577560,
                        KayakType = "Family"
                    },
                    new
                    {
                        Id = new Guid("0f9d25c6-f185-428b-82a0-c3efc4080ac4"),
                        Description = "Iure enim sint voluptatibus cum exercitationem et maiores harum.",
                        IntroduceAt = new DateTimeOffset(new DateTime(2021, 2, 25, 12, 25, 10, 34, DateTimeKind.Unspecified).AddTicks(7982),
                            new TimeSpan(0, -3, 0, 0, 0)),
                        Name = "ea",
                        Option = "Two",
                        PhotoUrl = "https://picsum.photos/640/480/?image=543",
                        Price = 0.2277459987210830225662950129m,
                        ProductTypeId = new Guid("d3e13982-118b-4b99-ac5d-cd3da3b4cc35"),
                        Rating = 1483839394,
                        Stock = -396742700,
                        AmountOfPerson = 715369448,
                        KayakType = "Family"
                    },
                    new
                    {
                        Id = new Guid("de44314e-49d9-4a34-9a6e-f3171880bb14"),
                        Description = "Iusto nisi consequatur.",
                        IntroduceAt = new DateTimeOffset(new DateTime(2020, 8, 26, 14, 36, 25, 972, DateTimeKind.Unspecified).AddTicks(8179),
                            new TimeSpan(0, -3, 0, 0, 0)),
                        Name = "officia",
                        Option = "Three",
                        PhotoUrl = "https://picsum.photos/640/480/?image=341",
                        Price = 0.682094765011370267942824863m,
                        ProductTypeId = new Guid("c814a26e-6e82-43ed-8e08-6eaa45d741ff"),
                        Rating = -1780778947,
                        Stock = -1167733038,
                        AmountOfPerson = 1192129652,
                        KayakType = "Family"
                    },
                    new
                    {
                        Id = new Guid("d21a5f07-204f-4aed-857e-186e5127e257"),
                        Description = "Ratione ratione iusto nostrum dolor rerum est vel.",
                        IntroduceAt = new DateTimeOffset(new DateTime(2020, 8, 27, 13, 26, 39, 372, DateTimeKind.Unspecified).AddTicks(2383),
                            new TimeSpan(0, -3, 0, 0, 0)),
                        Name = "nemo",
                        Option = "Two",
                        PhotoUrl = "https://picsum.photos/640/480/?image=323",
                        Price = 0.6563392465459756411457393355m,
                        ProductTypeId = new Guid("95a5fa4a-41fb-44ee-8670-a9305d24fe94"),
                        Rating = 968715424,
                        Stock = -788303762,
                        AmountOfPerson = 1975336817,
                        KayakType = "Diving"
                    },
                    new
                    {
                        Id = new Guid("f39824d2-7792-40c7-b4b2-e966650454e1"),
                        Description = "Amet dolores molestiae ipsum voluptas omnis ad iusto.",
                        IntroduceAt = new DateTimeOffset(new DateTime(2021, 5, 22, 4, 43, 46, 394, DateTimeKind.Unspecified).AddTicks(9101),
                            new TimeSpan(0, -3, 0, 0, 0)),
                        Name = "ullam",
                        Option = "Three",
                        PhotoUrl = "https://picsum.photos/640/480/?image=683",
                        Price = 0.3578949807054828704117183138m,
                        ProductTypeId = new Guid("c814a26e-6e82-43ed-8e08-6eaa45d741ff"),
                        Rating = -865107132,
                        Stock = 1250509495,
                        AmountOfPerson = 725408269,
                        KayakType = "Diving"
                    },
                    new
                    {
                        Id = new Guid("40d2736d-9b0b-4b17-a4b9-957a1b8362a7"),
                        Description = "Explicabo est cum aut voluptatum.",
                        IntroduceAt = new DateTimeOffset(new DateTime(2021, 5, 12, 16, 26, 12, 284, DateTimeKind.Unspecified).AddTicks(195),
                            new TimeSpan(0, -3, 0, 0, 0)),
                        Name = "vitae",
                        Option = "Three",
                        PhotoUrl = "https://picsum.photos/640/480/?image=830",
                        Price = 0.8880791808408761489715905911m,
                        ProductTypeId = new Guid("95a5fa4a-41fb-44ee-8670-a9305d24fe94"),
                        Rating = -1943901911,
                        Stock = -40836143,
                        AmountOfPerson = -1360855746,
                        KayakType = "Fishing"
                    },
                    new
                    {
                        Id = new Guid("ae8ba79e-ef91-4934-862e-b7597a20af7e"),
                        Description = "Tenetur officiis odio totam ullam sapiente provident ex numquam.",
                        IntroduceAt = new DateTimeOffset(new DateTime(2021, 7, 4, 16, 45, 39, 182, DateTimeKind.Unspecified).AddTicks(5077),
                            new TimeSpan(0, -3, 0, 0, 0)),
                        Name = "accusantium",
                        Option = "One",
                        PhotoUrl = "https://picsum.photos/640/480/?image=996",
                        Price = 0.3211088321935904346970753569m,
                        ProductTypeId = new Guid("d3e13982-118b-4b99-ac5d-cd3da3b4cc35"),
                        Rating = -173865831,
                        Stock = 1307221276,
                        AmountOfPerson = 1170361407,
                        KayakType = "Diving"
                    },
                    new
                    {
                        Id = new Guid("8269c550-9f4f-475f-8167-69f69bfc5302"),
                        Description = "Libero magnam consequatur et officia eaque voluptatibus dolores cum.",
                        IntroduceAt = new DateTimeOffset(new DateTime(2021, 1, 29, 13, 45, 11, 689, DateTimeKind.Unspecified).AddTicks(3313),
                            new TimeSpan(0, -3, 0, 0, 0)),
                        Name = "tempora",
                        Option = "One",
                        PhotoUrl = "https://picsum.photos/640/480/?image=635",
                        Price = 0.9549282230419998818557739828m,
                        ProductTypeId = new Guid("d3e13982-118b-4b99-ac5d-cd3da3b4cc35"),
                        Rating = -1621370537,
                        Stock = -2079297598,
                        AmountOfPerson = 1567433446,
                        KayakType = "Diving"
                    },
                    new
                    {
                        Id = new Guid("61bffc40-93b8-49ba-aab3-26af888c9690"),
                        Description = "Blanditiis sequi magnam omnis dolores quaerat.",
                        IntroduceAt = new DateTimeOffset(new DateTime(2020, 8, 24, 22, 22, 20, 822, DateTimeKind.Unspecified).AddTicks(2446),
                            new TimeSpan(0, -3, 0, 0, 0)),
                        Name = "modi",
                        Option = "Three",
                        PhotoUrl = "https://picsum.photos/640/480/?image=299",
                        Price = 0.611517086243293666991503884m,
                        ProductTypeId = new Guid("d3e13982-118b-4b99-ac5d-cd3da3b4cc35"),
                        Rating = 1201292104,
                        Stock = -1352556225,
                        AmountOfPerson = -45165690,
                        KayakType = "Fishing"
                    },
                    new
                    {
                        Id = new Guid("fc5c79fa-9acd-49a6-9fb1-22a05235df91"),
                        Description = "Et ad reprehenderit sapiente dolorem magni.",
                        IntroduceAt = new DateTimeOffset(new DateTime(2021, 5, 12, 20, 19, 8, 954, DateTimeKind.Unspecified).AddTicks(8039),
                            new TimeSpan(0, -3, 0, 0, 0)),
                        Name = "tenetur",
                        Option = "Three",
                        PhotoUrl = "https://picsum.photos/640/480/?image=510",
                        Price = 0.2508166424931265554274173102m,
                        ProductTypeId = new Guid("d3e13982-118b-4b99-ac5d-cd3da3b4cc35"),
                        Rating = 328109615,
                        Stock = 1444084526,
                        AmountOfPerson = 1512899282,
                        KayakType = "Diving"
                    },
                    new
                    {
                        Id = new Guid("4fc7687b-9798-4345-a62c-0e8486a2fdbb"),
                        Description = "Accusamus enim architecto.",
                        IntroduceAt = new DateTimeOffset(new DateTime(2020, 8, 13, 7, 38, 39, 940, DateTimeKind.Unspecified).AddTicks(3301),
                            new TimeSpan(0, -3, 0, 0, 0)),
                        Name = "consequatur",
                        Option = "Two",
                        PhotoUrl = "https://picsum.photos/640/480/?image=402",
                        Price = 0.7048112408699497512151115482m,
                        ProductTypeId = new Guid("95a5fa4a-41fb-44ee-8670-a9305d24fe94"),
                        Rating = 5091656,
                        Stock = -216935343,
                        AmountOfPerson = 2018603750,
                        KayakType = "Diving"
                    },
                    new
                    {
                        Id = new Guid("e33818b1-97a5-47cb-a5e3-367168114114"),
                        Description = "Quibusdam deserunt esse quia quidem facere.",
                        IntroduceAt = new DateTimeOffset(new DateTime(2020, 12, 2, 7, 22, 33, 229, DateTimeKind.Unspecified).AddTicks(9578),
                            new TimeSpan(0, -3, 0, 0, 0)),
                        Name = "officiis",
                        Option = "One",
                        PhotoUrl = "https://picsum.photos/640/480/?image=653",
                        Price = 0.7129447945621129406327654963m,
                        ProductTypeId = new Guid("c814a26e-6e82-43ed-8e08-6eaa45d741ff"),
                        Rating = -1345198957,
                        Stock = -1583056703,
                        AmountOfPerson = -1461448767,
                        KayakType = "Diving"
                    },
                    new
                    {
                        Id = new Guid("21106a06-7f7d-42e9-96f0-da5627777e19"),
                        Description = "Exercitationem atque perspiciatis mollitia iure sunt.",
                        IntroduceAt = new DateTimeOffset(new DateTime(2021, 1, 10, 11, 29, 1, 475, DateTimeKind.Unspecified).AddTicks(3302),
                            new TimeSpan(0, -3, 0, 0, 0)),
                        Name = "quia",
                        Option = "One",
                        PhotoUrl = "https://picsum.photos/640/480/?image=995",
                        Price = 0.9551791093043519468539070788m,
                        ProductTypeId = new Guid("c814a26e-6e82-43ed-8e08-6eaa45d741ff"),
                        Rating = 1424371355,
                        Stock = -1173099647,
                        AmountOfPerson = -2059298830,
                        KayakType = "Racing"
                    },
                    new
                    {
                        Id = new Guid("d57ac519-4637-4580-90f7-d55f71ee5662"),
                        Description = "Et ad laboriosam.",
                        IntroduceAt = new DateTimeOffset(new DateTime(2021, 5, 1, 22, 17, 6, 850, DateTimeKind.Unspecified).AddTicks(9617),
                            new TimeSpan(0, -3, 0, 0, 0)),
                        Name = "qui",
                        Option = "Two",
                        PhotoUrl = "https://picsum.photos/640/480/?image=332",
                        Price = 0.3055967472695038192349125996m,
                        ProductTypeId = new Guid("95a5fa4a-41fb-44ee-8670-a9305d24fe94"),
                        Rating = 903583053,
                        Stock = 1840197606,
                        AmountOfPerson = 178729091,
                        KayakType = "Diving"
                    },
                    new
                    {
                        Id = new Guid("165e2bf1-fa24-4bfa-8c26-1d2193e6e6e3"),
                        Description = "Sit dolorem aut qui ut eum repellendus illo perferendis ea.",
                        IntroduceAt = new DateTimeOffset(new DateTime(2021, 3, 7, 16, 0, 46, 936, DateTimeKind.Unspecified).AddTicks(2196),
                            new TimeSpan(0, -3, 0, 0, 0)),
                        Name = "aut",
                        Option = "Three",
                        PhotoUrl = "https://picsum.photos/640/480/?image=447",
                        Price = 0.3669955637836361189911542326m,
                        ProductTypeId = new Guid("d3e13982-118b-4b99-ac5d-cd3da3b4cc35"),
                        Rating = -1630174694,
                        Stock = -269211070,
                        AmountOfPerson = -1367716237,
                        KayakType = "Fishing"
                    },
                    new
                    {
                        Id = new Guid("eb9aad9b-6313-4933-a1b2-d380fef4a6a1"),
                        Description = "Et nostrum at dicta.",
                        IntroduceAt = new DateTimeOffset(new DateTime(2021, 6, 18, 9, 44, 41, 943, DateTimeKind.Unspecified).AddTicks(1031),
                            new TimeSpan(0, -3, 0, 0, 0)),
                        Name = "sint",
                        Option = "One",
                        PhotoUrl = "https://picsum.photos/640/480/?image=850",
                        Price = 0.7622977905951333665355867656m,
                        ProductTypeId = new Guid("c814a26e-6e82-43ed-8e08-6eaa45d741ff"),
                        Rating = 45509208,
                        Stock = -164439576,
                        AmountOfPerson = -309446720,
                        KayakType = "Fishing"
                    },
                    new
                    {
                        Id = new Guid("3e663442-4a87-4632-93c3-542366d8569c"),
                        Description = "Ut quas exercitationem voluptas tempora odio molestiae repudiandae.",
                        IntroduceAt = new DateTimeOffset(new DateTime(2020, 11, 22, 1, 4, 27, 731, DateTimeKind.Unspecified).AddTicks(6371),
                            new TimeSpan(0, -3, 0, 0, 0)),
                        Name = "ipsa",
                        Option = "One",
                        PhotoUrl = "https://picsum.photos/640/480/?image=961",
                        Price = 0.0031294108122969413221848419m,
                        ProductTypeId = new Guid("c814a26e-6e82-43ed-8e08-6eaa45d741ff"),
                        Rating = 1729985560,
                        Stock = -2013484093,
                        AmountOfPerson = -267827876,
                        KayakType = "Fishing"
                    },
                    new
                    {
                        Id = new Guid("5a27bb18-2209-4931-8d2e-c57b82075123"),
                        Description = "Rerum id enim aut.",
                        IntroduceAt = new DateTimeOffset(new DateTime(2020, 9, 9, 0, 33, 37, 75, DateTimeKind.Unspecified).AddTicks(5385),
                            new TimeSpan(0, -3, 0, 0, 0)),
                        Name = "omnis",
                        Option = "One",
                        PhotoUrl = "https://picsum.photos/640/480/?image=647",
                        Price = 0.3846316396945366261516217176m,
                        ProductTypeId = new Guid("d3e13982-118b-4b99-ac5d-cd3da3b4cc35"),
                        Rating = -2142471270,
                        Stock = -1192455615,
                        AmountOfPerson = 1615218068,
                        KayakType = "Racing"
                    },
                    new
                    {
                        Id = new Guid("699abdb8-e333-43ae-95f7-84d874bca34d"),
                        Description = "Veritatis beatae quam et harum consequuntur autem et et rerum.",
                        IntroduceAt = new DateTimeOffset(new DateTime(2020, 12, 24, 15, 56, 49, 675, DateTimeKind.Unspecified).AddTicks(608),
                            new TimeSpan(0, -3, 0, 0, 0)),
                        Name = "earum",
                        Option = "One",
                        PhotoUrl = "https://picsum.photos/640/480/?image=299",
                        Price = 0.4044690902829301743107668967m,
                        ProductTypeId = new Guid("d3e13982-118b-4b99-ac5d-cd3da3b4cc35"),
                        Rating = 1557884860,
                        Stock = -909983134,
                        AmountOfPerson = -5214752,
                        KayakType = "Camping"
                    },
                    new
                    {
                        Id = new Guid("ac684f52-2cf9-433f-84a1-221140e93f3a"),
                        Description = "Libero provident qui culpa officiis ut.",
                        IntroduceAt = new DateTimeOffset(new DateTime(2021, 4, 12, 14, 29, 59, 716, DateTimeKind.Unspecified).AddTicks(6859),
                            new TimeSpan(0, -3, 0, 0, 0)),
                        Name = "rerum",
                        Option = "One",
                        PhotoUrl = "https://picsum.photos/640/480/?image=230",
                        Price = 0.8445867760240015884730352195m,
                        ProductTypeId = new Guid("c814a26e-6e82-43ed-8e08-6eaa45d741ff"),
                        Rating = 1132769053,
                        Stock = 123295504,
                        AmountOfPerson = -1596642045,
                        KayakType = "Diving"
                    },
                    new
                    {
                        Id = new Guid("97c4d6d5-9879-4c3f-b77e-79f12dde1082"),
                        Description = "A eveniet qui quae sed est voluptate facilis quas mollitia.",
                        IntroduceAt = new DateTimeOffset(new DateTime(2021, 5, 30, 21, 51, 0, 885, DateTimeKind.Unspecified).AddTicks(5533),
                            new TimeSpan(0, -3, 0, 0, 0)),
                        Name = "eos",
                        Option = "Three",
                        PhotoUrl = "https://picsum.photos/640/480/?image=803",
                        Price = 0.4043081835178345150417074274m,
                        ProductTypeId = new Guid("95a5fa4a-41fb-44ee-8670-a9305d24fe94"),
                        Rating = -653289428,
                        Stock = 766904561,
                        AmountOfPerson = -731334327,
                        KayakType = "Racing"
                    },
                    new
                    {
                        Id = new Guid("ba1f8e54-c3d7-41e3-a32f-4c9e591e2fd4"),
                        Description = "Tempore aliquam repudiandae aliquam.",
                        IntroduceAt = new DateTimeOffset(new DateTime(2021, 1, 4, 20, 53, 19, 150, DateTimeKind.Unspecified).AddTicks(6446),
                            new TimeSpan(0, -3, 0, 0, 0)),
                        Name = "qui",
                        Option = "Three",
                        PhotoUrl = "https://picsum.photos/640/480/?image=551",
                        Price = 0.8197070692583373630067827438m,
                        ProductTypeId = new Guid("d3e13982-118b-4b99-ac5d-cd3da3b4cc35"),
                        Rating = -1706041055,
                        Stock = 1982334526,
                        AmountOfPerson = -183296729,
                        KayakType = "Racing"
                    },
                    new
                    {
                        Id = new Guid("e0517866-d58b-4af5-b00d-13c6b1db122d"),
                        Description = "Et perspiciatis quo dolor aut accusantium.",
                        IntroduceAt = new DateTimeOffset(new DateTime(2021, 4, 14, 7, 22, 47, 740, DateTimeKind.Unspecified).AddTicks(9033),
                            new TimeSpan(0, -3, 0, 0, 0)),
                        Name = "quasi",
                        Option = "Three",
                        PhotoUrl = "https://picsum.photos/640/480/?image=528",
                        Price = 0.7165625172451191782160675134m,
                        ProductTypeId = new Guid("d3e13982-118b-4b99-ac5d-cd3da3b4cc35"),
                        Rating = -730688094,
                        Stock = 924368266,
                        AmountOfPerson = -668476868,
                        KayakType = "Racing"
                    },
                    new
                    {
                        Id = new Guid("f998c65c-c2c0-4ea6-9a11-3d1040b2e51a"),
                        Description = "Voluptatem rerum recusandae id a rerum.",
                        IntroduceAt = new DateTimeOffset(new DateTime(2021, 4, 8, 18, 20, 56, 650, DateTimeKind.Unspecified).AddTicks(5411),
                            new TimeSpan(0, -3, 0, 0, 0)),
                        Name = "optio",
                        Option = "Two",
                        PhotoUrl = "https://picsum.photos/640/480/?image=632",
                        Price = 0.2953318365515326711289741026m,
                        ProductTypeId = new Guid("d3e13982-118b-4b99-ac5d-cd3da3b4cc35"),
                        Rating = -355733018,
                        Stock = -481603342,
                        AmountOfPerson = 806819933,
                        KayakType = "Racing"
                    },
                    new
                    {
                        Id = new Guid("7ee45a11-2af4-4c41-adfb-8e5d292f7b8c"),
                        Description = "Quam magni sed vitae mollitia.",
                        IntroduceAt = new DateTimeOffset(new DateTime(2020, 10, 3, 17, 55, 51, 285, DateTimeKind.Unspecified).AddTicks(7103),
                            new TimeSpan(0, -3, 0, 0, 0)),
                        Name = "qui",
                        Option = "One",
                        PhotoUrl = "https://picsum.photos/640/480/?image=115",
                        Price = 0.2858609342207917298449093326m,
                        ProductTypeId = new Guid("95a5fa4a-41fb-44ee-8670-a9305d24fe94"),
                        Rating = -1054259024,
                        Stock = -1356861826,
                        AmountOfPerson = 1893056032,
                        KayakType = "Racing"
                    },
                    new
                    {
                        Id = new Guid("3b4c6cfb-5906-4567-a508-40a3799ae8a3"),
                        Description = "Sunt quis ab sit repudiandae esse neque ut optio.",
                        IntroduceAt = new DateTimeOffset(new DateTime(2020, 12, 9, 14, 33, 32, 170, DateTimeKind.Unspecified).AddTicks(3458),
                            new TimeSpan(0, -3, 0, 0, 0)),
                        Name = "et",
                        Option = "Three",
                        PhotoUrl = "https://picsum.photos/640/480/?image=576",
                        Price = 0.2055755199877413780609159414m,
                        ProductTypeId = new Guid("c814a26e-6e82-43ed-8e08-6eaa45d741ff"),
                        Rating = -736054542,
                        Stock = 1463063347,
                        AmountOfPerson = -966278405,
                        KayakType = "Camping"
                    },
                    new
                    {
                        Id = new Guid("e273c720-07de-4597-a000-6157621c7614"),
                        Description = "Non saepe sit magnam quasi nostrum sequi magnam excepturi dolor.",
                        IntroduceAt = new DateTimeOffset(new DateTime(2021, 6, 20, 10, 29, 26, 662, DateTimeKind.Unspecified).AddTicks(1379),
                            new TimeSpan(0, -3, 0, 0, 0)),
                        Name = "ducimus",
                        Option = "One",
                        PhotoUrl = "https://picsum.photos/640/480/?image=135",
                        Price = 0.2412590343664832745286479729m,
                        ProductTypeId = new Guid("c814a26e-6e82-43ed-8e08-6eaa45d741ff"),
                        Rating = -199810745,
                        Stock = 332659574,
                        AmountOfPerson = 1886086435,
                        KayakType = "Racing"
                    },
                    new
                    {
                        Id = new Guid("491eaf4a-2d9a-49bc-86a9-23951109d9e5"),
                        Description = "Hic consequatur autem.",
                        IntroduceAt = new DateTimeOffset(new DateTime(2020, 12, 6, 9, 49, 20, 521, DateTimeKind.Unspecified).AddTicks(9900),
                            new TimeSpan(0, -3, 0, 0, 0)),
                        Name = "et",
                        Option = "Two",
                        PhotoUrl = "https://picsum.photos/640/480/?image=553",
                        Price = 0.4950246161590198397522231497m,
                        ProductTypeId = new Guid("c814a26e-6e82-43ed-8e08-6eaa45d741ff"),
                        Rating = -1492460672,
                        Stock = -1643754746,
                        AmountOfPerson = -1701608620,
                        KayakType = "Fishing"
                    },
                    new
                    {
                        Id = new Guid("e56a1014-0651-4ed3-8a4f-d44595f983f7"),
                        Description = "Et esse harum sequi exercitationem aut enim.",
                        IntroduceAt = new DateTimeOffset(new DateTime(2020, 12, 20, 5, 24, 22, 765, DateTimeKind.Unspecified).AddTicks(2119),
                            new TimeSpan(0, -3, 0, 0, 0)),
                        Name = "quia",
                        Option = "Three",
                        PhotoUrl = "https://picsum.photos/640/480/?image=350",
                        Price = 0.35791370114420569733321556m,
                        ProductTypeId = new Guid("d3e13982-118b-4b99-ac5d-cd3da3b4cc35"),
                        Rating = -1740270310,
                        Stock = 210559691,
                        AmountOfPerson = -954460240,
                        KayakType = "Family"
                    },
                    new
                    {
                        Id = new Guid("1ea6522e-4dc0-44bb-a4c5-d374b438e05f"),
                        Description = "Aut vel qui aut id vel.",
                        IntroduceAt = new DateTimeOffset(new DateTime(2021, 7, 17, 11, 46, 37, 934, DateTimeKind.Unspecified).AddTicks(99),
                            new TimeSpan(0, -3, 0, 0, 0)),
                        Name = "omnis",
                        Option = "One",
                        PhotoUrl = "https://picsum.photos/640/480/?image=218",
                        Price = 0.4610139093285580344780870623m,
                        ProductTypeId = new Guid("d3e13982-118b-4b99-ac5d-cd3da3b4cc35"),
                        Rating = -522660318,
                        Stock = 1056065498,
                        AmountOfPerson = -1668532573,
                        KayakType = "Family"
                    },
                    new
                    {
                        Id = new Guid("e65f5cdf-6e88-46ef-8833-4dc99fb7fa68"),
                        Description = "Nemo voluptatem minus cupiditate cumque non molestias sed laboriosam.",
                        IntroduceAt = new DateTimeOffset(new DateTime(2021, 1, 11, 19, 55, 27, 889, DateTimeKind.Unspecified).AddTicks(7714),
                            new TimeSpan(0, -3, 0, 0, 0)),
                        Name = "pariatur",
                        Option = "Three",
                        PhotoUrl = "https://picsum.photos/640/480/?image=570",
                        Price = 0.3186577190818941996466647378m,
                        ProductTypeId = new Guid("95a5fa4a-41fb-44ee-8670-a9305d24fe94"),
                        Rating = -986932532,
                        Stock = -1678144084,
                        AmountOfPerson = 1699916934,
                        KayakType = "Fishing"
                    });
            });

            modelBuilder.Entity("Dotnet5.GraphQL.Store.Domain.ValueObjects.ProductTypes.TypeOne", b =>
            {
                b.HasBaseType("Dotnet5.GraphQL.Store.Domain.ValueObjects.ProductTypes.ProductType");

                b.HasDiscriminator().HasValue("TypeOne");

                b.HasData(new
                {
                    Id = new Guid("c814a26e-6e82-43ed-8e08-6eaa45d741ff")
                });
            });

            modelBuilder.Entity("Dotnet5.GraphQL.Store.Domain.ValueObjects.ProductTypes.TypeThree", b =>
            {
                b.HasBaseType("Dotnet5.GraphQL.Store.Domain.ValueObjects.ProductTypes.ProductType");

                b.HasDiscriminator().HasValue("TypeThree");

                b.HasData(new
                {
                    Id = new Guid("95a5fa4a-41fb-44ee-8670-a9305d24fe94")
                });
            });

            modelBuilder.Entity("Dotnet5.GraphQL.Store.Domain.ValueObjects.ProductTypes.TypeTwo", b =>
            {
                b.HasBaseType("Dotnet5.GraphQL.Store.Domain.ValueObjects.ProductTypes.ProductType");

                b.HasDiscriminator().HasValue("TypeTwo");

                b.HasData(new
                {
                    Id = new Guid("d3e13982-118b-4b99-ac5d-cd3da3b4cc35")
                });
            });

            modelBuilder.Entity("Dotnet5.GraphQL.Store.Domain.Entities.Products.Product", b =>
            {
                b.HasOne("Dotnet5.GraphQL.Store.Domain.ValueObjects.ProductTypes.ProductType", "ProductType")
                   .WithMany()
                   .HasForeignKey("ProductTypeId");
            });

            modelBuilder.Entity("Dotnet5.GraphQL.Store.Domain.Entities.Review", b =>
            {
                b.HasOne("Dotnet5.GraphQL.Store.Domain.Entities.Products.Product", "Product")
                   .WithMany()
                   .HasForeignKey("ProductId");
            });
#pragma warning restore 612, 618
        }
    }
}