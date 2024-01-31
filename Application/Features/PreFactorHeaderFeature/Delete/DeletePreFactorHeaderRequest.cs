using MediatR;

namespace Application.Features.PreFactorHeaderFeature.Delete
{
    public sealed record DeletePreFactorHeaderRequest(Guid Id) : 
        IRequest<DeletePreFactorHeaderResponse>;
}