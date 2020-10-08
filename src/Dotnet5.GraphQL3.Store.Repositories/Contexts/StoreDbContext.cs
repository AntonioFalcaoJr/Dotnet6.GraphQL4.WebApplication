using Dotnet5.GraphQL3.Store.Domain.Entities.Products;
using Dotnet5.GraphQL3.Store.Domain.Entities.Reviews;
using Dotnet5.GraphQL3.Store.Domain.ValueObjects.ProductTypes;
using Microsoft.EntityFrameworkCore;

namespace Dotnet5.GraphQL3.Store.Repositories.Contexts
{
    public class StoreDbContext : DbContext
    {
        public StoreDbContext(DbContextOptions options)
            : base(options) { }

        public DbSet<Product> Products { get; set; }
        public DbSet<ProductType> ProductTypes { get; set; }
        public DbSet<Review> Reviews { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.UseCollation("SQL_Latin1_General_CP1_CS_AS");
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(StoreDbContext).Assembly);
            modelBuilder.Seed();
            base.OnModelCreating(modelBuilder);
        }
    }
}