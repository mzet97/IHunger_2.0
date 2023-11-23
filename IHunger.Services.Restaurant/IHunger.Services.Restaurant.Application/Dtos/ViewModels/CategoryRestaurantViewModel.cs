using IHunger.Services.Restaurants.Core.Entities;

namespace IHunger.Services.Restaurants.Application.Dtos.ViewModels
{
    public class CategoryRestaurantViewModel : BaseViewModel
    {
        public string Name { get; set; }
        public string Description { get; set; }

        public CategoryRestaurantViewModel(
            Guid id,
            string name,
            string description,
            DateTime createdAt,
            DateTime? updatedAt,
            DateTime? deletedAt) : base(id, createdAt, updatedAt, deletedAt)
        {
            Name = name;
            Description = description;
        }

        public static CategoryRestaurantViewModel FromEntity(CategoryRestaurant entity)
        {
            return new CategoryRestaurantViewModel(
                entity.Id,
                entity.Name,
                entity.Description,
                entity.CreatedAt,
                entity.UpdatedAt,
                entity.DeletedAt);
        }
    }
}
