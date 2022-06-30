using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Application.Interfaces;
using Infraestructure.Repositories;
using Microsoft.Extensions.DependencyInjection;

namespace Infraestructure
{
    public static class ServiceRegistration
    {
        public static void AddInfraesctructure(this IServiceCollection services)
        {
            services.AddTransient<IPacienteRepository, PacienteRepository>();
            services.AddTransient<IMedicoRepository, MedicoRepository>();
            services.AddTransient<ICitaRepository, CitaRepository>();
            services.AddTransient<IEspecialidadRepository, EspecialidadRepository>();
            services.AddTransient<IUnitOfWork, UnitOfWork>();
        }
    }
}
