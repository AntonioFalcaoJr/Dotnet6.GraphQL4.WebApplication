using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Dotnet5.GraphQL.Store.Domain.Entities;
using Dotnet5.GraphQL.Store.Repositories.Abstractions;

namespace Dotnet5.GraphQL.Store.Repositories
{
    public interface IReviewRepository : IRepository<Review, Guid>
    {
        Task<ILookup<Guid, Review>> GetForProducts(IEnumerable<Guid> productIds);
    }
}