using System.Threading.Tasks;
using AutoMapper;
using Clean.Api.ViewModels;
using Clean.Core.Domain;
using Clean.FeatureSets.Users.AddUser;
using Clean.FeatureSets.Users.DeleteUser;
using Clean.FeatureSets.Users.GetUserById;
using Clean.FeatureSets.Users.UpdateUser;
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
        
        /// <summary>
        /// Get User By Id
        /// </summary>
        /// <param name="userId"></param>
        /// <returns></returns>
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
        public async Task<IActionResult> Post(AddUserViewModel adduser)
        {
           var user = _mapper.Map<AddUserViewModel, User>(adduser);
            
            var result = await _mediator.Send(new AddUserRequest(user));
            var viewModel = _mapper.Map<User, UserViewModel>(result);
            
            return Ok(viewModel);
        }

        /// <summary>
        /// Update user
        /// </summary>
        /// <returns></returns>
        [HttpPost("/api/user")]
        public async Task<IActionResult> Put(UpdateUserViewModel updateUser)
        {
            var user = _mapper.Map<UpdateUserViewModel, User>(updateUser);
            
            var result = await _mediator.Send(new UpdateUserRequest(user));
            var viewModel = _mapper.Map<User, UserViewModel>(result);
            
            return Ok(viewModel);
        }

        /// <summary>
        /// Delete User
        /// </summary>
        /// <returns></returns>
        [HttpDelete("/api/user/{userId:int}")]
        public async Task<IActionResult> Delete(int userId)
        {
            await _mediator.Send(new DeleteUserRequest(userId));
            return Ok();
        }
    }
}