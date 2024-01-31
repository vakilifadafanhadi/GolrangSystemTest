namespace Domain.Entities
{
    public class SalesLine : BaseEntity
    {
        public string Title { get; set; }
        public IList<Product> Products { get; set; }
        public IList<ApplicationUser> Users { get; set; }
    }
}
