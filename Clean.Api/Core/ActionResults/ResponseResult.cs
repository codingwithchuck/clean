using System.Collections.Generic;
using System.Linq;
using Clean.Common.Notifications;
using Clean.Common.Notifications.NotificationsTypes;

namespace Clean.Api.Core.ActionResults
{
    public class ResponseResult
    {
        public string Version { get; set; }

        /// <summary>
        ///     Gets or sets the result.
        /// </summary>
        /// <value>The result.</value>
        public object Model { get; set; }

        public IList<INotification> Dispatches { get; set; } = new List<INotification>();

        public bool HasErrors()
        {
            return Dispatches.Any(s => s.Notification == NotificationValueObject.Error);
        }
    }
}