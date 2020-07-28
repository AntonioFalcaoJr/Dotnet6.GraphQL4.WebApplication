using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Dotnet5.GraphQL.WebApplication.Domain.Entities;
using Dotnet5.GraphQL.WebApplication.Repositories.Abstractions;

namespace Dotnet5.GraphQL.WebApplication.Repositories
{
    public interface IReviewRepository : IRepository<Review, Guid>
    {
        Task<ILookup<Guid, Review>> GetForProducts(IEnumerable<Guid> productIds);
    }
}