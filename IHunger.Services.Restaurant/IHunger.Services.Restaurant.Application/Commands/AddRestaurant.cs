using IHunger.Services.Restaurants.Application.Dtos.InputModels;
using MediatR;

namespace IHunger.Services.Restaurants.Application.Commands
{
    public class AddRestaurant : IRequest<Guid>
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public string Image { get; set; }

        public Guid IdCategoryRestaurant { get; set; }

        public AddAddressRestaurant AddressRestaurant { get; set; }

    }
}
