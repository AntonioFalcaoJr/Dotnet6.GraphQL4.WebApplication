using System;
using System.Reactive.Subjects;
using AutoMapper;
using Dotnet5.GraphQL3.Services.Abstractions.Messages;
using Dotnet5.GraphQL3.Store.Services.Models;
using Dotnet5.GraphQL3.Store.Services.Models.Messages;

namespace Dotnet5.GraphQL3.Store.Services.Messages
{
    public class ReviewMessageService : MessageService<ReviewMessage, ReviewModel, Guid>, IReviewMessageService
    {
        public ReviewMessageService(IMapper mapper, ISubject<ReviewMessage> subject)
            : base(mapper, subject) { }
    }
}