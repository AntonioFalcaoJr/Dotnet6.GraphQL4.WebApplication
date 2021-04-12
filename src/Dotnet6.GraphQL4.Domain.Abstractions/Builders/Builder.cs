using System;
using Dotnet6.GraphQL4.Domain.Abstractions.Builders.Extensions;
using Dotnet6.GraphQL4.Domain.Abstractions.Entities;

namespace Dotnet6.GraphQL4.Domain.Abstractions.Builders
{
    public abstract class Builder<TBuilder, TEntity, TId> : IBuilder<TBuilder, TEntity, TId>
        where TBuilder : Builder<TBuilder, TEntity, TId>
        where TEntity : Entity<TId>
        where TId : struct
    {
        protected TId Id;
        public abstract TEntity Build();

        public TBuilder With<TProperty>(Func<TBuilder, TProperty> func)
            => ((TBuilder) this).With<TBuilder, TProperty>(func);
    }
}