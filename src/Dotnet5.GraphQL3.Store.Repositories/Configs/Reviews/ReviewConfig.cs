using Dotnet5.GraphQL3.Store.Domain.Entities.Reviews;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Dotnet5.GraphQL3.Store.Repositories.Configs.Reviews
{
    public class ReviewConfig : IEntityTypeConfiguration<Review>
    {
        public void Configure(EntityTypeBuilder<Review> builder)
        {
            builder
                .HasKey(x => x.Id);

            builder
                .Property(x => x.Comment);

            builder
                .Property(x => x.Title)
                .HasMaxLength(100);

            builder
                .HasOne(x => x.Product)
                .WithMany(x => x.Reviews);
        }
    }
}