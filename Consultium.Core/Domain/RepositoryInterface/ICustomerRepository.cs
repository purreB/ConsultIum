using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
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