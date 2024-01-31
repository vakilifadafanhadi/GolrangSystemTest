using Application.Repositories;
using Domain.Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace Persistence.Repositories
{
    public sealed class ApplicationRoleRepository(RoleManager<ApplicationRole> roleManager) : IApplicationRoleRepository
    {
        private readonly RoleManager<ApplicationRole> _roleManager = roleManager;

        public async Task AddAsync(ApplicationRole applicationRole, CancellationToken cancellationToken)
        {
            var result = await _roleManager.CreateAsync(applicationRole);
            if (!result.Succeeded)
                throw new Exception("Role creation failed");
        }
        ~ApplicationRoleRepository() => Dispose();
        public void Dispose()
        {
            _roleManager.Dispose();
            GC.SuppressFinalize(this);
        }
        public async Task<bool> Exists(string name, CancellationToken cancellationToken)
        {
            var allRoles = await _roleManager.Roles.Select(role => role.Name).ToListAsync(cancellationToken);
            return allRoles.Any(a => string.Equals(name, a, StringComparison.OrdinalIgnoreCase));
        }
    }
}
