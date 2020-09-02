using System;
using System.ComponentModel.DataAnnotations;

namespace Dotnet5.GraphQL.Store.WebMVC.Models
{
    public class ReviewModel
    {
        [Required, StringLength(400)]
        public string Comment { get; set; }
        
        [Required, StringLength(100)]
        public string Title { get; set; }
        
        [Required]
        public Guid ProductId { get; set; }
    }
}