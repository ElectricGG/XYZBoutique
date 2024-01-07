using MediatR;
using XYZBoutique.Application.Dtos;
using XYZBoutique.Application.UseCase.Commons.Bases.Response;

namespace XYZBoutique.Application.UseCase.UseCases.Usuario.Queries.GetByQuery
{
    /// <summary>
    /// Consulta para obtener usuarios por rol.
    /// </summary>
    public class GetUsuariosByRolQuery : IRequest<BaseResponse<IEnumerable<UsuariosByRolDto>>>
    {
        /// <summary>
        /// Obtiene o establece el identificador del rol para filtrar los usuarios.
        /// </summary>
        public int idRol { get; set; }
    }
}
