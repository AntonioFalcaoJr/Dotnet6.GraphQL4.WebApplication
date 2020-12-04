using System;
using System.Threading.Tasks;
using Dotnet5.GraphQL3.Services.Abstractions.Models;

namespace Dotnet5.GraphQL3.Services.Abstractions.Messages
{
    public interface IMessageService<TMessage, in TModel, TId>
        where TMessage : class
        where TModel : Model<TId>
        where TId : struct
    {
        TMessage Add(TModel model);
        Task<IObservable<TMessage>> MessagesAsync();
    }
}