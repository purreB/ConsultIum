using Contracts;
using Domain.RepositoryInterface;
using Services.Abstractions;

namespace Services
{
  internal sealed class CustomerService : ICustomerService

  {

    private readonly IRepositoryManager _repositoryManager;
    public CustomerService(IRepositoryManager repositoryManager) => _repositoryManager = repositoryManager;
    public Task<CustomerForCreationDto> CreateAsync(CustomerForCreationDto customerForCreationDto, CancellationToken cancellationToken = default)
    {
      throw new NotImplementedException();
    }

    public Task<IEnumerable<CustomerDto>> GetAllAsync(CancellationToken cancellationToken = default)
    {
      throw new NotImplementedException();
    }

    public Task<CustomerDto> GetByIdAsync(Guid Id, CancellationToken cancellationToken = default)
    {
      throw new NotImplementedException();
    }

    public void UpdateCustomer(CustomerDto customerToUpdate, CancellationToken cancellationToken = default)
    {
      throw new NotImplementedException();
    }
  }
}