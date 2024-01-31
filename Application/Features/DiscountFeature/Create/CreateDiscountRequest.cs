using MediatR;

namespace Application.Features.DiscountFeature.Create
{
    public sealed record CreateDiscountRequest(
        Guid PreFactorHeaderId, 
        Guid PreFactorDetailId, 
        byte Type,
        ulong Amount) : 
        IRequest<CreateDiscountResponse>;
}