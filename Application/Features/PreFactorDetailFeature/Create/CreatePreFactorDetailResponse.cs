namespace Application.Features.PreFactorDetailFeature.Create
{
    public sealed record CreatePreFactorDetailResponse(
        Guid Id,
        Guid ProductId,
        int Quantity,
        ulong Price);
}