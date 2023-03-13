using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Contracts;

namespace Services.Abstractions
{
  public interface IUserService
  {

    Task<IEnumerable<UserDto>> GetAllAsync(CancellationToken cancellationToken = default);
    Task<UserDto> GetByIdAsync(Guid Id, CancellationToken cancellationToken = default);
    Task<UserDto> CreateAsync(UserForCreationDto userForCreationDto, CancellationToken cancellationToken = default);
    Task<UserDto> UpdateUser(UserForUpdateDto userForUpdateDto, Guid id, CancellationToken cancellationToken = default);
  }
}

