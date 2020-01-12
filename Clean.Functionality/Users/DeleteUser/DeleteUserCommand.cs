using System.Threading;
using System.Threading.Tasks;
using Clean.Core.DataAccess;
using MediatR;

namespace Clean.Functionality.Users.DeleteUser
{
    public class DeleteUserCommand : AsyncRequestHandler<DeleteUserRequest>
    {
        private readonly IUserRepository _userRepository;

        public DeleteUserCommand(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }
        
        protected override Task Handle(DeleteUserRequest request, CancellationToken cancellationToken)
        {
            var userId = request.Value;
            _userRepository.Delete(userId);
            
            return Task.CompletedTask;
        }
    }
}