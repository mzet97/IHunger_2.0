using IHunger.Services.Restaurants.Core.Repositories;
using IHunger.Services.Restaurants.Infrastructure.Context;
using IHunger.Services.Restaurants.Infrastructure.Extensions;
using IHunger.Services.Restaurants.Infrastructure.MessageBus;
using IHunger.Services.Restaurants.Infrastructure.Repository;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;
using RabbitMQ.Client;
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

        public static IServiceCollection AddMessageBus(this IServiceCollection services, IConfiguration configuration)
        {
            var connectionFactory = new ConnectionFactory();

            var rabbitMqSection = configuration.GetSection("RabbitMq");
            services.Configure<RabbitMq>(rabbitMqSection);
            var rabbitMq = rabbitMqSection.Get<RabbitMq>();
            
            if(rabbitMq == null)
            {
                throw new ArgumentNullException("RabbitMq configuration is missing");
            }

            connectionFactory.HostName = rabbitMq.Host;
            connectionFactory.Port = rabbitMq.Port;
            connectionFactory.UserName = rabbitMq.Username;
            connectionFactory.Password = rabbitMq.Password;

            var connection = connectionFactory.CreateConnection("restaurant-producer");

            services.AddSingleton(new ProducerConnection(connection));
            services.AddSingleton<IMessageBusClient, RabbitMqClient>();

            return services;
        }
    }


}
