using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Dotnet5.GraphQL.Store.MVC.Models;
using GraphQL.Client;
using GraphQL.Common.Request;

namespace Dotnet5.GraphQL.Store.MVC.Clients
{
    public class ProductGraphClient : IProductGraphClient
    {
        private readonly GraphQLClient _client;

        public ProductGraphClient(GraphQLClient client)
        {
            _client = client;
        }

        public async Task<IEnumerable<ProductModel>> GetProducts()
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

        public async Task<ProductModel> GetProductAsync(Guid id)
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
    }
}