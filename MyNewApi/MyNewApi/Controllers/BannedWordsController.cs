using MediatR;
using Microsoft.AspNetCore.Mvc;
using MyNewApi.Application.Managements.AddBannedWord;
using MyNewApi.Application.Managements.DeleteBannedWord;
using MyNewApi.Application.Managements.GetAllBannedWords;

namespace MyNewApi.Controllers
{

    [ApiController]
    [Route("[controller]")]
    public class BannedWordsController(IMediator mediator) : ControllerBase
    {
        private readonly IMediator _mediator = mediator;

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var bannedWords = await _mediator.Send(new GetAllBannedWordsRequest());
            return Ok(bannedWords);
        }

        [HttpPost]
        public async Task<IActionResult> Add(AddBannedWordRequest request)
        {
            return Ok(await _mediator.Send(request));
        }

        [HttpDelete]
        [Route("{word}")]
        public async Task<IActionResult> Delete(string word)
        {
            await _mediator.Send(new DeleteBannedWordRequest() { Word = word });
            return Ok();
        }

    }
}
