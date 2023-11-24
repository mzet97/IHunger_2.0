using IHunger.Services.Restaurants.Core.Events;

namespace IHunger.Services.Restaurants.Core.Entities
{
    public class Restaurant : AggregateRoot
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public string Image { get; set; }

        public virtual IEnumerable<RestaurantProduct>? Products { get; set; }
        public virtual IEnumerable<RestaurantComment>? Comments { get; set; }

        public Guid IdCategoryRestaurant { get; set; }
        public virtual CategoryRestaurant CategoryRestaurant { get; set; }

        public Guid IdAddressRestaurant { get; set; }
        public virtual AddressRestaurant AddressRestaurant { get; set; }

        public Restaurant(){}

        public Restaurant(
            Guid id,
            string name,
            string description,
            string image,
            AddressRestaurant addressRestaurant,
            CategoryRestaurant categoryRestaurant)
        {
            Id = id;
            Name = name;
            Description = description;
            Image = image;
            AddressRestaurant = addressRestaurant;
            CategoryRestaurant = categoryRestaurant;
        }

        public static Restaurant Create(
            string name,
            string description,
            string image,
            Guid idCategoryRestaurant,
            AddressRestaurant addressRestaurant,
            CategoryRestaurant categoryRestaurant)
        {
            var restaurant = new Restaurant(Guid.NewGuid(), name, description, image, addressRestaurant, categoryRestaurant);

            restaurant.AddEvent(new RestaurantCreated(restaurant.Id, restaurant.Name, restaurant.Description, restaurant.Image, idCategoryRestaurant, addressRestaurant.ToDomainEvent()));

            return restaurant;
        }

        public void Update(
            Guid id, string name, string description, string image, 
            Guid idCategoryRestaurant, Guid idAddressRestaurant, 
            AddressRestaurant addressRestaurant, CategoryRestaurant categoryRestaurant)
        {
            Name = name;
            Description = description;
            Image = image;
            IdCategoryRestaurant = idCategoryRestaurant;
            IdAddressRestaurant = idAddressRestaurant;
            AddressRestaurant = addressRestaurant;
            CategoryRestaurant = categoryRestaurant;

            AddEvent(new RestaurantUpdated(Id, Name, Description, Image, IdCategoryRestaurant, IdAddressRestaurant, addressRestaurant.ToDomainEvent()));
        }
    }
}
