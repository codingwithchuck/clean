﻿using System.Collections.Generic;
 using Clean.Common.Notifications.NotificationsTypes;

 namespace Clean.Common.Notifications
{
    public interface INotificationCollection
    {
        IList<INotification> Notifications { get; set; }
    }
}