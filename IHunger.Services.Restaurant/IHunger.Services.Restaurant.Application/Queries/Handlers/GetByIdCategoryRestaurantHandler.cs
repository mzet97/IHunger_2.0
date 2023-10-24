using IHunger.Services.Restaurants.Application.Dtos.ViewModels;
using IHunger.Services.Restaurants.Core.Repositories;
using MediatR;

namespace IHunger.Services.Restaurants.Application.Queries.Handlers
{
    public class GetByIdCategoryRestaurantHandler : IRequestHandler<GetByIdCategoryRestaurant, CategoryRestaurantViewModel>
    {
        private readonly ICategoryRestaurantRepository _categoryRestaurantRepository;

        public GetByIdCategoryRestaurantHandler(ICategoryRestaurantRepository categoryRestaurantRepository)
        {
            _categoryRestaurantRepository = categoryRestaurantRepository;
        }

        public async Task<CategoryRestaurantViewModel> Handle(GetByIdCategoryRestaurant request, CancellationToken cancellationToken)
        {
            var entity = await _categoryRestaurantRepository.GetById(request.Id);

            if (entity == null)
            {
                // Todo
                throw new ArgumentException("Null");
            }

            return CategoryRestaurantViewModel.FromEntity(entity);
        }
    }
}
