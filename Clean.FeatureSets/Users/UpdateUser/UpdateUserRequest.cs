using Clean.Core.Domain;
using MediatR;

namespace Clean.FeatureSets.Users.UpdateUser
{
    public class UpdateUserRequest : IRequest<User>
    {
        public UpdateUserRequest(User user) 
            => Value = user;

        public User Value { get; set; }
    }
}