using IHunger.Services.Restaurants.Core.Repositories;
using IHunger.Services.Restaurants.Infrastructure.Context;
using IHunger.Services.Restaurants.Infrastructure.Repository;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IHunger.Services.Restaurants.Infrastructure.Configuration
{
    public static class DependencyInjectionConfig
    {
        public static IServiceCollection ResolveDependencies(this IServiceCollection services)
        {
            services.AddScoped<RestaurantDbContext>();

            #region Repository
            services.AddScoped<IAddressRestaurantRepository, AddressRestaurantRepository>();
            services.AddScoped<ICategoryRestaurantRepository, CategoryRestaurantRepository>();
            services.AddScoped<IRestaurantCommentRepository, RestaurantCommentRepository>();
            services.AddScoped<IRestaurantProductRepository, RestaurantProductRepository>();
            services.AddScoped<IRestaurantRepository, RestaurantRepository>();

            #endregion

            return services;
        }
    }
}
