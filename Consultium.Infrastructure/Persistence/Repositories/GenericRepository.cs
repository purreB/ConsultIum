using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Domain.RepositoryInterface;

namespace Persistence.Repositories
{
  public abstract class GenericRepository<T> : IGenericRepository<T> where T : class
  {
    public Task<T> AddEntity(T entity)
    {
      throw new NotImplementedException();
    }

    public Task<IEnumerable<T>> GetAllEntities()
    {
      throw new NotImplementedException();
    }

    public Task<T> GetEntityById(Guid id)
    {
      throw new NotImplementedException();
    }
  }
}