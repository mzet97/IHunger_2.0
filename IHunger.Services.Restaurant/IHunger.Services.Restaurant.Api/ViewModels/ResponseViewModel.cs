namespace IHunger.Services.Restaurants.Api.ViewModels
{
    public class ResponseViewModel
    {

        public bool success { get; set; }
        public object data { get; set; }

        public ResponseViewModel()
        {

        }

        public ResponseViewModel(bool success, object data)
        {
            this.success = success;
            this.data = data;
        }
    }
}
