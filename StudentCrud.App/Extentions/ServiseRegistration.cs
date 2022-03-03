using Microsoft.Extensions.DependencyInjection;
using StudentCrud.App.Interfaces;
using StudentCrud.App.Profiles;
using StudentCrud.App.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentCrud.App.Extentions
{
    public static class ServiseRegistration
    {
        public static void AddAplicationLayer(this IServiceCollection services)
        {
            services.AddAutoMapper(typeof(MappingInitializer));

            services.AddTransient<IStudentService, StudentService>();
        }
    }
}
