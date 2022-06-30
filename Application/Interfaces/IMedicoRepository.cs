using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Core.Common;
using Core.Models;

namespace Application.Interfaces
{
    public interface IMedicoRepository
    {
        Task<GenericResponse<int>> CrearMedico(Medico medico);
    }
}
