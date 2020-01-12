using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Clean.Core.DataAccess;
using Clean.Core.Domain;
using MediatR;

namespace Clean.Functionality.Services
{
    public class RetrieveAllServicesCommand : IRequestHandler<RetrieveAllServicesRequest, List<Service>>
    {
        private readonly IServiceRepository _serviceRepository;

        public RetrieveAllServicesCommand(IServiceRepository serviceRepository)
        {
            _serviceRepository = serviceRepository;
        }
        
        public Task<List<Service>> Handle(RetrieveAllServicesRequest request, CancellationToken cancellationToken)
        {
           var services = _serviceRepository.GetAllServices();
           return Task.FromResult(services);
        }
    }
}