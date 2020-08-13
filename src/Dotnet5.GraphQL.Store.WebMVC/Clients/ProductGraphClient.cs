using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Dotnet5.GraphQL.Store.WebMVC.Models;
using GraphQL.Client;
using GraphQL.Common.Request;

namespace Dotnet5.GraphQL.Store.WebMVC.Clients
{
    public class ProductGraphClient : IProductGraphClient
    {
        private readonly GraphQLClient _client;

        public ProductGraphClient(GraphQLClient client)
        {
            _client = client;
        }

        public async Task<IEnumerable<ProductModel>> GetProductsAsync()
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

            var response = await _client.PostAsync(query);
            return response.GetDataFieldAs<IEnumerable<ProductModel>>("products");
        }

        public async Task<ProductModel> GetProductByIdAsync(Guid id)
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
                              }
                            }",
                Variables = new {productId = id}
            };

            var response = await _client.PostAsync(query);
            return response.GetDataFieldAs<ProductModel>("product");
        }

        public async Task<IEnumerable<ReviewModel>> GetReviewByProductIdAsync(Guid id)
        {
            var query = new GraphQLRequest
            {
                Query = @"query ReviewsByProductQuery($productId: ID!) {
                          reviews(productId: $productId) {
                            id
                            title
                            comment
                          }
                        }",
                Variables = new {productId = id}
            };

            var response = await _client.PostAsync(query);
            return response.GetDataFieldAs<IEnumerable<ReviewModel>>("reviews");
        }
    }
}