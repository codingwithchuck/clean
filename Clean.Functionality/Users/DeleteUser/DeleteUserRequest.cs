using MediatR;

namespace Clean.Functionality.Users.DeleteUser
{
    public class DeleteUserRequest : IRequest
    {
        public DeleteUserRequest(int userId) 
            => this.Value = userId;

        public int Value { get; set; }
    }
}