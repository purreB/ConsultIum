using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Contracts;

namespace Services.Abstractions
{
  public interface IConsultantService
  {
    Task<IEnumerable<ConsultantDto>> GetAllAsync(CancellationToken cancellationToken = default);
    Task<ConsultantDto> GetByIdAsync(Guid Id, CancellationToken cancellationToken = default);
    Task<ConsultantDto> CreateAsync(ConsultantForCreationDto consultantForCreationDto, CancellationToken cancellationToken = default);
    Task<ConsultantDto> UpdateConsultant(ConsultantForUpdateDto consultantToUpdate, Guid id, CancellationToken cancellationToken = default);
  }
}