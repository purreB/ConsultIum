namespace Domain.Exceptions
{
  public sealed class EntityNotFoundException : NotFoundBaseException
  {
    public EntityNotFoundException(Guid id) : base($"The entity with the ID: {id} was not found.") { }
  }
}