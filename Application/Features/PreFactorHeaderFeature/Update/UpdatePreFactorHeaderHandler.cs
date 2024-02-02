using Application.Repositories;
using Domain.Entities;
using Domain.Enums;
using Mapster;
using MediatR;

namespace Application.Features.PreFactorHeaderFeature.Update
{
    public sealed class UpdatePreFactorHeaderHandler(
        IPreFactorHeaderRepository preFactorHeaderRepository,
        IPreFactorDetailRepository preFactorDetailRepository,
        IApplicationUserRepository applicationUserRepository,
        ICustomerRepository customerRepository,
        ISalesLineRepository salesLineRepository,
        IUnitOfWork unitOfWork
        ) :
        IRequestHandler<UpdatePreFactorHeaderRequest, UpdatePreFactorHeaderResponse>
    {
        private readonly IPreFactorHeaderRepository _preFactorHeaderRepository = preFactorHeaderRepository;
        private readonly IPreFactorDetailRepository _preFactorDetailRepository = preFactorDetailRepository;
        private readonly IApplicationUserRepository _applicationUserRepository = applicationUserRepository;
        private readonly ICustomerRepository _customerRepository = customerRepository;
        private readonly ISalesLineRepository _salesLineRepository = salesLineRepository;
        private readonly IUnitOfWork _unitOfWork = unitOfWork;
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
            if (oldPreFactorHeader.PreFactorDetailId.HasValue && request.SalesLineId != oldPreFactorHeader.SalesLineId)
                throw new ArgumentException("Sales Line Cant Be Modified In This Case");
            if(request.Status == (byte)PreFactorStatusEnum.Final)
            {
                var sumPrice = await _preFactorDetailRepository.SumCustomerPriceAsync(request.Id, request.CustomerId, cancellationToken);
                if (sumPrice >= 1000000)
                    throw new ArgumentOutOfRangeException();
            }
            var newPreFactorHeader = request.Adapt(oldPreFactorHeader);
            _preFactorHeaderRepository.Update(newPreFactorHeader);
            await _unitOfWork.SaveAsync(cancellationToken);
            var result = newPreFactorHeader.Adapt<UpdatePreFactorHeaderResponse>();
            return result;
        }
    }
}
