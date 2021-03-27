using Dotnet6.GraphQL4.Store.Domain.Entities.Products;
using Dotnet6.GraphQL4.Store.Domain.Entities.Products.Backpacks;
using Dotnet6.GraphQL4.Store.Domain.Enumerations;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace Dotnet6.GraphQL4.Store.Repositories.Configurations.Products
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