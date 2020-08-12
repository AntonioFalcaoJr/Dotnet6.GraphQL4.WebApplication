using System;
using System.Threading;
using System.Threading.Tasks;
using Dotnet5.GraphQL.Store.Domain.Entities.Products;
using Dotnet5.GraphQL.Store.Domain.Entities.Reviews;
using Dotnet5.GraphQL.Store.Services.Abstractions;
using Dotnet5.GraphQL.Store.Services.Models;

namespace Dotnet5.GraphQL.Store.Services
{
    public interface IProductService : IService<Product, ProductModel, Guid>
    {
        public Task<Review> AddReviewAsync(ReviewModel reviewModel, CancellationToken cancellationToken = default);
    }
}