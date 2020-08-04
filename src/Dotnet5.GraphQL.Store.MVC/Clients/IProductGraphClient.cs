using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Dotnet5.GraphQL.Store.MVC.Models;

namespace Dotnet5.GraphQL.Store.MVC.Clients
{
    public interface IProductGraphClient
    {
        Task<ProductModel> GetProductAsync(Guid id);
        Task<IEnumerable<ProductModel>> GetProducts();
    }
}