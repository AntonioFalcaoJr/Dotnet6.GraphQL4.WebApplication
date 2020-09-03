using System;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using Dotnet5.GraphQL.Store.CrossCutting.Notifications;
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
        private readonly INotificationContext _notificationContext;
        private readonly IProductRepository _repository;

        public ProductService(IUnitOfWork unitOfWork, IProductRepository repository, IMapper mapper, INotificationContext notificationContext)
            : base(unitOfWork, repository, mapper, notificationContext)
        {
            _repository = repository;
            _mapper = mapper;
            _notificationContext = notificationContext;
        }

        public async Task<Review> AddReviewAsync(ReviewModel reviewModel, CancellationToken cancellationToken = default)
        {
            if (reviewModel is null)
            {
                _notificationContext.AddNotificationWithType(Resource.Object_Null, typeof(ReviewModel));
                return default;
            }

            var product = await _repository.GetByIdAsync(
                id: reviewModel.ProductId,
                include: products => products.Include(x => x.Reviews),
                withTracking: true,
                cancellationToken: cancellationToken);

            var review = _mapper.Map<Review>(reviewModel);
            product?.AddReview(review);
            await OnEditAsync(product, cancellationToken);
            return review;
        }
    }
}