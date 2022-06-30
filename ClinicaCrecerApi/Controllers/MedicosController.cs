using Application.Interfaces;
using AutoMapper;
using Core.Common;
using Core.DTOs;
using Core.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ClinicaCrecerApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MedicosController : ControllerBase
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        public MedicosController(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }
        [HttpPost]
        [Route("CrearMedico")]
        public async Task<GenericResponse<int>> CrearPaciente([FromBody] MedicoDto medicoDto)
        {
            var medico = _mapper.Map<Medico>(medicoDto);
            var response = await _unitOfWork.Medico.CrearMedico(medico);
            return response;
        }
    }
}
