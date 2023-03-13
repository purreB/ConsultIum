using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Domain.RepositoryInterface
{
  public interface IUnitOfWork : IDisposable
  {
    IConsultantRepository Consultants { get; }
    ICustomerRepository Customers { get; }
    IUserRepository Users { get; }
    Task<int> SaveChangesAsync(CancellationToken cancellationToken = default);
  }
}