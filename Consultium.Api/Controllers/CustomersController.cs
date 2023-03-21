using Microsoft.AspNetCore.Mvc;
using Contracts;
using Services.Abstractions;

namespace Consultium.Api.Controllers
{
  [ApiController]
  [Route("api/[controller]")]
  public class CustomersController : ControllerBase
  {
    private IServiceManager _serviceManager;

    public CustomersController(IServiceManager serviceManager) => _serviceManager = serviceManager;

    [HttpGet]
    [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(List<CustomerDto>))]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<IActionResult> GetAllCustomers()
    {
      var Customers = await _serviceManager.CustomerService.GetAllAsync();
      if (!Customers.Any())
      {
        return NotFound();
      }
      else
      {
        return Ok(Customers);
      }
    }

    [HttpGet("{id}")]
    [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(CustomerDto))]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<IActionResult> GetById(Guid id)
    {
      try
      {
        var Customer = await _serviceManager.CustomerService.GetByIdAsync(id);
        if (Customer == null)
        {
          return NotFound();
        }
        return Ok(Customer);
      }
      catch (System.Exception)
      {
        throw;
      }
    }
    [HttpPost]
    [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(CustomerDto))]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<IActionResult> AddCustomer(CustomerForCreationDto customerForCreationDto)
    {
      try
      {
        var customer = new CustomerForCreationDto();
        customer.CustomerId = Guid.NewGuid();
        customer.CompanyName = customerForCreationDto.CompanyName;
        customer.ConsultantIds = customerForCreationDto.ConsultantIds.ToList();

        //! DO UNIT OF WORK COMPLETE INSIDE SERVICE
        await _serviceManager.CustomerService.CreateAsync(customer);

        return CreatedAtAction(nameof(GetById), new { id = customer.CustomerId }, customer);
      }
      catch (System.Exception)
      {

        throw;
      }
    }
  }
}