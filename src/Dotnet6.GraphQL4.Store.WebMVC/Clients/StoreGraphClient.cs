using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Dotnet6.GraphQL4.Store.WebMVC.Models;
using GraphQL;
using GraphQL.Client.Abstractions;
using GraphQL.Client.Http;
using Microsoft.Extensions.Logging;

namespace Dotnet6.GraphQL4.Store.WebMVC.Clients
{
    public class StoreGraphClient : IStoreGraphClient
    {
        private readonly GraphQLHttpClient _client;
        private readonly ILogger<IStoreGraphClient> _logger;

        public StoreGraphClient(GraphQLHttpClient client, ILogger<IStoreGraphClient> logger)
        {
            _client = client;
            _logger = logger;
        }

        public async Task<List<ProductModel>> GetAllProductsAsync(CancellationToken cancellationToken = default)
        {
            var request = new GraphQLRequest
            {
                Query = @"query getAll {
                                  products {
                                    items {
                                      id
                                      name
                                      price
                                      rating
                                      photoUrl
                                      description
                                      stock
                                      introduceAt
                                    }
                                  }
                                }",
                OperationName = "getAll"
            };

            var response = await _client.SendQueryAsync(
                request: request,
                defineResponseType: () => new {products = new {items = new List<ProductModel>()}},
                cancellationToken: cancellationToken);

            return response.Errors?.Any() ?? default ? default : response.Data.products.items;
        }

        public async Task<ProductModel> GetProductByIdAsync(Guid id, CancellationToken cancellationToken = default)
        {
            var request = new GraphQLRequest
            {
                Query = @"query ProductQuery($productId: Guid!) {
                              product(id: $productId) {
                                id
                                name
                                price
                                rating
                                photoUrl
                                description
                                stock
                                introduceAt
                                reviews {
                                      id
                                      title
                                      comment
                                      productId
                                    }
                                  }
                               }",
                OperationName = "ProductQuery",
                Variables = new {productId = id}
            };

            var response = await _client.SendQueryAsync(
                request: request,
                defineResponseType: () => new {product = new ProductModel()},
                cancellationToken: cancellationToken);
            
            return response.Errors?.Any() ?? default ? default : response.Data.product;
        }

        public async Task<IEnumerable<ReviewModel>> GetReviewByProductIdAsync(Guid id, CancellationToken cancellationToken = default)
        {
            var request = new GraphQLRequest
            {
                Query = @"query ReviewsByProductQuery($productId: Guid!) {
                          reviews(productId: $productId) {
                            id
                            title
                            comment
                            productId
                          }
                        }",
                OperationName = "ReviewsByProductQuery",
                Variables = new {productId = id}
            };

            var response = await _client.SendQueryAsync(
                request: request,
                defineResponseType: () => new {reviews = new List<ReviewModel>()},
                cancellationToken: cancellationToken);

            return response.Errors?.Any() ?? default ? default : response.Data.reviews;
        }

        public async Task<Guid> AddReviewAsync(ReviewModel review, CancellationToken cancellationToken = default)
        {
            var request = new GraphQLRequest
            {
                Query = @"mutation($review: reviewInput!) {
                              createReview(review: $review) {
                                id
                              }
                            }",
                Variables = new {review}
            };

            var response = await _client.SendMutationAsync(
                request: request,
                defineResponseType: () => new {createReview = new {id = new Guid()}},
                cancellationToken: cancellationToken);

            return response.Errors?.Any() ?? default ? default : response.Data.createReview.id;
        }

        public void SubscribeToUpdates()
        {
            var request = new GraphQLRequest
            {
                Query = @"subscription {
                              reviewAdded {
                                productId
                                title
                              }
                            }"
            };

            var stream = _client.CreateSubscriptionStream<AddedReviewSubscriptionResult>(
                request: request,
                exceptionHandler: exception => _logger.LogError(exception.Message));

            var subscription = stream.Subscribe(response
                => _logger.LogInformation($"A new Review from Product '{response.Data.Review.ProductId}' " +
                                          $"was added with Title: {response.Data.Review.Title}"));

            subscription.Dispose();
        }
    }
}