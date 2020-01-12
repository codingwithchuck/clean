using Clean.Core.Domain;
using MediatR;

namespace Clean.Functionality.Admin
{
    public class ChangeStatusOfUserRequest : IRequest<User>
    {
        public void Deconstruct(out int userId, out int status)
        {
            userId = UserId;
            status = Status;
        }

        public int UserId { get; }
        public int Status { get; }

        public ChangeStatusOfUserRequest(int userId, int status)
        {
            UserId = userId;
            Status = status;
        }
    }
}