using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Contracts;
using Domain.Entities;
using Domain.RepositoryInterface;
using Microsoft.AspNetCore.Mvc;

namespace Consultium.Api.Controllers
{
  [ApiController]
  [Route("api/[controller]")]
  public class ConsultantsController : ControllerBase
  {
    private IUnitOfWork _unitOfWork;

    public ConsultantsController(IUnitOfWork unitOfWork)
    {
      _unitOfWork = unitOfWork;
    }

    [HttpGet]
    [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(List<ConsultantDto>))]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<IActionResult> GetAllConsultants()
    {
      var Consultants = await _unitOfWork.Consultants.GetAllEntities();
      if (!Consultants.Any())
      {
        return NotFound();
      }
      else
      {
        return Ok(Consultants);
      }
    }

    [HttpGet("{id}")]
    [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(Consultant))]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<IActionResult> GetById(Guid id)
    {
      try
      {
        var consultant = await _unitOfWork.Consultants.GetEntityById(id);
        if (consultant == null)
        {
          return NotFound();
        }
        return Ok(consultant);
      }
      catch (System.Exception)
      {
        throw;
      }
    }

    [HttpPost]
    [ProducesResponseType(StatusCodes.Status201Created, Type = typeof(Consultant))]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<IActionResult> AddConsultant(ConsultantForCreationDto consultantForCreationDto)
    {
      var consultant = new Consultant();
      consultant.ConsultantId = Guid.NewGuid();
      consultant.FirstName = consultantForCreationDto.FirstName;
      consultant.LastName = consultantForCreationDto.LastName;
      consultant.Skills = consultantForCreationDto.Skills;
      consultant.HasAsignment = consultantForCreationDto.HasAsignment;

      await _unitOfWork.Consultants.AddEntity(consultant);
      _unitOfWork.Complete();
      return CreatedAtAction(nameof(GetById), new { id = consultant.ConsultantId }, consultant);
    }

    [HttpPatch]
    [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(Consultant))]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<IActionResult> UpdateConsultant(ConsultantForUpdateDto consult)
    {
      try
      {
        var consultant = new Consultant();
        consultant.ConsultantId = consult.Id;
        consultant.FirstName = consult.FirstName;
        consultant.LastName = consult.LastName;
        consultant.Skills = consult.Skills;
        consultant.HasAsignment = consult.HasAsignment;

        _unitOfWork.Consultants.UpdateEntity(consultant);
        _unitOfWork.Complete();

        return CreatedAtAction(nameof(GetById), new { id = consult.Id }, consultant);
      }
      catch (System.Exception)
      {

        throw;
      }

    }
  }
}