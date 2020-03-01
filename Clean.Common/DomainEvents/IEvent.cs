namespace Clean.Common.DomainEvents
{
    public interface IEvent
    {
        /// <summary>
        /// Raises the event.
        /// </summary>
        void Raise();
    }
}