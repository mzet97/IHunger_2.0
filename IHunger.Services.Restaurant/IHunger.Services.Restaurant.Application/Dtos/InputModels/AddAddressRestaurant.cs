namespace IHunger.Services.Restaurants.Application.Dtos.InputModels
{
    public class AddAddressRestaurant
    {
        public string Street { get; set; }
        public string Number { get; set; }
        public string District { get; set; }
        public string City { get; set; }
        public string County { get; set; }
        public string ZipCode { get; set; }
        public string Latitude { get; set; }
        public string Longitude { get; set; }
    }
}
