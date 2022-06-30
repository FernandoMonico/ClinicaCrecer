﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Models
{
    public class Cita
    {
        public int? Id { get; set; }
        public DateTime FechaProgramada { get; set; }
        public int PacienteId { get; set; }
        public int MedicoId { get; set; }
        public string? Estado { get; set; }
        public string? Diagnostico { get; set; }
    }
}
