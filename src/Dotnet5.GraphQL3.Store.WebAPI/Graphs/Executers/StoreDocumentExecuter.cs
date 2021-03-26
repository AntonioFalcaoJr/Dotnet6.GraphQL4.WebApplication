using GraphQL;
using GraphQL.Execution;
using GraphQL.Language.AST;

namespace Dotnet5.GraphQL3.Store.WebAPI.Graphs.Executers
{
    public class StoreDocumentExecuter : SubscriptionDocumentExecuter
    {
        protected override IExecutionStrategy SelectExecutionStrategy(ExecutionContext context)
            => context.Operation.OperationType is OperationType.Subscription 
                ? SubscriptionExecutionStrategy.Instance 
                : base.SelectExecutionStrategy(context);
    }
}