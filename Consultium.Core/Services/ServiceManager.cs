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
    public ServiceManager(IRepositoryManager repositoryManager)
    {
      _lazyCustomerService = new Lazy<ICustomerService>(() => new CustomerService(repositoryManager));
      _lazyConsultantService = new Lazy<IConsultantService>(() => new ConsultantService(repositoryManager));
    }
    public ICustomerService CustomerService => _lazyCustomerService.Value;

    public IConsultantService ConsultantService => _lazyConsultantService.Value;
  }
}