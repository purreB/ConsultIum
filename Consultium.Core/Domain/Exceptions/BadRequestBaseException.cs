using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Domain.Exceptions
{
  public abstract class BadRequestBaseException : Exception
  {
    protected BadRequestBaseException(string message) : base(message) { }
  }
}