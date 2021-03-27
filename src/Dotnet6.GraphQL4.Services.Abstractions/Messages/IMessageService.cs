using System;
using System.Threading.Tasks;
using Dotnet6.GraphQL4.Services.Abstractions.Models;

namespace Dotnet6.GraphQL4.Services.Abstractions.Messages
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