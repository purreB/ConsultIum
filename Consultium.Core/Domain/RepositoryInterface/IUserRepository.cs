using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Domain.Entities;

namespace Domain.RepositoryInterface
{
  public interface IUserRepository
  {
    Task<IEnumerable<User>> GetAllUsers(CancellationToken cancellationToken);
    Task<User> GetUserById(Guid id);
    void AddUser(User user);

    void UpdateUser(User user);
  }
}