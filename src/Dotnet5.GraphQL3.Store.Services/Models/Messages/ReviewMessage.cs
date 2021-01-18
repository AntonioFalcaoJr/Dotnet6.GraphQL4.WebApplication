using System;

namespace Dotnet5.GraphQL3.Store.Services.Models.Messages
{
    public record ReviewMessage
    {
        public string Title { get; init; }
        public Guid ProductId { get; init; }
    }
}