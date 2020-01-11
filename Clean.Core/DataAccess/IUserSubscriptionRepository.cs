using System.Collections.Generic;
using Clean.Common.Data.Specifications;
using Clean.Core.Domain;

namespace Clean.Core.DataAccess
{
    public interface IUserSubscriptionRepository
    {
        void Subscribe(int userId, int serviceId);

        void Unsubscribe(int userId, int serviceId);

        IList<Service> Filter(IDataSpecification<Service> specification);
    }
}