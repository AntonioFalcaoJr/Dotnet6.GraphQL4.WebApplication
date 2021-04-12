using System;
using Dotnet6.GraphQL4.Domain.Abstractions.Builders;

namespace Dotnet6.GraphQL4.Store.Domain.Entities.Reviews
{
    public class ReviewBuilder : Builder<ReviewBuilder, Review, Guid>, IReviewBuilder
    {
        public string Title { get; set; }
        public string Comment { get; set; }
        public Guid ProductId { get; set; }

        public override Review Build()
            => new(Title, Comment, ProductId);
    }
}