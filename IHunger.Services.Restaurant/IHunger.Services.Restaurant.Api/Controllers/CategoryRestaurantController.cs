using IHunger.Services.Restaurants.Application.Commands;
using IHunger.Services.Restaurants.Application.Queries;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace IHunger.Services.Restaurants.Api.Controllers
{
    [Route("api/restaurant/category-restaurant")]
    [ApiController]
    public class CategoryRestaurantController : MainController
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
                return CustomResponse(false, null);

            return CustomResponse(true, result);
        }

        [HttpGet]
        public async Task<IActionResult> Get([FromQuery] SearchCategoryRestaurant query)
        {
            var result = await _mediator.Send(query);

            if (result == null)
                return CustomResponse(false, null);

            return CustomResponse(true, result);
        }

        [HttpPost]
        public async Task<IActionResult> Post([FromBody] AddCategoryRestaurant command)
        {
            var id = await _mediator.Send(command);

            return await Get(id);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Put([FromBody] UpdateCategoryRestaurant command)
        {
            var result = await _mediator.Send(command);

            return await Get(result);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(Guid id)
        {
            var command = new DeleteRestaurant(id);

            var result = await _mediator.Send(command);

            return CustomResponse(true, result);
        }
    }
}
