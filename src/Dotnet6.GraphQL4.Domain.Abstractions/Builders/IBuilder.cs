using Dotnet6.GraphQL4.Domain.Abstractions.Entities;

namespace Dotnet6.GraphQL4.Domain.Abstractions.Builders
{
    public interface IBuilder<out TEntity, TId>
        where TEntity : Entity<TId>
        where TId : struct
    {
        TEntity Build();
    }
}