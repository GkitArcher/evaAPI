using Evaluacion2.Data;
using Evaluacion2.Models;
using Evaluacion2.DTO;
using Microsoft.EntityFrameworkCore;


namespace Evaluacion2.Services
{
    public class UsuariosServices
    {
        private readonly ProyectoDBContext _context;

        
        public UsuariosServices(ProyectoDBContext context)
        {
            _context = context;
        }

        
        public async Task<List<Usuario>> ObtenerUsuarios()
        {
            return await _context.Usuarios.ToListAsync();
        }

        
        public async Task<Usuario> ObtenerUsuarioPorId(int id)
        {
            return await _context.Usuarios.FindAsync(id);
        }

        
        public async Task<bool> IngresarUsuario(UsuarioDTO usuarioDTO)
        {
            var nuevoUsuario = new Usuario
            {
                Nombre = usuarioDTO.Nombre,
                Apellido = usuarioDTO.Apellido,
                Email = usuarioDTO.Email,
                Password = usuarioDTO.Password,
                RolId = usuarioDTO.RolId
            };

            _context.Usuarios.Add(nuevoUsuario);
            await _context.SaveChangesAsync();
            return true;
        }

        
        public async Task<bool> ActualizarUsuario(int id, UsuarioDTO usuarioDTO)
        {
            var usuarioIngresado = await _context.Usuarios.FindAsync(id);
            if (usuarioIngresado != null)
            {
                usuarioIngresado.Nombre = usuarioDTO.Nombre;
                usuarioIngresado.Apellido = usuarioDTO.Apellido;
                usuarioIngresado.Email = usuarioDTO.Email;
                usuarioIngresado.Password = usuarioDTO.Password;
                usuarioIngresado.RolId = usuarioDTO.RolId;

                await _context.SaveChangesAsync();
                return true;
            }
            return false;
        }

        
        public async Task<bool> EliminarUsuario(int id)
        {
            var usuarioIngresado = await _context.Usuarios.FindAsync(id);
            if (usuarioIngresado != null)
            {
                _context.Usuarios.Remove(usuarioIngresado);
                await _context.SaveChangesAsync();
                return true;
            }
            return false;
        }
    }
}
