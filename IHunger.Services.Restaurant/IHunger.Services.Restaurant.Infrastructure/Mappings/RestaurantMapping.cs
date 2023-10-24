using IHunger.Services.Restaurants.Core.Entities;
using Microsoft.EntityFrameworkCore;
using System.Reflection.Emit;
using System.Reflection.Metadata;

namespace IHunger.Services.Restaurants.Infrastructure.Mappings
{
    public class RestaurantMapping : IEntityTypeConfiguration<Restaurant>
    {
        public void Configure(Microsoft.EntityFrameworkCore.Metadata.Builders.EntityTypeBuilder<Restaurant> builder)
        {
            builder.HasKey(r => r.Id);

            builder.Property(r => r.Name)
                .IsRequired()
                .HasColumnType("varchar(50)");

            builder.Property(r => r.Description)
               .IsRequired()
               .HasColumnType("varchar(200)");

            builder.Property(r => r.Image)
               .IsRequired()
               .HasColumnType("varchar(10000)");

            builder.Property(p => p.CreatedAt)
                .IsRequired(true);

            builder.Property(p => p.UpdatedAt)
                .IsRequired(false);

            builder.Property(p => p.DeletedAt)
                .IsRequired(false);


            builder.Property(x => x.IdAddressRestaurant).IsRequired();
            builder.HasOne(x => x.AddressRestaurant).WithMany().HasForeignKey(x => x.IdAddressRestaurant);

            builder.Property(x => x.IdCategoryRestaurant).IsRequired();
            builder.HasOne(x => x.CategoryRestaurant).WithMany().HasForeignKey(x => x.IdCategoryRestaurant);


            builder
                .HasMany(e => e.Products)
                .WithOne(e => e.Restaurant)
                .HasForeignKey(e => e.IdRestaurant)
                .IsRequired(false);

            builder
                .HasMany(e => e.Comments)
                .WithOne(e => e.Restaurant)
                .HasForeignKey(e => e.IdRestaurant)
                .IsRequired(false);


        }
    }
}
