namespace Application.Features.PreFactorDetailFeature.Paginate
{
    public sealed record PaginatePreFactorDetailResponse(
        int Count,
        IList<PreFactorDetailDto> Data);
    public sealed record PreFactorDetailDto(
        Guid Id,
        Guid ProductId,
        int Quantity,
        ulong Price);
}