using Dotnet5.GraphQL.WebApplication.Domain.Enumerations;
using GraphQL.Types;

namespace Dotnet5.GraphQL.WebApplication.MVC.GraphQL.Types.Products.Backpacks
{
    public class BackpakcTypeEnumGraphType : EnumerationGraphType<BackpackType>
    {
        public BackpakcTypeEnumGraphType()
        {
            Name = "Backpack type";
            Description = "Backpack types";
        }
    }
}