using GraphQL.Server.Ui.Playground;
using GraphQL.Types;
using Microsoft.AspNetCore.Builder;

namespace Dotnet6.GraphQL4.Store.WebAPI.DependencyInjection.Extensions
{
    public static class ApplicationBuilderExtensions
    {
        public static IApplicationBuilder UseApplicationGraphQL<TSchema>(this IApplicationBuilder app)
            where TSchema : ISchema
            => app
                .UseWebSockets()
                .UseGraphQLWebSockets<TSchema>()
                .UseGraphQL<TSchema>()
                .UseGraphQLPlayground(
                    options: new() 
                    {
                        BetaUpdates = true,
                        RequestCredentials = RequestCredentials.Omit,
                        HideTracingResponse = false,
                        EditorCursorShape = EditorCursorShape.Line,
                        EditorTheme = EditorTheme.Dark,
                        EditorFontSize = 14,
                        EditorReuseHeaders = true,
                        EditorFontFamily = "JetBrains Mono"
                    },
                    path: "/ui/playground");
    }
}