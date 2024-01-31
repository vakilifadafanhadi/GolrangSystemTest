using Application.Repositories;
using Domain.Entities;
using Mapster;
using MediatR;

namespace Application.Features.SalesLineFeature.Create
{
    public sealed class CreateSalesLineHandler(
        ISalesLineRepository salesLineRepository,
        IUnitOfWork unitOfWork
        ) : IRequestHandler<CreateSalesLineRequest, CreateSalesLineResponse>
    {
        private ISalesLineRepository _salesLineRepository = salesLineRepository;
        private IUnitOfWork _unitOfWork = unitOfWork;
        public async Task<CreateSalesLineResponse> Handle(CreateSalesLineRequest request, CancellationToken cancellationToken)
        {
            var salesLine = request.Adapt<SalesLine>();
            await _salesLineRepository.AddAsync(salesLine, cancellationToken);
            await _unitOfWork.SaveAsync(cancellationToken);
            var result = salesLine.Adapt<CreateSalesLineResponse>();
            return result;
        }
    }
}
