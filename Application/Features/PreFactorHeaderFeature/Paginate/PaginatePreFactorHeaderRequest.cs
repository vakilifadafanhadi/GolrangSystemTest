using MediatR;

namespace Application.Features.PreFactorHeaderFeature.Paginate
{
    public sealed record PaginatePreFactorHeaderRequest(
        int Take,
        int Page
        ) : IRequest<PaginatePreFactorHeaderResponse>;
    
}