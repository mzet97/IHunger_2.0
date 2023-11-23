using MediatR;

namespace IHunger.Services.Restaurants.Application.Commands
{
    public class DeleteRestaurant : IRequest<Unit>
    {
        public DeleteRestaurant(Guid id)
        {
            Id = id;
        }

        public Guid Id { get; set; }
    }
}
