using Consultium.Infrastructure;
using Domain.RepositoryInterface;
using Domain.Entities;

namespace Persistence.Repositories
{
  internal sealed class CustomerRepository : ICustomerRepository
  {
    private readonly RepositoryDbContext _dbContext;
    public CustomerRepository(RepositoryDbContext dbContext) => _dbContext = dbContext;

    public Task AddCustomer(Customer customer)
    {
      throw new NotImplementedException();
    }

    public Task<IEnumerable<Customer>> GetAllCustomers()
    {
      throw new NotImplementedException();
    }

    public Task<Customer> GetCustomerById(Guid id)
    {
      throw new NotImplementedException();
    }

    public void UpdateCustomer(Customer customer)
    {
      throw new NotImplementedException();
    }
  }
}