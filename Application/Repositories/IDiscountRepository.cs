using Domain.Entities;

namespace Application.Repositories
{
    public interface IDiscountRepository : IBaseRepository<Discount>
    {
        Task<ulong> SumPreFactorDiscounts(Guid preFactorHeaderId, CancellationToken cancellationToken);
    }
}
