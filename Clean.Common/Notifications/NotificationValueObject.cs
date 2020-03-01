﻿ namespace Clean.Common.Notifications
{
    public class NotificationValueObject : ValueObject<NotificationValueObject>
    {
        public static readonly NotificationValueObject Success = new NotificationValueObject {Id = 1, Name = "Success"};
        public static readonly NotificationValueObject Error = new NotificationValueObject {Id = 2, Name = "Error"};
        public static readonly NotificationValueObject Info = new NotificationValueObject {Id = 3, Name = "Info"};
        public static readonly NotificationValueObject Warning = new NotificationValueObject {Id = 4, Name = "Warning"};
    }
}