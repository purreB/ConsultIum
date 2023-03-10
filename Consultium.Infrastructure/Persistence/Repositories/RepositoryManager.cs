using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Consultium.Infrastructure;
using Domain.RepositoryInterface;

namespace Persistence.Repositories
{
  public sealed class RepositoryManager : IRepositoryManager
  {
    private readonly Lazy<ICustomerRepository> _lazyCustomerRepository;
    private readonly Lazy<IConsultantRepository> _lazyConsultantRepository;
    private readonly Lazy<IUnitOfWork> _lazyUnitOfWork;
    public RepositoryManager(RepositoryDbContext dbContext)
    {
      _lazyCustomerRepository = new Lazy<ICustomerRepository>(() => new CustomerRepository(dbContext));
      _lazyConsultantRepository = new Lazy<IConsultantRepository>(() => new ConsultantRepository(dbContext));
      _lazyUnitOfWork = new Lazy<IUnitOfWork>(() => new UnitOfWork(dbContext));
    }
    public ICustomerRepository CustomerRepository => _lazyCustomerRepository.Value;
    public IConsultantRepository ConsultantRepository => _lazyConsultantRepository.Value;
    public IUnitOfWork UnitOfWork => _lazyUnitOfWork.Value;
  }
}