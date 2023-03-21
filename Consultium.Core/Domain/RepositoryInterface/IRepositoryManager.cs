namespace Domain.RepositoryInterface
{
  public interface IRepositoryManager
  {
    IConsultantRepository ConsultantRepository { get; }
    ICustomerRepository CustomerRepository { get; }
    IUserRepository UserRepository { get; }
    IUnitOfWork UnitOfWork { get; }
  }
}