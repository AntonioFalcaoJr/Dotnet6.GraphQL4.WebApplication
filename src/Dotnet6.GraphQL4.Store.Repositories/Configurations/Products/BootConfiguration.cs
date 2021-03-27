using Dotnet6.GraphQL4.Store.Domain.Entities.Products;
using Dotnet6.GraphQL4.Store.Domain.Entities.Products.Boots;
using Dotnet6.GraphQL4.Store.Domain.Enumerations;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace Dotnet6.GraphQL4.Store.Repositories.Configurations.Products
{
    public class BootConfiguration : IEntityTypeConfiguration<Boot>
    {
        public void Configure(EntityTypeBuilder<Boot> builder)
        {
            builder
                .HasBaseType<Product>();

            builder
                .Property(x => x.Size);

            builder
                .Property(x => x.BootType)
                .HasConversion(new EnumToStringConverter<BootType>());
        }
    }
}