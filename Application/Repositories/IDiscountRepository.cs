using Domain.Entities;

namespace Application.Repositories
{
    public interface IDiscountRepository : IBaseRepository<Discount>
    {
        Task<decimal> SumPreFactorDiscounts(Guid preFactorHeaderId, CancellationToken cancellationToken);
    }
}
