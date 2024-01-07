using MediatR;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using WatchDog;
using XYZBoutique.Application.Interface;
using XYZBoutique.Application.UseCase.Commons.Bases.Response;
using XYZBoutique.Utilities;
using User = XYZBoutique.Domain.Entities.Usuario;

namespace XYZBoutique.Application.UseCase.UseCases.Usuario.Queries.GetTokenQuery
{
    /// <summary>
    /// Manejador para la consulta de obtener un token.
    /// </summary>
    public class GetTokenHandler : IRequestHandler<GetTokenQuery, BaseResponse<string>>
    {
        private readonly IUserRepository _userRepository;
        private readonly IConfiguration _configuration;

        /// <summary>
        /// Constructor de la clase GetTokenHandler.
        /// </summary>
        /// <param name="userRepository">Repositorio de usuarios.</param>
        /// <param name="configuration">Configuración de la aplicación.</param>
        public GetTokenHandler(IUserRepository userRepository, IConfiguration configuration)
            => (_userRepository, _configuration) = (userRepository, configuration);

        /// <summary>
        /// Maneja la solicitud para obtener un token.
        /// </summary>
        /// <param name="request">Consulta para obtener un token.</param>
        /// <param name="cancellationToken">Token de cancelación.</param>
        /// <returns>Respuesta con el token generado correspondiente a la consulta.</returns>
        public async Task<BaseResponse<string>> Handle(GetTokenQuery request, CancellationToken cancellationToken)
        {
            var response = new BaseResponse<string>();

            try
            {
                // Obtener la cuenta de usuario por el código del trabajador
                var account = await _userRepository.AccountByCodigoTrabajador(request.codigoTrabajador!);

                if (account is not null)
                {
                    // Verificar si la clave proporcionada coincide con la clave almacenada
                    if (account.Clave == request.clave)
                    {
                        response.IsSuccess = true;
                        response.Data = GenerateToken(account);
                        response.Message = ReplyMessage.MESSAGE_TOKEN;

                        return response;
                    }
                    else
                    {
                        response.IsSuccess = false;
                        response.Message = ReplyMessage.MESSAGE_TOKEN_ERROR;
                    }
                }
            }
            catch(Exception ex)
            {
                response.IsSuccess = false;
                response.Message = ex.Message;
                WatchLogger.Log(ex.Message);
            }
            
            return response;
        }

        /// <summary>
        /// Genera un token JWT basado en la información del usuario.
        /// </summary>
        /// <param name="usuario">Información del usuario para el cual se genera el token.</param>
        /// <returns>Token JWT.</returns>
        private string GenerateToken(User usuario)
        {
            // Obtener la clave secreta para la firma del token desde la configuración
            var jwt = _configuration["Jwt:Secret"]!.ToString();

            // Crear una clave de seguridad utilizando la clave secreta
            var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["Jwt:Secret"]!));

            // Configurar las credenciales para la firma del token
            var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);

            // Definir las reclamaciones (claims) del token
            var claims = new List<Claim>
            {
                new Claim(JwtRegisteredClaimNames.NameId, usuario.CodigoTrabajador!),
                new Claim(JwtRegisteredClaimNames.UniqueName, usuario.IdUsuario.ToString()),
                new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
                new Claim(JwtRegisteredClaimNames.Iat, Guid.NewGuid().ToString(), ClaimValueTypes.Integer64)
            };

            // Crear un nuevo token JWT
            var token = new JwtSecurityToken(
                issuer: _configuration["Jwt:Issuer"],
                audience: _configuration["Jwt:Issuer"],
                claims: claims,
                expires: DateTime.UtcNow.AddHours(int.Parse(_configuration["Jwt:Expires"]!)),
                notBefore: DateTime.UtcNow,
                signingCredentials: credentials
            );

            // Escribir el token como una cadena
            return new JwtSecurityTokenHandler().WriteToken(token);
        }
    }

}
