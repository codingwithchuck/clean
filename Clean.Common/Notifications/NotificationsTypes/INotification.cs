﻿  namespace Clean.Common.Notifications.NotificationsTypes
{
    public interface INotification
    {
        NotificationValueObject Notification { get; }

        string Message { get; }
    }
}