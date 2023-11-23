using IHunger.Services.Restaurants.Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace IHunger.Services.Restaurants.Infrastructure.Mappings
{
    public class CategoryRestaurantMapping : IEntityTypeConfiguration<CategoryRestaurant>
    {
        public void Configure(EntityTypeBuilder<CategoryRestaurant> builder)
        {
            builder.HasKey(p => p.Id);

            builder.Property(c => c.Description)
                .IsRequired()
                .HasColumnType("varchar(200)");

            builder.Property(c => c.Name)
                .IsRequired()
                .HasColumnType("varchar(50)");
        }
    }
}
