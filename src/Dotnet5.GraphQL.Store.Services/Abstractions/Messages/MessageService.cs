using System;
using System.Reactive.Linq;
using System.Reactive.Subjects;
using AutoMapper;
using Dotnet5.GraphQL.Store.Services.Models;

namespace Dotnet5.GraphQL.Store.Services.Abstractions.Messages
{
    public abstract class MessageService<TMessage, TModel, TId> : IMessageService<TMessage, TModel, TId>
        where TMessage : class
        where TModel : Model<TId>
        where TId : struct
    {
        private readonly IMapper _mapper;
        private readonly ISubject<TMessage> _subject = new ReplaySubject<TMessage>();

        protected MessageService(IMapper mapper)
        {
            _mapper = mapper;
        }

        public TMessage Add(TModel model)
        {
            var message = _mapper.Map<TMessage>(model);
            _subject.OnNext(message);
            return message;
        }

        public IObservable<TMessage> Messages()
            => _subject.AsObservable();
    }
}