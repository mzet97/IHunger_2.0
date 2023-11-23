using IHunger.Services.Restaurants.Application.Commands;
using IHunger.Services.Restaurants.Application.Queries;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace IHunger.Services.Restaurants.Api.Controllers
{
    [Route("api/restaurant/category-restaurant")]
    [ApiController]
    public class CategoryRestaurantController : ControllerBase
    {
        private readonly IMediator _mediator;

        public CategoryRestaurantController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> Get(Guid id)
        {
            var query = new GetByIdCategoryRestaurant(id);

            var result = await _mediator.Send(query);

            if (result == null)
                return NotFound();

            return Ok(result);
        }

        [HttpGet]
        public async Task<IActionResult> Get([FromQuery] SearchCategoryRestaurant query)
        {
            var result = await _mediator.Send(query);

            if (result == null)
                return NotFound();

            return Ok(result);
        }

        [HttpPost]
        public async Task<IActionResult> Post([FromBody] AddCategoryRestaurant command)
        {
            var id = await _mediator.Send(command);

            return await Get(id);
        }


    }
}
