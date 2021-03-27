using Dotnet6.GraphQL4.Store.Domain.Enumerations;

namespace Dotnet6.GraphQL4.Store.Services.Models.Products
{
    public record BootModel : ProductModel
    {
        public BootType Type { get; init; }
        public int Size { get; init; }
    }
}