namespace IHunger.Services.Restaurants.Core.Events
{
    public class RestaurantCreated : IDomainEvent
    {
        public Guid Id { get; private set; }
        public string Name { get; private set; }
        public string Description { get; private set; }
        public string Image { get; private set; }
        public Guid IdCategoryRestaurant { get; private set; }
        public Address Address { get; private set; }

        public RestaurantCreated(Guid id, string name, string description, string image, Guid idCategoryRestaurant, Address address)
        {
            Id = id;
            Name = name;
            Description = description;
            Image = image;
            IdCategoryRestaurant = idCategoryRestaurant;
            Address = address;
        }
    }

    public class Address
    {
        public Guid Id { get; private set; }
        public string Street { get; private set; }
        public string Number { get; private set; }
        public string District { get; private set; }
        public string City { get; private set; }
        public string County { get; private set; }
        public string ZipCode { get; private set; }
        public string Latitude { get; private set; }
        public string Longitude { get; private set; }

        public Address(Guid id, string street, string number, string district, string city, string county, string zipCode, string latitude, string longitude)
        {
            Id = id;
            Street = street;
            Number = number;
            District = district;
            City = city;
            County = county;
            ZipCode = zipCode;
            Latitude = latitude;
            Longitude = longitude;
        }

        public static Address Create(Guid id, string street, string number, string district, 
            string city, string county, string zipCode, string latitude, string longitude)
        {
            var address = new Address(Guid.NewGuid(), street, number, district,
                city, county, zipCode, latitude, longitude);

            return address;
        }
    }
}
