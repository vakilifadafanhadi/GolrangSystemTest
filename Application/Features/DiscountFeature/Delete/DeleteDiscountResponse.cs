namespace Application.Features.DiscountFeature.Delete
{
    public sealed record DeleteDiscountResponse(
        Guid Id,
        Guid PreFactorHeaderId,
        Guid PreFactorDetailId,
        byte Type,
        ulong Amount);
}