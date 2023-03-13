using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Consultium.Infrastructure;
using Domain.Entities;
using Domain.RepositoryInterface;

namespace Persistence.Repositories
{
  public class UserRepository : IUserRepository
  {

    private readonly RepositoryDbContext _dbContext;
    public UserRepository(RepositoryDbContext dbContext) => _dbContext = dbContext;
    public void AddUser(User user)
    {
      throw new NotImplementedException();
    }

    public Task<IEnumerable<User>> GetAllUsers(CancellationToken cancellationToken)
    {
      throw new NotImplementedException();
    }

    public Task<User> GetUserById(Guid id)
    {
      throw new NotImplementedException();
    }

    public void UpdateUser(User user)
    {
      throw new NotImplementedException();
    }
  }
}