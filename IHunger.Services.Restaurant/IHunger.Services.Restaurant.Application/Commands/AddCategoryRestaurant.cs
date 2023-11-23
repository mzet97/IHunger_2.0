using IHunger.Services.Restaurants.Core.Entities;
using MediatR;

namespace IHunger.Services.Restaurants.Application.Commands
{
    public class AddCategoryRestaurant : IRequest<Guid>
    {
        public required string Name { get; set; }
        public required string Description { get; set; }

        public CategoryRestaurant ToEntity()
        {
            return new CategoryRestaurant(Name, Description);
        }
    }
}
