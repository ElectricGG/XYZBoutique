using AutoMapper;
using MediatR;
using WatchDog;
using XYZBoutique.Application.Dtos;
using XYZBoutique.Application.Interface;
using XYZBoutique.Application.UseCase.Commons.Bases.Response;
using XYZBoutique.Utilities;

namespace XYZBoutique.Application.UseCase.UseCases.Usuario.Queries.GetByQuery
{

    /// <summary>
    /// Manejador para la consulta de obtener usuarios por rol.
    /// </summary>
    public class GetUsuariosByRolHandler : IRequestHandler<GetUsuariosByRolQuery, BaseResponse<IEnumerable<UsuariosByRolDto>>>
    {
        private readonly IUserRepository _userRepository;
        private readonly IMapper _mapper;

        /// <summary>
        /// Constructor de la clase GetUsuariosByRolHandler.
        /// </summary>
        /// <param name="userRepository">Repositorio de usuarios.</param>
        /// <param name="mapper">Instancia de AutoMapper para realizar mapeos.</param>
        public GetUsuariosByRolHandler(IUserRepository userRepository, IMapper mapper)
            => (_userRepository, _mapper) = (userRepository, mapper);

        /// <summary>
        /// Maneja la solicitud para obtener usuarios por rol.
        /// </summary>
        /// <param name="request">Consulta para obtener usuarios.</param>
        /// <param name="cancellationToken">Token de cancelación.</param>
        /// <returns>Respuesta con la lista de usuarios correspondiente a la consulta.</returns>
        public async Task<BaseResponse<IEnumerable<UsuariosByRolDto>>> Handle(GetUsuariosByRolQuery request, CancellationToken cancellationToken)
        {
            var response = new BaseResponse<IEnumerable<UsuariosByRolDto>>();

            try
            {
                // Obtener usuarios por rol desde el repositorio
                var Usuario = await _userRepository.GetUsuariosByRol(request.idRol);

                // Mapear los usuarios a DTOs de usuarios por rol
                var usuariosDto = _mapper.Map<IEnumerable<UsuariosByRolDto>>(Usuario);

                // Verificar si la lista de DTOs no es nula
                if (usuariosDto is not null)
                {
                    response.IsSuccess = true;
                    response.Data = usuariosDto;
                    response.TotalRecords = usuariosDto.Count();
                    response.Message = ReplyMessage.MESSAGE_QUERY;
                }
            }
            catch (Exception ex)
            {
                // Capturar y manejar excepciones
                response.IsSuccess = false;
                response.Message = ex.Message;
                WatchLogger.Log(ex.Message);
            }

            return response;
        }
    }
}
