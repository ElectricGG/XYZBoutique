using AutoMapper;
using XYZBoutique.Application.Dtos;
using XYZBoutique.Domain.Entities;

namespace XYZBoutique.Application.UseCase.Mappers
{
    public class UsuarioMappingsProfile : Profile
    {
        public UsuarioMappingsProfile()
        {
            CreateMap<Usuario, UsuariosByRolDto>()
                .ForMember(dest => dest.Rol, opt => opt.MapFrom(src => src.IdRolNavigation!.Nombre));
        }
    }
}
