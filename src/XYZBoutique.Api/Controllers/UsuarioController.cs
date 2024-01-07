using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using XYZBoutique.Application.UseCase.UseCases.Usuario.Queries.GetByQuery;
using XYZBoutique.Application.UseCase.UseCases.Usuario.Queries.GetTokenQuery;

namespace XYZBoutique.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsuarioController : ControllerBase
    {
        private readonly IMediator _mediator;
        public UsuarioController(IMediator mediator) => _mediator = mediator;

        [AllowAnonymous]
        [HttpPost("Authenticate")]
        public async Task<IActionResult> Authenticate([FromBody] GetTokenQuery query) => Ok(await _mediator.Send(query));

        [AllowAnonymous]
        [HttpGet("UsusariosByRol/{idRol:int}")]
        public async Task<IActionResult> UsusariosByRol(int idRol) => Ok(await _mediator.Send( new GetUsuariosByRolQuery { idRol = idRol }));
    }
}
