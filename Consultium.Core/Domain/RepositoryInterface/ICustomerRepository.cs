using Domain.Entities;

namespace Domain.RepositoryInterface
{
  public interface ICustomerRepository
  {
    Task<IEnumerable<Customer>> GetAllCustomers();
    Task<Customer> GetCustomerById(Guid id);
    Task AddCustomer(Customer customer);

    void UpdateCustomer(Customer customer);
  }
}