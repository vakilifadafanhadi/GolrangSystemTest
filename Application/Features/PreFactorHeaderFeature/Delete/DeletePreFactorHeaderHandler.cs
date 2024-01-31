using Application.Repositories;
using Domain.Entities;
using Mapster;
using MediatR;

namespace Application.Features.PreFactorHeaderFeature.Delete
{
    public sealed class DeletePreFactorHeaderHandler(
        IPreFactorHeaderRepository preFactorHeaderRepository,
        IUnitOfWork unitOfWork) : 
        IRequestHandler<DeletePreFactorHeaderRequest, DeletePreFactorHeaderResponse>
    {
        private readonly IPreFactorHeaderRepository _preFactorHeaderRepository = preFactorHeaderRepository;
        private readonly IUnitOfWork _unitOfWork = unitOfWork;
        public async Task<DeletePreFactorHeaderResponse> Handle(DeletePreFactorHeaderRequest request, CancellationToken cancellationToken)
        {
            var preFactorHeader = await _preFactorHeaderRepository.GetByIdAsync(request.Id, cancellationToken) ??
                throw new ArgumentNullException(nameof(PreFactorHeader));
            _preFactorHeaderRepository.Delete(preFactorHeader);
            var result = preFactorHeader.Adapt<DeletePreFactorHeaderResponse>();
            return result;
        }
    }
}
