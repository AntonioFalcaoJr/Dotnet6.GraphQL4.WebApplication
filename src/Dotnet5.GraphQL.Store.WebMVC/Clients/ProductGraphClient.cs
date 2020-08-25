using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Dotnet5.GraphQL.Store.WebMVC.Models;
using GraphQL;
using GraphQL.Client.Http;

namespace Dotnet5.GraphQL.Store.WebMVC.Clients
{
    public class ProductGraphClient : IProductGraphClient
    {
        private readonly GraphQLHttpClient _client;

        public ProductGraphClient(GraphQLHttpClient client)
        {
            _client = client;
        }

        public async Task<IEnumerable<ProductModel>> GetAllAsync(CancellationToken cancellationToken = default)
        {
            var query = new GraphQLRequest
            {
                Query = @"{
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
                        }"
            };

            var response = await _client
                .SendQueryAsync<IEnumerable<ProductModel>>(query, cancellationToken);

            return response.Errors?.Any() is false
                ? response.Data
                : default;
        }

        public async Task<ProductModel> GetByIdAsync(Guid id, CancellationToken cancellationToken = default)
        {
            var query = new GraphQLRequest
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

                Variables = new {productId = id}
            };

            var response = await _client
                .SendQueryAsync<ProductModel>(query, cancellationToken);

            return response.Errors?.Any() is false
                ? response.Data
                : default;
        }

        public async Task<IEnumerable<ReviewModel>> GetReviewByProductIdAsync(Guid id, CancellationToken cancellationToken = default)
        {
            var query = new GraphQLRequest
            {
                Query = @"query ReviewsByProductQuery($productId: ID!) {
                          reviews(productId: $productId) {
                            id
                            title
                            comment
                            productId
                          }
                        }",
                Variables = new {productId = id}
            };

            var response = await _client
                .SendQueryAsync<IEnumerable<ReviewModel>>(query, cancellationToken);

            return response.Errors?.Any() is false
                ? response.Data
                : default;
        }

        public async Task<ReviewModel> AddReviewAsync(ReviewModel review)
        {
            var query = new GraphQLRequest
            {
                Query = @"mutation($review: reviewInput!) {
                              createReview(review: $review) {
                                id
                              }
                            }",
                Variables = new {review}
            };

            var response = await _client.SendMutationAsync<ReviewModel>(query);
            
            return response.Errors?.Any() is false
                ? response.Data
                : default;
        }
    }
}