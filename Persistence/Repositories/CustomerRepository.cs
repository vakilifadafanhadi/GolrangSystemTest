using Application.Repositories;
using Domain.Entities;

namespace Persistence.Repositories
{
    public sealed class DiscountRepository(DataContext dataContext) : 
        BaseRepository<Discount>(dataContext), IDiscountRepository
    {
        ~DiscountRepository() => Dispose();
    }
}
