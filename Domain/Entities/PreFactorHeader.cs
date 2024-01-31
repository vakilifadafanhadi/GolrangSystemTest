namespace Domain.Entities
{
    public class PreFactorHeader : BaseEntity
    {
        public Guid SalesLineId { get; set; }
        public SalesLine SalesLine { get; set; }
        public Guid UserId { get; set; }
        public ApplicationUser User{ get; set; }
        public Guid CustomerId { get; set; }
        public Customer Customer { get; set; }
        public byte Status { get; set; }
        public Guid? PreFactorDetailId { get; set; }
        public PreFactorDetail? PreFactorDetail { get; set; }
    }
}
