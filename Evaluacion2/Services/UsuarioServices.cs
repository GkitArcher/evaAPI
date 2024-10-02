using Evaluacion2.Data;
using Evaluacion2.Models;
using Evaluacion2.DTO;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

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
            var usuarioExistente = await _context.Usuarios.FindAsync(id);
            if (usuarioExistente != null)
            {
                usuarioExistente.Nombre = usuarioDTO.Nombre;
                usuarioExistente.Email = usuarioDTO.Email;
                usuarioExistente.Password = usuarioDTO.Password;
                usuarioExistente.RolId = usuarioDTO.RolId;

                await _context.SaveChangesAsync();
                return true;
            }
            return false;
        }

        
        public async Task<bool> EliminarUsuario(int id)
        {
            var usuarioExistente = await _context.Usuarios.FindAsync(id);
            if (usuarioExistente != null)
            {
                _context.Usuarios.Remove(usuarioExistente);
                await _context.SaveChangesAsync();
                return true;
            }
            return false;
        }
    }
}
