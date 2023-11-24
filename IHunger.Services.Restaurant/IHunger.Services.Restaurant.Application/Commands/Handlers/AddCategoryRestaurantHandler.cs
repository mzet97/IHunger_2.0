using IHunger.Services.Restaurants.Core.Entities;
using IHunger.Services.Restaurants.Core.Events;
using IHunger.Services.Restaurants.Core.Repositories;
using IHunger.Services.Restaurants.Core.Validations;
using IHunger.Services.Restaurants.Infrastructure.MessageBus;
using MediatR;

namespace IHunger.Services.Restaurants.Application.Commands.Handlers
{
    public class AddCategoryRestaurantHandler : IRequestHandler<AddCategoryRestaurant, Guid>
    {
        private readonly ICategoryRestaurantRepository _categoryRestaurantRepository;

        private readonly IMessageBusClient _messageBus;

        public AddCategoryRestaurantHandler(
            ICategoryRestaurantRepository categoryRestaurantRepository,
            IMessageBusClient messageBus)
        {
            _categoryRestaurantRepository = categoryRestaurantRepository;
            _messageBus = messageBus;
        }

        public async Task<Guid> Handle(AddCategoryRestaurant request, CancellationToken cancellationToken)
        {
            var entity = request.ToEntity();

            if (!Validator.Validate(new CategoryRestaurantValidation(), entity))
            {
                var noticiation = new NotificationError("Validate CategoryRestaurant has error", "Validate CategoryRestaurant has error");
                var routingKey = noticiation.GetType().Name.ToDashCase();

                _messageBus.Publish(noticiation, routingKey, "noticiation-service");

                throw new Exception("Validate Error");
            }

            await _categoryRestaurantRepository.Add(entity);

            return entity.Id;
        }
    }
}
