using MediatR;

namespace Application.Features.DiscountFeature.Paginate
{
    public sealed record PaginateDiscountRequest(
        int Take,
        int Page
        ) : IRequest<PaginateDiscountResponse>;
    
}