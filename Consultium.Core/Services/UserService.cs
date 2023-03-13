using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Contracts;
using Domain.RepositoryInterface;
using Services.Abstractions;

namespace Services
{
  public class UserService : IUserService
  {
    private readonly IRepositoryManager _repositoryManager;
    public UserService(IRepositoryManager repositoryManager) => _repositoryManager = repositoryManager;
    public Task<UserDto> CreateAsync(UserForCreationDto userForCreationDto, CancellationToken cancellationToken = default)
    {
      throw new NotImplementedException();
    }

    public Task<IEnumerable<UserDto>> GetAllAsync(CancellationToken cancellationToken = default)
    {
      throw new NotImplementedException();
    }

    public Task<UserDto> GetByIdAsync(Guid Id, CancellationToken cancellationToken = default)
    {
      throw new NotImplementedException();
    }

    public Task<UserDto> UpdateUser(UserForUpdateDto userForUpdateDto, Guid id, CancellationToken cancellationToken = default)
    {
      throw new NotImplementedException();
    }
  }
}