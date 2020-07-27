using System;
using System.Collections.Generic;
using System.Linq;
using Bogus;
using Dotnet5.GraphQL.WebApplication.Domain.Entities;
using Dotnet5.GraphQL.WebApplication.Domain.ValueObjects.ProductTypes;
using Microsoft.EntityFrameworkCore;

namespace Dotnet5.GraphQL.WebApplication.Repositories.Contexts
{
    public static class Seeder
    {
        private static readonly Faker Faker = new Faker();
        private static readonly List<ProductType> ProductTypes = new List<ProductType>();

        public static void Seed(this ModelBuilder modelBuilder)
        {
            modelBuilder.SeedProductTypes();
            modelBuilder.SeedProducts();
        }

        private static void SeedProducts(this ModelBuilder modelBuilder)
        {
            var products = Enumerable.Range(0, 10)
               .Select(index => new
                {
                    Id = Guid.NewGuid(),
                    Description = Faker.Lorem.Sentence(),
                    IntroduceAt = Faker.Date.FutureOffset(),
                    Name = Faker.Lorem.Word(),
                    PhotoFileName = Faker.System.FileName(),
                    Price = Faker.Finance.Random.Decimal(),
                    ProductTypeId = Faker.PickRandom(ProductTypes).Id,
                    Rating = Faker.Random.Int(),
                    Stock = Faker.Random.Int(),
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
    }
}