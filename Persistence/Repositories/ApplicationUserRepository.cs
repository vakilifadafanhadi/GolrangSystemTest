using Application.Repositories;
using Domain.Entities;
using IdentityModel;
using Microsoft.AspNetCore.Identity;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace Persistence.Repositories
{
    public sealed class ApplicationUserRepository(
        UserManager<ApplicationUser> userManager,
        SignInManager<ApplicationUser> signInManager,
        RoleManager<ApplicationRole> roleManager) :
        IApplicationUserRepository
    {
        private readonly SignInManager<ApplicationUser> _signInManager = signInManager;
        private readonly UserManager<ApplicationUser> _userManager = userManager;
        private readonly RoleManager<ApplicationRole> _roleManager = roleManager;
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

        public async Task<KeyValuePair<ApplicationUser, string>> LoginAsync(string userName, string password, bool isPresistant, CancellationToken cancellationToken)
        {
            ApplicationUser user = await _userManager.FindByNameAsync(userName) ??
                throw new Exception("Wrong User Credentials");
            SignInResult isPasswordCorrect = await _signInManager.PasswordSignInAsync(
                user,
                password,
                isPresistant,
                false);
            if (!isPasswordCorrect.Succeeded)
                throw new Exception("Wrong User Credentials");
            await _signInManager.SignInAsync(user, isPresistant);
            var token = await CreateToken(user);
            return new KeyValuePair<ApplicationUser, string>(user, token);
        }
        internal async Task<string> CreateToken(ApplicationUser user)
        {
            var applicationRoleNames = await _userManager.GetRolesAsync(user);
            var applicationRoleIds = _roleManager.Roles.
                Where(a => applicationRoleNames.Contains(a.Name))
            .Select(a => a.Id)
                .ToList();
            var userIdClaim = _userManager.GetClaimsAsync(user).Result.First(a => a.Type == JwtClaimTypes.Id);
            List<Claim> claims = new()
            {
                userIdClaim
            };
            SymmetricSecurityKey symmetricSecurityKey = new(
                Encoding.UTF8
                .GetBytes("fUjXn2r4u7x!A%D*G-KaPdSgVkYp3s6v8y/B?E(H+MbQeThWmZq4t7w!z$C&F)J@NcRfUjXn2r5u8x/A?D*G-KaPdSgVkYp3s6v9y$B&E)H+MbQeThWmZq4t7w!z%C*F-JaNcRfUjXn2r5u8x/A?D(G+KbPeSgVkYp3s6v9y$B&E)H@McQfTjWmZq4t7w!z%C*F-JaNdRgUkXp2r5u8x/A?D(G+KbPeShVmYq3t6v9y$B&E)H@McQfTjWnZr4u7x!z%C*F-JaNdRgUkXp2s5v8y/B?D(G+KbPeShVmYq3t6w9z$C&F)H@McQfTjWnZr4u7x!A%D*G-KaNdRgUkXp2s5v8y/B?E(H+MbQeShVmYq3t6w9z$C&F)J@NcRfUjWnZr4u7x!A%D*G-KaPdSgVkYp2s5v8y/B?E(H+MbQeThWmZq4t7w9z$C&F)J@NcRfUjXn2r5u8x/A%D*G-KaPdSgVkYp3s6v9y$B&E(H+MbQeThWmZq4t7w!z%C*F-J@Nc"));
            SigningCredentials signingCredentials = new(
                symmetricSecurityKey,
                SecurityAlgorithms.HmacSha256
                );
            JwtSecurityToken jwtSecurityToken = new(
                signingCredentials: signingCredentials,
                claims: claims,
                expires: DateTime.Now.AddMinutes(365));
            return new JwtSecurityTokenHandler().WriteToken(jwtSecurityToken);
        }
    }
}
