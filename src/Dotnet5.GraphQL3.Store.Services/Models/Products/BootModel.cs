using Dotnet5.GraphQL3.Store.Domain.Enumerations;

namespace Dotnet5.GraphQL3.Store.Services.Models.Products
{
    public record BootModel : ProductModel
    {
        public BootType Type { get; init; }
        public int Size { get; init; }
    }
}