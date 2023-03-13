using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Domain.RepositoryInterface
{
  public interface IRepositoryManager
  {
    IConsultantRepository ConsultantRepository { get; }
    ICustomerRepository CustomerRepository { get; }
    IUnitOfWork UnitOfWork { get; }
  }
}