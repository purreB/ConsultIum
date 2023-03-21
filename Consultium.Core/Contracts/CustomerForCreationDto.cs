namespace Contracts
{
  public class CustomerForCreationDto
  {
    public Guid CustomerId { get; set; }
    public string CompanyName { get; set; }
    public List<Guid> ConsultantIds { get; set; }
  }
}