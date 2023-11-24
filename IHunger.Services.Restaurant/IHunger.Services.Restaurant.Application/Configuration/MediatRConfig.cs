using IHunger.Services.Restaurants.Application.Commands;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IHunger.Services.Restaurants.Application.Configuration
{
    public static class MediatRConfig
    {
        public static IServiceCollection AddHandlers(this IServiceCollection services)
        {
            services.AddMediatR(cfg => cfg.RegisterServicesFromAssembly(typeof(AddCategoryRestaurant).Assembly));

            return services;
        }
    }
}
