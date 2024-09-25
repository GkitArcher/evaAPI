using Evaluacion2.Models;
using Microsoft.AspNetCore.DataProtection.Repositories;

namespace Evaluacion2.Services
{
    public class RolServices
    {

        private IRolRepositorio _rolRepositorio;
        public RolServices(IRolRepositorio rolRepositorio)
        {
            _rolRepositorio = rolRepositorio;
        }

        public IEnumerable<Rol> ObtenerTodosLosRoles()
        {
            return _rolRepositorio.ObtenerTodosLosRoles();
        }

        public IEnumerable<Usuario> ObtenerUsuariosPorRol(int IdRol)
        {
            return _rolRepositorio.ObtenerUsuariosPorRol(IdRol);
        }
    }
}
