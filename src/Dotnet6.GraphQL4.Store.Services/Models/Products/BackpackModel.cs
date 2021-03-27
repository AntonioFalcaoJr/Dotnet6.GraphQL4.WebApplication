using Dotnet6.GraphQL4.Store.Domain.Enumerations;

namespace Dotnet6.GraphQL4.Store.Services.Models.Products
{
    public record BackpackModel : ProductModel
    {
        public BackpackType Type { get; init; }
    }
}