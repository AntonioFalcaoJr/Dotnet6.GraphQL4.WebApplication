using System;
using Dotnet6.GraphQL4.Domain.Abstractions.Builders;

namespace Dotnet6.GraphQL4.Store.Domain.Entities.Reviews
{
    public interface IReviewBuilder : IBuilder<ReviewBuilder, Review, Guid>
    {
        string Title { get; set; }
        string Comment { get; set; }
        Guid ProductId { get; set; }
    }
}