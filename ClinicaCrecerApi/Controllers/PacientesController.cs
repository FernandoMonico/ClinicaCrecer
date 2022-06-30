using Application.Interfaces;
using AutoMapper;
using Core.Common;
using Core.DTOs;
using Core.Models;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace ClinicaCrecerApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PacientesController : ControllerBase
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        public PacientesController(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        [HttpGet("PacientePorDui/{dui}")]
        public async Task<GenericResponse<Paciente>> PacientePorDui(string dui)
        {
            var response = await _unitOfWork.Paciente.PacientePorDui(dui);
            return response;
        }

        [HttpPost]
        [Route("CrearPaciente")]
        public async Task<GenericResponse<int>> CrearPaciente([FromBody] PacienteDto pacienteDto)
        {
            var paciente = _mapper.Map<Paciente>(pacienteDto);
            var response = await _unitOfWork.Paciente.CrearPaciente(paciente);
            return response;
        }
    }
}
