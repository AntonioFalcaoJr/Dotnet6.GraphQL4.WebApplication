using Dotnet5.GraphQL.WebApplication.Domain.ValueObjects.ProductTypes;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Dotnet5.GraphQL.WebApplication.Repositories.Configs
{
    public class ProductTypeConfig : IEntityTypeConfiguration<ProductType>
    {
        private const string DiscriminatorDefaultName = "Discriminator";

        public void Configure(EntityTypeBuilder<ProductType> builder)
        {
            builder.HasKey(x => x.Id);

            builder
               .HasDiscriminator()
               .HasValue<TypeOne>(nameof(TypeOne))
               .HasValue<TypeTwo>(nameof(TypeTwo))
               .HasValue<TypeThree>(nameof(TypeThree));

            builder
               .Property(DiscriminatorDefaultName)
               .HasMaxLength(30);

            builder
               .HasIndex(DiscriminatorDefaultName).IsUnique();
        }
    }
}