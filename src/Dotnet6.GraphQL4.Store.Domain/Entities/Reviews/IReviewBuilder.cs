using System;
using Dotnet6.GraphQL4.Domain.Abstractions.Builders;

namespace Dotnet6.GraphQL4.Store.Domain.Entities.Reviews
{
    public interface IReviewBuilder : IBuilder<Review, Guid>
    {
        IReviewBuilder WithTitle(string title);
        IReviewBuilder WithComment(string comment);
        IReviewBuilder WithProductReference(Guid productId);
    }
}