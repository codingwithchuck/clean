using System.Collections.Generic;
using Clean.Core.DataAccess;
using Clean.Core.Domain;

namespace Clean.Infrastructure.DataAccess
{
    public class ServiceRepository : IServiceRepository
    {
        private readonly InMemoryData _data;

        public ServiceRepository(InMemoryData data) 
            => _data = data;

        /// <summary>
        /// Retrieves all the services in the data store
        /// </summary>
        /// <returns></returns>
        public List<Service> GetAllServices() 
            => _data.Services;
    }
}