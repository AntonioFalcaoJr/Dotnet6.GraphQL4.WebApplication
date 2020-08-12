using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Text.Json;
using System.Threading;
using System.Threading.Tasks;
using Dotnet5.GraphQL.Store.Domain.Abstractions;
using FluentValidation.Results;

namespace Dotnet5.GraphQL.Store.WebMVC.Abstractions.Clients
{
    public abstract class HttpClient<TEntity, TId> : IHttpClient<TEntity, TId>
        where TEntity : Entity<TId>
        where TId : struct
    {
        private readonly IHttpClientFactory _httpClientFactory;

        protected HttpClient(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        public ValidationResult ValidationResult { get; set; }

        protected abstract string ClientName { get; }
        protected abstract string DeleteEndpoint { get; }
        protected abstract string GetEndpoint { get; }
        protected abstract string PostEndpoint { get; }
        protected abstract string PutEndpoint { get; }

        public async Task<Response<TEntity>> GetAsync(CancellationToken token)
        {
            var responseMessage = await GetClient().GetAsync(GetEndpoint, token);
            return await GetResponse(responseMessage);
        }

        public async Task<Response<TEntity>> PostAsync(TEntity entity, CancellationToken cancellationToken)
        {
            var byteContent = GetByteContent(entity);
            var responseMessage = await GetClient().PostAsync(PostEndpoint, byteContent, cancellationToken);
            return await GetResponse(responseMessage);
        }

        public Task<Response<TEntity>> PutAsync(CancellationToken cancellationToken) => throw new NotImplementedException();

        public Task<Response<TEntity>> DeleteAsync(CancellationToken cancellationToken) => throw new NotImplementedException();

        private static ByteArrayContent GetByteContent(object obj)
        {
            var content = JsonSerializer.Serialize(obj);
            var buffer = Encoding.UTF8.GetBytes(content);
            var byteContent = new ByteArrayContent(buffer);
            byteContent.Headers.ContentType = new MediaTypeHeaderValue("application/json");
            return byteContent;
        }

        private HttpClient GetClient() => _httpClientFactory.CreateClient(ClientName);

        private static async Task<Response<TEntity>> GetResponse(HttpResponseMessage responseMessage)
            => responseMessage.IsSuccessStatusCode
                ? await OnSuccessAsync(responseMessage)
                : OnError(responseMessage);

        private static Response<TEntity> OnError(HttpResponseMessage responseMessage)
        {
            var client = new Response<TEntity>();
            client.Errors.Add(responseMessage.ToString());
            return client;
        }

        private static async Task<Response<TEntity>> OnSuccessAsync(HttpResponseMessage responseMessage)
        {
            var resultAsString = await responseMessage.Content.ReadAsStringAsync();
            return new Response<TEntity> {Results = JsonSerializer.Deserialize<List<TEntity>>(resultAsString)};
        }
    }
}