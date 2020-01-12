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
    public class UsersActiveController : ControllerBase
    {
        private readonly IMediator _mediator;
        private readonly IMapper _mapper;

        public UsersActiveController(IMediator mediator, IMapper mapper)
        {
            _mediator = mediator;
            _mapper = mapper;
        }
        
        [HttpGet("/api/users/status/active")]
        public async Task<IActionResult> Get()
        {
            var result = await _mediator.Send(new FilterUserByStatusRequest(AccountStatus.Active));
            var viewModels = result.Select(s=> _mapper.Map<User, UserViewModel>(s)).ToList();
            
            return Ok(viewModels);
        }
    }
}