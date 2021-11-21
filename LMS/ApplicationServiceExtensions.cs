using Data.Repositories;
using Domain.IRepositories;
using Domain.IServices;
using Domain.Services;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API
{
    public static class ApplicationServiceExtensions
    {
        public static IServiceCollection AddApplicationServices(this IServiceCollection services, IConfiguration config)
        {

            services.AddTransient<IBookR, BookR>();
            services.AddTransient<IBookS, BookS>();

            services.AddTransient<ICustomerService, CustomerService>();
            services.AddTransient<ICustomerRepository, CustomerRepository>();

            services.AddTransient<IReserveBookByCustomerService, ReserveBookByCustomerService>();
            services.AddTransient<IReserveBookByCustomerRepository, ReserveBookByCustomerRepository>();


            return services;

        }
    }
}
