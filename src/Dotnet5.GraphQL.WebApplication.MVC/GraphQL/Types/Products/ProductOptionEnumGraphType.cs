using Dotnet5.GraphQL.WebApplication.Domain.Enumerations;
using GraphQL.Types;

namespace Dotnet5.GraphQL.WebApplication.MVC.GraphQL.Types.Products
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