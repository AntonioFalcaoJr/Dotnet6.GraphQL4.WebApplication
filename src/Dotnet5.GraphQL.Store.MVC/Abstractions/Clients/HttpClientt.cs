using System;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Dotnet5.GraphQL.Store.Domain.Abstractions;

namespace Dotnet5.GraphQL.Store.MVC.Abstractions.Clients
{
    public abstract class HttpClient<TEntity, TClientModel, TId> : IHttpClient<TEntity, TClientModel, TId>
        where TClientModel : ClientModel<TId>, new()
        where TEntity : Entity<TId>
        where TId : struct
    {
        private readonly IHttpClientFactory _httpClientFactory;

        protected HttpClient(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        protected abstract string ClientName { get; }
        protected abstract string DeleteEndpoint { get; }
        protected abstract string GetEndpoint { get; }
        protected abstract string PostEndpoint { get; }
        protected abstract string PutEndpoint { get; }

        public async Task<TClientModel> GetAsync(CancellationToken token)
        {
            var responseMessage = await GetClient().GetAsync(GetEndpoint, token);

            return responseMessage.IsSuccessStatusCode
                ? await OnSuccessAsync(responseMessage)
                : OnError(responseMessage);
        }

        public async Task<TClientModel> PostAsync(TEntity entity, CancellationToken cancellationToken)
        {
            var byteContent = GetByteContent(entity);
            var responseMessage = await GetClient().PostAsync(PostEndpoint, byteContent, cancellationToken);

            return responseMessage.IsSuccessStatusCode
                ? await OnSuccessAsync(responseMessage)
                : OnError(responseMessage);
        }

        public Task<TClientModel> PutAsync(CancellationToken cancellationToken) => throw new NotImplementedException();

        public Task<TClientModel> DeleteAsync(CancellationToken cancellationToken) => throw new NotImplementedException();

        private static ByteArrayContent GetByteContent(object obj)
        {
            var content = JsonConvert.SerializeObject(obj);
            var buffer = Encoding.UTF8.GetBytes(content);
            var byteContent = new ByteArrayContent(buffer);
            byteContent.Headers.ContentType = new MediaTypeHeaderValue("application/json");
            return byteContent;
        }

        private HttpClient GetClient() => _httpClientFactory.CreateClient(ClientName);

        private static TClientModel OnError(HttpResponseMessage responseMessage)
        {
            var client = new TClientModel();
            client.Notification.AddError(responseMessage.ToString());
            return client;
        }

        private static async Task<TClientModel> OnSuccessAsync(HttpResponseMessage responseMessage)
        {
            var resultAsString = await responseMessage.Content.ReadAsStringAsync();
            return new TClientModel {Result = resultAsString};
        }
    }
}