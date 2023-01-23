using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Reflection;
using Microsoft.EntityFrameworkCore;

namespace Consultium.Infrastructure
{
  public class RepositoryDbContext : DbContext
  {
    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
      optionsBuilder.UseSqlite(@"DataSource=ConsultiumDb.db");
    }
  }
}