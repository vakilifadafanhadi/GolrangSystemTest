namespace Application.Features.DiscountFeature.Create
{
    public sealed record CreateDiscountResponse(
        Guid Id,
        Guid PreFactorHeaderId,
        Guid PreFactorDetailId,
        byte Type,
        ulong Amount);
}