using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IHunger.Services.Restaurants.Core.Events
{
    public class NotificationError : IDomainEvent
    {
        public string EventName { get; set; }
        public string Description { get; set; }

        public NotificationError() { }

        public NotificationError(string eventName, string description)
        {
            EventName = eventName;
            Description = description;
        }
    }
}
