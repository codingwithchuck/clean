using System.Collections.Generic;
using System.Linq;
using Clean.Common.Specifications;
using Clean.Core.Domain;
using Clean.Core.ValueTypes;
using Clean.FeatureSets.Users.FilterUserByStatus;
using FluentAssertions;
using Xunit;

namespace Clean.Tests
{
    public class AccountStatusSpecificationTests
    {
        private readonly List<User> _users = new List<User>
        {
            new User {AccountStatus = AccountStatus.Active},
            new User {AccountStatus = AccountStatus.Disabled},
            new User {AccountStatus = AccountStatus.Suspended}
        };

        [Fact]
        public void filter_users_by_active_status()
        {
            const AccountStatus status = AccountStatus.Active;
            filter_user_by_account_status(status);
        }
        
        [Fact]
        public void filter_users_by_disabled_status()
        {
            const AccountStatus status = AccountStatus.Disabled;
            filter_user_by_account_status(status);
        }
        
        [Fact]
        public void filter_users_by_suspended_status()
        {
            const AccountStatus status = AccountStatus.Active;
            filter_user_by_account_status(status);
        }

        private void filter_user_by_account_status(AccountStatus status)
        {
            var specification = new AccountStatusSpecifications(status);
            var users = SpecificationProcessor<User>.ApplySpecification(_users.AsQueryable(), specification);

            users.ToList().Should().HaveCount(1);
        }
    }
}