using IHunger.Services.Restaurants.Core.Repositories;
using MediatR;

namespace IHunger.Services.Restaurants.Application.Commands.Handlers
{
    public class AddCategoryRestaurantHandler : IRequestHandler<AddCategoryRestaurant, Guid>
    {
        private readonly ICategoryRestaurantRepository _categoryRestaurantRepository;

        public AddCategoryRestaurantHandler(ICategoryRestaurantRepository categoryRestaurantRepository)
        {
            _categoryRestaurantRepository = categoryRestaurantRepository;
        }

        public async Task<Guid> Handle(AddCategoryRestaurant request, CancellationToken cancellationToken)
        {
            var entity = request.ToEntity();

            await _categoryRestaurantRepository.Add(entity);

            return entity.Id;
        }
    }
}
