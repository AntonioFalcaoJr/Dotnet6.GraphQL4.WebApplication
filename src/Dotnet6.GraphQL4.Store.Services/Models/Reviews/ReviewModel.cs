using System;
using Dotnet6.GraphQL4.Services.Abstractions.Models;

namespace Dotnet6.GraphQL4.Store.Services.Models.Reviews
{
    public record ReviewModel : Model<Guid>
    {
        public string Title { get; init; }
        public string Comment { get; init; }
        public Guid ProductId { get; init; }
    }
}