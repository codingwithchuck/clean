using Clean.Core.Domain;
using MediatR;

namespace Clean.FeatureSets.Users.GetUserById
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