using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Contracts
{
  public class ConsultantForCreationDto
  {
    public Guid ConsultantId { get; set; }
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string[] Skills { get; set; }
    public bool HasAssignment { get; set; }
    public Guid Assignment { get; set; }
  }
}