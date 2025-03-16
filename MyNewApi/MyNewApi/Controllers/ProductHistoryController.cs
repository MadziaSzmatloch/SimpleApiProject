using MediatR;
using Microsoft.AspNetCore.Mvc;
using MyNewApi.Application.Managements.GetAllProductHistory;

namespace MyNewApi.Controllers
{

    [ApiController]
    [Route("[controller]")]
    public class ProductHistoryController(IMediator mediator) : ControllerBase
    {
        private readonly IMediator _mediator = mediator;

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var histories = await _mediator.Send(new GetAllProductHistoryRequest());
            return Ok(histories);
        }
    }
}
