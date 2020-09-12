using System;
using Dotnet5.GraphQL.Store.Services.Abstractions.Messages;
using Dotnet5.GraphQL.Store.Services.Models;
using Dotnet5.GraphQL.Store.Services.Models.Messages;

namespace Dotnet5.GraphQL.Store.Services.Messages
{
    public interface IReviewMessageService : IMessageService<ReviewMessage, ReviewModel, Guid> { }
}