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
#pragma warning disable CS8632 // The annotation for nullable reference types should only be used in code within a '#nullable' annotations context.
        public PreFactorDetail? PreFactorDetail { get; set; }
#pragma warning restore CS8632 // The annotation for nullable reference types should only be used in code within a '#nullable' annotations context.
    }
}
