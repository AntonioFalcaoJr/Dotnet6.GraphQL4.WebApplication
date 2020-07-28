using System;
using Dotnet5.GraphQL.WebApplication.Domain.Entities;
using Dotnet5.GraphQL.WebApplication.Repositories.Abstractions;

namespace Dotnet5.GraphQL.WebApplication.Repositories
{
    public interface IReviewRepository : IRepository<Review, Guid> { }
}