﻿ using Clean.Common.Notifications.NotificationsTypes;

  namespace Clean.Common.Notifications
{
    public interface INotification
    {
        NotificationType NotificationType { get; }

        string Message { get; }
    }
}