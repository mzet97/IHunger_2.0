using IHunger.Services.Restaurants.Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using NodaTime;

namespace IHunger.Services.Restaurants.Infrastructure.Context
{
    public class RestaurantDbContext : DbContext
    {
        public RestaurantDbContext(DbContextOptions<RestaurantDbContext> options) : base(options)
        {
            AppContext.SetSwitch("Npgsql.EnableLegacyTimestampBehavior", true);
        }

        public DbSet<Restaurant> Restaurants { get; set; }
        public DbSet<CategoryRestaurant> CategoryRestaurants { get; set; }
        public DbSet<AddressRestaurant> AddressRestaurants { get; set; }
        public DbSet<RestaurantProduct> RestaurantProducts { get; set; }
        public DbSet<RestaurantComment> RestaurantComments { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.LogTo(Console.WriteLine);
            //optionsBuilder.UseLazyLoadingProxies();
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasDefaultSchema("public");
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(RestaurantDbContext).Assembly);

            foreach (var relationship in modelBuilder.Model.GetEntityTypes().SelectMany(e => e.GetForeignKeys())) relationship.DeleteBehavior = DeleteBehavior.ClientSetNull;

            base.OnModelCreating(modelBuilder);
        }

        protected override void ConfigureConventions(ModelConfigurationBuilder configurationBuilder)
        {
            base.ConfigureConventions(configurationBuilder);

            configurationBuilder.Properties<ZonedDateTime>(x => x.HaveConversion<ZonedDateTimeConverter>());
        }

        public override Task<int> SaveChangesAsync(CancellationToken cancellationToken = new CancellationToken())
        {
            foreach (var entry in ChangeTracker.Entries().Where(entry => entry.Entity.GetType().GetProperty("CreatedAt") != null))
            {
                if (entry.State == EntityState.Added)
                {
                    entry.Property("CreatedAt").CurrentValue = DateTime.Now;
                    entry.Property("UpdatedAt").CurrentValue = DateTime.Now;
                }

                if (entry.State == EntityState.Modified)
                {
                    entry.Property("UpdatedAt").CurrentValue = DateTime.Now;
                    entry.Property("CreatedAt").IsModified = false;
                }
            }

            return base.SaveChangesAsync(cancellationToken);
        }
    }

    internal class ZonedDateTimeConverter : ValueConverter<ZonedDateTime, LocalDateTime>
    {
        public ZonedDateTimeConverter() :
           base(v => v.WithZone(DateTimeZone.Utc).LocalDateTime, v => v.InUtc())
        {
        }
    }
}
