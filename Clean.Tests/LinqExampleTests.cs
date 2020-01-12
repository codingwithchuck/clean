using System.ComponentModel.Design;
using System.Linq;
using Clean.Core.ValueTypes;
using Clean.Infrastructure.DataAccess;
using Xunit;

namespace Clean.Tests
{
    public class LinqExampleTests
    {
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