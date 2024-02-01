using Application.Repositories;
using Domain.Entities;

namespace Persistence.Repositories
{
    public sealed class DiscountRepository(DataContext dataContext) : 
        BaseRepository<Discount>(dataContext), IDiscountRepository
    {
        public async Task<ulong> SumPreFactorDiscounts(Guid preFactorHeaderId, CancellationToken cancellationToken)
        {
            _dataContext.Set<Discount>();
        }
        ~DiscountRepository() => Dispose();
    }
}
