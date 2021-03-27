using System;
using System.Collections.Generic;

namespace Dotnet6.GraphQL4.Store.WebMVC.Models
{
    public class ProductModel
    {
        public string Description { get; set; }
        public Guid Id { get; set; }
        public DateTimeOffset IntroduceAt { get; set; }
        public string Name { get; set; }
        public string PhotoUrl { get; set; }
        public decimal Price { get; set; }
        public int Rating { get; set; }
        public int Stock { get; set; }
        public IEnumerable<ReviewModel> Reviews { get; set; }
    }
}