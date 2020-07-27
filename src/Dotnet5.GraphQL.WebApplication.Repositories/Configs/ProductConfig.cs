using Dotnet5.GraphQL.WebApplication.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Dotnet5.GraphQL.WebApplication.Repositories.Configs
{
    public class ProductConfig : IEntityTypeConfiguration<Product>
    {
        public void Configure(EntityTypeBuilder<Product> builder)
        {
            builder
               .HasKey(x => x.Id);

            builder
               .Property(x => x.Description)
               .HasMaxLength(100);

            builder.Property(x => x.IntroduceAt);

            builder
               .Property(x => x.Name)
               .HasMaxLength(50)
               .IsRequired();

            builder
               .Property(x => x.PhotoFileName)
               .HasMaxLength(100);

            builder
               .Property(x => x.Price)
               .HasPrecision(18, 2)
               .IsRequired();

            builder.Property(x => x.Rating);

            builder.Property(x => x.Stock);

            builder.HasOne(x => x.ProductType);
        }
    }
}