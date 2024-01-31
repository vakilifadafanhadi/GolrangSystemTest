using Application.Repositories;
using Domain.Entities;

namespace Persistence.Repositories
{
    public sealed class CustomerRepository(DataContext dataContext) : 
        BaseRepository<Customer>(dataContext), ICustomerRepository
    {
        ~CustomerRepository() => Dispose();
    }
}
