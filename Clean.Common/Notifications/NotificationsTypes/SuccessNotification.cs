﻿ namespace Clean.Common.Notifications.NotificationsTypes
{
    public class SuccessNotification: INotification
    {
        public SuccessNotification() { }

        public SuccessNotification(string message) 
            => Message = message;

        public NotificationValueObject Notification { get; } = NotificationValueObject.Info;

        public string Message { get; set; } = string.Empty;
    }
}