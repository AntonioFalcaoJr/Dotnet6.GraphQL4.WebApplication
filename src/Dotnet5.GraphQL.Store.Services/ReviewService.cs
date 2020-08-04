using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Dotnet5.GraphQL.Store.Domain.Entities;
using Dotnet5.GraphQL.Store.Repositories;
using Dotnet5.GraphQL.Store.Repositories.UnitsOfWorks;
using Dotnet5.GraphQL.Store.Services.Abstractions;
using Dotnet5.GraphQL.Store.Services.Models;

namespace Dotnet5.GraphQL.Store.Services
{
    public class ReviewService : Service<Review, ReviewModel, Guid>, IReviewService
    {
        private readonly IReviewRepository _repository;

        public ReviewService(IUnitOfWork unitOfWork, IReviewRepository repository, IMapper mapper)
            : base(unitOfWork, repository, mapper)
        {
            _repository = repository;
        }

        public async Task<ILookup<Guid, Review>> GetLookupByProductIdsAsync(IEnumerable<Guid> productIds)
        {
            var reviews = await _repository.GetAllAsync(x => productIds.Contains(x.Product.Id));
            return reviews.ToLookup(x => x.Product.Id);
        }
    }
}