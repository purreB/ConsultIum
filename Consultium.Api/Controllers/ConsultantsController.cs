using Contracts;
using Microsoft.AspNetCore.Mvc;
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
        return NotFound("There are no currently no consultants");
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
        return NotFound($"The entity with the id: '{id}' was not found.");
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

    [HttpPatch("{id}")]
    [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(ConsultantDto))]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<IActionResult> UpdateConsultant(ConsultantForUpdateDto consultant, Guid id)
    {
      var consultantDto = await _serviceManager.ConsultantService.UpdateConsultant(consultant, id);
      return CreatedAtAction(nameof(GetById), new { id = consultantDto.ConsultantId }, consultantDto);
    }

    // [HttpDelete("{id}")]
    // [ProducesResponseType(StatusCodes.Status204NoContent)]
    // public async Task<IActionResult> DeleteConsultant(ConsultantDto consultantDto)
    // {
    //   await _serviceManager.ConsultantService.DeleteConsultant(consultantDto);
    //   return NoContent();
    // }
  }
}