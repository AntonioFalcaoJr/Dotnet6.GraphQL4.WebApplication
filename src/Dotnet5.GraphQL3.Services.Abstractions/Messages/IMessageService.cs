using System;
using Dotnet5.GraphQL3.Services.Abstractions.Models;

namespace Dotnet5.GraphQL3.Services.Abstractions.Messages
{
    public interface IMessageService<out TMessage, in TModel, TId>
        where TMessage : class
        where TModel : Model<TId>
        where TId : struct
    {
        TMessage Add(TModel model);
        IObservable<TMessage> Messages();
    }
}