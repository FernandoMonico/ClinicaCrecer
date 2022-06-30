using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Interfaces
{
    public interface IUnitOfWork
    {
        public IPacienteRepository Paciente { get; }
        public IMedicoRepository Medico { get; }
        public IEspecialidadRepository Especialidad { get; }
        public ICitaRepository Cita { get; }
    }
}
