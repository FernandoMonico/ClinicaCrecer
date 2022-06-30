using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.DTOs
{
    public class PacienteDto
    {
        public string Nombre { get; set; }
        public string Dui { get; set; }
        public string TelefonoFijo { get; set; }
        public string Movil { get; set; }
        public string Sexo { get; set; }
        public string Direccion { get; set; }
        public string FechaNacimiento { get; set; }
    }
}
