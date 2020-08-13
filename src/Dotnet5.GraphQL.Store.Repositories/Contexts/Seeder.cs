using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using Bogus;
using Dotnet5.GraphQL.Store.Domain.Entities.Products;
using Dotnet5.GraphQL.Store.Domain.Entities.Reviews;
using Dotnet5.GraphQL.Store.Domain.Enumerations;
using Dotnet5.GraphQL.Store.Domain.ValueObjects.ProductTypes;
using Microsoft.EntityFrameworkCore;

namespace Dotnet5.GraphQL.Store.Repositories.Contexts
{
    public static class Seeder
    {
        private const int Amount = 50;
        private static readonly Faker Faker = new Faker();
        private static readonly List<ProductType> ProductTypes = new List<ProductType>();
        private static readonly List<Guid> ProductIds = new List<Guid>();

        public static void Seed(this ModelBuilder modelBuilder)
        {
            GenerateSomeProductIds();
            modelBuilder.SeedProductTypes();
            modelBuilder.SeedProducts();
            modelBuilder.SeedReviews();
        }

        private static void GenerateSomeProductIds()
        {
            for (var i = 0; i < Amount; i++) ProductIds.Add(Guid.NewGuid());
        }

        private static void SeedProducts(this ModelBuilder modelBuilder)
        {
            var types = Assembly.GetAssembly(typeof(Product))?.GetTypes()
                .Where(type => type.IsClass && type.IsAbstract is false && type.IsSubclassOf(typeof(Product)));

            var productIds = ProductIds.ToList();

            types?.ToList().ForEach(type =>
            {
                var products = Enumerable.Range(0, Amount)
                    .Select(index =>
                    {
                        Guid? productId = productIds.FirstOrDefault();
                        var product = new
                        {
                            Id = productId == default(Guid) ? Guid.NewGuid() : productId,
                            Description = Faker.Commerce.ProductDescription(),
                            IntroduceAt = Faker.Date.FutureOffset(),
                            Name = Faker.Commerce.ProductName(),
                            PhotoUrl = Faker.Image.PicsumUrl(),
                            Price = Convert.ToDecimal(Faker.Commerce.Price()),
                            ProductTypeId = Faker.PickRandom(ProductTypes).Id,
                            Rating = Faker.Random.Int(0, 10),
                            Stock = Faker.Random.Int(0, 5000),
                            Size = Faker.Random.Int(20, 30),
                            AmountOfPerson = Faker.Random.Int(1, 3),
                            Option = Faker.PickRandom<Option>(),
                            BackpackType = Faker.PickRandom<BackpackType>(),
                            BootType = Faker.PickRandom<BootType>(),
                            KayakType = Faker.PickRandom<KayakType>()
                        };
                        if (productId.HasValue) productIds.Remove(productId.Value);
                        return product;
                    });

                modelBuilder
                    .Entity(type)
                    .HasData(products);
            });
        }

        private static void SeedProductTypes(this ModelBuilder modelBuilder)
        {
            ProductTypes.AddRange(new ProductType[]
            {
                new TypeOne {Id = Guid.NewGuid()},
                new TypeTwo {Id = Guid.NewGuid()},
                new TypeThree {Id = Guid.NewGuid()}
            });

            ProductTypes.ForEach(type =>
                modelBuilder
                    .Entity(type.GetType())
                    .HasData(type));
        }

        private static void SeedReviews(this ModelBuilder modelBuilder)
        {
            var reviews = ProductIds.Take(Amount)
                .Select(productId => new
                {
                    Id = Guid.NewGuid(),
                    ProductId = productId,
                    Comment = Faker.Lorem.Paragraphs(),
                    Title = Faker.Lorem.Sentence()
                });

            modelBuilder
                .Entity<Review>()
                .HasData(reviews);
        }
    }
}