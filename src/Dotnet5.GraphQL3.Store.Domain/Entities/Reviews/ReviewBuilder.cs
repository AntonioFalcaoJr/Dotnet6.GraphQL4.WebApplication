using System;
using Dotnet5.GraphQL3.Domain.Abstractions.Builders;

namespace Dotnet5.GraphQL3.Store.Domain.Entities.Reviews
{
    public class ReviewBuilder : Builder<ReviewBuilder, Review, Guid>, IReviewBuilder
    {
        private string _comment;
        private Guid _productId;
        private string _title;

        public override Review Build() => new(_title, _comment, _productId);

        public IReviewBuilder WithTitle(string title)
        {
            _title = title;
            return this;
        }

        public IReviewBuilder WithComment(string comment)
        {
            _comment = comment;
            return this;
        }

        public IReviewBuilder WithProductReference(Guid productId)
        {
            _productId = productId;
            return this;
        }
    }
}