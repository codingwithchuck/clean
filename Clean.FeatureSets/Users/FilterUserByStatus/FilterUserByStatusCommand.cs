using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Clean.Core.DataAccess;
using Clean.Core.Domain;
using MediatR;

namespace Clean.FeatureSets.Users.FilterUserByStatus
{
    public class FilterUserByStatusCommand : IRequestHandler<FilterUserByStatusRequest, List<User>>
    {
        private readonly IUserRepository _userRepository;

        public FilterUserByStatusCommand(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }
        
        public Task<List<User>> Handle(FilterUserByStatusRequest request, CancellationToken cancellationToken)
        {
            var status = request.AccountStatus;
            var users = _userRepository.Filter(new AccountStatusSpecifications(status));

            return Task.FromResult(users);
        }
    }
}