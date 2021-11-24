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

            services.AddScoped<IBookRepository, BookRepository>();
            services.AddScoped<IBookService, BookS>();

            services.AddScoped<ICustomerService, CustomerService>();
            services.AddScoped<ICustomerRepository, CustomerRepository>();

            services.AddScoped<IReserveBookByCustomerService, ReserveBookByCustomerService>();
            services.AddScoped<IReserveBookByCustomerRepository, ReserveBookByCustomerRepository>();

            services.AddScoped<IPublisherRepository, PublisherRepository>();
            services.AddScoped<IPublisherService, PublisherS>();


            return services;

        }
    }
}
