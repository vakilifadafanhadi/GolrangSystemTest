using MediatR;

namespace Application.Features.DiscountFeature.Update
{
    public sealed record UpdateDiscountRequest(
        Guid Id,
        Guid PreFactorHeaderId,
        Guid? PreFactorDetailId,
        byte Type,
        ulong Amount) : 
        IRequest<UpdateDiscountResponse>;
}