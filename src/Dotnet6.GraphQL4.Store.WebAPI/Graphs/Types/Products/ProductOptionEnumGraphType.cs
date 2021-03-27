using Dotnet6.GraphQL4.Store.Domain.Enumerations;
using GraphQL.Types;

namespace Dotnet6.GraphQL4.Store.WebAPI.Graphs.Types.Products
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