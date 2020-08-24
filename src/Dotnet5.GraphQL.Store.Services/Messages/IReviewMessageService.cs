using System;
using Dotnet5.GraphQL.Store.Services.Abstractions.Messages;
using Dotnet5.GraphQL.Store.Services.Models;

namespace Dotnet5.GraphQL.Store.Services.Messages
{
    public interface IReviewMessageService : IMessageService<ReviewMessage, ReviewModel, Guid> { }
}