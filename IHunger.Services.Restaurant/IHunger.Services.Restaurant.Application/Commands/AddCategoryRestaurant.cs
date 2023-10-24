using IHunger.Services.Restaurants.Core.Entities;
using MediatR;

namespace IHunger.Services.Restaurants.Application.Commands
{
    public class AddCategoryRestaurant : IRequest<Guid>
    {
        public string Name { get; set; }
        public string Description { get; set; }

        public CategoryRestaurant ToEntity()
        {
            return new CategoryRestaurant(Name, Description);
        }
    }
}
