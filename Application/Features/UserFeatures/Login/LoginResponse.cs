namespace Application.Features.UserFeatures.Login
{
    public sealed record LoginResponse(
        Guid Id,
        string FirstName,
        string LastName,
        string Token
        );
}