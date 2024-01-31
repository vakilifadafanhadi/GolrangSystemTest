using Application.Repositories;
using Domain.Entities;
using Mapster;
using MediatR;

namespace Application.Features.CustomerFeature.Create
{
    public sealed class CreateCustomerHandler(
        ICustomerRepository customerRepository,
        IUnitOfWork unitOfWork
        ) : IRequestHandler<CreateCustomerRequest, CreateCustomerResponse>
    {
        private readonly ICustomerRepository _customerRepository = customerRepository;
        private readonly IUnitOfWork _unitOfWork = unitOfWork;
        public async Task<CreateCustomerResponse> Handle(CreateCustomerRequest request, CancellationToken cancellationToken)
        {
            var customer = request.Adapt<Customer>();
            await _customerRepository.AddAsync(customer, cancellationToken);
            await _unitOfWork.SaveAsync(cancellationToken);
            var result = customer.Adapt<CreateCustomerResponse>();
            return result;
        }
    }
}
