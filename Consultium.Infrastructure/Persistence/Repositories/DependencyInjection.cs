using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Extensions.DependencyInjection;
using Domain.RepositoryInterface;
using Microsoft.EntityFrameworkCore;
using Consultium.Infrastructure;

namespace Persistence.Repositories
{
  public static class DependencyInjection
  {
    public static IServiceCollection AddRepository(this IServiceCollection services)
    {
      services.AddTransient<IConsultantRepository, ConsultantRepository>();
      services.AddTransient<ICustomerRepository, CustomerRepository>();
      //services.AddTransient<IUnitOfWork, UnitOfWork>();

      services.AddDbContext<RepositoryDbContext>(opt => opt
          .UseSqlServer("Server=localhost,1433; Database=BooksDB;User Id=sa; Password=password_01;"));
      return services;
    }
  }

}