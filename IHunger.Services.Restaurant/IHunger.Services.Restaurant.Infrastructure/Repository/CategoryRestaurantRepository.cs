using IHunger.Services.Restaurants.Core.Entities;
using IHunger.Services.Restaurants.Core.Repositories;
using IHunger.Services.Restaurants.Infrastructure.Context;

namespace IHunger.Services.Restaurants.Infrastructure.Repository
{
    public class CategoryRestaurantRepository : Repository<CategoryRestaurant>, ICategoryRestaurantRepository
    {
        public CategoryRestaurantRepository(RestaurantDbContext db) : base(db)
        {
        }
    }
}
