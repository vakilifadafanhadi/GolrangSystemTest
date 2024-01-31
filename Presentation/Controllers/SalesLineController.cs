using Application.Features.SalesLineFeature.Create;
using Application.Features.UserFeatures.AssignToSalesLine;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Presentation.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class SalesLineController(IMediator mediator) : ControllerBase
    {
        private readonly IMediator _mediator = mediator;
        [HttpGet]
        [Route("[action]/{title}")]
        public async Task<IActionResult> Create([FromRoute] string title, CancellationToken cancellationToken)
        {
            await _mediator.Send(new CreateSalesLineRequest(title), cancellationToken);
            return Ok();
        }
        [HttpGet]
        [Route("[action]/{salesLineId}/{sellerId}")]
        public async Task<IActionResult> AssignToSeller([FromRoute] Guid salesLineId, [FromRoute] Guid sellerId, CancellationToken cancellationToken)
        {
            await _mediator.Send(new AssignToSalesLineRequest(sellerId, salesLineId), cancellationToken);
            return Ok();
        }
    }
}
