namespace Application.Features.UserFeatures.AssignToSalesLine
{
    public sealed record AssignToSalesLineResponse(
        Guid Id,
        Guid SalesLineId,
        string FirstName,
        string LastName,
        string SalesLineTitle);
}