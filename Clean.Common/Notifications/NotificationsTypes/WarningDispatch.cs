﻿ namespace Clean.Common.Notifications.NotificationsTypes
{
    public class WarningNotification : INotification
    {
        public WarningNotification() { }

        public WarningNotification(string message) 
            => Message = message;

        public NotificationValueObject Notification { get; } = NotificationValueObject.Warning;
        public string Message { get; set; } = string.Empty;
    }
}