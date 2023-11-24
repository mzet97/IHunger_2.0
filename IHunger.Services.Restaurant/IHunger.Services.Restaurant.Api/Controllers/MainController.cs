using IHunger.Services.Restaurants.Api.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;

namespace IHunger.Services.Restaurants.Api.Controllers
{
    [ApiController]
    public class MainController : ControllerBase
    {
        protected IActionResult CustomResponse(bool success, object? result = null)
        {
            if(success)
            {
                return Ok(new ResponseViewModel(true, result));

            }

            return BadRequest(new ResponseViewModel(false, result));
        }
    }
}
