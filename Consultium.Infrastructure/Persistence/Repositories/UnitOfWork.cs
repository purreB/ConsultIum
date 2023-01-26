using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Consultium.Infrastructure;
using Domain.RepositoryInterface;

namespace Persistence.Repositories
{
  public class UnitOfWork : IUnitOfWork
  {
    private readonly RepositoryDbContext _context;
    public IConsultantRepository Consultants { get; }

    public ICustomerRepository Customers { get; }

    public UnitOfWork(RepositoryDbContext context, IConsultantRepository consultantRepository, ICustomerRepository customerRepository)
    {
      this._context = context;
      this.Consultants = consultantRepository;
      this.Customers = customerRepository;
    }
    public int Complete()
    {
      return _context.SaveChanges();
    }

    public void Dispose()
    {
      Dispose(true);
      GC.SuppressFinalize(this);
    }

    protected virtual void Dispose(bool disposing)
    {
      if (disposing)
      {
        _context.Dispose();
      }
    }
  }
}