namespace IHunger.Services.Restaurants.Infrastructure.MessageBus
{
    public interface IMessageBusClient
    {
        void Publish(object message, string routingKey, string exchange);
    }
}
