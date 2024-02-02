using Application.Repositories;
using Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Persistence.Repositories
{
    public sealed class DiscountRepository(DataContext dataContext) : 
        BaseRepository<Discount>(dataContext), IDiscountRepository
    {
        public async Task<decimal> SumPreFactorDiscounts(Guid preFactorHeaderId, CancellationToken cancellationToken) =>
            await _dataContext.Set<Discount>()
            .Where(discount => discount.IsDeleted == false)
            .Where(discount => discount.PreFactorHeaderId == preFactorHeaderId)
            .SumAsync(discount => (decimal)discount.Amount, cancellationToken);
        ~DiscountRepository() => Dispose();
    }
}
