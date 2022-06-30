using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Application.Interfaces;
using Core.Common;
using Core.Models;
using Dapper;
using Microsoft.Extensions.Configuration;

namespace Infraestructure.Repositories
{
    public class CitaRepository : ICitaRepository
    {
        private readonly IConfiguration _configuration;

        public CitaRepository(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public async Task<GenericResponse<int>> CrearCita(Cita cita)
        {
            try
            {
                var query = "exec [SP_CrearCita] @FechaProgramada, @PacienteId, @MedicoId, @Estado";
                var parameters = new { FechaProgramada = cita.FechaProgramada, PacienteId = cita.PacienteId, MedicoId = cita.MedicoId, Estado = "Programada" };
                var connectionString = _configuration.GetConnectionString("ClinicaCrecer");
                await using var connection = new SqlConnection(connectionString);
                connection.Open();
                var result = await connection.QueryAsync<int>(query, parameters);
                return new GenericResponse<int>
                {
                    Data = result.FirstOrDefault(),
                    Success = true,
                    Message = "Exito al registrar la cita."
                };
            }
            catch (Exception ex)
            {
                return new GenericResponse<int>
                {
                    Success = false,
                    Message = "No fue posible crear la cita, intente mas tarde."
                };
            }
        }
    }
}
