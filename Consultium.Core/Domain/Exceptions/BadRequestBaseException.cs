namespace Domain.Exceptions
{
  public abstract class BadRequestBaseException : Exception
  {
    protected BadRequestBaseException(string message) : base(message) { }
  }
}