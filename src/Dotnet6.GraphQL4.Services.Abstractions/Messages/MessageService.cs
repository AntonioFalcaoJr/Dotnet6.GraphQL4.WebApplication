using System;
using System.Reactive.Linq;
using System.Reactive.Subjects;
using System.Threading.Tasks;
using AutoMapper;
using Dotnet6.GraphQL4.Services.Abstractions.Models;

namespace Dotnet6.GraphQL4.Services.Abstractions.Messages
{
    public abstract class MessageService<TMessage, TModel, TId> : IMessageService<TMessage, TModel, TId>
        where TMessage : class
        where TModel : Model<TId>
        where TId : struct
    {
        private readonly IMapper _mapper;
        private readonly ISubject<TMessage> _subject;

        protected MessageService(IMapper mapper, ISubject<TMessage> subject)
        {
            _mapper = mapper;
            _subject = subject;
        }

        public TMessage Add(TModel model)
        {
            var message = _mapper.Map<TMessage>(model);
            _subject.OnNext(message);
            return message;
        }

        public async Task<IObservable<TMessage>> MessagesAsync()
            =>  await Task.FromResult(_subject.AsObservable());
    }
}