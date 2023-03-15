using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Contracts;
using Domain.Entities;
using Domain.RepositoryInterface;
using Mapster;
using Services.Abstractions;
using Domain.Exceptions;

namespace Services
{
  internal sealed class ConsultantService : IConsultantService
  {

    private readonly IRepositoryManager _repositoryManager;
    public ConsultantService(IRepositoryManager repositoryManager) => _repositoryManager = repositoryManager;

    public async Task<IEnumerable<ConsultantDto>> GetAllAsync(CancellationToken cancellationToken = default)
    {
      var Consultants = await _repositoryManager.ConsultantRepository.GetAllConsultants(cancellationToken);
      var consultantDto = Consultants.Adapt<IEnumerable<ConsultantDto>>();
      return consultantDto;
    }

    public async Task<ConsultantDto> GetByIdAsync(Guid Id, CancellationToken cancellationToken = default)
    {
      var Consultant = await _repositoryManager.ConsultantRepository.GetConsultantById(Id);
      var consultantDto = Consultant.Adapt<ConsultantDto>();
      return consultantDto;
    }

    public async Task<ConsultantDto> CreateAsync(ConsultantForCreationDto consultantForCreationDto, CancellationToken cancellationToken = default)
    {
      var consultantForCreation = consultantForCreationDto.Adapt<Consultant>();
      _repositoryManager.ConsultantRepository.AddConsultant(consultantForCreation);
      await _repositoryManager.UnitOfWork.SaveChangesAsync(cancellationToken);
      var consultantToReturn = consultantForCreation.Adapt<ConsultantDto>();
      return consultantToReturn;
    }

    public async Task<ConsultantDto> UpdateConsultant(ConsultantForUpdateDto consultantForUpdateDto, Guid id, CancellationToken cancellationToken = default)
    {
      var consultantToUpdate = consultantForUpdateDto.Adapt<Consultant>();
      consultantToUpdate.ConsultantId = id;
      _repositoryManager.ConsultantRepository.UpdateConsultant(consultantToUpdate);
      await _repositoryManager.UnitOfWork.SaveChangesAsync(cancellationToken);
      var consultantToReturn = consultantToUpdate.Adapt<ConsultantDto>();
      return consultantToReturn;
    }

    // public async Task DeleteConsultant(ConsultantDto consultantDto, CancellationToken cancellationToken = default)
    // {
    //   try
    //   {
    //     // var consultantDtoToRemove = await GetByIdAsync(id);
    //     var consultantToRemove = consultantDto.Adapt<Consultant>();
    //     _repositoryManager.ConsultantRepository.DeleteConsultant(consultantToRemove);
    //     await _repositoryManager.UnitOfWork.SaveChangesAsync(cancellationToken);
    //   }
    //   catch (System.Exception)
    //   {
    //     throw;
    //   }
    // }
  }
}