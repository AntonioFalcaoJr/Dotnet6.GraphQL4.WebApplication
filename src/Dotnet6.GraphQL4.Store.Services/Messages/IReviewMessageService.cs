using System;
using Dotnet6.GraphQL4.Services.Abstractions.Messages;
using Dotnet6.GraphQL4.Store.Services.Models.Reviews;
using Dotnet6.GraphQL4.Store.Services.Models.Reviews.Messages;

namespace Dotnet6.GraphQL4.Store.Services.Messages
{
    public interface IReviewMessageService : IMessageService<ReviewMessage, ReviewModel, Guid> { }
}