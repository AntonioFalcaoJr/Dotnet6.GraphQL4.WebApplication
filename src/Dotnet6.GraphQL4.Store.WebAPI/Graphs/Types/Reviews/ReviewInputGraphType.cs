using GraphQL.Types;

namespace Dotnet6.GraphQL4.Store.WebAPI.Graphs.Types.Reviews
{
    public class ReviewInputGraphType : InputObjectGraphType
    {
        public ReviewInputGraphType()
        {
            Name = "reviewInput";
            Field<NonNullGraphType<StringGraphType>>("title");
            Field<NonNullGraphType<StringGraphType>>("comment");
            Field<NonNullGraphType<GuidGraphType>>("productId");
        }
    }
}