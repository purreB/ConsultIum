using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Contracts;

namespace Services.Abstractions
{
  public interface ICustomerService
  {
    Task<IEnumerable<CustomerDto>> GetAllAsync(CancellationToken cancellationToken = default);
    Task<CustomerDto> GetByIdAsync(Guid Id, CancellationToken cancellationToken = default);
    Task<CustomerForCreationDto> CreateAsync(CustomerForCreationDto customerForCreationDto, CancellationToken cancellationToken = default);
    void UpdateCustomer(CustomerDto customerToUpdate, CancellationToken cancellationToken = default);
  }
}