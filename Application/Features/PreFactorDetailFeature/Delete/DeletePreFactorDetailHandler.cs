using Application.Repositories;
using Domain.Entities;
using Mapster;
using MediatR;

namespace Application.Features.PreFactorDetailFeature.Delete
{
    public sealed class DeletePreFactorDetailHandler(
        IPreFactorDetailRepository preFactorDetailRepository,
        IUnitOfWork unitOfWork) : 
        IRequestHandler<DeletePreFactorDetailRequest, DeletePreFactorDetailResponse>
    {
        private readonly IPreFactorDetailRepository _preFactorDetailRepository = preFactorDetailRepository;
        private readonly IUnitOfWork _unitOfWork = unitOfWork;
        public async Task<DeletePreFactorDetailResponse> Handle(DeletePreFactorDetailRequest request, CancellationToken cancellationToken)
        {
            var preFactorDetail = await _preFactorDetailRepository.GetByIdAsync(request.Id, cancellationToken) ??
                throw new ArgumentNullException(nameof(PreFactorDetail));
            _preFactorDetailRepository.Delete(preFactorDetail);
            var result = preFactorDetail.Adapt<DeletePreFactorDetailResponse>();
            return result;
        }
    }
}
