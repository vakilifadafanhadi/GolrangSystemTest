
namespace Application.Features.PreFactorDetailFeature.Update
{
    public sealed record UpdatePreFactorDetailResponse(
        Guid Id,
        Guid ProductId,
        int Quantity,
        ulong Price);
}