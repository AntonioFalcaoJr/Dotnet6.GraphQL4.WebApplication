using System;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using Dotnet5.GraphQL.Store.Domain.Entities.Products;
using Dotnet5.GraphQL.Store.Domain.Entities.Reviews;
using Dotnet5.GraphQL.Store.Repositories;
using Dotnet5.GraphQL.Store.Repositories.UnitsOfWorks;
using Dotnet5.GraphQL.Store.Services.Abstractions;
using Dotnet5.GraphQL.Store.Services.Models;
using Microsoft.EntityFrameworkCore;

namespace Dotnet5.GraphQL.Store.Services
{
    public class ProductService : Service<Product, ProductModel, Guid>, IProductService
    {
        private readonly IMapper _mapper;
        private readonly IProductRepository _repository;
        private readonly IUnitOfWork _unitOfWork;

        public ProductService(IUnitOfWork unitOfWork, IProductRepository repository, IMapper mapper)
            : base(unitOfWork, repository, mapper)
        {
            _unitOfWork = unitOfWork;
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<Review> AddReviewAsync(ReviewModel reviewModel, CancellationToken cancellationToken = default)
        {
            if (reviewModel is null) return default;
            var review = _mapper.Map<Review>(reviewModel);

            if (review.IsValid is false) return default;
            
            var product = await _repository.GetByIdAsync(
                id: reviewModel.ProductId,
                include: products => products.Include(x => x.Reviews),
                withTracking: true,
                cancellationToken: cancellationToken);

            if (product is null || product.IsValid is false) return default;

            product.AddReview(review);
            await _repository.UpdateAsync(product, cancellationToken);
            await _unitOfWork.SaveChangesAsync(cancellationToken);
            return review;
        }
    }
}