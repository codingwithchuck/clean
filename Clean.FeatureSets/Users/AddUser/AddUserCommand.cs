using System.Threading;
using System.Threading.Tasks;
using Clean.Core.DataAccess;
using Clean.Core.Domain;
using MediatR;

namespace Clean.FeatureSets.Users.AddUser
{
    public class AddUserCommand : IRequestHandler<AddUserRequest, User>
    {
        private readonly IUserRepository _userRepository;

        public AddUserCommand(IUserRepository userRepository) 
            => _userRepository = userRepository;

        public Task<User> Handle(AddUserRequest request, CancellationToken cancellationToken)
        {
           var user = request.Value;
           return Task.FromResult(_userRepository.Add(user));
        }
    }
}