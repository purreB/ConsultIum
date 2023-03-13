using Microsoft.Extensions.DependencyInjection;
using Domain.RepositoryInterface;
using Consultium.Infrastructure;

namespace Persistence.Repositories
{
  public static class DependencyInjection
  {
    public static IServiceCollection AddRepository(this IServiceCollection services)
    {
      services.AddTransient<IConsultantRepository, ConsultantRepository>();
      services.AddTransient<ICustomerRepository, CustomerRepository>();
      services.AddTransient<IUnitOfWork, UnitOfWork>();
      services.AddTransient<IUserRepository, UserRepository>();

      services.AddDbContext<RepositoryDbContext>();
      return services;
    }
  }

}