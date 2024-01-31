using Application.Repositories;
using Domain.Entities;

namespace Persistence.Repositories
{
    public sealed class ProductRepository(DataContext dataContext) : BaseRepository<Product>(dataContext), IProductRepository
    {
    }
}
