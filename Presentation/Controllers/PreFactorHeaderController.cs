using Application.Features.PreFactorHeaderFeature.Create;
using Application.Features.PreFactorHeaderFeature.Delete;
using Application.Features.PreFactorHeaderFeature.Paginate;
using Application.Features.PreFactorHeaderFeature.Update;
using Mapster;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Presentation.Controllers
{
    [Route("[controller]")]
    [ApiController]
    [Authorize]
    public class PreFactorHeaderController(IMediator mediator) : BaseController
    {
        private readonly IMediator _mediator = mediator;
        [HttpGet]
        [Route("[action]/{salesLineId}/{customerId}")]
        public async Task<IActionResult> CreateAsync([FromRoute] Guid salesLineId, [FromRoute] Guid customerId, CancellationToken cancellationToken)
        {
            var userId = GetUserId();
            await _mediator.Send(new CreatePreFactorHeaderRequest(salesLineId, customerId, userId), cancellationToken);
            return Ok();
        }
        [HttpPost]
        [Route("[action]")]
        public async Task<IActionResult> UpdateAsync([FromBody] UpdatePreFactorHeaderDto request, CancellationToken cancellationToken)
        {
            var userId = GetUserId();
            var req = request.Adapt<UpdatePreFactorHeaderRequest>();
            await _mediator.Send(req with { SellerId = userId }, cancellationToken);
            return Ok();
        }
        [HttpGet]
        [Route("[action]/{id}")]
        public async Task<IActionResult> DeleteAsync([FromRoute] Guid id, CancellationToken cancellationToken)
        {
            await _mediator.Send(new DeletePreFactorHeaderRequest(id), cancellationToken);
            return Ok();
        }
        [HttpGet]
        [Route("[action]/{take}/{page}")]
        public async Task<IActionResult> PaginateAsync([FromRoute] int take, [FromRoute] int page, CancellationToken cancellationToken)
        {
            var result = await _mediator.Send(new PaginatePreFactorHeaderRequest(take, page), cancellationToken);
            return Ok(result);
        }
    }
    public sealed record UpdatePreFactorHeaderDto(
        Guid Id,
        Guid SalesLineId,
        Guid SellerId,
        Guid CustomerId,
        byte Status
        );
}
