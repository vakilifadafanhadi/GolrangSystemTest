using System.Diagnostics.CodeAnalysis;

namespace Domain.Entities
{
    public class Discount : BaseEntity
    {
        public Guid PreFactorHeaderId { get; set; }
        public PreFactorHeader PreFactorHeader { get; set; }
        [AllowNull]
        public Guid? PreFactorDetailId { get; set; }
        public PreFactorDetail PreFactorDetail { get; set; }
        public byte Type { get; set; }
        public ulong Amount { get; set; }

    }
}
