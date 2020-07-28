using System;
using System.Collections.Generic;
using System.Linq;
using Bogus;
using Dotnet5.GraphQL.WebApplication.Domain.Entities;
using Dotnet5.GraphQL.WebApplication.Domain.Enumerations;
using Dotnet5.GraphQL.WebApplication.Domain.ValueObjects.ProductTypes;
using Microsoft.EntityFrameworkCore;

namespace Dotnet5.GraphQL.WebApplication.Repositories.Contexts
{
    public static class Seeder
    {
        private const int Amount = 50;
        private static readonly Faker Faker = new Faker();
        private static readonly List<ProductType> ProductTypes = new List<ProductType>();
        private static readonly List<Guid> ProductIds = new List<Guid>();

        public static void Seed(this ModelBuilder modelBuilder)
        {
            GenerateIds();
            modelBuilder.SeedProductTypes();
            modelBuilder.SeedProducts();
            modelBuilder.SeedReviews();
        }

        private static void GenerateIds()
        {
            for (var i = 0; i < Amount; i++) ProductIds.Add(Guid.NewGuid());
        }

        private static void SeedProducts(this ModelBuilder modelBuilder)
        {
            var products = ProductIds
               .Select(id => new
                {
                    Id = id,
                    Description = Faker.Lorem.Sentence(),
                    IntroduceAt = Faker.Date.FutureOffset(),
                    Name = Faker.Lorem.Word(),
                    PhotoFileName = Faker.System.CommonFileName(),
                    Price = Faker.Finance.Random.Decimal(),
                    ProductTypeId = Faker.PickRandom(ProductTypes).Id,
                    Rating = Faker.Random.Int(),
                    Stock = Faker.Random.Int(),
                    Option = Faker.PickRandom<Option>()
                });

            modelBuilder
               .Entity<Product>()
               .HasData(products);
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
            var reviews = ProductIds
               .Select(id => new
                {
                    Id = Guid.NewGuid(),
                    ProductId = id,
                    Comment = Faker.Lorem.Sentence(),
                    Title = Faker.Lorem.Word(),
                });

            modelBuilder
               .Entity<Review>()
               .HasData(reviews);
        }
    }
}