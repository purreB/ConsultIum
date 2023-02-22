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
    public DbSet<Consultant> consultants { get; set; }
    public DbSet<Customer> customers { get; set; }
    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
      optionsBuilder.UseNpgsql(@"Host=localhost;Username=postgres;Password=root;Database=ConsultiumDb", b => b.MigrationsAssembly("Consultium.Api"))
      .UseSnakeCaseNamingConvention();
      // options.UseSqlServer(connection, b => b.MigrationsAssembly("Consultium.Api"))
      //optionsBuilder.UseSqlite(@"DataSource=ConsultiumDb.db");
    }
    public RepositoryDbContext(DbContextOptions<RepositoryDbContext> options) : base(options)
    { }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
      // modelBuilder.HasDefaultSchema("public");
      // base.OnModelCreating(modelBuilder);

      //   modelBuilder.Entity<Consultant>(entity =>
      // {
      //   entity.HasOne(x => x.Customer)
      //     .WithOne()
      //     .HasForeignKey("CustomerId");
      // });
    }
  }
}