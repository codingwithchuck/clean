using System.Collections.Generic;

namespace Clean.Common.DomainEvents
{
    public class DomainEventProcessor
    {
        /// <summary>
        /// Raises all the events on IDomainEvent interface
        /// </summary>
        /// <param name="entity"></param>
        public static void Raise(IDomainEvent entity)
        {
            // guard against a null entity
            var events = entity?.Events ?? new List<IEvent>();

            foreach (var @event in events)
            {
                @event.Raise();
            }
        }
    }
}