using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using Dotnet6.GraphQL4.Services.Abstractions;
using Dotnet6.GraphQL4.Services.Abstractions.Resources;
using Dotnet6.GraphQL4.Store.Repositories;
using Dotnet6.GraphQL4.CrossCutting.Notifications;
using Dotnet6.GraphQL4.Repositories.Abstractions.UnitsOfWork;
using Dotnet6.GraphQL4.Store.Domain.Entities.Products;
using Dotnet6.GraphQL4.Store.Domain.Entities.Reviews;
using Dotnet6.GraphQL4.Store.Services.Models.Products;
using Dotnet6.GraphQL4.Store.Services.Models.Reviews;
using Microsoft.EntityFrameworkCore;

namespace Dotnet6.GraphQL4.Store.Services
{
    public class ProductService : Service<Product, ProductModel, Guid>, IProductService
    {
        public ProductService(IProductRepository repository, IUnitOfWork unitOfWork, INotificationContext notificationContext, IMapper mapper)
            : base(repository, unitOfWork, notificationContext, mapper) { }

        public Task<Review> AddReviewAsync(ReviewModel reviewModel, CancellationToken cancellationToken)
        {
            if (reviewModel is null)
            {
                NotificationContext.AddNotificationWithType(ServicesResource.Object_Null, typeof(ReviewModel));
                return default;
            }

            return UnitOfWork.ExecuteInTransactionScopeAsync(
                operationAsync: async ct =>
                {
                    var product = await Repository.GetByIdAsync(
                        id: reviewModel.ProductId,
                        include: products => products.Include(x => x.Reviews),
                        asTracking: true,
                        cancellationToken: ct);

                    var review = Mapper.Map<Review>(reviewModel);
                    product?.AddReview(review);
                    await OnEditAsync(product, ct);
                    return review;
                },
                condition: _ => NotificationContext.AllValidAsync,
                cancellationToken: cancellationToken);
        }

        public async Task<ILookup<Guid, Review>> GetLookupReviewsByProductIdsAsync(IEnumerable<Guid> productIds, CancellationToken cancellationToken)
        {
            var ids = productIds?.ToList();
            if (ids is not {Count: > 0}) return default;

            var pagedResult = await Repository.GetAllProjectionsAsync(
                pageParams: new() {Size = ids.Count},
                selector: product => product.Reviews,
                predicate: product => ids.Contains(product.Id),
                include: products => products.Include(product => product.Reviews),
                cancellationToken: cancellationToken);

            return pagedResult.Items
                .SelectMany(review => review)
                .ToLookup(review => review.ProductId);
        }
    }
}