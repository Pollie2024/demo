using Application.Activities;

using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BaseApiController : ControllerBase
    {

        [HttpGet] //api/activities

        public async Task<ActionResult<List<Domain.Activity>>> GetActivities(CancellationToken)
        {
            return await _mediator.Send(new List.Query());
        }

    }
}
