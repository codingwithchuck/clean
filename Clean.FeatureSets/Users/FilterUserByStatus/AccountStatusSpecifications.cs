using Clean.Common.Specifications;
using Clean.Core.Domain;
using Clean.Core.ValueTypes;

namespace Clean.FeatureSets.Users.FilterUserByStatus
{
    public class AccountStatusSpecifications : Specification<User>
    {
        public AccountStatusSpecifications(AccountStatus status)
        {
            Where(s => s.AccountStatus == status);
        }
    }
}