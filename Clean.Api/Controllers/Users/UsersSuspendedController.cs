using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Clean.Api.ViewModels;
using Clean.Core.Domain;
using Clean.Core.ValueTypes;
using Clean.Functionality.Users.FilterUserByStatus;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Clean.Api.Controllers.Users
{
    public class UsersSuspendedController : ControllerBase
    {
        private readonly IMediator _mediator;
        private readonly IMapper _mapper;

        public UsersSuspendedController(IMediator mediator, IMapper mapper)
        {
            _mediator = mediator;
            _mapper = mapper;
        }
        
        /// <summary>
        /// Get all the suspended Users
        /// </summary>
        /// <returns></returns>
        [HttpGet("/api/users/status/suspended")]
        public async Task<IActionResult> Get()
        {
            var result = await _mediator.Send(new FilterUserByStatusRequest(AccountStatus.Suspended));
            var viewModels = result.Select(s=> _mapper.Map<User, UserViewModel>(s)).ToList();
            
            return Ok(viewModels);
        }
    }
}