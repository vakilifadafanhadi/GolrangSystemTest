using Application.Features.DiscountFeature.Create;
using Application.Features.DiscountFeature.Delete;
using Application.Features.DiscountFeature.Paginate;
using Application.Features.DiscountFeature.Update;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Presentation.Controllers
{
    [Route("[controller]")]
    [ApiController]
    [Authorize]
    public class DiscountController(IMediator mediator) : ControllerBase
    {
        private readonly IMediator _mediator = mediator;
        [HttpPost]
        [Route("[action]")]
        public async Task<IActionResult> CreateAsync([FromBody] CreateDiscountRequest request, CancellationToken cancellationToken)
        {
            await _mediator.Send(request, cancellationToken);
            return Ok();
        }
        [HttpPost]
        [Route("[action]")]
        public async Task<IActionResult> UpdateAsync([FromBody] UpdateDiscountRequest request, CancellationToken cancellationToken)
        {
            await _mediator.Send(request, cancellationToken);
            return Ok();
        }
        [HttpGet]
        [Route("[action]/{id}")]
        public async Task<IActionResult> DeleteAsync([FromRoute] Guid id, CancellationToken cancellationToken)
        {
            await _mediator.Send(new DeleteDiscountRequest(id), cancellationToken);
            return Ok();
        }
        [HttpGet]
        [Route("[action]/{take}/{page}")]
        public async Task<IActionResult> PaginateAsync([FromRoute] int take, [FromRoute] int page, CancellationToken cancellationToken)
        {
            var result = await _mediator.Send(new PaginateDiscountRequest(take, page), cancellationToken);
            return Ok(result);
        }
    }
}
