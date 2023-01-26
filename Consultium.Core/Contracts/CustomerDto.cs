using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Contracts
{
  public class CustomerDto
  {
    public Guid CustomerId { get; set; }
    public string CompanyName { get; set; }
    public string[] Consultants { get; set; }
  }
}