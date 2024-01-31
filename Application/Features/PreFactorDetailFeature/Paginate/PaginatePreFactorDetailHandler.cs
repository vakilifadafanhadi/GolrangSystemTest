using Application.Repositories;
using Mapster;
using MediatR;

namespace Application.Features.PreFactorDetailFeature.Paginate
{
    public sealed class PaginatePreFactorDetailHandler(
        IPreFactorDetailRepository preFactorDetailRepository
        ) : 
        IRequestHandler<PaginatePreFactorDetailRequest, PaginatePreFactorDetailResponse>
    {
        private readonly IPreFactorDetailRepository _preFactorDetailRepository = preFactorDetailRepository;
        public async Task<PaginatePreFactorDetailResponse> Handle(PaginatePreFactorDetailRequest request, CancellationToken cancellationToken)
        {
            var data = await _preFactorDetailRepository.GetUndeletedPaginationAsync(request.Take, request.Page, cancellationToken);
            var count = await _preFactorDetailRepository.GetUndeletedCountAsync(cancellationToken);
            var result = new PaginatePreFactorDetailResponse(count, data.Adapt<IList<PreFactorDetailDto>>());
            return result;
        }
    }
}
