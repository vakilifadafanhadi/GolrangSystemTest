using MediatR;
using System.ComponentModel.DataAnnotations;

namespace Application.Features.DiscountFeature.Create
{
    public sealed record CreateDiscountRequest(
        Guid PreFactorHeaderId, 
        Guid? PreFactorDetailId, 
        byte Type,
        [Range(1, ulong.MaxValue)]
        ulong Amount) : 
        IRequest<CreateDiscountResponse>;
}