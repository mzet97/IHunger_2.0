using IHunger.Services.Restaurants.Application.Dtos.ViewModels;
using MediatR;

namespace IHunger.Services.Restaurants.Application.Queries
{
    public class GetByIdRestaurant : IRequest<RestaurantViewModel>
    {
        public Guid Id { get; set; }

        public GetByIdRestaurant(Guid id)
        {
            Id = id;
        }
    }
}
