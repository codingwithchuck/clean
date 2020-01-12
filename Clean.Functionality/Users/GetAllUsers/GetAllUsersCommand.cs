using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Clean.Core.DataAccess;
using Clean.Core.Domain;
using MediatR;

namespace Clean.Functionality.Users.GetAllUsers
{
    public class GetAllUsersCommand : IRequestHandler<GetAllUsersRequest, List<User>>
    {
        private readonly IUserRepository _userRepository;

        public GetAllUsersCommand(IUserRepository userRepository) 
            => _userRepository = userRepository;

        public Task<List<User>> Handle(GetAllUsersRequest request, CancellationToken cancellationToken)
        {
            var allUsers = _userRepository.GetAll();
            return Task.FromResult(allUsers);
        }
    }
}