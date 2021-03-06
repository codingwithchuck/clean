using System.Collections.Generic;

namespace Clean.Common.DomainEvents
{
    public static class DomainEventExtensions
    {
        /// <summary>
        /// Add a domain event to the entity.
        /// </summary>
        /// <param name="entity"></param>
        /// <param name="event"></param>
        public static void AddEvent(this IDomainEvent entity, IEvent @event)
        {
            if (entity != null)
            {
                if (entity.Events is null)
                {
                    entity.Events = new List<IEvent>();
                }

                entity.Events.Add(@event);
            }
        }

        /// <summary>
        /// Clears all the domain events from the entity
        /// </summary>
        /// <param name="entity"></param>
        public static void ClearEvents(this IDomainEvent entity)
        {
            entity?.Events?.Clear();
        }
        
        /// <summary>
        /// Raises all the events in the Event collection.  
        /// </summary>
        /// <param name="entity"></param>
        public static void RaiseEvents(this IDomainEvent entity)
        {
            DomainEventProcessor.Raise(entity);
        }

        /// <summary>
        /// Removes a single domain event
        /// </summary>
        /// <param name="entity"></param>
        /// <param name="event"></param>
        public static void RemoveEvent(this IDomainEvent entity, IEvent @event)
        {
            entity?.Events?.Remove(@event);
        }
    }
}