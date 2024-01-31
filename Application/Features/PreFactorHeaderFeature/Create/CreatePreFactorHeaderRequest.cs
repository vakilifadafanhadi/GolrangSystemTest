using MediatR;

namespace Application.Features.PreFactorHeaderFeature.Create
{
    public sealed record CreatePreFactorHeaderRequest(
        Guid SalesLineId, 
        Guid CustomerId, 
        Guid SellerId) : 
        IRequest<CreatePreFactorHeaderResponse>;
}