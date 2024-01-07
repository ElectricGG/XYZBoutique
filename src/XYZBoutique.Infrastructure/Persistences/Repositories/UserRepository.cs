using Microsoft.EntityFrameworkCore;
using XYZBoutique.Application.Interface;
using XYZBoutique.Domain.Entities;
using XYZBoutique.Infrastructure.Persistences.Context;

namespace XYZBoutique.Infrastructure.Persistences.Repositories
{
    /// <summary>
    /// Implementación del repositorio de usuarios utilizando Entity Framework Core.
    /// </summary>
    public class UserRepository : IUserRepository
    {
        private readonly ApplicationDbContext _dbcontext;

        public UserRepository(ApplicationDbContext dbcontext)
        {
            _dbcontext = dbcontext;
        }

        /// <summary>
        /// Obtiene una cuenta de usuario basada en el código del trabajador.
        /// </summary>
        /// <param name="codigoTrabajador">Código del trabajador.</param>
        /// <returns>Información del usuario asociada al código del trabajador.</returns>
        public async Task<Usuario> AccountByCodigoTrabajador(string codigoTrabajador)
        {
            // Realiza una consulta asincrónica para obtener un usuario sin rastreo en el contexto.
            var account = await _dbcontext.Usuarios.AsNoTracking().FirstOrDefaultAsync(x => x.CodigoTrabajador!.Equals(codigoTrabajador));

            return account!;
        }

        /// <summary>
        /// Obtiene una lista de usuarios por el ID del rol.
        /// </summary>
        /// <param name="idRol">ID del rol.</param>
        /// <returns>Lista de usuarios asociados al rol especificado.</returns>
        public async Task<IEnumerable<Usuario>> GetUsuariosByRol(int idRol)
        {
            // Realiza una consulta asincrónica para obtener usuarios filtrados por ID de rol y estado activo.
            var usuarios = await _dbcontext.Usuarios
                .Where(x => x.IdRol == idRol && x.Estado == true)
                .Include(u => u.IdRolNavigation)
                .ToListAsync();

            return usuarios;
        }
    }

}
