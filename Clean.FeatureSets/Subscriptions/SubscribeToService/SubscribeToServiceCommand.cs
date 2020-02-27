using System.Threading;
using System.Threading.Tasks;
using Clean.Core.DataAccess;
using Clean.Core.Domain;
using MediatR;

namespace Clean.FeatureSets.Subscriptions.SubscribeToService
{
    public class SubscribeToServiceCommand : IRequestHandler<SubscribeToServiceRequest, User>
    {
        private readonly IUserSubscriptionRepository _userSubscriptionRepository;
        private readonly IUserRepository _userRepository;

        public SubscribeToServiceCommand(
            IUserSubscriptionRepository userSubscriptionRepository, 
            IUserRepository userRepository
            )
        {
            _userSubscriptionRepository = userSubscriptionRepository;
            _userRepository = userRepository;
        }
        
        public Task<User> Handle(SubscribeToServiceRequest request, CancellationToken cancellationToken)
        {
            var (userId, serviceId) = request;
            
            _userSubscriptionRepository.Subscribe(userId, serviceId);
            var user = _userRepository.Get(userId);
            
            return Task.FromResult(user);
        }
    }
}