using AutoMapper;
using HRBackend.AppCore.Models.DTOs;
using HRBackend.AppCore.Models.Entities;

namespace HRBackend.Infrastructure.MappingProfile
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<User, UserDTO>().ReverseMap();
            CreateMap<Demande, DemandeDTO>().ReverseMap();
            CreateMap<Contrat, ContratDTO>().ReverseMap();

            // Add more mappings as needed
        }
    }
}
