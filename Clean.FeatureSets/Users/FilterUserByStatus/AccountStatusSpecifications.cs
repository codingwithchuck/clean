using Clean.Common.Data.Specifications;
using Clean.Common.Specifications;
using Clean.Core.Domain;
using Clean.Core.ValueTypes;

namespace Clean.FeatureSets.Users.FilterUserByStatus
{
    public class AccountStatusSpecifications : DataSpecification<User>
    {
        public AccountStatusSpecifications(AccountStatus status)
        {
            Where(s => s.AccountStatus == status);
        }
    }
}