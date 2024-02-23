
using AutoMapper;
using Domain.IRepository;
using Infrastructure.Data;
using Infrastructure.Repository;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure
{
    public static class ConfigurationService
    {

        public static IServiceCollection AddInfrastructorService(this IServiceCollection service, IConfiguration configuration)
        {
              service.AddDbContext<BlogDbContext>(option =>
            {
                option.UseSqlServer(configuration.GetConnectionString("DefaultConnection"));
            });
            service.AddTransient<IBlogRepository, BlogRepository>();   

            return service;
        }



        
    }
}
