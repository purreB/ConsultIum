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
    Task<ConsultantForCreationDto> CreateAsync(ConsultantForCreationDto consultantForCreationDto, CancellationToken cancellationToken = default);
    void UpdateConsultant(ConsultantDto consultantToUpdate, CancellationToken cancellationToken = default);
  }
}