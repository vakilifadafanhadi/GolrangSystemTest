using Application.Repositories;
using Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Persistence.Repositories
{
    public sealed class DiscountRepository(DataContext dataContext) : 
        BaseRepository<Discount>(dataContext), IDiscountRepository
    {
        public async Task<ulong> SumPreFactorDiscounts(Guid preFactorHeaderId, CancellationToken cancellationToken)
        {
            var list = await _dataContext.Set<Discount>()
                .Where(discount => discount.IsDeleted == false)
                .Where(discount => discount.PreFactorHeaderId == preFactorHeaderId)
                .SumAsync(current => current.Amount, cancellationToken);
        }
        ~DiscountRepository() => Dispose();
    }
}
