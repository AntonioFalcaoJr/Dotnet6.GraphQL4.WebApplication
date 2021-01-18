using Dotnet5.GraphQL3.Store.Domain.Enumerations;

namespace Dotnet5.GraphQL3.Store.Services.Models.Products
{
    public record KayakModel : ProductModel
    {
        public int AmountOfPerson { get; init; }
        public KayakType Type { get; init; }
    }
}