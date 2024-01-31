using Domain.Entities;

namespace Application.Repositories
{
    public interface IApplicationRoleRepository : IDisposable
    {
        Task AddAsync(ApplicationRole applicationRole, CancellationToken cancellationToken);
        Task<bool> Exists(string name, CancellationToken cancellationToken);
    }
}
