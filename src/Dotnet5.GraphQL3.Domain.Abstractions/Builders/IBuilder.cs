using Dotnet5.GraphQL3.Domain.Abstractions.Entities;

namespace Dotnet5.GraphQL3.Domain.Abstractions.Builders
{
    public interface IBuilder<out TEntity, TId>
        where TEntity : Entity<TId>
        where TId : struct
    {
        TEntity Build();
    }
}