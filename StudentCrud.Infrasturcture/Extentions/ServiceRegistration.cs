using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using StudentCrud.Infrasturcture.Interfaces;
using StudentCrud.Infrasturcture.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentCrud.Infrasturcture.Extentions
{
    public static class ServiceRegistration
    {
        public static void AddInfrastructure(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<AppDbContext>(options => options.UseSqlServer
            (
                configuration.GetConnectionString("DefaultSqlServerConnection"
            )));

            services.AddScoped(typeof(IGenericRepositoryAsync<>), typeof(GenericRepositoryAsync<>));

            services.AddScoped<IStudentRepositoryAsync, StudentRepositoryAsync>();

        }
    }
}
