using IHunger.Services.Restaurants.Application.Dtos.ViewModels;
using MediatR;

namespace IHunger.Services.Restaurants.Application.Queries
{
    public class SearchCategoryRestaurant : BaseSearch, IRequest<List<CategoryRestaurantViewModel>>
    {
        
        public string? Name { get; set; }
        public string? Description { get; set; }

    }
}
