using Bogus;
using Dotnet5.GraphQL.WebApplication.Domain.Entities;

namespace Dotnet5.GraphQL.WebApplication.Repositories.Extensions.ModelBuilder
{
    public static class Seeder
    {
        public static void Seed(this Microsoft.EntityFrameworkCore.ModelBuilder modelBuilder)
        {
            var products = new Faker<Product>()
               .RuleFor(x => x.Description, f => f.Lorem.Sentence())
               .Generate(10);

            modelBuilder
               .Entity<Product>()
               .HasData(products);
        }
    }
}