using Domain.IServices;
using Domain.Services;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System.Linq;

namespace LMS
{
    public class ScopeServices
    {
           public ScopeServices(IServiceCollection services) {
            services.AddScoped<ICustomerService, CustomerService>().Reverse();
            }
       
     }
    
}