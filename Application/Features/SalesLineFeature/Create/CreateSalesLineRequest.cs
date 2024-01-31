using MediatR;

namespace Application.Features.SalesLineFeature.Create
{
    public sealed record CreateSalesLineRequest(string Title) : IRequest<CreateSalesLineResponse>;
}