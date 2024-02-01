using Application.Repositories;
using Domain.Entities;

namespace Persistence.Repositories
{
    public sealed class CustomerRepository(DataContext dataContext) : 
        BaseRepository<Discount>(dataContext), ICustomerRepository
    {
        ~CustomerRepository() => Dispose();
    }
}
