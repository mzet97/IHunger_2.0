using IHunger.Services.Restaurants.Application.Dtos.ViewModels;
using IHunger.Services.Restaurants.Core.Repositories;
using MediatR;

namespace IHunger.Services.Restaurants.Application.Queries.Handlers
{
    public class GetByIdRestaurantHandler : IRequestHandler<GetByIdRestaurant, RestaurantViewModel>
    {
        private readonly IRestaurantRepository _restaurantRepository;

        public GetByIdRestaurantHandler(IRestaurantRepository restaurantRepository)
        {
            _restaurantRepository = restaurantRepository;
        }

        public async Task<RestaurantViewModel> Handle(GetByIdRestaurant request, CancellationToken cancellationToken)
        {
            var entity = await _restaurantRepository.GetById(request.Id);

            if (entity == null)
            {
                // Todo
                throw new ArgumentException("Null");
            }

            return RestaurantViewModel.FromEntity(entity);
        }
    }
}
