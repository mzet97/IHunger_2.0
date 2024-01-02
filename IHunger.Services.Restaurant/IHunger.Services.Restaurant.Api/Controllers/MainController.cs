using Microsoft.AspNetCore.Mvc;

namespace IHunger.Services.Restaurants.Api.Controllers
{
    [ApiController]
    public class MainController : ControllerBase
    {
        protected IActionResult CustomResponse(bool success, object? result = null)
        {
            if(success)
            {
                return Ok(result);

            }

            return BadRequest(result);
        }
    }
}
