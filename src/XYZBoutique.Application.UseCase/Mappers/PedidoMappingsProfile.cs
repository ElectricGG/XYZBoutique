using AutoMapper;
using XYZBoutique.Application.Dtos;
using XYZBoutique.Application.UseCase.UseCases.Pedidos.Commands.CreateCommand;
using XYZBoutique.Domain.Entities;

namespace XYZBoutique.Application.UseCase.Mappers
{
    public class PedidoMappingsProfile : Profile
    {
        public PedidoMappingsProfile()
        {
            CreateMap<CreatePedidoCommand, Pedido>()
            .ForMember(dest => dest.IdUsuarioSolicitante, opt => opt.MapFrom(src => src.IdUsuarioSolicitante))
            .ForMember(dest => dest.Repartidor, opt => opt.MapFrom(src => src.Repartidor))
            .ForMember(dest => dest.DetallePedido, opt => opt.MapFrom(src => src.DetallePedido))
            .ReverseMap();

            CreateMap<DetallePedidoCommand, DetallePedido>().ReverseMap();

            CreateMap<Pedido, PedidosWithFilterDto>()
                .ForMember(dest => dest.UsuarioSolicitante, opt => opt.MapFrom(src => src.IdUsuarioSolicitanteNavigation!.NombreCompleto))
                .ForMember(dest => dest.EstadoPedido, opt => opt.MapFrom(src => src.IdEstadoPedidoNavigation!.Nombre));

            CreateMap<DetallePedido,DetallePedidoDto>()
                .ForMember(dest => dest.Producto, opt => opt.MapFrom(src => src.IdProductoNavigation!.Nombre))
                .ReverseMap();
        }
    }
}
