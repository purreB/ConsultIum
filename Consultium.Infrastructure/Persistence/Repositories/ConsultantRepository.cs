using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Consultium.Infrastructure;
using Domain.RepositoryInterface;
using Domain.Entities;

namespace Persistence.Repositories
{
  internal sealed class ConsultantRepository : IConsultantRepository
  {
    private readonly RepositoryDbContext _dbContext;
    public ConsultantRepository(RepositoryDbContext dbContext) => _dbContext = dbContext;

    public Task AddConsultant(Consultant consultant)
    {
      throw new NotImplementedException();
    }

    public Task<IEnumerable<Consultant>> GetAllConsultants()
    {
      Console.WriteLine("Hit get all consultants inside repository");
      throw new NotImplementedException();
    }

    public Task<Consultant> GetConsultantById(Guid id)
    {
      throw new NotImplementedException();
    }

    public void UpdateConsultant(Consultant consultant)
    {
      throw new NotImplementedException();
    }
  }
}