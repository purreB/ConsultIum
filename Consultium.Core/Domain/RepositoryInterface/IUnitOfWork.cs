namespace Domain.RepositoryInterface
{
  public interface IUnitOfWork : IDisposable
  {
    IConsultantRepository Consultants { get; }
    ICustomerRepository Customers { get; }
    IUserRepository Users { get; }
    Task<int> SaveChangesAsync(CancellationToken cancellationToken = default);
  }
}