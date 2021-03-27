using System;
using Dotnet6.GraphQL4.Domain.Abstractions.Entities;
using Dotnet6.GraphQL4.Store.Domain.Entities.Products;

namespace Dotnet6.GraphQL4.Store.Domain.Entities.Reviews
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
            => OnValidate<ReviewValidator, Review>(this, new());
    }
}