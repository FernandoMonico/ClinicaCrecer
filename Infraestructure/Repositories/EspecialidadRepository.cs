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
    public class EspecialidadRepository : IEspecialidadRepository
    {
        private readonly IConfiguration _configuration;

        public EspecialidadRepository(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public async Task<GenericResponse<int>> CrearEspecialidad(Especialidad especialidad)
        {
            try
            {
                var query = "exec [SP_CrearEspecialidad] @Nombre, @Descripcion";
                var parameters = new { Nombre = especialidad.Nombre, Descripcion = especialidad.Descripcion };
                var connectionString = _configuration.GetConnectionString("ClinicaCrecer");
                await using var connection = new SqlConnection(connectionString);
                connection.Open();
                var result = await connection.QueryAsync<int>(query, parameters);
                return new GenericResponse<int>
                {
                    Data = result.FirstOrDefault(),
                    Success = true,
                    Message = "Exito al registrar la especialidad."
                };
            }
            catch (Exception ex)
            {
                return new GenericResponse<int>
                {
                    Success = false,
                    Message = "No fue posible crear la especialidad, intente mas tarde."
                };
            }
        }
    }
}
