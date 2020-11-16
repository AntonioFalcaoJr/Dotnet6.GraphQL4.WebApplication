using Dotnet5.GraphQL3.Repositories.Abstractions.Pages;
using GraphQL.Types;

namespace Dotnet5.GraphQL3.Store.WebAPI.GraphQL.Types.Pages
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