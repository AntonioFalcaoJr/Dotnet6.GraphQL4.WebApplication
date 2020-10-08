using System;
using Dotnet5.GraphQL3.Services.Abstractions.Messages;
using Dotnet5.GraphQL3.Store.Services.Models;
using Dotnet5.GraphQL3.Store.Services.Models.Messages;

namespace Dotnet5.GraphQL3.Store.Services.Messages
{
    public interface IReviewMessageService : IMessageService<ReviewMessage, ReviewModel, Guid> { }
}