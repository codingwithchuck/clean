using System.Threading.Tasks;
using AutoMapper;
using Clean.Api.ViewModels;
using Clean.Core.Domain;
using Clean.Functionality.Admin;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Clean.Api.Controllers
{
    public class AdminUserStatusController : ControllerBase
    {
        private readonly IMediator _mediator;
        private readonly IMapper _mapper;

        public AdminUserStatusController(IMediator mediator, IMapper mapper)
        {
            _mediator = mediator;
            _mapper = mapper;
        }
        
        /// <summary>
        /// Update user status
        /// </summary>
        /// <param name="userId"></param>
        /// <param name="status"></param>
        /// <returns></returns>
        [HttpPut("/api/admin/user/{userId:int}/status/{status:int}")]
        public async Task<IActionResult> Put(int userId, int status)
        {
            var result = await _mediator.Send(new ChangeStatusOfUserRequest(userId, status));
            var viewModel = _mapper.Map<User, UserViewModel>(result);
            
            return Ok(viewModel);
        }
    }
}