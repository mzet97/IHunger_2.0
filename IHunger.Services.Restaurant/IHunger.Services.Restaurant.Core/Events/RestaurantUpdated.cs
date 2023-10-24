namespace IHunger.Services.Restaurants.Core.Events
{
    public class RestaurantUpdated : IDomainEvent
    {
        public Guid Id { get; private set; }
        public string Name { get; private set; }
        public string Description { get; private set; }
        public string Image { get; private set; }
        public Guid IdCategoryRestaurant { get; private set; }
        public Guid IdAddressRestaurant { get; private set; }
        public Address Address { get; private set; }

        public RestaurantUpdated(Guid id, string name, string description, string image, Guid idCategoryRestaurant, Guid idAddressRestaurant, Address address)
        {
            Id = id;
            Name = name;
            Description = description;
            Image = image;
            IdCategoryRestaurant = idCategoryRestaurant;
            IdAddressRestaurant = idAddressRestaurant;
            Address = address;
        }
    }
}
