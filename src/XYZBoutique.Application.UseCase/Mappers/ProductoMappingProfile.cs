using AutoMapper;
using XYZBoutique.Application.Dtos;
using XYZBoutique.Domain.Entities;

namespace XYZBoutique.Application.UseCase.Mappers
{
    public class ProductoMappingProfile : Profile
    {
        public ProductoMappingProfile()
        {
            CreateMap<Producto, ProductoBySkuOrNombreDto>()
                .ForMember(dest => dest.Tipo, opt => opt.MapFrom(src => src.IdTipoNavigation!.Nombre))
                .ForMember(dest => dest.UnidadMedida, opt => opt.MapFrom(src => src.IdUnidadMedidaNavigation!.Nombre));
        }
    }
}
