using System;

namespace Dotnet6.GraphQL4.Domain.Abstractions.Builders
{
    internal static class BuilderExtensions
    {
        internal static TBuilder With<TBuilder, TProperty>(this TBuilder builder, Func<TBuilder, TProperty> func)
        {
            func(builder);
            return builder;
        }
    }
}