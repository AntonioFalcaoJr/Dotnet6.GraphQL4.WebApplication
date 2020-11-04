using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Dotnet5.GraphQL3.CrossCutting.Notifications;
using GraphQL;
using GraphQL.Execution;
using GraphQL.Server;
using GraphQL.Server.Internal;
using GraphQL.Types;
using GraphQL.Validation;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;

namespace Dotnet5.GraphQL3.Store.WebAPI.GraphQL.Executers
{
    public class StoreExecuter<TSchema> : DefaultGraphQLExecuter<TSchema> where TSchema : ISchema
    {
        public StoreExecuter(TSchema schema, IDocumentExecuter documentExecuter, IOptions<GraphQLOptions> options, IEnumerable<IDocumentExecutionListener> listeners, IEnumerable<IValidationRule> validationRules)
            : base(schema, documentExecuter, options, listeners, validationRules) { }

        public override async Task<ExecutionResult> ExecuteAsync(string operationName, string query, Inputs variables, IDictionary<string, object> context, IServiceProvider requestServices, CancellationToken cancellationToken = new CancellationToken())
        {
            var result = await base.ExecuteAsync(operationName, query, variables, context, requestServices, cancellationToken);
            var notification = requestServices.GetRequiredService<INotificationContext>();

            if (notification.HasNotifications is false) return result;

            result.Errors = notification.ExecutionErrors;
            result.Data = default;
            
            return result;
        }
    }
}