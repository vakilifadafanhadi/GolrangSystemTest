
using System.ComponentModel.DataAnnotations;

namespace Application.Features.DiscountFeature.Update
{
    public sealed record UpdateDiscountResponse(
        Guid Id,
        Guid PreFactorHeaderId,
        Guid PreFactorDetailId,
        byte Type,
        [Range(1, ulong.MaxValue)]
        ulong Amount);
}