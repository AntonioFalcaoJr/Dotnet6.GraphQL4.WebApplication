using Dotnet5.GraphQL3.Domain.Abstractions.Entities;

namespace Dotnet5.GraphQL3.Domain.Abstractions.Builders
{
    public abstract class Builder<TBuilder, TEntity, TId> : IBuilder<TEntity, TId>
        where TBuilder : Builder<TBuilder, TEntity, TId>
        where TEntity : Entity<TId>
        where TId : struct
    {
        protected TId Id;

        public abstract TEntity Build();

        public TBuilder WithId(TId id)
        {
            Id = id;
            return (TBuilder) this;
        }
    }
}