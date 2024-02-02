using MediatR;

namespace Application.Features.UserFeatures.Login
{
    public sealed record LoginRequest(
        string UserName, 
        string Password, 
        bool IsPresistant) : IRequest<LoginResponse>;
}