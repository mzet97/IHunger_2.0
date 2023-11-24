
using IHunger.Services.Restaurants.Core.Entities;

namespace IHunger.Services.Restaurants.Application.Dtos.ViewModels
{
    public class RestaurantViewModel : BaseViewModel
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public string Image { get; set; }

        public RestaurantViewModel(
            Guid id,
            string name,
            string description,
            string image,
            DateTime createdAt,
            DateTime? updatedAt,
            DateTime? deletedAt
            ) : base(id, createdAt, updatedAt, deletedAt)
        {
            Name = name;
            Description = description;
            Image = image;
        }

        public static RestaurantViewModel FromEntity(Restaurant entity)
        {
            return new RestaurantViewModel(
                entity.Id,
                entity.Name,
                entity.Description,
                entity.Image,
                entity.CreatedAt,
                entity.UpdatedAt,
                entity.DeletedAt);
        }
    }
}
