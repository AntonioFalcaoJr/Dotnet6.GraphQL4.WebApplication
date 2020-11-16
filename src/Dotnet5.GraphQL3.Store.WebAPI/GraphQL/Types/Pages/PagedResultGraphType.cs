using Dotnet5.GraphQL3.Repositories.Abstractions.Pages;
using GraphQL.Types;

namespace Dotnet5.GraphQL3.Store.WebAPI.GraphQL.Types.Pages
{
    public sealed class PagedResultGraphType<TGraphType, T> : ObjectGraphType<PagedResult<T>>
        where TGraphType : IGraphType
    {
        public PagedResultGraphType()
        {
            Name = $"{typeof(TGraphType).Name}List";
            Field(x => x.Items, type: typeof(ListGraphType<TGraphType>));
            Field(x => x.PageInfo, type: typeof(PageInfoGraphType));
        }
    }
}