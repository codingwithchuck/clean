using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Clean.Api.Core.ActionFilters;
using Clean.Api.ViewModels;
using Clean.Core.Domain;
using Clean.Core.ValueTypes;
using Clean.Functionality.Users.FilterUserByStatus;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Clean.Api.Controllers.Users
{
    public class UsersActiveController : ControllerBase
    {
        private readonly IMediator _mediator;
        private readonly IMapper _mapper;

        public UsersActiveController(IMediator mediator, IMapper mapper)
        {
            _mediator = mediator;
            _mapper = mapper;
        }
        
        /// <summary>
        /// Get active users
        /// </summary>
        /// <returns></returns>
        [HttpGet("/api/users/status/active")]
        [HeaderSecret("x-api-key", "9876")]
        public async Task<IActionResult> Get()
        {
            var result = await _mediator.Send(new FilterUserByStatusRequest(AccountStatus.Active));
            var viewModels = result.Select(s=> _mapper.Map<User, UserViewModel>(s)).ToList();
            
            return Ok(viewModels);
        }
    }
}