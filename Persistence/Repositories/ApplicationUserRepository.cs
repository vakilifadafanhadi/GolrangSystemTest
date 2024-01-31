using Application.Repositories;
using Domain.Entities;
using IdentityModel;
using Microsoft.AspNetCore.Identity;
using System.Security.Claims;

namespace Persistence.Repositories
{
    public sealed class ApplicationUserRepository(UserManager<ApplicationUser> userManager) :
        IApplicationUserRepository
    {
        private readonly UserManager<ApplicationUser> _userManager = userManager;
        public async Task<ApplicationUser> RegisterAsync(ApplicationUser applicationUser, string password, CancellationToken cancellationToken)
        {
            var identityResult = await _userManager.CreateAsync(applicationUser, password);
            if (!identityResult.Succeeded)
                throw new ApplicationException(identityResult.Errors.FirstOrDefault().Description);
            Claim claim = new(
                JwtClaimTypes.Id,
                applicationUser.Id.ToString()
                );
            await _userManager.AddClaimAsync(
                applicationUser,
                claim
                );
            return applicationUser;
        }
        public async Task<ApplicationUser> GetByIdAsync(Guid id)
        {
            var applicationUser = await _userManager.FindByIdAsync(id.ToString());
            return applicationUser;
        }
        public async Task UpdateAsync(ApplicationUser applicationUser)
        {
            applicationUser.DateUpdated = DateTime.UtcNow;
            await _userManager.UpdateAsync(applicationUser);
        }
        ~ApplicationUserRepository() =>
            Dispose();
        public void Dispose()
        {
            _userManager?.Dispose();
            GC.SuppressFinalize(this);
        }
    }
}
