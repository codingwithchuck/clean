namespace Clean.Core.DomainEvents
{
    public interface IEvent
    {
        /// <summary>
        /// Raises the event.
        /// </summary>
        void Raise();
    }
}