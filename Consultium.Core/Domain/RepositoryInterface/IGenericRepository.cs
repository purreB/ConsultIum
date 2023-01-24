using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Domain.RepositoryInterface
{
  public interface IGenericRepository<T> where T : class
  {
    Task<IEnumerable<T>> GetAllEntities();
    Task<T> GetEntityById(Guid id);
    Task AddEntity(T entity);
  }
}