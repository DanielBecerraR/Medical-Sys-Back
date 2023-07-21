using AutoMapper;
using Back.Models.DTO;

namespace Back.Models.Profiles
{
    public class PacienteProfiles : Profile
    {
        public PacienteProfiles()
        {
            CreateMap<Paciente, PacienteDTO>();
            CreateMap<PacienteDTO, Paciente>();
        }
    }
}
