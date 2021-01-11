using Dotnet5.GraphQL3.Store.Domain.Enumerations;

namespace Dotnet5.GraphQL3.Store.Services.Models.Products
{
    public record BackpackModel : ProductModel
    {
        public BackpackType Type { get; init; }
    }
}