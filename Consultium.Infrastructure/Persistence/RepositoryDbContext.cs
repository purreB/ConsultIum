using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Reflection;
using Microsoft.EntityFrameworkCore;
using Domain.Entities;

namespace Consultium.Infrastructure
{
  public class RepositoryDbContext : DbContext
  {
    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
      optionsBuilder.UseSqlite(@"DataSource=ConsultiumDb.db");
    }
    public RepositoryDbContext(DbContextOptions<RepositoryDbContext> options) : base(options)
    { }
    public DbSet<Consultant> Consultants { get; set; }
    public DbSet<Customer> Customers { get; set; }
  }
}