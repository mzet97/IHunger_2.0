namespace IHunger.Services.Restaurants.Core.Entities
{
    public class RestaurantComment : AggregateRoot
    {
        public Guid IdRestaurant { get; set; }
        public Restaurant Restaurant { get; set; }
        public Guid IdComment { get; set; }

        public RestaurantComment()
        {
            
        }

        public RestaurantComment(Guid id, Guid idRestaurantEntity, Restaurant restaurant, Guid idComment)
        {
            Id = id;
            IdRestaurant = idRestaurantEntity;
            Restaurant = restaurant;
            IdComment = idComment;
        }
    }
}
