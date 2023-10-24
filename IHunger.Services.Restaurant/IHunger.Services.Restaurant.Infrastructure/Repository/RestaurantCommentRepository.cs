using IHunger.Services.Restaurants.Core.Entities;
using IHunger.Services.Restaurants.Core.Repositories;
using IHunger.Services.Restaurants.Infrastructure.Context;

namespace IHunger.Services.Restaurants.Infrastructure.Repository
{
    public class RestaurantCommentRepository : Repository<RestaurantComment>, IRestaurantCommentRepository
    {
        public RestaurantCommentRepository(RestaurantDbContext db) : base(db)
        {
        }
    }
}
