using BestNews.Application.DTO.Item;
using BestNews.Application.Features.Stories.Requests.Queries;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace BestNews.API.Controllers
{
    [Route("api/best-stories")]
    [ApiController]
    public class BestStoriesController : ControllerBase
    {
        private readonly IMediator _mediator;
        public BestStoriesController(IMediator mediator)
        {
            _mediator = mediator;
        }

        // GET api/<BestStoriesController>/5
        [HttpGet("{count}")]
        public async Task<ActionResult<List<StoryDto>>> Get(int count)
        {
            var stories = await _mediator.Send(new GetStoriesListByCountRequest { Count = count});
            return Ok(stories);
        }
    }
}
