using System;

namespace Dotnet5.GraphQL.Store.Services.Messages
{
    public class ReviewMessage
    {
        public string Title { get; set; }
        public Guid ProductId { get; set; }
    }
}