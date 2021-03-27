using System;
using System.ComponentModel.DataAnnotations;

namespace Dotnet6.GraphQL4.Store.WebMVC.Models
{
    public class ReviewModel
    {
        [Required, StringLength(400)]
        public string Comment { get; init; }
        
        [Required, StringLength(100)]
        public string Title { get; init; }
        
        [Required]
        public Guid ProductId { get; init; }
    }
}