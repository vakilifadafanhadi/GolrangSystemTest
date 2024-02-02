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

        public async Task<decimal> SumCustomerPriceAsync(Guid preFactorHeaderId, Guid customerId, CancellationToken cancellationToken) =>
            await _dataContext.Set<PreFactorDetail>()
            .Where(preFactorDetail => preFactorDetail.IsDeleted == false)
            .Where(preFactorDetail => preFactorDetail.PreFactorHeaderId == preFactorHeaderId)
            .Where(preFactorDetail => preFactorDetail.PreFactorHeader.CustomerId == customerId)
            .SumAsync(prefactorDetail => (decimal)prefactorDetail.Price, cancellationToken);

        public async Task<decimal> SumPriceAsync(Guid preFactorHeaderId, CancellationToken cancellationToken) =>
            await _dataContext.Set<PreFactorDetail>()
            .Where(preFactorDetail => preFactorDetail.IsDeleted == false)
            .Where(preFactorDetail => preFactorDetail.PreFactorHeaderId == preFactorHeaderId)
            .SumAsync(prefactorDetail => (decimal)prefactorDetail.Price, cancellationToken);
    }
}
