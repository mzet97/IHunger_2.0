
namespace IHunger.Services.Restaurants.Application.Dtos.ViewModels
{
    public class RestaurantViewModel : BaseViewModel
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public string Image { get; set; }

        public RestaurantViewModel(Guid id, DateTime createdAt, DateTime? updatedAt, DateTime? deletedAt, string name, string description, string image) : base(id, createdAt, updatedAt, deletedAt)
        {
            Name = name;
            Description = description;
            Image = image;
        }
    }
}
