using System;
using Dotnet6.GraphQL4.Domain.Abstractions.Entities;

namespace Dotnet6.GraphQL4.Domain.Abstractions.Builders
{
    public interface IBuilder<out TBuilder, out TEntity, TId>
        where TBuilder : IBuilder<TBuilder, TEntity, TId>
        where TEntity : Entity<TId>
        where TId : struct
    {
        TEntity Build();
        TBuilder With<TProperty>(Func<TBuilder, TProperty> func);
    }
}