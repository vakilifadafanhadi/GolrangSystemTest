namespace Application.Features.CustomerFeature.Create
{
    public sealed record CreateCustomerResponse(
        Guid Id, 
        string FirstName, 
        string LastName
        );
}