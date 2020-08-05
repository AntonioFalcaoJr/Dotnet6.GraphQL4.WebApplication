using System;

namespace Dotnet5.GraphQL.Store.MVC.Models
{
    public class ReviewModel
    {
        public string Comment { get; set; }
        public Guid Id { get; set; }
        public string Title { get; set; }
    }
}