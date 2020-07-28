using System;
using AutoMapper;
using Dotnet5.GraphQL.WebApplication.Domain.Entities;
using Dotnet5.GraphQL.WebApplication.Repositories;
using Dotnet5.GraphQL.WebApplication.Repositories.UnitsOfWorks;
using Dotnet5.GraphQL.WebApplication.Services.Abstractions;
using Dotnet5.GraphQL.WebApplication.Services.Models;

namespace Dotnet5.GraphQL.WebApplication.Services
{
    public class ReviewService : Service<Review, ReviewModel, Guid>, IReviewService
    {
        public ReviewService(IUnitOfWork unitOfWork, IReviewRepository repository, IMapper mapper)
            : base(unitOfWork, repository, mapper) { }
    }
}