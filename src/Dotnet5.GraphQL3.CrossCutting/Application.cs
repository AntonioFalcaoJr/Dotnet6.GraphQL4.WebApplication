using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;

namespace Dotnet5.GraphQL3.CrossCutting
{
    public static class Application
    {
        public static string Prefix { get; } = Assembly.GetEntryAssembly()?.FullName?.Substring(0, 16);
        public static IEnumerable<Assembly> Assemblies { get; } =
            AppDomain.CurrentDomain.GetAssemblies().Where(assembly => assembly.FullName?.StartsWith(Prefix) ?? false);
    }
}