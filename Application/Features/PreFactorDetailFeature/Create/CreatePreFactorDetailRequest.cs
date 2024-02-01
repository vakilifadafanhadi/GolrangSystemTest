using MediatR;
using System.ComponentModel.DataAnnotations;

namespace Application.Features.PreFactorDetailFeature.Create
{
    public sealed record CreatePreFactorDetailRequest(
        Guid ProductId, 
        Guid PreFactorHeaderId,
        int Quantity,
        [Range(1,ulong.MaxValue)]
        ulong Price) : 
        IRequest<CreatePreFactorDetailResponse>;
}