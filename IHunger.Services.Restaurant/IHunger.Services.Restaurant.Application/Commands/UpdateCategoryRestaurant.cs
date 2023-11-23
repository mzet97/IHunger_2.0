using IHunger.Services.Restaurants.Core.Entities;
using MediatR;

namespace IHunger.Services.Restaurants.Application.Commands
{
    public class UpdateCategoryRestaurant : IRequest<Guid>
    {
        public required Guid Id { get; set; }
        public required string Name { get; set; }
        public required string Description { get; set; }

        public CategoryRestaurant ToEntity()
        {
            return new CategoryRestaurant(Id, Name, Description);
        }
    }
}
