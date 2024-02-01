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
        private IPreFactorHeaderRepository _preFactorHeaderRepository = preFactorHeaderRepository;
        private IPreFactorDetailRepository _preFactorDetailRepository = preFactorDetailRepository;
        private IDiscountRepository _discountRepository = discountRepository;
        private IUnitOfWork _unitOfWork = unitOfWork;
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
            var discount = request.Adapt<Discount>();
            await _discountRepository.AddAsync(discount, cancellationToken);
            await _unitOfWork.SaveAsync(cancellationToken);
            var result = preFactorHeader.Adapt<CreateDiscountResponse>();
            return result;
        }
    }
}
