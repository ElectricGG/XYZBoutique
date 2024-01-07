using MediatR;
using XYZBoutique.Application.UseCase.Commons.Bases.Response;

namespace XYZBoutique.Application.UseCase.UseCases.Usuario.Queries.GetTokenQuery
{
    /// <summary>
    /// Consulta para obtener un token.
    /// </summary>
    public class GetTokenQuery : IRequest<BaseResponse<string>>
    {
        /// <summary>
        /// Obtiene o establece el código del trabajador para autenticación.
        /// </summary>
        public string? codigoTrabajador { get; set; }

        /// <summary>
        /// Obtiene o establece la clave para autenticación.
        /// </summary>
        public string? clave { get; set; }
    }
}
