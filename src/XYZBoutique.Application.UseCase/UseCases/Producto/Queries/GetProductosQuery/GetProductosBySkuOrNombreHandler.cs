using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;
using WatchDog;
using XYZBoutique.Application.Dtos;
using XYZBoutique.Application.Interface;
using XYZBoutique.Application.UseCase.Commons.Bases.Response;
using XYZBoutique.Utilities;
using XYZProducto = XYZBoutique.Domain.Entities.Producto;

namespace XYZBoutique.Application.UseCase.UseCases.Producto.Queries.GetProductosQuery
{
    /// <summary>
    /// Manejador para la consulta de obtener productos por SKU o nombre.
    /// </summary>
    public class GetProductosBySkuOrNombreHandler : IRequestHandler<GetProductosBySkuOrNombreQuery, BaseResponse<IEnumerable<ProductoBySkuOrNombreDto>>>
    {
        private readonly IProductoRepository _productoRepository;
        private readonly IMapper _mapper;

        /// <summary>
        /// Constructor de la clase GetProductosBySkuOrNombreHandler.
        /// </summary>
        /// <param name="productoRepository">Repositorio de productos.</param>
        /// <param name="mapper">Instancia de AutoMapper para realizar mapeos.</param>
        public GetProductosBySkuOrNombreHandler(IProductoRepository productoRepository, IMapper mapper)
            => (_productoRepository, _mapper) = (productoRepository, mapper);

        /// <summary>
        /// Maneja la solicitud para obtener productos por SKU o nombre.
        /// </summary>
        /// <param name="request">Consulta para obtener productos.</param>
        /// <param name="cancellationToken">Token de cancelación.</param>
        /// <returns>Respuesta con la lista de productos correspondiente a la consulta.</returns>
        public async Task<BaseResponse<IEnumerable<ProductoBySkuOrNombreDto>>> Handle(GetProductosBySkuOrNombreQuery request, CancellationToken cancellationToken)
        {
            var response = new BaseResponse<IEnumerable<ProductoBySkuOrNombreDto>>();

            try
            {
                Expression<Func<XYZProducto, bool>> filtro = null;

                // Validar si ambos nombre y SKU están vacíos
                if (request.Nombre != "" && request.Sku != "")
                {
                    response.IsSuccess = false;
                    response.Data = null;
                    response.TotalRecords = 0;
                    response.Message = ReplyMessage.MESSAGE_FAILED;

                    return response;
                }

                // Construir el filtro según los valores de nombre y SKU proporcionados
                if (!(string.IsNullOrEmpty(request.Nombre) && string.IsNullOrEmpty(request.Sku)))
                {
                    if (request.Nombre != "")
                    {
                        filtro = p => EF.Functions.Like(p.Nombre, $"%{request.Nombre}%");
                    }

                    if (request.Sku != "")
                    {
                        filtro = p => EF.Functions.Like(p.Sku, $"%{request.Sku}%");
                    }
                }

                // Obtener productos según el filtro
                var Producto = await _productoRepository.GetProductos(filtro);

                /// Mapea los productos obtenidos a una lista de DTOs de productos por SKU o nombre.
                
                var productoDto = _mapper.Map<IEnumerable<ProductoBySkuOrNombreDto>>(Producto.ToList());

                /// Verifica si la lista de DTOs de productos por SKU o nombre no es nula.
                /// Si la lista no es nula, configura la respuesta con los resultados de la consulta exitosa.
                if (productoDto is not null)
                {
                    response.IsSuccess = true;
                    response.Data = productoDto;
                    response.TotalRecords = productoDto.Count();
                    response.Message = ReplyMessage.MESSAGE_QUERY;
                }
            }
            catch (Exception ex)
            {
                response.IsSuccess = false;
                response.Message = ex.Message;
                WatchLogger.Log(ex.Message);
            }

            return response;
        }
    }

}
