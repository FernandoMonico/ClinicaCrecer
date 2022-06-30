using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Application.Interfaces;

namespace Infraestructure.Repositories
{
    public class UnitOfWork : IUnitOfWork
    {
        public UnitOfWork(IPacienteRepository pacienteRepository, IMedicoRepository medicoRepository, IEspecialidadRepository especialidadRepository, ICitaRepository citaRepository)
        {
            Paciente = pacienteRepository;
            Medico = medicoRepository;
            Especialidad = especialidadRepository;
            Cita = citaRepository;
        }
        public IPacienteRepository Paciente { get; }
        public IMedicoRepository Medico { get; }
        public IEspecialidadRepository Especialidad { get; }
        public ICitaRepository Cita { get; }
    }
}
