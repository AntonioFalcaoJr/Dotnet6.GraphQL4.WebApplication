using System;
using Dotnet5.GraphQL.Store.Domain.Abstractions.Builders;

namespace Dotnet5.GraphQL.Store.Domain.Entities.Reviews
{
    public interface IReviewBuilder : IBuilder<Review, Guid>
    {
        IReviewBuilder WithTitle(string title);
        IReviewBuilder WithComment(string comment);
        IReviewBuilder WithProductReference(Guid productId);
    }
}