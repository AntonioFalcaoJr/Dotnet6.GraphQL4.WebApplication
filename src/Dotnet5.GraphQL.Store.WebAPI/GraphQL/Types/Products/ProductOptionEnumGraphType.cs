using Dotnet5.GraphQL.Store.Domain.Enumerations;
using GraphQL.Types;

namespace Dotnet5.GraphQL.Store.WebAPI.GraphQL.Types.Products
{
    public class ProductOptionEnumGraphType : EnumerationGraphType<Option>
    {
        public ProductOptionEnumGraphType()
        {
            Name = "Options";
            Description = "Options from product";
        }
    }
}