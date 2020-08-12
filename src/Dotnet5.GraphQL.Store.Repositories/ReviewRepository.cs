using System;
using Dotnet5.GraphQL.Store.Domain.Entities;
using Dotnet5.GraphQL.Store.Domain.Entities.Reviews;
using Dotnet5.GraphQL.Store.Repositories.Abstractions;
using Dotnet5.GraphQL.Store.Repositories.Contexts;

namespace Dotnet5.GraphQL.Store.Repositories
{
    public class ReviewRepository : Repository<Review, Guid>, IReviewRepository
    {
        public ReviewRepository(StoreDbContext dbDbContext)
            : base(dbDbContext) { }
    }
}