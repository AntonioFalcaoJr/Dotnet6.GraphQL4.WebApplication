using System;
using AutoMapper;
using Dotnet5.GraphQL.Store.Services.Abstractions.Messages;
using Dotnet5.GraphQL.Store.Services.Models;
using Dotnet5.GraphQL.Store.Services.Models.Messages;

namespace Dotnet5.GraphQL.Store.Services.Messages
{
    public class ReviewMessageService : MessageService<ReviewMessage, ReviewModel, Guid>, IReviewMessageService
    {
        public ReviewMessageService(IMapper mapper)
            : base(mapper) { }
    }
}