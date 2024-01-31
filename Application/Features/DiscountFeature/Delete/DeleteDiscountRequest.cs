using MediatR;

namespace Application.Features.DiscountFeature.Delete
{
    public sealed record DeleteDiscountRequest(Guid Id) : 
        IRequest<DeleteDiscountResponse>;
}