using IHunger.Services.Restaurants.Core.Events;

namespace IHunger.Services.Restaurants.Core.Entities
{
    public class AggregateRoot : IEntityBase
    {
        public Guid Id { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime? UpdatedAt { get; set; }
        public DateTime? DeletedAt { get; set; }

        private List<IDomainEvent> _events = new List<IDomainEvent>();

        protected void AddEvent(IDomainEvent @event)
        {
            if (_events == null)
                _events = new List<IDomainEvent>();

            _events.Add(@event);
        }
    }
}
