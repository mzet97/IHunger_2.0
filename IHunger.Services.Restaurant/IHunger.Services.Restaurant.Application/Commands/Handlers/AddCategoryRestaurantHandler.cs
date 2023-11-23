using IHunger.Services.Restaurants.Core.Entities;
using IHunger.Services.Restaurants.Core.Repositories;
using IHunger.Services.Restaurants.Core.Validations;
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

            if (!Validator.Validate(new CategoryRestaurantValidation(), entity))
                throw new Exception("Erro");

            await _categoryRestaurantRepository.Add(entity);

            return entity.Id;
        }
    }
}
