using Application.Repositories;
using Domain.Entities;
using Domain.Enums;
using Mapster;
using MediatR;

namespace Application.Features.ProductFeature.Create
{
    public sealed class CreateProductHandler(
        IProductRepository productRepository,
        IUnitOfWork unitOfWork
        ) : IRequestHandler<CreateProductRequest, CreateProductResponse>
    {
        private IProductRepository _productRepository = productRepository;
        private IUnitOfWork _unitOfWork = unitOfWork;
        public async Task<CreateProductResponse> Handle(CreateProductRequest request, CancellationToken cancellationToken)
        {
            var product = request.Adapt<Product>();
            await _productRepository.AddAsync(product, cancellationToken);
            await _unitOfWork.SaveAsync(cancellationToken);
            var result = product.Adapt<CreateProductResponse>();
            return result;
        }
    }
}
