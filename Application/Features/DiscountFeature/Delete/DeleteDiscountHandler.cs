using Application.Repositories;
using Domain.Entities;
using Mapster;
using MediatR;

namespace Application.Features.DiscountFeature.Delete
{
    public sealed class DeleteDiscountHandler(
        IDiscountRepository discountRepository,
        IUnitOfWork unitOfWork) : 
        IRequestHandler<DeleteDiscountRequest, DeleteDiscountResponse>
    {
        private readonly IDiscountRepository _discountRepository = discountRepository;
        private readonly IUnitOfWork _unitOfWork = unitOfWork;
        public async Task<DeleteDiscountResponse> Handle(DeleteDiscountRequest request, CancellationToken cancellationToken)
        {
            var discount = await _discountRepository.GetByIdAsync(request.Id, cancellationToken) ??
                throw new ArgumentNullException(nameof(Discount));
            _discountRepository.Delete(discount);
            var result = discount.Adapt<DeleteDiscountResponse>();
            return result;
        }
    }
}
