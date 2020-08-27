using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Dotnet5.GraphQL.Store.WebMVC.Models;
using GraphQL;
using GraphQL.Client.Http;
using GraphQL.Client.Abstractions;

namespace Dotnet5.GraphQL.Store.WebMVC.Clients
{
    public class ProductGraphClient : IProductGraphClient
    {
        private readonly GraphQLHttpClient _client;

        public ProductGraphClient(GraphQLHttpClient client)
        {
            _client = client;
        }

        public async Task<List<ProductModel>> GetAllAsync(CancellationToken cancellationToken = default)
        {
            var request = new GraphQLRequest
            {
                Query = @"query getAll {
                                  products {
                                    id
                                    name
                                    price
                                    rating
                                    photoUrl
                                    description
                                    stock
                                    introduceAt
                                  }
                                }",
                OperationName = "getAll"
            };

            var response = await _client.SendQueryAsync(
                request: request,
                defineResponseType: () => new {products = new List<ProductModel>()},
                cancellationToken: cancellationToken);

            return response.Errors?.Any() ?? default ? default : response.Data.products;
        }

        public async Task<ProductModel> GetByIdAsync(Guid id, CancellationToken cancellationToken = default)
        {
            var request = new GraphQLRequest
            {
                Query = @"query ProductQuery($productId: ID!) {
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
                Query = @"query ReviewsByProductQuery($productId: ID!) {
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
    }
}