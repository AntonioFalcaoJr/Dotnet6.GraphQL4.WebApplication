using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FluentValidation.Results;
using GraphQL;

namespace Dotnet6.GraphQL4.CrossCutting.Notifications
{
    public class NotificationContext : INotificationContext
    {
        private List<Notification> _notifications { get; } = new();

        private IEnumerable<ExecutionError> _executionErrors
            => _notifications.Select<Notification, ExecutionError>(notification 
                => new(notification.Message));

        public ExecutionErrors ExecutionErrors
        {
            get
            {
                ExecutionErrors executionErrors = new();
                executionErrors.AddRange(_executionErrors);
                return executionErrors;
            }
        }

        public IReadOnlyList<Notification> Notifications 
            => _notifications;
        public bool AllValid 
            => HasNotifications is false;
        public Task<bool> AllValidAsync 
            => Task.FromResult(HasNotifications is false);   
        public bool HasNotifications 
            => _notifications.Any();
        public Task<bool> HasNotificationsAsync 
            => Task.FromResult(HasNotifications);

        public void AddNotification(string message, string key = default)
            => _notifications.Add(new(key, message));

        public void AddNotification(Notification notification)
            => _notifications.Add(notification);

        public void AddNotifications(IEnumerable<Notification> notifications)
            => _notifications.AddRange(notifications);

        public void AddNotifications(ValidationResult validationResult)
            => validationResult.Errors.ToList().ForEach(failure 
                => AddNotification(failure.ErrorMessage, failure.ErrorCode));

        public void AddNotificationWithId(string message, object id)
            => AddNotification(string.Format(message, id));

        public void AddNotificationWithType(string message, Type type)
            => AddNotification(string.Format(message, type.Name));
    }
}