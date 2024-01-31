using Application.Repositories;
using Domain.Entities;
using Mapster;
using MediatR;

namespace Application.Features.UserFeatures.Register
{
    public sealed class RegisterUserHandler(
        IApplicationUserRepository applicationUserRepository,
        IUnitOfWork unitOfWork
        ) : IRequestHandler<RegisterUserRequest, RegisterUserResponse>
    {
        private IApplicationUserRepository _applicationUserRepository = applicationUserRepository;
        private IUnitOfWork _unitOfWork = unitOfWork;
        public async Task<RegisterUserResponse> Handle(RegisterUserRequest request, CancellationToken cancellationToken)
        {
            if (request.Password != request.ConfirmPassword)
                throw new ArgumentException("Password and Confirm Password Are Not Equal");
            var applicationUser = request.Adapt<ApplicationUser>();
            await _applicationUserRepository.RegisterAsync(applicationUser, request.Password, cancellationToken);
            await _unitOfWork.SaveAsync(cancellationToken);
            var result = applicationUser.Adapt<RegisterUserResponse>();
            return result;
        }
    }
}
