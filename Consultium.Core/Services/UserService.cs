using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Contracts;
using Domain.Entities;
using Domain.RepositoryInterface;
using Mapster;
using Services.Abstractions;

namespace Services
{
  internal sealed class UserService : IUserService
  {
    private readonly IRepositoryManager _repositoryManager;
    public UserService(IRepositoryManager repositoryManager) => _repositoryManager = repositoryManager;
    public async Task<UserDto> CreateAsync(UserForCreationDto userForCreationDto, CancellationToken cancellationToken = default)
    {
      var userForCreation = userForCreationDto.Adapt<User>();
      _repositoryManager.UserRepository.AddUser(userForCreation);
      await _repositoryManager.UnitOfWork.SaveChangesAsync(cancellationToken);
      var userToReturn = userForCreationDto.Adapt<UserDto>();
      return userToReturn;
    }

    public async Task<IEnumerable<UserDto>> GetAllAsync(CancellationToken cancellationToken = default)
    {
      var Users = await _repositoryManager.UserRepository.GetAllUsers(cancellationToken);
      var userDto = Users.Adapt<IEnumerable<UserDto>>();
      return userDto;
    }

    public async Task<UserDto> GetByIdAsync(Guid id, CancellationToken cancellationToken = default)
    {
      var User = await _repositoryManager.UserRepository.GetUserById(id);
      var userDto = User.Adapt<UserDto>();
      return userDto;
    }

    public Task<UserDto> UpdateUser(UserForUpdateDto userForUpdateDto, Guid id, CancellationToken cancellationToken = default)
    {
      throw new NotImplementedException();
    }
  }
}