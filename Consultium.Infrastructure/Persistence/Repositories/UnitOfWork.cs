using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Consultium.Infrastructure;
using Domain.RepositoryInterface;

namespace Persistence.Repositories
{
  internal class UnitOfWork : IUnitOfWork
  {
    private readonly RepositoryDbContext _dbContext;
    public IConsultantRepository Consultants { get; }

    public IUserRepository Users { get; }

    public ICustomerRepository Customers { get; }
    public UnitOfWork(RepositoryDbContext dbContext) => _dbContext = dbContext;

    public UnitOfWork(RepositoryDbContext context, IConsultantRepository consultantRepository, ICustomerRepository customerRepository, IUserRepository userRepository)
    {
      this._dbContext = context;
      this.Consultants = consultantRepository;
      this.Customers = customerRepository;
      this.Users = userRepository;
    }


    public Task<int> SaveChangesAsync(CancellationToken cancellationToken = default) => _dbContext.SaveChangesAsync(cancellationToken);

    public void Dispose()
    {
      Dispose(true);
      GC.SuppressFinalize(this);
    }

    protected virtual void Dispose(bool disposing)
    {
      if (disposing)
      {
        _dbContext.Dispose();
      }
    }
  }
}