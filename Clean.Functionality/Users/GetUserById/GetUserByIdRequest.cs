using Clean.Core.Domain;
using Clean.Functionality.Common.Requests;
using MediatR;

namespace Clean.Functionality.Users.GetUserById
{
    public class GetUserByIdRequest : IRequest<User>
    {
        public GetUserByIdRequest(int value)
        {
            Value = value;
        }
        
        public int Value { get; }
    }
}