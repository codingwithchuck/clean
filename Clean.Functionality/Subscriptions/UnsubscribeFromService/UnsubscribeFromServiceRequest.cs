using Clean.Core.Domain;
using MediatR;

namespace Clean.Functionality.Subscriptions.UnsubscribeFromService
{
    public class UnsubscribeFromServiceRequest : IRequest<User>
    {
        public void Deconstruct(out int serviceId, out int userId)
        {
            serviceId = ServiceId;
            userId = UserId;
        }

        public int ServiceId { get; }
        
        public int UserId { get; }

        public UnsubscribeFromServiceRequest(int serviceId, int userId)
        {
            ServiceId = serviceId;
            UserId = userId;
        }
    }
}