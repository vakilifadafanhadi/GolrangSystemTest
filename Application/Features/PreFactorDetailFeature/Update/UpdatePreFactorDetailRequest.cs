using MediatR;

namespace Application.Features.PreFactorDetailFeature.Update
{
    public sealed record UpdatePreFactorDetailRequest(
        Guid Id,
        Guid ProductId,
        int Quantity,
        ulong Price) : 
        IRequest<UpdatePreFactorDetailResponse>;
}