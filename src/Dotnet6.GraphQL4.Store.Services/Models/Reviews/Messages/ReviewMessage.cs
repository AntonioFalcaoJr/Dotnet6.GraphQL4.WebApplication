using System;

namespace Dotnet6.GraphQL4.Store.Services.Models.Reviews.Messages
{
    public record ReviewMessage
    {
        public string Title { get; init; }
        public Guid ProductId { get; init; }
    }
}