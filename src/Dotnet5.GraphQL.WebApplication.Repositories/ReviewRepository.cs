using System;
using Dotnet5.GraphQL.WebApplication.Domain.Entities;
using Dotnet5.GraphQL.WebApplication.Repositories.Abstractions;
using Dotnet5.GraphQL.WebApplication.Repositories.Contexts;

namespace Dotnet5.GraphQL.WebApplication.Repositories
{
    public class ReviewRepository : Repository<Review, Guid>, IReviewRepository
    {
        public ReviewRepository(StoreContext dbContext)
            : base(dbContext) { }
    }
}