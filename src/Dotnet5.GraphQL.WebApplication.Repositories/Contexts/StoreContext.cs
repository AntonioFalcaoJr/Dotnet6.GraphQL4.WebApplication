using Dotnet5.GraphQL.WebApplication.Domain.Entities;
using Dotnet5.GraphQL.WebApplication.Repositories.Extensions.ModelBuilder;
using Microsoft.EntityFrameworkCore;

namespace Dotnet5.GraphQL.WebApplication.Repositories.Contexts
{
    public class StoreContext : DbContext
    {
        public StoreContext(DbContextOptions options)
            : base(options) { }

        public DbSet<Product> Products { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.UseCollation("SQL_Latin1_General_CP1_CS_AS");
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(StoreContext).Assembly);
            modelBuilder.Seed();
            base.OnModelCreating(modelBuilder);
        }
    }
}