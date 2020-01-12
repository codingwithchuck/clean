using System.Threading;
using System.Threading.Tasks;
using Clean.Core.DataAccess;
using Clean.Core.Domain;
using Clean.Core.ValueTypes;
using MediatR;

namespace Clean.Functionality.Admin
{
    public class ChangeStatusOfUserCommand : IRequestHandler<ChangeStatusOfUserRequest, User>
    {
        private readonly IUserRepository _userRepository;

        public ChangeStatusOfUserCommand(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }
        
        public Task<User> Handle(ChangeStatusOfUserRequest request, CancellationToken cancellationToken)
        {
            var (userId, status) = request;
            
            var user = _userRepository.Get(userId);
           user.AccountStatus = (AccountStatus) status;
           _userRepository.Update(user);

           return Task.FromResult(user);
        }
    }
}