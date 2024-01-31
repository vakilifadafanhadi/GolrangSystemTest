using MediatR;

namespace Application.Features.ProductFeature.Create
{
    public sealed record CreateProductRequest(
        string Title
        ) : 
        IRequest<CreateProductResponse>;
}