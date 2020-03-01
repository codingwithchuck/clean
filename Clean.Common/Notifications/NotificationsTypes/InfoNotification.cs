﻿ namespace Clean.Common.Notifications.NotificationsTypes
{
    public class InfoNotification : INotification
    {
        public InfoNotification() { }

        public InfoNotification(string message)
        {
            Message = message;
        }

        public NotificationValueObject Notification { get; } = NotificationValueObject.Info;
        public string Message { get; set; } = string.Empty;
    }
}