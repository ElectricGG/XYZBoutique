using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using XYZBoutique.Application.UseCase.UseCases.Pedido.Commands.UpdateCommand;
using XYZBoutique.Application.UseCase.UseCases.Pedido.Queries.GetQuery;
using XYZBoutique.Application.UseCase.UseCases.Pedidos.Commands.CreateCommand;
using XYZBoutique.Application.UseCase.UseCases.Usuario.Queries.GetByQuery;

namespace XYZBoutique.Api.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class PedidoController : ControllerBase
    {
        private readonly IMediator _mediator;
        public PedidoController(IMediator mediator) => _mediator = mediator;

        [AllowAnonymous]
        [HttpPost("Create")]
        public async Task<IActionResult> Create([FromBody] CreatePedidoCommand command)
        {
            if (!ModelState.IsValid)
            {
            }

            return Ok(await _mediator.Send(command));
        }

        [AllowAnonymous]
        [HttpPost("UpdateEstadoPedido")]
        public async Task<IActionResult> UpdateEstadoPedido([FromBody] UpdateEstadoPedidoByIdCommand command) => Ok(await _mediator.Send(command));

        [AllowAnonymous]
        [HttpGet("PedidosWithFilter")]
        public async Task<IActionResult> PedidosWithFilter([FromQuery]string nroPedido = null) => Ok(await _mediator.Send(new GetPedidosWithFilterQuery { NroPedido = nroPedido }));
    }
}
