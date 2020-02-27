using MediatR;

namespace Clean.FeatureSets.Users.DeleteUser
{
    public class DeleteUserRequest : IRequest
    {
        public DeleteUserRequest(int userId) 
            => Value = userId;

        public int Value { get; set; }
    }
}