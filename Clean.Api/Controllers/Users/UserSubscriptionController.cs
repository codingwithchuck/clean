using System.Threading.Tasks;
using AutoMapper;
using Clean.Api.ViewModels;
using Clean.Core.Domain;
using Clean.FeatureSets.Subscriptions.SubscribeToService;
using Clean.FeatureSets.Subscriptions.UnsubscribeFromService;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Clean.Api.Controllers.Users
{
    [Route("/api/subscription/{serviceId:int}/user/{userId:int}")]
    public class UserSubscriptionController : ControllerBase
    {
        private readonly IMediator _mediator;
        private readonly IMapper _mapper;

        public UserSubscriptionController(IMediator mediator, IMapper mapper)
        {
            _mediator = mediator;
            _mapper = mapper;
        }
        
        /// <summary>
        /// Add new Subscription
        /// </summary>
        /// <returns></returns>
        [HttpPost]
        public async Task<IActionResult> Post(int serviceId, int userId)
        {
            var result = await _mediator.Send(new SubscribeToServiceRequest(serviceId, userId));
            var viewModel = _mapper.Map<User, UserViewModel>(result);
            
            return Ok(viewModel);
        }

        /// <summary>
        /// Unsubscribe
        /// </summary>
        /// <returns></returns>
        [HttpDelete]
        public async Task<IActionResult> Delete(int serviceId, int userId)
        {
            var result = await _mediator.Send(new UnsubscribeFromServiceRequest(serviceId, userId));
            var viewModel = _mapper.Map<User, UserViewModel>(result);
            
            return Ok(viewModel);
        }
    }
}