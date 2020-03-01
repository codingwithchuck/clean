﻿﻿ namespace Clean.Common.Notifications
{
    public class ErrorNotification : INotification
    {
        public ErrorNotification() { }

        public ErrorNotification(string message)
        {
            Message = message;
        }

        public NotificationType NotificationType { get; } = NotificationType.Error;
        public string Message { get; set; } = string.Empty;
    }
}