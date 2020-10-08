using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using Dotnet5.GraphQL3.CrossCutting.Notifications;
using Dotnet5.GraphQL3.Repositories.Abstractions.UnitsOfWork;
using Dotnet5.GraphQL3.Services.Abstractions;
using Dotnet5.GraphQL3.Services.Abstractions.Resources;
using Dotnet5.GraphQL3.Store.Domain.Entities.Products;
using Dotnet5.GraphQL3.Store.Domain.Entities.Reviews;
using Dotnet5.GraphQL3.Store.Repositories;
using Dotnet5.GraphQL3.Store.Services.Models;
using Dotnet5.GraphQL3.Store.Services.Models.Products;
using Microsoft.EntityFrameworkCore;

namespace Dotnet5.GraphQL3.Store.Services
{
    public class ProductService : Service<Product, ProductModel, Guid>, IProductService
    {
        public ProductService(IUnitOfWork unitOfWork, IProductRepository repository, IMapper mapper, INotificationContext notificationContext)
            : base(unitOfWork, repository, mapper, notificationContext) { }

        public async Task<Review> AddReviewAsync(ReviewModel reviewModel, CancellationToken cancellationToken = default)
        {
            if (reviewModel is null)
            {
                NotificationContext.AddNotificationWithType(ServicesResource.Object_Null, typeof(ReviewModel));
                return default;
            }

            var product = await Repository.GetByIdAsync(
                    id: reviewModel.ProductId,
                    include: products => products.Include(x => x.Reviews),
                    withTracking: true,
                    cancellationToken: cancellationToken);

            var review = Mapper.Map<Review>(reviewModel);
            product?.AddReview(review);
            await OnEditAsync(product, cancellationToken);
            return review;
        }

        public async Task<ILookup<Guid, Review>> GetLookupReviewsByProductIdsAsync(IEnumerable<Guid> productIds, CancellationToken cancellationToken = default)
        {
            var reviews = await Repository.GetAllAsync(
                    selector: product => product.Reviews,
                    predicate: product => productIds.Contains(product.Id),
                    include: products => products.Include(x => x.Reviews),
                    cancellationToken: cancellationToken);

            return reviews.SelectMany(x => x)
                .ToLookup(review => review.ProductId);
        }
    }
}