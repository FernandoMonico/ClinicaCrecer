using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Models
{
    public class Paciente
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
        public string Dui { get; set; }
        public string TelefonoFijo { get; set; }
        public string Movil { get; set; }
        public string Sexo { get; set; }
        public string Direccion { get; set; }
        public DateTime FechaNacimiento { get; set; }
    }
}
