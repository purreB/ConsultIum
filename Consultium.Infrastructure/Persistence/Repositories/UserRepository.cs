using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Consultium.Infrastructure;
using Domain.Entities;
using Domain.RepositoryInterface;
using Microsoft.EntityFrameworkCore;

namespace Persistence.Repositories
{
  internal sealed class UserRepository : IUserRepository
  {

    private readonly RepositoryDbContext _dbContext;
    public UserRepository(RepositoryDbContext dbContext) => _dbContext = dbContext;
    public void AddUser(User user) => _dbContext.users.Add(user);

    public async Task<IEnumerable<User>> GetAllUsers(CancellationToken cancellationToken)
    {
      var users = await _dbContext.users.ToListAsync(cancellationToken);
      return users;
    }

    public async Task<User> GetUserById(Guid id) => await _dbContext.users.FindAsync(id);

    public void UpdateUser(User user)
    {
      throw new NotImplementedException();
    }
  }
}