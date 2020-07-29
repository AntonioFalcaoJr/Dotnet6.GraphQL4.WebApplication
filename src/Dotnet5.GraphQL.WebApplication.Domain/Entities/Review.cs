using System;
using Dotnet5.GraphQL.WebApplication.Domain.Abstractions;
using Dotnet5.GraphQL.WebApplication.Domain.Entities.Products;
using FluentValidation;

namespace Dotnet5.GraphQL.WebApplication.Domain.Entities
{
    public class Review : Entity<Guid>
    {
        public Review(Product product, string title, string comment)
        {
            Product = product;
            Title = title;
            Comment = comment;

            Validate(this, new InlineValidator<Review>());
        }

        protected Review() { }

        public string Comment { get; }
        public Product Product { get; }
        public string Title { get; }
    }
}