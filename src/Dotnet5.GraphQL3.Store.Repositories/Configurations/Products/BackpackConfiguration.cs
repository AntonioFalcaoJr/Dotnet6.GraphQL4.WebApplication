using Dotnet5.GraphQL3.Store.Domain.Entities.Products;
using Dotnet5.GraphQL3.Store.Domain.Entities.Products.Backpacks;
using Dotnet5.GraphQL3.Store.Domain.Enumerations;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace Dotnet5.GraphQL3.Store.Repositories.Configurations.Products
{
    public class BackpackConfiguration : IEntityTypeConfiguration<Backpack>
    {
        public void Configure(EntityTypeBuilder<Backpack> builder)
        {
            builder
                .HasBaseType<Product>();

            builder
                .Property(x => x.BackpackType)
                .HasConversion(new EnumToStringConverter<BackpackType>());
        }
    }
}