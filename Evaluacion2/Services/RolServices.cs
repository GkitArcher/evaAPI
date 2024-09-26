using Evaluacion2.Data;
using Evaluacion2.Models;

namespace Evaluacion2.Services
{
    public class RolServices
    {
        private readonly ProyectoDBContext _context;

        public RolServices(ProyectoDBContext context)
        {
            _context = context;
        }

        public IEnumerable<Rol> ObtenerTodosLosRoles()
        {
            return _context.Roles.ToList();
        }

        public IEnumerable<Usuario> ObtenerUsuariosPorRol(int IdRol)
        {
            return _context.Usuarios.Where(u => u.RolId == IdRol).ToList();
        }
    }
}
