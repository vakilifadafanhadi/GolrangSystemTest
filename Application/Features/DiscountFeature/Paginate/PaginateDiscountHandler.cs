using Application.Repositories;
using Mapster;
using MediatR;

namespace Application.Features.DiscountFeature.Paginate
{
    public sealed class PaginateDiscountHandler(
        IDiscountRepository discountRepository
        ) : 
        IRequestHandler<PaginateDiscountRequest, PaginateDiscountResponse>
    {
        private readonly IDiscountRepository _discountRepository = discountRepository;
        public async Task<PaginateDiscountResponse> Handle(PaginateDiscountRequest request, CancellationToken cancellationToken)
        {
            var data = await _discountRepository.GetUndeletedPaginationAsync(request.Take, request.Page, cancellationToken);
            var count = await _discountRepository.GetUndeletedCountAsync(cancellationToken);
            var result = new PaginateDiscountResponse(count, data.Adapt<IList<DiscountDto>>());
            return result;
        }
    }
}
