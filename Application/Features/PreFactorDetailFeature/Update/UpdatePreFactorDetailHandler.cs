using Application.Repositories;
using Domain.Entities;
using Mapster;
using MediatR;

namespace Application.Features.PreFactorDetailFeature.Update
{
    public sealed class UpdatePreFactorDetailHandler(
        IPreFactorDetailRepository preFactorDetailRepository,
        IProductRepository productRepository,
        IUnitOfWork unitOfWork
        ) :
        IRequestHandler<UpdatePreFactorDetailRequest, UpdatePreFactorDetailResponse>
    {
        private IPreFactorDetailRepository _preFactorDetailRepository = preFactorDetailRepository;
        private IProductRepository _productRepository = productRepository;
        private IUnitOfWork _unitOfWork = unitOfWork;
        public async Task<UpdatePreFactorDetailResponse> Handle(UpdatePreFactorDetailRequest request, CancellationToken cancellationToken)
        {
            var product = await _productRepository.GetByIdAsync(request.ProductId, cancellationToken) ??
                throw new ArgumentNullException(nameof(Product));
            var oldPreFactorDetail = await _preFactorDetailRepository.GetByIdAsync(request.Id, cancellationToken) ??
                throw new ArgumentNullException(nameof(PreFactorDetail));
            var newPreFactorDetail = request.Adapt(oldPreFactorDetail);
            _preFactorDetailRepository.Update(newPreFactorDetail);
            await _unitOfWork.SaveAsync(cancellationToken);
            var result = newPreFactorDetail.Adapt<UpdatePreFactorDetailResponse>();
            return result;
        }
    }
}
