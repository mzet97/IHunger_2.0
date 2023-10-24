using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IHunger.Services.Restaurants.Core.Entities
{
    public class CategoryRestaurant : AggregateRoot
    {
        public string Name { get; set; }
        public string Description { get; set; }

        public CategoryRestaurant()
        {
        }

        public CategoryRestaurant(Guid id, string name, string description)
        {
            Id = id;
            Name = name;
            Description = description;
        }

        public CategoryRestaurant(string name, string description)
        {
            Name = name;
            Description = description;
        }
    }
}
