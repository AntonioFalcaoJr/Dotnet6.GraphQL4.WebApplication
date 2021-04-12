using System;
using Dotnet6.GraphQL4.Domain.Abstractions.Builders;

namespace Dotnet6.GraphQL4.Store.Domain.Entities.Reviews
{
    public interface IReviewBuilder : IBuilder<ReviewBuilder, Review, Guid>
    {
        string Title { set; }
        string Comment { set; }
        Guid ProductId { set; }
    }
}