using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Domain.Entities
{
    public class ApplicationUser : IdentityUser<Guid>
    {
        [Required]
        public string FirstName { get; set; }
        [Required]
        public string LastName { get; set; }
        public bool IsDeleted { get; set; } = false;
        [Required]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public DateTimeOffset CreatedDate { get; set; } = DateTimeOffset.UtcNow;
        [DatabaseGenerated(DatabaseGeneratedOption.Computed)]
        public DateTimeOffset? DateUpdated { get; set; }
        public Guid? SalesLineId { get; set; }
        public SalesLine? SalesLine { get; set; }
    }
}
