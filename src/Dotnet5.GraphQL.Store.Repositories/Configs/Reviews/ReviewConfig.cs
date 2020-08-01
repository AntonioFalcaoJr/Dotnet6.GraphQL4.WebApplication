using Dotnet5.GraphQL.Store.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Dotnet5.GraphQL.Store.Repositories.Configs.Reviews
{
    public class ReviewConfig : IEntityTypeConfiguration<Review>
    {
        public void Configure(EntityTypeBuilder<Review> builder)
        {
            builder
               .HasKey(x => x.Id);

            builder
               .Property(x => x.Comment)
               .HasMaxLength(300);

            builder
               .Property(x => x.Title)
               .HasMaxLength(50);

            builder
               .HasOne(x => x.Product);
        }
    }
}