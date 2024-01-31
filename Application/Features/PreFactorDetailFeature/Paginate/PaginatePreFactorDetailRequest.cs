using MediatR;

namespace Application.Features.PreFactorDetailFeature.Paginate
{
    public sealed record PaginatePreFactorDetailRequest(
        int Take,
        int Page
        ) : IRequest<PaginatePreFactorDetailResponse>;
    
}