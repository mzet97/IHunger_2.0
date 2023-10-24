using IHunger.Services.Restaurants.Core.Events;

namespace IHunger.Services.Restaurants.Core.Entities
{
    public class AddressRestaurant : AggregateRoot
    {
        public string Street { get; set; }
        public string Number { get; set; }
        public string District { get; set; }
        public string City { get; set; }
        public string County { get; set; }
        public string ZipCode { get; set; }
        public string Latitude { get; set; }
        public string Longitude { get; set; }

        public AddressRestaurant()
        {
            
        }

        public AddressRestaurant(Guid id, string street, string number, string district, string city, string county, string zipCode, string latitude, string longitude)
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

        public bool Equals(AddressRestaurant other)
        {
            return Street.Equals(other.Street, StringComparison.OrdinalIgnoreCase) &&
                Number.Equals(other.Number, StringComparison.OrdinalIgnoreCase) &&
                District.Equals(other.District, StringComparison.OrdinalIgnoreCase) &&
                City.Equals(other.City, StringComparison.OrdinalIgnoreCase) &&
                County.Equals(other.County, StringComparison.OrdinalIgnoreCase) &&
                ZipCode.Equals(other.ZipCode, StringComparison.OrdinalIgnoreCase) &&
                Latitude.Equals(other.Latitude, StringComparison.OrdinalIgnoreCase) &&
                Longitude.Equals(other.Longitude, StringComparison.OrdinalIgnoreCase) && Id == other.Id;
        }

        public override bool Equals(object? obj)
        {
            return obj is AddressRestaurant addressRestaurant && Equals(obj);
        }

        public override int GetHashCode()
        {
            HashCode hash = new HashCode();
            hash.Add(Id);
            hash.Add(Street);
            hash.Add(Number);
            hash.Add(District);
            hash.Add(City);
            hash.Add(County);
            hash.Add(ZipCode);
            hash.Add(Latitude);
            hash.Add(Longitude);
            return hash.ToHashCode();
        }

        public Address ToDomainEvent()
        {
            var adress = new Address(Id, Street, Number, District, City, County, ZipCode, Latitude, Longitude);

            return adress;
        }
    }
}
