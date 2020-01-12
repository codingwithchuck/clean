using System.Threading.Tasks;
using AutoMapper;
using Clean.Api.ViewModels;
using Clean.Core.Domain;
using Clean.Functionality.Users.GetUserById;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Clean.Api.Controllers.Users
{
    public class UserController : ControllerBase
    {
        private readonly IMediator _mediator;
        private readonly IMapper _mapper;

        public UserController(IMediator mediator, IMapper mapper)
        {
            _mediator = mediator;
            _mapper = mapper;
        }
        
        [HttpGet("/api/user/{userId:int}")]
        public async Task<IActionResult> Get(int userId)
        {
            var result = await _mediator.Send(new GetUserByIdRequest(userId));
            var viewModel = _mapper.Map<User, UserViewModel>(result);
            
            return Ok(viewModel);
        }

        /// <summary>
        /// Add new user
        /// </summary>
        /// <returns></returns>
        [HttpPost("/api/user")]
        public IActionResult Post(AddUserViewModel adduser)
        {
            return null;
        }

        /// <summary>
        /// Update user
        /// </summary>
        /// <returns></returns>
        [HttpPost("/api/user")]
        public IActionResult Put(UpdateUserViewModel updateUser)
        {
            return null;
        }

        /// <summary>
        /// Delete User
        /// </summary>
        /// <returns></returns>
        [HttpDelete("/api/user/{userId:int}")]
        public IActionResult Delete(int userId)
        {
            return null;
        }
    }
}