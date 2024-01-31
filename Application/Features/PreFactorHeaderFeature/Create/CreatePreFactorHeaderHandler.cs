using Application.Repositories;
using Domain.Entities;
using Domain.Enums;
using Mapster;
using MediatR;

namespace Application.Features.PreFactorHeaderFeature.Create
{
    public sealed class CreatePreFactorHeaderHandler(
        IPreFactorHeaderRepository preFactorHeaderRepository,
        IApplicationUserRepository applicationUserRepository,
        ICustomerRepository customerRepository,
        ISalesLineRepository salesLineRepository,
        IUnitOfWork unitOfWork
        ) : IRequestHandler<CreatePreFactorHeaderRequest, CreatePreFactorHeaderResponse>
    {
        private IPreFactorHeaderRepository _preFactorHeaderRepository = preFactorHeaderRepository;
        private IApplicationUserRepository _applicationUserRepository = applicationUserRepository;
        private ICustomerRepository _customerRepository = customerRepository;
        private ISalesLineRepository _salesLineRepository = salesLineRepository;
        private IUnitOfWork _unitOfWork = unitOfWork;
        public async Task<CreatePreFactorHeaderResponse> Handle(CreatePreFactorHeaderRequest request, CancellationToken cancellationToken)
        {
            var user = await _applicationUserRepository.GetByIdAsync(request.SellerId) ??
                throw new ArgumentNullException(nameof(ApplicationUser));
            var customer = await _customerRepository.GetByIdAsync(request.CustomerId, cancellationToken) ??
                throw new ArgumentNullException(nameof(Customer));
            var salesLine = await _salesLineRepository.GetByIdAsync(request.SalesLineId, cancellationToken) ??
                throw new ArgumentNullException(nameof(SalesLine));
            var preFactorHeader = request.Adapt<PreFactorHeader>();
            preFactorHeader.Status = (byte)PreFactorStatusEnum.Draft;
            await _preFactorHeaderRepository.AddAsync(preFactorHeader, cancellationToken);
            await _unitOfWork.SaveAsync(cancellationToken);
            var result = preFactorHeader.Adapt<CreatePreFactorHeaderResponse>();
            return result;
        }
    }
}
