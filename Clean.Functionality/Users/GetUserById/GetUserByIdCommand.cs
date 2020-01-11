using System.Threading;
using System.Threading.Tasks;
using Clean.Core.DataAccess;
using Clean.Core.Domain;
using MediatR;

namespace Clean.Functionality.Users.GetUserById
{
    public class GetUserByIdCommand : IRequestHandler<GetUserByIdRequest, User>
    {
        private readonly IUserRepository _userRepository;

        public GetUserByIdCommand(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }
        
        public Task<User> Handle(GetUserByIdRequest request, CancellationToken cancellationToken)
        {
            var user = _userRepository.Get(request.Value);
            return Task.FromResult(user);
        }
    }
}