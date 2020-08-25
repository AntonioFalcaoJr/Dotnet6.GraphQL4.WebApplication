using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Dotnet5.GraphQL.Store.WebMVC.Models;

namespace Dotnet5.GraphQL.Store.WebMVC.Clients
{
    public interface IProductGraphClient
    {
        Task<ProductModel> GetByIdAsync(Guid id, CancellationToken cancellationToken = default);
        Task<IEnumerable<ProductModel>> GetAllAsync(CancellationToken cancellationToken = default);
        Task<IEnumerable<ReviewModel>> GetReviewByProductIdAsync(Guid id, CancellationToken cancellationToken = default);
        Task<ReviewModel> AddReviewAsync(ReviewModel review);
    }
}