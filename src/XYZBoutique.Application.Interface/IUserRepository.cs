using XYZBoutique.Domain.Entities;

namespace XYZBoutique.Application.Interface
{
    public interface IUserRepository
    {
        Task<Usuario> AccountByCodigoTrabajador(string codigoTrabajador);
        Task<IEnumerable<Usuario>> GetUsuariosByRol(int idRol);
    }
}
