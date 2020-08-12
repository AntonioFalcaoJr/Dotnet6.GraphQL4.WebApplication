using System;
using Dotnet5.GraphQL.Store.Services.Abstractions;

namespace Dotnet5.GraphQL.Store.Services.Models
{
    public class ReviewModel : Model<Guid>
    {
        public string Title { get; set; }
        public string Comment { get; set; }
        public Guid ProductId { get; set; }
    }
}