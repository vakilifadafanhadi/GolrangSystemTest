
namespace Application.Features.DiscountFeature.Update
{
    public sealed record UpdateDiscountResponse(
        Guid Id,
        Guid PreFactorHeaderId,
        Guid PreFactorDetailId,
        byte Type,
        ulong Amount);
}