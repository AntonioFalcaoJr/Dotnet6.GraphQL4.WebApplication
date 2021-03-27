using Dotnet6.GraphQL4.Repositories.Abstractions.Pages;
using GraphQL.Types;

namespace Dotnet6.GraphQL4.Store.WebAPI.Graphs.Types.Pages
{
    public sealed class PageParamsGraphType : InputObjectGraphType<PageParams>
    {
        public PageParamsGraphType()
        {
            Name = nameof(PageParamsGraphType);
            Field(x => x.Index, true, typeof(IntGraphType));
            Field(x => x.Size, true, typeof(IntGraphType));
        }
    }
}