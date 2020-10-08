using System;
using System.Collections.Generic;
using FluentValidation.Results;
using GraphQL;

namespace Dotnet5.GraphQL3.CrossCutting.Notifications
{
    public interface INotificationContext
    {
        ExecutionErrors ExecutionErrors { get; }
        IReadOnlyList<Notification> Notifications { get; }
        bool HasNotifications { get; }

        void AddNotification(string message, string key = default);
        void AddNotification(Notification notification);
        void AddNotifications(IEnumerable<Notification> notifications);
        void AddNotifications(ValidationResult validationResult);
        void AddNotificationWithId(string message, object id);
        void AddNotificationWithType(string message, Type type);
    }
}