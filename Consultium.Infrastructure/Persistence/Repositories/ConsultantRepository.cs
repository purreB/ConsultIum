using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Consultium.Infrastructure;
using Domain.RepositoryInterface;
using Domain.Entities;

namespace Persistence.Repositories
{
  public class ConsultantRepository : GenericRepository<Consultant>, IConsultantRepository
  {
    public ConsultantRepository(RepositoryDbContext context) : base(context)
    {
    }
  }
}