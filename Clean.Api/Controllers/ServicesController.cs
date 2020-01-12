using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Clean.Api.ViewModels;
using Clean.Core.Domain;
using Clean.Functionality.Services;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Clean.Api.Controllers
{
    public class ServicesController : ControllerBase
    {
        private readonly IMediator _mediator;
        private readonly IMapper _mapper;

        public ServicesController(IMediator mediator, IMapper mapper)
        {
            _mediator = mediator;
            _mapper = mapper;
        }
        
        /// <summary>
        /// Get all Services
        /// </summary>
        /// <returns></returns>
        [HttpGet("/api/services")]
        public async Task<IActionResult> Get()
        {
           var services = await _mediator.Send(new RetrieveAllServicesRequest());
           var viewModels = services.Select(s => _mapper.Map<Service, ServiceViewModel>(s));
           return Ok(viewModels);
        }
    }
}