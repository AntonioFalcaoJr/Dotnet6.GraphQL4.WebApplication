using System.Reflection;

namespace Dotnet5.GraphQL3.CrossCutting.Extensions
{
    public static class LocalAssemblyExtensions
    {
        public static string GetEntryAssemblySuffix(this Assembly assembly)
            => Assembly.GetEntryAssembly()?.FullName?.Substring(0, 16);
    }
}