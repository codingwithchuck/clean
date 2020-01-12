using System.Collections.Generic;
using Clean.Core.Domain;
using Clean.Core.ValueTypes;
using MediatR;

namespace Clean.Functionality.Users.FilterUserByStatus
{
    public class FilterUserByStatusRequest : IRequest<List<User>>
    {
        public FilterUserByStatusRequest(AccountStatus status)
            => AccountStatus = status;

        public AccountStatus AccountStatus { get; set; }
    }
}