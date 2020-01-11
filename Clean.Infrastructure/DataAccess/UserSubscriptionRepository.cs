using System.Collections.Generic;
using Clean.Common.Data.Specifications;
using Clean.Core.DataAccess;
using Clean.Core.Domain;

namespace Clean.Infrastructure.DataAccess
{
    public class UserSubscriptionRepository : IUserSubscriptionRepository
    {
        public void Subscribe(int userId, int serviceId)
        {
            throw new System.NotImplementedException();
        }

        public void Unsubscribe(int userId, int serviceId)
        {
            throw new System.NotImplementedException();
        }

        public IList<Service> Filter(IDataSpecification<Service> specification)
        {
            throw new System.NotImplementedException();
        }
    }
}