using Dotnet5.GraphQL3.Repositories.Abstractions.Pages;
using GraphQL.Types;

namespace Dotnet5.GraphQL3.Store.WebAPI.GraphQL.Types.Pages
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