using Clean.Core.Domain;
using MediatR;

namespace Clean.FeatureSets.Subscriptions.SubscribeToService
{
    public class SubscribeToServiceRequest : IRequest<User>
    {
        public int UserId { get; }

        public void Deconstruct(out int userId, out int serviceId)
        {
            userId = UserId;
            serviceId = ServiceId;
        }

        public int ServiceId { get; }

        public SubscribeToServiceRequest(int serviceId, int userId)
        {
            UserId = userId;
            ServiceId = serviceId;
        }
    }
}