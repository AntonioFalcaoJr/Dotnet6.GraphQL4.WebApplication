using System;
using Dotnet5.GraphQL.Store.Domain.Entities.Reviews;
using Dotnet5.GraphQL.Store.Repositories.Abstractions;
using Microsoft.EntityFrameworkCore;

namespace Dotnet5.GraphQL.Store.Repositories
{
    public class ReviewRepository : Repository<Review, Guid>, IReviewRepository
    {
        public ReviewRepository(DbContext dbDbContext)
            : base(dbDbContext) { }
    }
}