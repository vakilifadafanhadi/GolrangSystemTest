using Application.Repositories;
using Domain.Entities;

namespace Persistence.Repositories
{
    public sealed class PreFactorHeaderRepository(DataContext dataContext) : 
        BaseRepository<PreFactorHeader>(dataContext), IPreFactorHeaderRepository
    {
        ~PreFactorHeaderRepository() =>
            Dispose();
    }
}
