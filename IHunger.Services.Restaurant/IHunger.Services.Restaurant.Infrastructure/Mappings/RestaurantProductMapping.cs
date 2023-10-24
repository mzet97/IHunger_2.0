using IHunger.Services.Restaurants.Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace IHunger.Services.Restaurants.Infrastructure.Mappings
{
    public class RestaurantProductMapping : IEntityTypeConfiguration<RestaurantProduct>
    {
        public void Configure(EntityTypeBuilder<RestaurantProduct> builder)
        {
            builder.HasKey(p => p.Id);

            builder.Property(c => c.IdRestaurant)
                .IsRequired();

            builder.Property(c => c.IdProduct)
                .IsRequired();

            builder.Property(p => p.CreatedAt)
                .IsRequired(true);

            builder.Property(p => p.UpdatedAt)
                .IsRequired(false);

            builder.Property(p => p.DeletedAt)
                .IsRequired(false);
        }
    }
}
