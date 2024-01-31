using Application.Repositories;
using Domain.Entities;

namespace Persistence.Repositories
{
    public sealed class PreFactorDetailRepository(DataContext dataContext) : 
        BaseRepository<PreFactorDetail>(dataContext), IPreFactorDetailRepository
    {
        ~PreFactorDetailRepository() =>
            Dispose();
    }
}
