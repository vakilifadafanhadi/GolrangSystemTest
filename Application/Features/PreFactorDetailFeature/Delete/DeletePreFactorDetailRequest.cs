using MediatR;

namespace Application.Features.PreFactorDetailFeature.Delete
{
    public sealed record DeletePreFactorDetailRequest(Guid Id) : 
        IRequest<DeletePreFactorDetailResponse>;
}