using MediatR;

namespace Application.Features.PreFactorHeaderFeature.Update
{
    public sealed record UpdatePreFactorHeaderRequest(
        Guid Id,
        Guid SalesLineId,
        Guid SellerId,
        Guid UserId,
        Guid CustomerId,
        byte Status) : 
        IRequest<UpdatePreFactorHeaderResponse>;
}