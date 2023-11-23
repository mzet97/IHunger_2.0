using IHunger.Services.Restaurants.Core.Repositories;
using MediatR;

namespace IHunger.Services.Restaurants.Application.Commands.Handlers
{
    public class DeleteRestaurantHandler : IRequestHandler<DeleteRestaurant, Unit>
    {
        private readonly ICategoryRestaurantRepository _categoryRestaurantRepository;

        public DeleteRestaurantHandler(ICategoryRestaurantRepository categoryRestaurantRepository)
        {
            _categoryRestaurantRepository = categoryRestaurantRepository;
        }

        public async Task<Unit> Handle(DeleteRestaurant request, CancellationToken cancellationToken)
        {
            var entity = await _categoryRestaurantRepository.GetById(request.Id);

            if(entity == null)
            {
                // Todo
                throw new ArgumentException("Null");
            }

            await _categoryRestaurantRepository.Remove(entity.Id);

            return Unit.Value;
        }
    }
}
