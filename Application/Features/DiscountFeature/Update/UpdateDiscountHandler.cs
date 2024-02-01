using Application.Repositories;
using Domain.Entities;
using Domain.Enums;
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
            PreFactorDetail preFactorDetail;
            if (request.Type == (byte)DiscountTypesEnum.PerRow)
                preFactorDetail = await _preFactorDetailRepository.GetByIdAsync((Guid)request.PreFactorDetailId, cancellationToken) ??
                    throw new ArgumentNullException(nameof(PreFactorDetail));
            if (request.Type == (byte)DiscountTypesEnum.PerDocument && request.PreFactorDetailId is not null)
                throw new ArgumentException(nameof(PreFactorDetail), "Should Be Null");
            var preFactorHeader = await _preFactorHeaderRepository.GetByIdAsync(request.PreFactorHeaderId, cancellationToken) ??
                throw new ArgumentNullException(nameof(PreFactorHeader));
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
