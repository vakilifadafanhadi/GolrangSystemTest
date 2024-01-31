using Domain.Entities;
namespace Application.Repositories
{
    public interface IApplicationUserRepository : IDisposable
    {
        Task<ApplicationUser> RegisterAsync(ApplicationUser applicationUser, string password, CancellationToken cancellationToken);
        Task<ApplicationUser> GetByIdAsync(Guid id);
        Task UpdateAsync(ApplicationUser applicationUser);
    }
}
