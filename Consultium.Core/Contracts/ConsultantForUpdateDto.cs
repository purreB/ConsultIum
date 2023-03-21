namespace Contracts
{
  public class ConsultantForUpdateDto
  {
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string[] Skills { get; set; }
    public bool HasAssignment { get; set; }

    public Guid Assignment { get; set; }
  }
}