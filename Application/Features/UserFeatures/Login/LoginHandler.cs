using Application.Repositories;
using MediatR;

namespace Application.Features.UserFeatures.Login
{
    public sealed class LoginHandler(
        IApplicationUserRepository applicationUserRepository
        ) : IRequestHandler<LoginRequest, LoginResponse>
    {
        private readonly IApplicationUserRepository _userRepository = applicationUserRepository;
        public async Task<LoginResponse> Handle(LoginRequest request, CancellationToken cancellationToken)
        {
            var result = await _userRepository.LoginAsync(
                request.UserName, 
                request.Password, 
                request.IsPresistant, 
                cancellationToken);
            return new LoginResponse(
                result.Key.Id, 
                result.Key.FirstName, 
                result.Key.LastName, 
                result.Value);
        }
    }
}
