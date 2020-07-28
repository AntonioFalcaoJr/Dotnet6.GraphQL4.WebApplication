using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
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
        private readonly IReviewRepository _repository;

        public ReviewService(IUnitOfWork unitOfWork, IReviewRepository repository, IMapper mapper)
            : base(unitOfWork, repository, mapper)
        {
            _repository = repository;
        }

        public async Task<ILookup<Guid, Review>> GetForProductsAsync(IEnumerable<Guid> productIds)
            => await _repository.GetForProducts(productIds);
    }
}