using Dotnet6.GraphQL4.Repositories.Abstractions.Pages;
using GraphQL.Types;

namespace Dotnet6.GraphQL4.Store.WebAPI.Graphs.Types.Pages
{
    public sealed class PageInfoGraphType : ObjectGraphType<PageInfo>
    {
        public PageInfoGraphType()
        {
            Name = "PageInfo";
            Field(x => x.Current);
            Field(x => x.Size);
            Field(x => x.HasPrevious);
            Field(x => x.HasNext);
        }
    }
}