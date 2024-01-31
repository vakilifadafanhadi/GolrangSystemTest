using MediatR;

namespace Application.Features.UserFeatures.AssignToSalesLine
{
    public sealed record AssignToSalesLineRequest(Guid Id, Guid SalesLineId) : IRequest<AssignToSalesLineResponse>;
}