using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Dotnet5.GraphQL3.Store.WebMVC.Models;

namespace Dotnet5.GraphQL3.Store.WebMVC.Clients
{
    public interface IStoreGraphClient
    {
        Task<ProductModel> GetProductByIdAsync(Guid id, CancellationToken cancellationToken = default);
        Task<List<ProductModel>> GetAllProductsAsync(CancellationToken cancellationToken = default);
        Task<IEnumerable<ReviewModel>> GetReviewByProductIdAsync(Guid id, CancellationToken cancellationToken = default);
        Task<Guid> AddReviewAsync(ReviewModel review, CancellationToken cancellationToken = default);
        void SubscribeToUpdates();
    }
}