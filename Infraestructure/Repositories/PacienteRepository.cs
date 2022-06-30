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
    public class PacienteRepository : IPacienteRepository
    {
        private readonly IConfiguration _configuration;

        public PacienteRepository(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public async Task<GenericResponse<int>> CrearPaciente(Paciente paciente)
        {
            try
            {
                var query = "exec [SP_CrearPaciente] @Nombre, @Dui, @TelefonoFijo, @Movil, @Sexo, @Direccion, @FechaNacimiento";
                var parameters = new { Nombre = paciente.Nombre, Dui = paciente.Dui, TelefonoFijo = paciente.TelefonoFijo, Movil = paciente.Movil, Sexo = paciente.Sexo, Direccion = paciente.Direccion, FechaNacimiento = paciente.FechaNacimiento };
                var connectionString = _configuration.GetConnectionString("ClinicaCrecer");
                await using var connection = new SqlConnection(connectionString);
                connection.Open();
                var result = await connection.QueryAsync<int>(query, parameters);
                var data = result.FirstOrDefault();
                if(data == -1)
                    return new GenericResponse<int>
                    {
                        Data = result.FirstOrDefault(),
                        Success = true,
                        Message = "Ya existe un paciente con el DUI ingresado."
                    };
                return new GenericResponse<int>
                {
                    Data = result.FirstOrDefault(),
                    Success = true,
                    Message = "Exito al registrar el paciente."
                };
            }
            catch (Exception ex)
            {
                return new GenericResponse<int>
                {
                    Success = false,
                    Message = "No fue posible crear el paciente, intente mas tarde."
                };
            }
        }

        public async Task<GenericResponse<Paciente>> PacientePorDui(string dui)
        {
            try
            {
                var query = "exec [SP_PacientePorDui] @Dui";
                var parameters = new { Dui = dui };
                var connectionString = _configuration.GetConnectionString("ClinicaCrecer");
                await using var connection = new SqlConnection(connectionString);
                connection.Open();
                var result = await connection.QueryAsync<Paciente>(query, parameters);
                return new GenericResponse<Paciente>
                {
                    Data = result.FirstOrDefault(),
                    Success = true,
                    Message = "Exito en la operación."
                };
            }
            catch (Exception ex)
            {
                return new GenericResponse<Paciente>
                {
                    Success = false,
                    Message = "No fue posible obtener el paciente, intente mas tarde."
                };
            }
        }
    }
}
