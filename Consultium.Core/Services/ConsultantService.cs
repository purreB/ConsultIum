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

    public Task<ConsultantForCreationDto> CreateAsync(ConsultantForCreationDto consultantForCreationDto, CancellationToken cancellationToken = default)
    {
      throw new NotImplementedException();
    }

    public async Task<IEnumerable<ConsultantDto>> GetAllAsync(CancellationToken cancellationToken = default)
    {
      Console.WriteLine("Hit get all async inside service");
      var Consultants = await _repositoryManager.ConsultantRepository.GetAllConsultants();
      if (Consultants == null)
      {
        throw new ArgumentException(nameof(Consultants));
      }
      var consultantDto = Consultants.Adapt<IEnumerable<Consultant>>();
      return (IEnumerable<ConsultantDto>)consultantDto;
    }

    public Task<ConsultantDto> GetByIdAsync(Guid Id, CancellationToken cancellationToken = default)
    {
      throw new NotImplementedException();
    }

    public void UpdateConsultant(ConsultantDto consultantToUpdate, CancellationToken cancellationToken = default)
    {
      throw new NotImplementedException();
    }
  }
}