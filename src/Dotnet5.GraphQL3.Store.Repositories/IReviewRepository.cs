using System;
using Dotnet5.GraphQL3.Repositories.Abstractions;
using Dotnet5.GraphQL3.Store.Domain.Entities.Reviews;

namespace Dotnet5.GraphQL3.Store.Repositories
{
    public interface IReviewRepository : IRepository<Review, Guid> { }
}