using MediatR;
using System.ComponentModel.DataAnnotations;

namespace Application.Features.PreFactorDetailFeature.Update
{
    public sealed record UpdatePreFactorDetailRequest(
        Guid Id,
        Guid ProductId,
        int Quantity,
        [Range(1, ulong.MaxValue)]
        ulong Price) : 
        IRequest<UpdatePreFactorDetailResponse>;
}