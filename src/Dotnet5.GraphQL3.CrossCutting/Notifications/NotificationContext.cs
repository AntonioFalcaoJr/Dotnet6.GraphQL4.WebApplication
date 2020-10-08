using System;
using System.Collections.Generic;
using System.Linq;
using FluentValidation.Results;
using GraphQL;

namespace Dotnet5.GraphQL3.CrossCutting.Notifications
{
    public class NotificationContext : INotificationContext
    {
        private readonly List<Notification> _notifications;

        public NotificationContext()
        {
            _notifications = new List<Notification>();
        }

        private IEnumerable<ExecutionError> _executionErrors
            => _notifications.Select(notification => new ExecutionError(notification.Message));

        public ExecutionErrors ExecutionErrors
        {
            get
            {
                var executionErrors = new ExecutionErrors();
                executionErrors.AddRange(_executionErrors);
                return executionErrors;
            }
        }

        public IReadOnlyList<Notification> Notifications => _notifications;
        public bool HasNotifications => _notifications.Any();

        public void AddNotification(string message, string key = default)
            => _notifications.Add(new Notification(key, message));

        public void AddNotification(Notification notification)
            => _notifications.Add(notification);

        public void AddNotifications(IEnumerable<Notification> notifications)
            => _notifications.AddRange(notifications);

        public void AddNotifications(ValidationResult validationResult)
        {
            foreach (var error in validationResult.Errors)
                AddNotification(error.ErrorMessage, error.ErrorCode);
        }

        public void AddNotificationWithId(string message, object id)
            => AddNotification(string.Format(message, id));

        public void AddNotificationWithType(string message, Type type)
            => AddNotification(string.Format(message, type.Name));
    }
}