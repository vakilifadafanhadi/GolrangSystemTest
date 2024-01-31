namespace Domain.Entities
{
    public class Product : BaseEntity
    {
        public string Title { get; set; }
        public Guid SalesLineId { get; set; }
        public SalesLine SalesLine { get; set; }
    }
}
