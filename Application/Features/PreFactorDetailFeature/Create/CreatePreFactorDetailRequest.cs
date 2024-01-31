using MediatR;

namespace Application.Features.PreFactorDetailFeature.Create
{
    public sealed record CreatePreFactorDetailRequest(
        Guid ProductId, 
        Guid PreFactorHeaderId,
        int Quantity, 
        ulong Price) : 
        IRequest<CreatePreFactorDetailResponse>;
}