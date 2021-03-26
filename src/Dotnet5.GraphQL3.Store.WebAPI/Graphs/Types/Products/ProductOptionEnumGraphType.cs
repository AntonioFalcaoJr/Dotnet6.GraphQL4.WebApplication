using Dotnet5.GraphQL3.Store.Domain.Enumerations;
using GraphQL.Types;

namespace Dotnet5.GraphQL3.Store.WebAPI.Graphs.Types.Products
{
    public class ProductOptionEnumGraphType : EnumerationGraphType<Option>
    {
        public ProductOptionEnumGraphType()
        {
            Name = "options";
            Description = "Options from product";
        }
    }
}