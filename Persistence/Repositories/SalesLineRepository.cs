using Application.Repositories;
using Domain.Entities;

namespace Persistence.Repositories
{
    public sealed class SalesLineRepository(DataContext dataContext) : BaseRepository<SalesLine>(dataContext), ISalesLineRepository
    {
        ~SalesLineRepository() => Dispose();
    }
}
