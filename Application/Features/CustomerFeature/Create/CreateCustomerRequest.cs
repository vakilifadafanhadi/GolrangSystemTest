using MediatR;

namespace Application.Features.CustomerFeature.Create
{
    public sealed record CreateCustomerRequest(
        string FirstName, 
        string LastName) : 
        IRequest<CreateCustomerResponse>;
}