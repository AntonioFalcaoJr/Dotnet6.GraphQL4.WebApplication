using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Dotnet6.GraphQL4.Services.Abstractions;
using Dotnet6.GraphQL4.Store.Domain.Entities.Products;
using Dotnet6.GraphQL4.Store.Domain.Entities.Reviews;
using Dotnet6.GraphQL4.Store.Services.Models.Products;
using Dotnet6.GraphQL4.Store.Services.Models.Reviews;

namespace Dotnet6.GraphQL4.Store.Services
{
    public interface IProductService : IService<Product, ProductModel, Guid>
    {
        public Task<Review> AddReviewAsync(ReviewModel reviewModel, CancellationToken cancellationToken);
        Task<ILookup<Guid, Review>> GetLookupReviewsByProductIdsAsync(IEnumerable<Guid> productIds, CancellationToken cancellationToken);
    }
}