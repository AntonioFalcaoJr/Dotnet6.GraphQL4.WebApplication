using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using Dotnet5.GraphQL.Store.CrossCutting.Notifications;
using Dotnet5.GraphQL.Store.Domain.Entities.Products;
using Dotnet5.GraphQL.Store.Domain.Entities.Reviews;
using Dotnet5.GraphQL.Store.Repositories;
using Dotnet5.GraphQL.Store.Repositories.Abstractions.UnitsOfWork;
using Dotnet5.GraphQL.Store.Services.Abstractions;
using Dotnet5.GraphQL.Store.Services.Abstractions.Resources;
using Dotnet5.GraphQL.Store.Services.Models;
using Microsoft.EntityFrameworkCore;

namespace Dotnet5.GraphQL.Store.Services
{
    public class ProductService : Service<Product, ProductModel, Guid>, IProductService
    {
        private readonly IMapper _mapper;
        private readonly INotificationContext _notificationContext;
        private readonly IProductRepository _productRepository;

        public ProductService(IUnitOfWork unitOfWork, IProductRepository productRepository, IMapper mapper, INotificationContext notificationContext)
            : base(unitOfWork, productRepository, mapper, notificationContext)
        {
            _productRepository = productRepository;
            _mapper = mapper;
            _notificationContext = notificationContext;
        }

        public async Task<Review> AddReviewAsync(ReviewModel reviewModel, CancellationToken cancellationToken = default)
        {
            if (reviewModel is null)
            {
                _notificationContext.AddNotificationWithType(ServicesResource.Object_Null, typeof(ReviewModel));
                return default;
            }

            var product = await _productRepository.GetByIdAsync(
                id: reviewModel.ProductId,
                include: products => products.Include(x => x.Reviews),
                withTracking: true,
                cancellationToken: cancellationToken);

            var review = _mapper.Map<Review>(reviewModel);
            product?.AddReview(review);
            await OnEditAsync(product, cancellationToken);
            return review;
        }

        public async Task<ILookup<Guid, Review>> GetLookupReviewsByProductIdsAsync(IEnumerable<Guid> productIds, CancellationToken cancellationToken = default)
        {
            var reviews = await _productRepository.GetAllAsync(
                selector: product => product.Reviews,
                product => productIds.Contains(product.Id),
                include: products => products.Include(x => x.Reviews),
                cancellationToken: cancellationToken);

            return reviews.SelectMany(x => x)
                .ToLookup(review => review.ProductId);
        }
    }
}