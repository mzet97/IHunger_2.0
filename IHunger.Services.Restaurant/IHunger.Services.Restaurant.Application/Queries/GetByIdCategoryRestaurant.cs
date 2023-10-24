using IHunger.Services.Restaurants.Application.Dtos.ViewModels;
using MediatR;

namespace IHunger.Services.Restaurants.Application.Queries
{
    public class GetByIdCategoryRestaurant : IRequest<CategoryRestaurantViewModel>
    {

        public Guid Id { get; set; }

        public GetByIdCategoryRestaurant(Guid id)
        {
            Id = id;
        }
    }
}
