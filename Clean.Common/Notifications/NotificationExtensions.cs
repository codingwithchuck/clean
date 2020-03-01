using System.Collections.Generic;
using Clean.Common.Notifications.Collections;
using Clean.Common.Notifications.NotificationsTypes;

namespace Clean.Common.Notifications
{
    public static class NotificationExtensions
    {
        public static List<T> WithNotification<T>(this List<T> list, INotification notification) 
            => new ListWithNotifications<T>(list, notification);
    }
}