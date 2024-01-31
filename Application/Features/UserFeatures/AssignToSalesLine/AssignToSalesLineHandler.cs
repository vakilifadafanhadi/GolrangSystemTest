using Application.Repositories;
using Domain.Entities;
using Mapster;
using MediatR;

namespace Application.Features.UserFeatures.AssignToSalesLine
{
    public sealed class AssignToSalesLineHandler(
        IApplicationUserRepository applicationUserRepository,
        ISalesLineRepository salesLineRepository,
        IUnitOfWork unitOfWork)
        : IRequestHandler<AssignToSalesLineRequest, AssignToSalesLineResponse>
    {
        private readonly IApplicationUserRepository _applicationUserRepository = applicationUserRepository;
        private readonly IUnitOfWork _unitOfWork = unitOfWork;
        private readonly ISalesLineRepository _salesLineRepository = salesLineRepository;
        public async Task<AssignToSalesLineResponse> Handle(AssignToSalesLineRequest request, CancellationToken cancellationToken)
        {
            var applicationUser = await _applicationUserRepository.GetByIdAsync(request.Id) ?? 
                throw new ArgumentNullException(nameof(ApplicationUser));
            var salesLine = await _salesLineRepository.GetByIdAsync(request.SalesLineId, cancellationToken) ??
                throw new ArgumentNullException(nameof(SalesLine));
            applicationUser.SalesLineId = request.SalesLineId;
            await _applicationUserRepository.UpdateAsync(applicationUser);
            var result = applicationUser.Adapt<AssignToSalesLineResponse>();
            await _unitOfWork.SaveAsync(cancellationToken);
            return result with { SalesLineId = request.SalesLineId };
        }
    }
}
