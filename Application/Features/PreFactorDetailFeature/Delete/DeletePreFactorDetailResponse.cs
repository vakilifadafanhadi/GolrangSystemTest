namespace Application.Features.PreFactorDetailFeature.Delete
{
    public sealed record DeletePreFactorDetailResponse(
        Guid Id,
        Guid ProductId,
        int Quantity,
        ulong Price);
}