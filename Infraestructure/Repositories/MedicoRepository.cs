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
    public class MedicoRepository : IMedicoRepository
    {
        private readonly IConfiguration _configuration;

        public MedicoRepository(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public async Task<GenericResponse<int>> CrearMedico(Medico medico)
        {
            try
            {
                var query = "exec [SP_CrearMedico] @Nombre, @Dui, @TelefonoFijo, @Movil, @Sexo, @Direccion, @FechaNacimiento, @EspecialidadId ";
                var parameters = new { Nombre = medico.Nombre, Dui = medico.Dui, TelefonoFijo = medico.TelefonoFijo, Movil = medico.Movil, Sexo = medico.Sexo, Direccion = medico.Direccion, FechaNacimiento = medico.FechaNacimiento, EspecialidadId = medico.EspecialidadId };
                var connectionString = _configuration.GetConnectionString("ClinicaCrecer");
                await using var connection = new SqlConnection(connectionString);
                connection.Open();
                var result = await connection.QueryAsync<int>(query, parameters);
                return new GenericResponse<int>
                {
                    Data = result.FirstOrDefault(),
                    Success = true,
                    Message = "Exito al registrar el medico."
                };
            }
            catch (Exception ex)
            {
                return new GenericResponse<int>
                {
                    Success = false,
                    Message = "No fue posible crear el medico, intente mas tarde."
                };
            }
        }
    }
}
