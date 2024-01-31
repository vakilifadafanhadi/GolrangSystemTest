using MediatR;
using System.ComponentModel.DataAnnotations;

namespace Application.Features.UserFeatures.Register
{
    public sealed record RegisterUserRequest(
        [Required]
        string UserName,
        [Required]
        string FirstName,
        string LastName,
        [Required]
        string Password,
        [Required]
        string ConfirmPassword) : IRequest<RegisterUserResponse>;
}