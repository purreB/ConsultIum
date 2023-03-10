using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Consultium.Infrastructure;
using Domain.RepositoryInterface;
using Domain.Entities;
using Microsoft.EntityFrameworkCore;

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

    public async Task<IEnumerable<Consultant>> GetAllConsultants() => await _dbContext.consultants.ToListAsync();


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