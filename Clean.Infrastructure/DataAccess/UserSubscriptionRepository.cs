using System.Collections.Generic;
using System.Linq;
using Clean.Common.Data.Specifications;
using Clean.Core.DataAccess;
using Clean.Core.Domain;

namespace Clean.Infrastructure.DataAccess
{
    public class UserSubscriptionRepository : IUserSubscriptionRepository
    {
        private readonly InMemoryData _data;

        public UserSubscriptionRepository(InMemoryData data) 
            => _data = data;

        /// <summary>
        /// Subscribe to service
        /// </summary>
        /// <param name="userId"></param>
        /// <param name="serviceId"></param>
        public void Subscribe(int userId, int serviceId)
        {
            var user =_data.Users.Single(s => s.Id == userId);
            var isNewSubscription = user.Subscriptions.All(s => s.Id != serviceId);

            if (isNewSubscription)
            {
                var service = _data.Services.Single(s => s.Id == serviceId);
                user.Subscriptions.Add(service);
            }
        }

        /// <summary>
        /// Unsubscribe from the service.
        /// </summary>
        /// <param name="userId"></param>
        /// <param name="serviceId"></param>
        public void Unsubscribe(int userId, int serviceId)
        {
            const int notFoundPosition = -1;
            var user =_data.Users.Single(s => s.Id == userId);
            var index = user.Subscriptions.FindIndex(s => s.Id == serviceId);

            if (index > notFoundPosition)
            {
                user.Subscriptions.RemoveAt(index);
            }
        }

        
        public IList<Service> Filter(IDataSpecification<Service> specification)
        {
            throw new System.NotImplementedException();
        }
    }
}