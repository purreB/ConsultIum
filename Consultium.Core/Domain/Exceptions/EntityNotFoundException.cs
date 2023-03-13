using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Domain.Exceptions
{
  public sealed class EntityNotFoundException : NotFoundBaseException
  {
    public EntityNotFoundException(Guid id) : base($"The entity with the ID: {id} was not found.") { }
  }
}