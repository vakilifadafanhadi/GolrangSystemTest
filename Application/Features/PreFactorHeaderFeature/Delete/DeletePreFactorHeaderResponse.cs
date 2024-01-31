namespace Application.Features.PreFactorHeaderFeature.Delete
{
    public sealed record DeletePreFactorHeaderResponse(
        Guid Id,
        Guid SalesLineId,
        Guid CustomerId,
        Guid SellerId,
        byte Type);
}