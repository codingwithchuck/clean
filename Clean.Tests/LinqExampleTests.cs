using System.Collections.Generic;
using System.Linq;
using Clean.Common.Notifications;
using Clean.Common.Notifications.NotificationsTypes;
using Clean.Core.ValueTypes;
using Clean.Infrastructure.DataAccess;
using Xunit;

namespace Clean.Tests
{
    public class LinqExampleTests
    {
        [Fact]
        public void linq_example_1()
        {
            var strings = new List<string>
            {
                "Chuck",
                "Cat",
                "Bat"
            };


          var items= strings.WithNotification(new SuccessNotification());
          
          //Merge the notifications on the Model and the passed in notifications
          if (items is INotificationCollection notifications)
          {
              var n = notifications.Notifications;
          }
          
        }
        
        [Fact]
        public void linq_example()
        {
            var data = new InMemoryData().BuildData();

            var activeUsers = 
                (from user in data.Users
                where user.AccountStatus == AccountStatus.Active
                select user).ToList();

            var flattened =
                (from user in data.Users
                    from subscription in user.Subscriptions
                    select new {subscription, user}
                ).ToList();
        }
    }
}