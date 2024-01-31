using Application.Repositories;
using Domain.Entities;
using Mapster;
using MediatR;

namespace Application.Features.PreFactorDetailFeature.Create
{
    public sealed class CreatePreFactorDetailHandler(
        IPreFactorDetailRepository preFactorDetailRepository,
        IPreFactorHeaderRepository preFactorHeaderRepository,
        IProductRepository productRepository,
        IUnitOfWork unitOfWork
        ) : IRequestHandler<CreatePreFactorDetailRequest, CreatePreFactorDetailResponse>
    {
        private IPreFactorDetailRepository _preFactorDetailRepository = preFactorDetailRepository;
        private IPreFactorHeaderRepository _preFactorHeaderRepository = preFactorHeaderRepository;
        private IProductRepository _productRepository = productRepository;
        private IUnitOfWork _unitOfWork = unitOfWork;
        public async Task<CreatePreFactorDetailResponse> Handle(CreatePreFactorDetailRequest request, CancellationToken cancellationToken)
        {
            var product = await _productRepository.GetByIdAsync(request.ProductId, cancellationToken) ??
                throw new ArgumentNullException(nameof(Product));
            var preFactorHeader = await _preFactorHeaderRepository.GetByIdAsync(request.PreFactorHeaderId, cancellationToken) ??
                throw new ArgumentNullException(nameof(PreFactorHeader));
            var preFactorDetail = request.Adapt<PreFactorDetail>();
            await _preFactorDetailRepository.AddAsync(preFactorDetail, cancellationToken);
            await _unitOfWork.SaveAsync(cancellationToken);
            var result = preFactorDetail.Adapt<CreatePreFactorDetailResponse>();
            return result;
        }
    }
}
