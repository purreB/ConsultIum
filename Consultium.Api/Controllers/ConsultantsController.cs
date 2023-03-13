using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Contracts;
using Domain.Entities;
using Domain.RepositoryInterface;
using Microsoft.AspNetCore.Mvc;
using Services;
using Services.Abstractions;

namespace Consultium.Api.Controllers
{
  [ApiController]
  [Route("api/[controller]")]
  public class ConsultantsController : ControllerBase
  {
    private readonly IServiceManager _serviceManager;
    public ConsultantsController(IServiceManager serviceManager) => _serviceManager = serviceManager;

    [HttpGet]
    [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(List<ConsultantDto>))]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<IActionResult> GetAllConsultants()
    {
      var Consultants = await _serviceManager.ConsultantService.GetAllAsync();
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
    [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(ConsultantDto))]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<IActionResult> GetById(Guid id)
    {
      var Consultant = await _serviceManager.ConsultantService.GetByIdAsync(id);
      if (Consultant == null)
      {
        return NotFound();
      }
      return Ok(Consultant);
    }

    [HttpPost]
    [ProducesResponseType(StatusCodes.Status201Created, Type = typeof(ConsultantDto))]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<IActionResult> AddConsultant(ConsultantForCreationDto consultantForCreationDto)
    {
      var consultantDto = await _serviceManager.ConsultantService.CreateAsync(consultantForCreationDto);
      return CreatedAtAction(nameof(GetById), new { id = consultantDto.ConsultantId }, consultantDto);
    }

    [HttpPatch]
    [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(ConsultantDto))]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<IActionResult> UpdateConsultant(ConsultantForUpdateDto consult)
    {
      try
      {
        var consultant = new ConsultantDto();
        consultant.ConsultantId = consult.Id;
        consultant.FirstName = consult.FirstName;
        consultant.LastName = consult.LastName;
        consultant.Skills = consult.Skills;
        consultant.HasAsignment = consult.HasAsignment;

        //! DO UNIT OF WORK COMPLETE INSIDE SERVICE
        _serviceManager.ConsultantService.UpdateConsultant(consultant);

        return CreatedAtAction(nameof(GetById), new { id = consult.Id }, consultant);
      }
      catch (System.Exception)
      {

        throw;
      }

    }
  }
}