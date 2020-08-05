using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Dotnet5.GraphQL.Store.MVC.Models;

namespace Dotnet5.GraphQL.Store.MVC.Clients
{
    public interface IProductGraphClient
    {
        Task<ProductModel> GetProductByIdAsync(Guid id);
        Task<IEnumerable<ProductModel>> GetProductsAsync();
        Task<IEnumerable<ReviewModel>> GetReviewByProductIdAsync(Guid id);
    }
}