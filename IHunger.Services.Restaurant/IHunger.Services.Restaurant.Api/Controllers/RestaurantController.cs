using IHunger.Services.Restaurants.Application.Commands;
using IHunger.Services.Restaurants.Application.Queries;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace IHunger.Services.Restaurants.Api.Controllers
{
    [Route("api/restaurant")]
    [ApiController]
    public class RestaurantController : MainController
    {
        private readonly IMediator _mediator;

        public RestaurantController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> Get(Guid id)
        {
            var query = new GetByIdRestaurant(id);

            var result = await _mediator.Send(query);

            if (result == null)
                return CustomResponse(false, null);

            return CustomResponse(true, result);
        }

        [HttpPost]
        public async Task<IActionResult> Post([FromBody] AddRestaurant command)
        {
            var id = await _mediator.Send(command);

            return await Get(id);
        }
    }
}
