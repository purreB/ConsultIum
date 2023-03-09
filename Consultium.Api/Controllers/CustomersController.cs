using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Domain.Entities;
using Domain.RepositoryInterface;
using Microsoft.AspNetCore.Mvc;
using Contracts;

namespace Consultium.Api.Controllers
{
  [ApiController]
  [Route("api/[controller]")]
  public class CustomersController : ControllerBase
  {
    private IUnitOfWork _unitOfWork;

    public CustomersController(IUnitOfWork unitOfWork)
    {
      _unitOfWork = unitOfWork;
    }

    [HttpGet]
    [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(List<Customer>))]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<IActionResult> GetAllCustomers()
    {
      var Customers = await _unitOfWork.Customers.GetAllEntities();
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
    [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(Customer))]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<IActionResult> GetById(Guid id)
    {
      try
      {
        var Customer = await _unitOfWork.Customers.GetEntityById(id);
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
    [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(Customer))]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<IActionResult> AddCustomer(CustomerForCreationDto customerForCreationDto)
    {
      try
      {
        var customer = new Customer();
        customer.CustomerId = Guid.NewGuid();
        customer.CompanyName = customerForCreationDto.CompanyName;
        customer.ConsultantIds = customerForCreationDto.ConsultantIds.ToList();

        await _unitOfWork.Customers.AddEntity(customer);
        _unitOfWork.Complete();

        return CreatedAtAction(nameof(GetById), new { id = customer.CustomerId }, customer);
      }
      catch (System.Exception)
      {

        throw;
      }
    }
  }
}