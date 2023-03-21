using Contracts;

namespace Services.Abstractions
{
  public interface IUserService
  {

    Task<IEnumerable<UserDto>> GetAllAsync(CancellationToken cancellationToken = default);
    Task<UserDto> GetByIdAsync(Guid id, CancellationToken cancellationToken = default);
    Task<UserDto> CreateAsync(UserForCreationDto userForCreationDto, CancellationToken cancellationToken = default);
    Task<UserDto> UpdateUser(UserForUpdateDto userForUpdateDto, Guid id, CancellationToken cancellationToken = default);
    Task DeleteUser(UserDto userDto, CancellationToken cancellationToken);
  }
}

