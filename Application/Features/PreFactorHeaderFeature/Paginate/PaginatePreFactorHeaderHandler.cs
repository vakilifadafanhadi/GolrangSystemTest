using Application.Repositories;
using Mapster;
using MediatR;

namespace Application.Features.PreFactorHeaderFeature.Paginate
{
    public sealed class PaginatePreFactorHeaderHandler(
        IPreFactorHeaderRepository preFactorHeaderRepository
        ) : 
        IRequestHandler<PaginatePreFactorHeaderRequest, PaginatePreFactorHeaderResponse>
    {
        private readonly IPreFactorHeaderRepository _preFactorHeaderRepository = preFactorHeaderRepository;
        public async Task<PaginatePreFactorHeaderResponse> Handle(PaginatePreFactorHeaderRequest request, CancellationToken cancellationToken)
        {
            var data = await _preFactorHeaderRepository.GetUndeletedPaginationAsync(request.Take, request.Page, cancellationToken);
            var count = await _preFactorHeaderRepository.GetUndeletedCountAsync(cancellationToken);
            var result = new PaginatePreFactorHeaderResponse(count, data.Adapt<IList<PreFactorHeaderDto>>());
            return result;
        }
    }
}
