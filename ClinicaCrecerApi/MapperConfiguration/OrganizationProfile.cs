using AutoMapper;
using Core.DTOs;
using Core.Models;

namespace ClinicaCrecerApi.MapperConfiguration
{
    public class OrganizationProfile : Profile
    {
        public OrganizationProfile()
        {
            CreateMap<PacienteDto, Paciente>()
                .ForMember(
                    dest => dest.FechaNacimiento,
                    opt => opt.MapFrom(src => Convert.ToDateTime(src.FechaNacimiento))
                );
            CreateMap<MedicoDto, Medico>()
                .ForMember(
                    dest => dest.FechaNacimiento,
                    opt => opt.MapFrom(src => Convert.ToDateTime(src.FechaNacimiento))
                );
        }
    }
}
