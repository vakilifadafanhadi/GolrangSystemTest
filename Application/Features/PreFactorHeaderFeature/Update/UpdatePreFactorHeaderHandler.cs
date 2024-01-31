using Application.Repositories;
using Domain.Entities;
using Mapster;
using MediatR;

namespace Application.Features.PreFactorHeaderFeature.Update
{
    public sealed class UpdatePreFactorHeaderHandler(
        IPreFactorHeaderRepository preFactorHeaderRepository,
        IApplicationUserRepository applicationUserRepository,
        ICustomerRepository customerRepository,
        ISalesLineRepository salesLineRepository,
        IUnitOfWork unitOfWork
        ) :
        IRequestHandler<UpdatePreFactorHeaderRequest, UpdatePreFactorHeaderResponse>
    {
        private IPreFactorHeaderRepository _preFactorHeaderRepository = preFactorHeaderRepository;
        private IApplicationUserRepository _applicationUserRepository = applicationUserRepository;
        private ICustomerRepository _customerRepository = customerRepository;
        private ISalesLineRepository _salesLineRepository = salesLineRepository;
        private IUnitOfWork _unitOfWork = unitOfWork;
        public async Task<UpdatePreFactorHeaderResponse> Handle(UpdatePreFactorHeaderRequest request, CancellationToken cancellationToken)
        {
            var user = await _applicationUserRepository.GetByIdAsync(request.SellerId) ??
                throw new ArgumentNullException(nameof(ApplicationUser));
            var customer = await _customerRepository.GetByIdAsync(request.CustomerId, cancellationToken) ??
                throw new ArgumentNullException(nameof(Customer));
            var salesLine = await _salesLineRepository.GetByIdAsync(request.SalesLineId, cancellationToken) ??
                throw new ArgumentNullException(nameof(SalesLine));
            var oldPreFactorHeader = await _preFactorHeaderRepository.GetByIdAsync(request.Id, cancellationToken) ??
                throw new ArgumentNullException(nameof(PreFactorHeader));
            var newPreFactorHeader = request.Adapt(oldPreFactorHeader);
            _preFactorHeaderRepository.Update(newPreFactorHeader);
            await _unitOfWork.SaveAsync(cancellationToken);
            var result = newPreFactorHeader.Adapt<UpdatePreFactorHeaderResponse>();
            return result;
        }
    }
}
