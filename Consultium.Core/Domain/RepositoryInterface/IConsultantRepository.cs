using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Domain.Entities;

namespace Domain.RepositoryInterface
{
  public interface IConsultantRepository
  {
    Task<IEnumerable<Consultant>> GetAllConsultants();
    Task<Consultant> GetConsultantById(Guid id);
    Task AddConsultant(Consultant consultant);

    void UpdateConsultant(Consultant consultant);
  }
}