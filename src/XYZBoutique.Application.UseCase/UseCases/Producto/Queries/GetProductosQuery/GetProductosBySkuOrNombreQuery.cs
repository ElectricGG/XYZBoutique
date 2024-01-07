using MediatR;
using XYZBoutique.Application.Dtos;
using XYZBoutique.Application.UseCase.Commons.Bases.Response;
using System.Collections.Generic;

namespace XYZBoutique.Application.UseCase.UseCases.Producto.Queries.GetProductosQuery
{
    /// <summary>
    /// Representa una consulta para obtener productos por SKU o nombre.
    /// </summary>
    public class GetProductosBySkuOrNombreQuery : IRequest<BaseResponse<IEnumerable<ProductoBySkuOrNombreDto>>>
    {
        /// <summary>
        /// Obtiene o establece el nombre del producto.
        /// </summary>
        public string? Nombre { get; set; }

        /// <summary>
        /// Obtiene o establece el SKU (código de inventario) del producto.
        /// </summary>
        public string? Sku { get; set; }
    }
}
