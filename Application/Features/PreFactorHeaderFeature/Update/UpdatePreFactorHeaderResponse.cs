
namespace Application.Features.PreFactorHeaderFeature.Update
{
    public sealed record UpdatePreFactorHeaderResponse(
        Guid Id,
        Guid SalesLineId,
        Guid UserId,
        Guid CustomerId,
        byte Status);
}