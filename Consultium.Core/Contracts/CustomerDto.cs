namespace Contracts
{
  public class CustomerDto
  {
    public Guid CustomerId { get; set; }
    public string CompanyName { get; set; }
    public string[] Consultants { get; set; }
  }
}