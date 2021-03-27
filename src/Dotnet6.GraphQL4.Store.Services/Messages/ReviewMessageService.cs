using System;
using System.Reactive.Subjects;
using AutoMapper;
using Dotnet6.GraphQL4.Services.Abstractions.Messages;
using Dotnet6.GraphQL4.Store.Services.Models.Reviews;
using Dotnet6.GraphQL4.Store.Services.Models.Reviews.Messages;

namespace Dotnet6.GraphQL4.Store.Services.Messages
{
    public class ReviewMessageService : MessageService<ReviewMessage, ReviewModel, Guid>, IReviewMessageService
    {
        public ReviewMessageService(IMapper mapper, ISubject<ReviewMessage> subject)
            : base(mapper, subject) { }
    }
}