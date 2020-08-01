using Dotnet5.GraphQL.Store.Domain.Entities.Products;
using Dotnet5.GraphQL.Store.Domain.Enumerations;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace Dotnet5.GraphQL.Store.Repositories.Configs.Products
{
    public class KayakConfig : IEntityTypeConfiguration<Kayak>
    {
        public void Configure(EntityTypeBuilder<Kayak> builder)
        {
            builder
               .HasBaseType<Product>();

            builder
               .Property(x => x.KayakType)
               .HasConversion(new EnumToStringConverter<KayakType>());

            builder
               .Property(x => x.AmountOfPerson);
        }
    }
}