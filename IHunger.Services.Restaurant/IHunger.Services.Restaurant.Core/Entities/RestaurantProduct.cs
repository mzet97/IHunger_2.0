namespace IHunger.Services.Restaurants.Core.Entities
{
    public class RestaurantProduct : AggregateRoot
    {
        public Guid IdRestaurant { get; set; }
        public Restaurant Restaurant { get; set; }
        public Guid IdProduct { get; set; }

        public RestaurantProduct()
        {
            
        }

        public RestaurantProduct(Guid id, Guid idRestaurantEntity, Restaurant restaurant, Guid idProduct)
        {
            Id = id;
            IdRestaurant = idRestaurantEntity;
            Restaurant = restaurant;
            IdProduct = idProduct;
        }
    }
}
