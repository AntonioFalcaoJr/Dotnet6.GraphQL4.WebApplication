using Dotnet5.GraphQL.Store.Domain.Entities.Products;
using Dotnet5.GraphQL.Store.Domain.Enumerations;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace Dotnet5.GraphQL.Store.Repositories.Configs.Products
{
    public class BackpackConfig : IEntityTypeConfiguration<Backpack>
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