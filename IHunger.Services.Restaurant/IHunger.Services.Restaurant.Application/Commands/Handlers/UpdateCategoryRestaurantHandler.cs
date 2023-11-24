using IHunger.Services.Restaurants.Core.Events;
using IHunger.Services.Restaurants.Core.Repositories;
using IHunger.Services.Restaurants.Core.Validations;
using IHunger.Services.Restaurants.Infrastructure.MessageBus;
using MediatR;

namespace IHunger.Services.Restaurants.Application.Commands.Handlers
{
    public class UpdateCategoryRestaurantHandler : IRequestHandler<UpdateCategoryRestaurant, Guid>
    {
        private readonly ICategoryRestaurantRepository _categoryRestaurantRepository;

        private readonly IMessageBusClient _messageBus;

        public UpdateCategoryRestaurantHandler(
            ICategoryRestaurantRepository categoryRestaurantRepository,
            IMessageBusClient messageBus)
        {
            _categoryRestaurantRepository = categoryRestaurantRepository;
            _messageBus = messageBus;
        }

        public async Task<Guid> Handle(UpdateCategoryRestaurant request, CancellationToken cancellationToken)
        {
            var entity = await _categoryRestaurantRepository.GetById(request.Id);

            if(entity == null)
            {
                var noticiation = new NotificationError("Update CategoryRestaurant has error", "Update CategoryRestaurant has error");
                var routingKey = noticiation.GetType().Name.ToDashCase();

                _messageBus.Publish(noticiation, routingKey, "noticiation-service");

                throw new Exception("Find Error");
            }

            if (!Validator.Validate(new CategoryRestaurantValidation(), entity))
            {
                var noticiation = new NotificationError("Validate CategoryRestaurant has error", "Validate CategoryRestaurant has error");
                var routingKey = noticiation.GetType().Name.ToDashCase();

                _messageBus.Publish(noticiation, routingKey, "noticiation-service");

                throw new Exception("Validate Error");
            }

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
