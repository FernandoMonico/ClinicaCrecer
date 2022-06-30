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
    public class EspecialidadController : ControllerBase
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        public EspecialidadController(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }
        [HttpPost]
        [Route("CrearEspecialidad")]
        public async Task<GenericResponse<int>> CrearEspecialidad([FromBody] Especialidad especialidad)
        {
            var response = await _unitOfWork.Especialidad.CrearEspecialidad(especialidad);
            return response;
        }
    }
}
