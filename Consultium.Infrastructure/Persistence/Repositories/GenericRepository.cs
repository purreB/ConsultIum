using System;
using System.Linq;
using System.Threading.Tasks;
using Consultium.Infrastructure;
using Domain.RepositoryInterface;
using Microsoft.EntityFrameworkCore;

namespace Persistence.Repositories
{
  public abstract class GenericRepository<T> : IGenericRepository<T> where T : class
  {
    protected readonly RepositoryDbContext _context;
    public GenericRepository(RepositoryDbContext context)
    {
      _context = context;
    }
    public async Task<IEnumerable<T>> GetAllEntities()
    {
      return await _context.Set<T>().ToListAsync();
    }

    public async Task<T> GetEntityById(Guid id)
    {
      return await _context.Set<T>().FindAsync(id);
    }
    public async Task AddEntity(T entity)
    {
      await _context.Set<T>().AddAsync(entity);
    }
  }
}