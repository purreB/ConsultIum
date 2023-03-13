using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Services.Abstractions;
using Domain.RepositoryInterface;

namespace Services
{
  public sealed class ServiceManager : IServiceManager
  {
    private readonly Lazy<ICustomerService> _lazyCustomerService;
    private readonly Lazy<IConsultantService> _lazyConsultantService;

    private readonly Lazy<IUserService> _lazyUserService;
    public ServiceManager(IRepositoryManager repositoryManager)
    {
      _lazyCustomerService = new Lazy<ICustomerService>(() => new CustomerService(repositoryManager));
      _lazyConsultantService = new Lazy<IConsultantService>(() => new ConsultantService(repositoryManager));
      _lazyUserService = new Lazy<IUserService>(() => new UserService(repositoryManager));
    }
    public ICustomerService CustomerService => _lazyCustomerService.Value;

    public IUserService UserService => _lazyUserService.Value;

    public IConsultantService ConsultantService => _lazyConsultantService.Value;
  }
}