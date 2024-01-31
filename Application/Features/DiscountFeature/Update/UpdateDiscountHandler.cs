using Application.Repositories;
using Domain.Entities;
using Mapster;
using MediatR;

namespace Application.Features.DiscountFeature.Update
{
    public sealed class UpdateDiscountHandler(
        IPreFactorHeaderRepository preFactorHeaderRepository,
        IPreFactorDetailRepository preFactorDetailRepository,
        IDiscountRepository discountRepository,
        IUnitOfWork unitOfWork
        ) :
        IRequestHandler<UpdateDiscountRequest, UpdateDiscountResponse>
    {
        private IPreFactorHeaderRepository _preFactorHeaderRepository = preFactorHeaderRepository;
        private IPreFactorDetailRepository _preFactorDetailRepository = preFactorDetailRepository;
        private IDiscountRepository _discountRepository = discountRepository;
        private IUnitOfWork _unitOfWork = unitOfWork;
        public async Task<UpdateDiscountResponse> Handle(UpdateDiscountRequest request, CancellationToken cancellationToken)
        {
            var preFactorHeader = await _preFactorHeaderRepository.GetByIdAsync(request.PreFactorHeaderId, cancellationToken) ??
                throw new ArgumentNullException(nameof(PreFactorHeader));
            var preFactorDetail = await _preFactorDetailRepository.GetByIdAsync(request.PreFactorDetailId, cancellationToken) ??
                throw new ArgumentNullException(nameof(PreFactorDetail));
            var oldDiscount = await _discountRepository.GetByIdAsync(request.Id, cancellationToken) ??
                throw new ArgumentNullException(nameof(Discount));
            var newDiscount = request.Adapt(oldDiscount);
            _discountRepository.Update(newDiscount);
            await _unitOfWork.SaveAsync(cancellationToken);
            var result = newDiscount.Adapt<UpdateDiscountResponse>();
            return result;
        }
    }
}
