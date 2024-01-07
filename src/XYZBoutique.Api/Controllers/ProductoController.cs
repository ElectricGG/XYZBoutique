using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using XYZBoutique.Application.UseCase.UseCases.Producto.Queries.GetProductosQuery;
using XYZBoutique.Application.UseCase.UseCases.Usuario.Queries.GetByQuery;

namespace XYZBoutique.Api.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class ProductoController : ControllerBase
    {
        private readonly IMediator _mediator;
        public ProductoController(IMediator mediator) => _mediator = mediator;

        [HttpPost("ProductosBySkuOrNombre")]
        public async Task<IActionResult> ProductosBySkuOrNombre([FromBody] GetProductosBySkuOrNombreQuery query) => Ok(await _mediator.Send(query));
    }
}
