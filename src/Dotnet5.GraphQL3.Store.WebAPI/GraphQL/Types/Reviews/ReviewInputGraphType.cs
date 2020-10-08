using GraphQL.Types;

namespace Dotnet5.GraphQL3.Store.WebAPI.GraphQL.Types.Reviews
{
    public class ReviewInputGraphType : InputObjectGraphType
    {
        public ReviewInputGraphType()
        {
            Name = "reviewInput";
            Field<NonNullGraphType<StringGraphType>>("title");
            Field<StringGraphType>("comment");
            Field<NonNullGraphType<StringGraphType>>("productId");
        }
    }
}