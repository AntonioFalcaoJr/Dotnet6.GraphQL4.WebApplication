using Dotnet6.GraphQL4.Store.Domain.Entities.Products;
using Dotnet6.GraphQL4.Store.Domain.Entities.Products.Kayaks;
using Dotnet6.GraphQL4.Store.Domain.Enumerations;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace Dotnet6.GraphQL4.Store.Repositories.Configurations.Products
{
    public class KayakConfiguration : IEntityTypeConfiguration<Kayak>
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