using System.Collections.Generic;
using Clean.Common.Notifications.NotificationsTypes;

namespace Clean.Common.Notifications.Collections
{
    public class ListWithNotifications<T> : List<T>, INotificationCollection
    {
        public ListWithNotifications() { }

        public ListWithNotifications(IEnumerable<T> items, INotification notification)
        {
            AddRange(items);
            Notifications.Add(notification);
        }
        
        public IList<INotification> Notifications { get; set; } = new List<INotification>();
    }
}