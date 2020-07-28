using System;
using Dotnet5.GraphQL.WebApplication.Domain.Entities;
using Dotnet5.GraphQL.WebApplication.Services.Abstractions;
using Dotnet5.GraphQL.WebApplication.Services.Models;

namespace Dotnet5.GraphQL.WebApplication.Services
{
    public interface IReviewService : IService<Review, ReviewModel, Guid> { }
}