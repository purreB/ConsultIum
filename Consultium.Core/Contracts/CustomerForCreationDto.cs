using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Contracts
{
  public class CustomerForCreationDto
  {
    public Guid CustomerId { get; set; }
    public string CompanyName { get; set; }
    public List<Guid> ConsultantIds { get; set; }
  }
}