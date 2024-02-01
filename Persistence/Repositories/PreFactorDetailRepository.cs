using Application.Repositories;
using Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Persistence.Repositories
{
    public sealed class PreFactorDetailRepository(DataContext dataContext) : 
        BaseRepository<PreFactorDetail>(dataContext), IPreFactorDetailRepository
    {
        ~PreFactorDetailRepository() =>
            Dispose();

        public async Task<bool> CheckExistingProduct(Guid productId, Guid preFactorHeaderId, CancellationToken cancellationToken)
        {
            return await _dataContext.Set<PreFactorDetail>()
                .Where(preFactorDetail => preFactorDetail.ProductId == productId)
                .Where(preFactorDetail => preFactorDetail.PreFactorHeaderId == preFactorHeaderId)
                .AnyAsync(cancellationToken);
        }
    }
}
