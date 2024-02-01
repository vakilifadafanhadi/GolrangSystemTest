using Domain.Entities;

namespace Application.Repositories
{
    public interface IPreFactorDetailRepository : IBaseRepository<PreFactorDetail>
    {
        Task<bool> CheckExistingProduct(Guid productId, Guid preFactorHeaderId, CancellationToken cancellationToken);
    }
}
