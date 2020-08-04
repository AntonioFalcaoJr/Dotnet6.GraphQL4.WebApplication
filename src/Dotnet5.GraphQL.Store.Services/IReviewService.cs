using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Dotnet5.GraphQL.Store.Domain.Entities;
using Dotnet5.GraphQL.Store.Services.Abstractions;
using Dotnet5.GraphQL.Store.Services.Models;

namespace Dotnet5.GraphQL.Store.Services
{
    public interface IReviewService : IService<Review, ReviewModel, Guid>
    {
        Task<ILookup<Guid, Review>> GetLookupByProductIdsAsync(IEnumerable<Guid> productIds);
    }
}