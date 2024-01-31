using Application.Features.PreFactorDetailFeature.Create;
using Application.Features.PreFactorDetailFeature.Delete;
using Application.Features.PreFactorDetailFeature.Paginate;
using Application.Features.PreFactorDetailFeature.Update;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Presentation.Controllers
{
    [Route("[controller]")]
    [ApiController]
    [Authorize]
    public class PreFactorDetailController(IMediator mediator) : ControllerBase
    {
        private readonly IMediator _mediator = mediator;
        [HttpPost]
        [Route("[action]")]
        public async Task<IActionResult> CreateAsync([FromBody] CreatePreFactorDetailRequest request, CancellationToken cancellationToken)
        {
            await _mediator.Send(request, cancellationToken);
            return Ok();
        }
        [HttpPost]
        [Route("[action]")]
        public async Task<IActionResult> UpdateAsync([FromBody] UpdatePreFactorDetailRequest request, CancellationToken cancellationToken)
        {
            await _mediator.Send(request, cancellationToken);
            return Ok();
        }
        [HttpGet]
        [Route("[action]/{id}")]
        public async Task<IActionResult> DeleteAsync([FromRoute] Guid id, CancellationToken cancellationToken)
        {
            await _mediator.Send(new DeletePreFactorDetailRequest(id), cancellationToken);
            return Ok();
        }
        [HttpGet]
        [Route("[action]/{take}/{page}")]
        public async Task<IActionResult> PaginateAsync([FromRoute] int take, [FromRoute] int page, CancellationToken cancellationToken)
        {
            var result = await _mediator.Send(new PaginatePreFactorDetailRequest(take, page), cancellationToken);
            return Ok(result);
        }
    }
}
