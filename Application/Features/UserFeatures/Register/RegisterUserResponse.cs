namespace Application.Features.UserFeatures.Register
{
    public sealed record RegisterUserResponse(
        Guid Id, 
        string FirstName, 
        string LastName
        );
}