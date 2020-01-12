using Clean.Common.Data.Specifications;
using Clean.Core.Domain;
using Clean.Core.ValueTypes;

namespace Clean.Functionality.Users.FilterUserByStatus
{
    public class AccountStatusSpecifications : DataSpecification<User>
    {
        public AccountStatusSpecifications(AccountStatus status)
        {
            Where(s => s.AccountStatus == status);
        }
    }
}