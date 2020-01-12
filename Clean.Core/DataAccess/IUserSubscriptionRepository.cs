namespace Clean.Core.DataAccess
{
    public interface IUserSubscriptionRepository
    {
        void Subscribe(int userId, int serviceId);

        void Unsubscribe(int userId, int serviceId);
    }
}