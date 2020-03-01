using System.Collections.Generic;

namespace Clean.Common.DomainEvents
{
    /// <summary>
    /// Adds Domain events to entity. When adding and removing events, prefer the event collection.
    /// </summary>
    public interface IDomainEvent
    {
        /// <summary>
        /// Event collection for domain events.
        /// </summary>
        ICollection<IEvent> Events { get; set; }
    }
}