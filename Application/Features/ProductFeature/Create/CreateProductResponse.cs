namespace Application.Features.ProductFeature.Create
{
    public sealed record CreateProductResponse(
        Guid Id,
        string Title
        );
}