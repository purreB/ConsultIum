namespace Services.Abstractions
{
  public interface IServiceManager
  {
    ICustomerService CustomerService { get; }
    IConsultantService ConsultantService { get; }
    IUserService UserService { get; }
  }
}