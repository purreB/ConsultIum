using Contracts;
using Microsoft.AspNetCore.Mvc;
using Services.Abstractions;

namespace Consultium.Api.Controllers
{
  [ApiController]
  [Route("api/[controller]")]
  public class UsersController : ControllerBase
  {
    private readonly IServiceManager _serviceManager;
    public UsersController(IServiceManager serviceManager) => _serviceManager = serviceManager;

    [HttpGet]
    [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(IEnumerable<UserDto>))]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<IActionResult> GetAllUsers()
    {
      var Users = await _serviceManager.UserService.GetAllAsync();
      if (Users == null || Users.Count() == 0)
      {
        return NotFound("There are currently no users");
      }
      else
      {
        return Ok(Users);
      }
    }

    [HttpGet("{id}")]
    [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(UserDto))]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<IActionResult> GetById(Guid id)
    {
      var User = await _serviceManager.UserService.GetByIdAsync(id);
      if (User == null)
      {
        return NotFound($"The entity with the id: {id} was not found.");
      }

      return Ok(User);
    }
    
    [HttpPost]
    [ProducesResponseType(StatusCodes.Status201Created, Type = typeof(UserDto))]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<IActionResult> CreateUser(UserForCreationDto userForCreationDto)
    {
      var userDto = await _serviceManager.UserService.CreateAsync(userForCreationDto);
      return CreatedAtAction(nameof(GetById), new { id = userDto.UserId }, userDto);
    }
    
    // [HttpDelete("{id}")]
    // [ProducesResponseType(StatusCodes.Status204NoContent)]
    // public async Task<IActionResult> DeleteConsultant(UserDto userDto)
    // {
    //   await _serviceManager.UserService
    //   return NoContent();
    // }

  }
}