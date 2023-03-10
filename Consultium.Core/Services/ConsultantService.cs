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
  internal sealed class ConsultantService : IConsultantService
  {

    private readonly IRepositoryManager _repositoryManager;
    public ConsultantService(IRepositoryManager repositoryManager) => _repositoryManager = repositoryManager;

    public async Task<ConsultantForCreationDto> CreateAsync(ConsultantForCreationDto consultantForCreationDto, CancellationToken cancellationToken = default)
    {
      var consultatForCreation = consultantForCreationDto.Adapt<Consultant>();
      _repositoryManager.ConsultantRepository.AddConsultant(consultatForCreation);
      await _repositoryManager.UnitOfWork.SaveChangesAsync(cancellationToken);
      return consultatForCreation.Adapt<ConsultantForCreationDto>();
    }

    public async Task<IEnumerable<ConsultantDto>> GetAllAsync(CancellationToken cancellationToken = default)
    {
      var Consultants = await _repositoryManager.ConsultantRepository.GetAllConsultants(cancellationToken);
      if (Consultants == null)
      {
        throw new ArgumentException(nameof(Consultants));
      }
      var consultantDto = Consultants.Adapt<IEnumerable<ConsultantDto>>();
      return consultantDto;
    }

    public async Task<ConsultantDto> GetByIdAsync(Guid Id, CancellationToken cancellationToken = default)
    {
      var Consultant = await _repositoryManager.ConsultantRepository.GetConsultantById(Id);
      if (Consultant == null)
      {
        throw new ArgumentException(nameof(Consultant));
      }
      var consultantDto = Consultant.Adapt<ConsultantDto>();
      return consultantDto;
    }

    public void UpdateConsultant(ConsultantDto consultantToUpdate, CancellationToken cancellationToken = default)
    {
      throw new NotImplementedException();
    }
  }
}