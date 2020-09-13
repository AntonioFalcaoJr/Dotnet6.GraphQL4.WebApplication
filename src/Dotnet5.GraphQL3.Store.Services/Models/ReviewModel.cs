using System;
using Dotnet5.GraphQL3.Services.Abstractions.Models;

namespace Dotnet5.GraphQL3.Store.Services.Models
{
    public class ReviewModel : Model<Guid>
    {
        public string Title { get; set; }
        public string Comment { get; set; }
        public Guid ProductId { get; set; }
    }
}