namespace Application.Repositories
{
    public interface IUnitOfWork : IDisposable
    {
        Task SaveAsync(CancellationToken cancellationToken);
    }
}
