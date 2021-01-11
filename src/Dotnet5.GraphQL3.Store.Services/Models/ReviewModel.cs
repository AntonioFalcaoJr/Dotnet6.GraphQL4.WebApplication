using System;
using Dotnet5.GraphQL3.Services.Abstractions.Models;

namespace Dotnet5.GraphQL3.Store.Services.Models
{
    public record ReviewModel : Model<Guid>
    {
        public string Title { get; init; }
        public string Comment { get; init; }
        public Guid ProductId { get; init; }
    }
}