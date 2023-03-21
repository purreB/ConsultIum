namespace Domain.Exceptions
{
  public abstract class NotFoundBaseException : Exception
  {
    protected NotFoundBaseException(string message) : base(message) { }
  }
}