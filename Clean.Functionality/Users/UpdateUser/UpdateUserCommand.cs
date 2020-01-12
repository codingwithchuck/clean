using System.Threading;
using System.Threading.Tasks;
using Clean.Core.DataAccess;
using Clean.Core.Domain;
using MediatR;

namespace Clean.Functionality.Users.UpdateUser
{
    public class UpdateUserCommand : IRequestHandler<UpdateUserRequest, User>
    {
        private readonly IUserRepository _userRepository;

        public UpdateUserCommand(IUserRepository userRepository) 
            => _userRepository = userRepository;

        public Task<User> Handle(UpdateUserRequest request, CancellationToken cancellationToken)
        {
            var user = request.Value;
            _userRepository.Update(user);

            return Task.FromResult(user);
        }
    }
}