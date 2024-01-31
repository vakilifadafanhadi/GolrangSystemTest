namespace Application.Features.PreFactorHeaderFeature.Create
{
    public sealed record CreatePreFactorHeaderResponse(
        Guid Id,
        Guid SalesLineId,
        Guid CustomerId,
        Guid SellerId,
        byte Type);
}