using Application.Interfaces;
using AutoMapper;
using Core.Common;
using Core.DTOs;
using Core.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ClinicaCrecerApi.Controllers
{
    [Route("api/Citas")]
    [ApiController]
    public class CitasController : ControllerBase
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        public CitasController(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }
        [HttpPost]
        [Route("CrearCita")]
        public async Task<GenericResponse<int>> CrearCita([FromBody] Cita cita)
        {
            var response = await _unitOfWork.Cita.CrearCita(cita);
            return response;
        }
    }
}
