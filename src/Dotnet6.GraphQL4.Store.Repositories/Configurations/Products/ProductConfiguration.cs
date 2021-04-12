using Dotnet6.GraphQL4.Store.Domain.Entities.Products;
using Dotnet6.GraphQL4.Store.Domain.Entities.Products.Backpacks;
using Dotnet6.GraphQL4.Store.Domain.Entities.Products.Boots;
using Dotnet6.GraphQL4.Store.Domain.Entities.Products.Kayaks;
using Dotnet6.GraphQL4.Store.Domain.Enumerations;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace Dotnet6.GraphQL4.Store.Repositories.Configurations.Products
{
    public class ProductConfiguration : IEntityTypeConfiguration<Product>
    {
        private const string DiscriminatorDefaultName = "Discriminator";

        public void Configure(EntityTypeBuilder<Product> builder)
        {
            builder
                .HasKey(x => x.Id);

            builder
                .Property(x => x.Description)
                .HasMaxLength(300);

            builder
                .Property(x => x.IntroduceAt);

            builder
                .Property(x => x.Name)
                .HasMaxLength(50)
                .IsRequired();

            builder
                .Property(x => x.PhotoUrl)
                .HasMaxLength(100);

            builder
                .Property(x => x.Price)
                .HasPrecision(10, 2)
                .IsRequired();

            builder
                .Property(x => x.Option)
                .HasConversion(new EnumToStringConverter<Option>());

            builder
                .Property(x => x.Rating);

            builder
                .Property(x => x.Stock);

            builder
                .HasOne(x => x.ProductType);

            builder
                .HasMany(x => x.Reviews)
                .WithOne(x => x.Product)
                .HasForeignKey(x => x.ProductId);

            builder
                .HasDiscriminator()
                .HasValue<Boot>(nameof(Boot))
                .HasValue<Kayak>(nameof(Kayak))
                .HasValue<Backpack>(nameof(Backpack));

            builder
                .Property(DiscriminatorDefaultName)
                .HasMaxLength(30);
        }
    }
}