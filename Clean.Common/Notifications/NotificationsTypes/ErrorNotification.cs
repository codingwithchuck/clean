﻿  namespace Clean.Common.Notifications.NotificationsTypes
{
    public class ErrorNotification : INotification
    {
        public ErrorNotification() { }

        public ErrorNotification(string message) 
            => Message = message;

        public NotificationValueObject Notification { get; } = NotificationValueObject.Error;
        public string Message { get; set; } = string.Empty;
    }
}