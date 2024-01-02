using IHunger.Services.Restaurants.Application.Dtos.ViewModels;
using IHunger.Services.Restaurants.Core.Models;
using MediatR;

namespace IHunger.Services.Restaurants.Application.Queries
{
    public class SearchCategoryRestaurant : BaseSearch, IRequest<BaseResult<CategoryRestaurantViewModel>>
    {
        
        public string? Name { get; set; }
        public string? Description { get; set; }

    }
}
