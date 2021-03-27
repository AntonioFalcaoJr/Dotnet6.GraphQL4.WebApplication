using Dotnet6.GraphQL4.Store.Domain.Enumerations;

namespace Dotnet6.GraphQL4.Store.Services.Models.Products
{
    public record KayakModel : ProductModel
    {
        public int AmountOfPerson { get; init; }
        public KayakType Type { get; init; }
    }
}