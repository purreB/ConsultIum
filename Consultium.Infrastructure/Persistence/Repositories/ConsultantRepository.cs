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

    public async Task<IEnumerable<Consultant>> GetAllConsultants(CancellationToken cancellationToken = default)
    => await _dbContext.consultants.ToListAsync(cancellationToken);


    public async Task<Consultant> GetConsultantById(Guid id)
    => await _dbContext.consultants.FindAsync(id);

    public void AddConsultant(Consultant consultant) => _dbContext.consultants.Add(consultant);

    public void UpdateConsultant(Consultant consultant) => _dbContext.consultants.Update(consultant);

    //public void DeleteConsultant(Consultant consultant) => _dbContext.consultants.Remove(consultant);
  }
}