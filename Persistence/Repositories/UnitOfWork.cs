using Application.Repositories;

namespace Persistence.Repositories
{
    public sealed class UnitOfWork(DataContext dataContext) : IUnitOfWork
    {
        private readonly DataContext _dataContext = dataContext;
        public Task SaveAsync(CancellationToken cancellationToken) =>
            _dataContext.SaveChangesAsync(cancellationToken);
        public void Dispose()
        {
            _dataContext.Dispose();
            GC.SuppressFinalize(this);
        }
        ~UnitOfWork() =>
            Dispose();
    }
}
