using System;
using Dotnet5.GraphQL3.Domain.Abstractions.Entities;
using Dotnet5.GraphQL3.Store.Domain.Entities.Products;

namespace Dotnet5.GraphQL3.Store.Domain.Entities.Reviews
{
    public class Review : Entity<Guid>
    {
        internal Review(string title, string comment, Guid productId)
        {
            Title = title;
            Comment = comment;
            ProductId = productId;
            Validate();
        }

        protected Review() { }

        public string Comment { get; }
        public Product Product { get; }
        public Guid ProductId { get; }
        public string Title { get; }

        protected sealed override bool Validate()
            => OnValidate(this, new ReviewValidator());
    }
}