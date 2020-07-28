using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Dotnet5.GraphQL.WebApplication.Domain.Entities;
using Dotnet5.GraphQL.WebApplication.Services.Abstractions;
using Dotnet5.GraphQL.WebApplication.Services.Models;

namespace Dotnet5.GraphQL.WebApplication.Services
{
    public interface IReviewService : IService<Review, ReviewModel, Guid>
    {
        Task<ILookup<Guid, Review>> GetForProductsAsync(IEnumerable<Guid> productIds);
    }
}