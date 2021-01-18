using GraphQL.Server;
using GraphQL.Server.Ui.Playground;
using GraphQL.Types;
using Microsoft.AspNetCore.Builder;

namespace Dotnet5.GraphQL3.Store.WebAPI.GraphQL.Extensions.DependencyInjection
{
    public static class ApplicationBuilderExtensions
    {
        public static IApplicationBuilder UseApplicationGraphQL<TSchema>(this IApplicationBuilder app)
            where TSchema : ISchema
            => app.UseWebSockets()
                .UseGraphQLWebSockets<TSchema>()
                .UseGraphQL<TSchema>()
                .UseGraphQLPlayground(
                    new GraphQLPlaygroundOptions
                    {
                        Path = "/ui/playground",
                        BetaUpdates = true,
                        RequestCredentials = RequestCredentials.Omit,
                        HideTracingResponse = false,

                        EditorCursorShape = EditorCursorShape.Line,
                        EditorTheme = EditorTheme.Dark,
                        EditorFontSize = 14,
                        EditorReuseHeaders = true,
                        EditorFontFamily = "JetBrains Mono"
                    });
    }
}