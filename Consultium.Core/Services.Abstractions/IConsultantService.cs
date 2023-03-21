using Contracts;

namespace Services.Abstractions
{
  public interface IConsultantService
  {
    Task<IEnumerable<ConsultantDto>> GetAllAsync(CancellationToken cancellationToken = default);
    Task<ConsultantDto> GetByIdAsync(Guid Id, CancellationToken cancellationToken = default);
    Task<ConsultantDto> CreateAsync(ConsultantForCreationDto consultantForCreationDto, CancellationToken cancellationToken = default);
    Task<ConsultantDto> UpdateConsultant(ConsultantForUpdateDto consultantToUpdate, Guid id, CancellationToken cancellationToken = default);

    //Task DeleteConsultant(ConsultantDto consultantDto, CancellationToken cancellationToken = default);
  }
}