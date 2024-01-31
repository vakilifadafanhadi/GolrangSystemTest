using Application.Repositories;
using Domain.Entities;
using Mapster;
using MediatR;

namespace Application.Features.DiscountFeature.Create
{
    public sealed class CreateDiscountHandler(
        IPreFactorHeaderRepository preFactorHeaderRepository,
        IPreFactorDetailRepository preFactorDetailRepository,
        IDiscountRepository discountRepository,
        IUnitOfWork unitOfWork
        ) : IRequestHandler<CreateDiscountRequest, CreateDiscountResponse>
    {
        private IPreFactorHeaderRepository _preFactorHeaderRepository = preFactorHeaderRepository;
        private IPreFactorDetailRepository _preFactorDetailRepository = preFactorDetailRepository;
        private IDiscountRepository _discountRepository = discountRepository;
        private IUnitOfWork _unitOfWork = unitOfWork;
        public async Task<CreateDiscountResponse> Handle(CreateDiscountRequest request, CancellationToken cancellationToken)
        {
            var preFactorHeader = await _preFactorHeaderRepository.GetByIdAsync(request.PreFactorHeaderId, cancellationToken) ??
                throw new ArgumentNullException(nameof(PreFactorHeader));
            var preFactorDetail = await _preFactorDetailRepository.GetByIdAsync(request.PreFactorDetailId, cancellationToken) ??
                throw new ArgumentNullException(nameof(PreFactorDetail));
            var discount = request.Adapt<Discount>();
            await _discountRepository.AddAsync(discount, cancellationToken);
            await _unitOfWork.SaveAsync(cancellationToken);
            var result = preFactorHeader.Adapt<CreateDiscountResponse>();
            return result;
        }
    }
}
