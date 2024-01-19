using MediatR;

namespace IHunger.Services.Restaurants.Application.Commands
{
    public class DeleteCategoryRestaurant : IRequest<Unit>
    {
        public DeleteCategoryRestaurant(Guid id)
        {
            Id = id;
        }

        public Guid Id { get; set; }
    }
}
