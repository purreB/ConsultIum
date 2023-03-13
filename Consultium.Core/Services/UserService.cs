using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Contracts;
using Domain.RepositoryInterface;
using Mapster;
using Services.Abstractions;

namespace Services
{
  internal sealed class UserService : IUserService
  {
    private readonly IRepositoryManager _repositoryManager;
    public UserService(IRepositoryManager repositoryManager) => _repositoryManager = repositoryManager;
    public Task<UserDto> CreateAsync(UserForCreationDto userForCreationDto, CancellationToken cancellationToken = default)
    {
      throw new NotImplementedException();
    }

    public async Task<IEnumerable<UserDto>> GetAllAsync(CancellationToken cancellationToken = default)
    {
      var Users = await _repositoryManager.UserRepository.GetAllUsers(cancellationToken);
      var userDto = Users.Adapt<IEnumerable<UserDto>>();
      return userDto;
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