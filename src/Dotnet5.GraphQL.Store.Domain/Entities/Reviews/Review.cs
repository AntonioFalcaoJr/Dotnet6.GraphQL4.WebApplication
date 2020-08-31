using System;
using Dotnet5.GraphQL.Store.Domain.Abstractions;
using Dotnet5.GraphQL.Store.Domain.Entities.Products;
using FluentValidation;

namespace Dotnet5.GraphQL.Store.Domain.Entities.Reviews
{
    public class Review : Entity<Guid>
    {
        public Review(string title, string comment, Guid productId)
        {
            Title = title;
            Comment = comment;
            ProductId = productId;

            Validate(this, new ReviewValidator());
        }

        protected Review() { }

        public string Comment { get; }
        public Product Product { get; }
        public Guid ProductId { get; }
        public string Title { get; }
    }
}