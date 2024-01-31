using Domain.Entities;

namespace Application.Repositories
{
    public interface IBaseRepository<T> : IDisposable where T : BaseEntity
    {
        Task AddAsync(T entity, CancellationToken cancellationToken);
        void Update(T entity);
        void Delete(T entity);
        Task<T> GetByIdAsync(Guid id, CancellationToken cancellationToken);
        Task<List<T>> GetAllAsync(CancellationToken cancellationToken);
        Task<List<T>> GetUndeletedAsync(CancellationToken cancellationToken);
        Task<List<T>> GetUndeletedPaginationAsync(int take, int page, CancellationToken cancellationToken);
        Task<int> GetUndeletedCountAsync(CancellationToken cancellationToken);
    }
}
