using Application.Repositories;
using Domain.Entities;
using Domain.Enums;
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
        private readonly IPreFactorHeaderRepository _preFactorHeaderRepository = preFactorHeaderRepository;
        private readonly IPreFactorDetailRepository _preFactorDetailRepository = preFactorDetailRepository;
        private readonly IDiscountRepository _discountRepository = discountRepository;
        private readonly IUnitOfWork _unitOfWork = unitOfWork;
        public async Task<CreateDiscountResponse> Handle(CreateDiscountRequest request, CancellationToken cancellationToken)
        {
            PreFactorDetail preFactorDetail;
            if (request.Type == (byte)DiscountTypesEnum.PerRow)
                preFactorDetail = await _preFactorDetailRepository.GetByIdAsync((Guid)request.PreFactorDetailId, cancellationToken) ??
                    throw new ArgumentNullException(nameof(PreFactorDetail));
            if (request.Type == (byte)DiscountTypesEnum.PerDocument && request.PreFactorDetailId is not null)
                throw new ArgumentException(nameof(PreFactorDetail), "Should Be Null");
            var preFactorHeader = await _preFactorHeaderRepository.GetByIdAsync(request.PreFactorHeaderId, cancellationToken) ??
                throw new ArgumentNullException(nameof(PreFactorHeader));
            var sumPrice = await _preFactorDetailRepository.SumPriceAsync(request.PreFactorHeaderId, cancellationToken);
            var sumDiscount = await _discountRepository.SumPreFactorDiscounts(request.PreFactorHeaderId, cancellationToken);
            if (sumPrice < sumDiscount + request.Amount)
                throw new ArgumentException("Sum Price Should Be Greater Than Discounts");
            var discount = request.Adapt<Discount>();
            await _discountRepository.AddAsync(discount, cancellationToken);
            await _unitOfWork.SaveAsync(cancellationToken);
            var result = preFactorHeader.Adapt<CreateDiscountResponse>();
            return result;
        }
    }
}
