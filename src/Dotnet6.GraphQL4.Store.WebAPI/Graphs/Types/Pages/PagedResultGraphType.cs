using Dotnet6.GraphQL4.Repositories.Abstractions.Pages;
using GraphQL.Types;

namespace Dotnet6.GraphQL4.Store.WebAPI.Graphs.Types.Pages
{
    public sealed class PagedResultGraphType<TGraphType, T> : ObjectGraphType<PagedResult<T>>
        where TGraphType : IGraphType
        where T : class
    {
        public PagedResultGraphType()
        {
            Name = $"{typeof(TGraphType).Name}List";
            Field(x => x.Items, type: typeof(ListGraphType<TGraphType>));
            Field(x => x.PageInfo, type: typeof(PageInfoGraphType));
        }
    }
}