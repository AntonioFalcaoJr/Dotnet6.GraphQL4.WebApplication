using System;
using Dotnet5.GraphQL3.Repositories.Abstractions;
using Dotnet5.GraphQL3.Store.Domain.Entities.Reviews;
using Microsoft.EntityFrameworkCore;

namespace Dotnet5.GraphQL3.Store.Repositories
{
    public class ReviewRepository : Repository<Review, Guid>, IReviewRepository
    {
        public ReviewRepository(DbContext dbDbContext)
            : base(dbDbContext) { }
    }
}