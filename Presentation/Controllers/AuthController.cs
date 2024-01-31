using Application.Features.UserFeatures.Register;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Presentation.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class AuthController(IMediator mediator) : ControllerBase
    {
        internal readonly IMediator _mediator = mediator;
        [HttpPost]
        [Route("[action]")]
        public async Task<IActionResult> RegisterUser([FromBody] RegisterUserRequest request, CancellationToken cancellationToken)
        {
            await _mediator.Send(request, cancellationToken);
            return Ok();
        }
    }
}
