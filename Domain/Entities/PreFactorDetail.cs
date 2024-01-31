namespace Domain.Entities
{
    public class PreFactorDetail : BaseEntity
    {
        public Guid ProductId { get; set; }
        public Product Product { get; set; }
        public int Quantity { get; set; }
        public ulong Price { get; set; }
        public Guid PreFactorHeaderId { get; set; }
        public PreFactorHeader PreFactorHeader { get; set; }
    }
}
