using Librerias.Entities.Interfaces;
using Librerias.Interfaces.DataContext;
using Librerias.Interfaces.Repository;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Text;

namespace Librerias.Interfaces
{
    public static class DependencyContainer
    {
        public static IServiceCollection AddRepositories(
            this IServiceCollection services,
            IConfiguration configuration)
        {
            services.AddDbContext<LibreriaDbContext>(options =>
            options.UseSqlServer(configuration.GetConnectionString("AppConection")));


            services.AddScoped<IRepositorys, Repositorys>();
            services.AddScoped<ILibroRepository, LibroRepository>();

            return services;
        }
    }
}
