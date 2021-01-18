using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Dotnet5.GraphQL3.Services.Abstractions;
using Dotnet5.GraphQL3.Store.Domain.Entities.Products;
using Dotnet5.GraphQL3.Store.Domain.Entities.Reviews;
using Dotnet5.GraphQL3.Store.Services.Models;
using Dotnet5.GraphQL3.Store.Services.Models.Products;

namespace Dotnet5.GraphQL3.Store.Services
{
    public interface IProductService : IService<Product, ProductModel, Guid>
    {
        public Task<Review> AddReviewAsync(ReviewModel reviewModel, CancellationToken cancellationToken);
        Task<ILookup<Guid, Review>> GetLookupReviewsByProductIdsAsync(IEnumerable<Guid> productIds, CancellationToken cancellationToken);
    }
}