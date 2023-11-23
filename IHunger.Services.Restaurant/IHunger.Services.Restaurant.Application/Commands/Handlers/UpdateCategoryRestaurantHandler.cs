using IHunger.Services.Restaurants.Core.Repositories;
using IHunger.Services.Restaurants.Core.Validations;
using MediatR;

namespace IHunger.Services.Restaurants.Application.Commands.Handlers
{
    public class UpdateCategoryRestaurantHandler : IRequestHandler<UpdateCategoryRestaurant, Guid>
    {
        private readonly ICategoryRestaurantRepository _categoryRestaurantRepository;

        public UpdateCategoryRestaurantHandler(ICategoryRestaurantRepository categoryRestaurantRepository)
        {
            _categoryRestaurantRepository = categoryRestaurantRepository;
        }

        public async Task<Guid> Handle(UpdateCategoryRestaurant request, CancellationToken cancellationToken)
        {
            var entity = await _categoryRestaurantRepository.GetById(request.Id);

            if (!Validator.Validate(new CategoryRestaurantValidation(), entity))
                throw new Exception("Erro");

            if (request.Name != entity.Name && !string.IsNullOrEmpty(request.Name))
            {
                entity.Name = request.Name;
            }

            if (request.Description != entity.Description && !string.IsNullOrEmpty(request.Description))
            {
                entity.Description = request.Description;
            }

            await _categoryRestaurantRepository.Update(entity);

            return entity.Id;
        }
    }
}
