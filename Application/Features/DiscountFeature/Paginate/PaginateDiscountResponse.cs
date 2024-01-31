namespace Application.Features.DiscountFeature.Paginate
{
    public sealed record PaginateDiscountResponse(
        int Count,
        IList<DiscountDto> Data);
    public sealed record DiscountDto(
        Guid Id,
        Guid PreFactorHeaderId,
        Guid PreFactorDetailId,
        byte Type,
        ulong Amount);
}