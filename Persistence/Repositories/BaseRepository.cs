using Application.Repositories;
using Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Persistence.Repositories
{
    public class BaseRepository<T>(DataContext dataContext) : IBaseRepository<T> where T : BaseEntity
    {
        protected readonly DataContext _dataContext = dataContext;
        ~BaseRepository() =>
            Dispose();
        public async Task AddAsync(T entity, CancellationToken cancellationToken) =>
            await _dataContext.AddAsync(entity, cancellationToken);
        public void Delete(T entity)
        {
            entity.IsDeleted = true;
            entity.UpdatedDate = DateTimeOffset.UtcNow;
            _dataContext.Update(entity);
        }
        public void Dispose()
        {
            _dataContext.Dispose();
            GC.SuppressFinalize(this);
        }
        public Task<T> GetByIdAsync(Guid id, CancellationToken cancellationToken) =>
            _dataContext.Set<T>().FirstOrDefaultAsync(x => x.Id == id, cancellationToken);
        public Task<List<T>> GetAllAsync(CancellationToken cancellationToken) =>
            _dataContext.Set<T>().ToListAsync(cancellationToken);
        public Task<List<T>> GetUndeletedAsync(CancellationToken cancellationToken) =>
            _dataContext.Set<T>()
            .Where(current => !current.IsDeleted)
            .ToListAsync(cancellationToken);
        public Task<List<T>> GetUndeletedPaginationAsync(int take, int page, CancellationToken cancellationToken) =>
            _dataContext.Set<T>()
            .Where(current => !current.IsDeleted)
            .Skip(take * page)
            .Take(take)
            .ToListAsync(cancellationToken);
        public Task<int> GetUndeletedCountAsync(CancellationToken cancellationToken) =>
            _dataContext.Set<T>()
            .Where(current => !current.IsDeleted)
            .CountAsync(cancellationToken);
        public void Update(T entity)
        {
            entity.UpdatedDate = DateTimeOffset.UtcNow;
            _dataContext.Update(entity);
        }
    }
}
