using IHunger.Services.Restaurants.Core.Entities;
using IHunger.Services.Restaurants.Core.Repositories;
using IHunger.Services.Restaurants.Infrastructure.Context;

namespace IHunger.Services.Restaurants.Infrastructure.Repositories
{
    public class RestaurantRepository : Repository<Restaurant>, IRestaurantRepository
    {
        public RestaurantRepository(RestaurantDbContext db) : base(db)
        {
        }
    }
}
