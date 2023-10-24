using IHunger.Services.Restaurants.Infrastructure.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace IHunger.Services.Restaurants.Infrastructure.Configuration
{
    public static class DbContextConfig
    {
        public static IServiceCollection AddDbContextConfig(this IServiceCollection services,
           IConfiguration configuration)
        {

            services.AddDbContext<RestaurantDbContext>(options =>
            {
                //options.UseLazyLoadingProxies();
                options.UseNpgsql(configuration.GetConnectionString("DefaultConnection"));
                options.EnableSensitiveDataLogging(true);
            });

            return services;
        }
    }
}
