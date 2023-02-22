using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Contracts
{
  public class ConsultantDto
  {
    public Guid Id { get; set; }
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string[] Skills { get; set; }
    public bool HasAsignment { get; set; }

    public string? Assignment { get; set; }
  }
}