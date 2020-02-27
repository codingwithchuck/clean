using Clean.Core.Domain;
using MediatR;

namespace Clean.FeatureSets.Users.AddUser
{
    public class AddUserRequest : IRequest<User>
    {
        public AddUserRequest(User user) 
            => Value = user;

        public User Value { get; set; }
    }
}