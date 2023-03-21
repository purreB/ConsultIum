using Domain.Entities;

namespace Domain.RepositoryInterface
{
  public interface IConsultantRepository
  {
    Task<IEnumerable<Consultant>> GetAllConsultants(CancellationToken cancellationToken);
    Task<Consultant> GetConsultantById(Guid id);
    void AddConsultant(Consultant consultant);

    void UpdateConsultant(Consultant consultant);

    //void DeleteConsultant(Consultant consultant);
  }
}