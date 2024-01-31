using Domain.Entities;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
namespace Persistence
{
    public class DataContext(DbContextOptions<DataContext> dbContextOptions) : 
        IdentityDbContext<ApplicationUser, ApplicationRole, Guid>(dbContextOptions)
    {
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
        }
    }
}
