namespace Application.Features.PreFactorHeaderFeature.Paginate
{
    public sealed record PaginatePreFactorHeaderResponse(
        int Count,
        IList<PreFactorHeaderDto> Data);
    public sealed record PreFactorHeaderDto(
        Guid Id,
        Guid SalesLineId,
        Guid CustomerId,
        Guid SellerId,
        byte Type);
}