using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Contracts
{
  public class CustomerForCreationDto
  {
    public string CompanyName { get; set; }
    public Guid[] ConsultantIds { get; set; }
  }
}