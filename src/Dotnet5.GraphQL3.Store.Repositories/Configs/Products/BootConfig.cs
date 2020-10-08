using Dotnet5.GraphQL3.Store.Domain.Entities.Products;
using Dotnet5.GraphQL3.Store.Domain.Entities.Products.Boots;
using Dotnet5.GraphQL3.Store.Domain.Enumerations;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace Dotnet5.GraphQL3.Store.Repositories.Configs.Products
{
    public class BootConfig : IEntityTypeConfiguration<Boot>
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