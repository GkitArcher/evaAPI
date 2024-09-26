using Evaluacion2.Models;
using Evaluacion2.DTO;

namespace Evaluacion2.Services
{
    public class UsuariosServices
    {
        private List<Usuario> usuarios = new List<Usuario>
        {
            new Usuario { Id = 1, 
                Nombre = "Usuario A", 
                Email = "usuarioA@mail.com", 
                Password = "alumnocft", 
                RolId = 1 },

            new Usuario { Id = 2, 
                Nombre = "Usuario B", 
                Email = "usuarioB@mail.com", 
                Password = "cftsa2024", 
                RolId = 2 }
        };

        public async Task<List<Usuario>> ObtenerUsuarios()
        {
            return await Task.FromResult(usuarios);
        }

        public async Task<Usuario> ObtenerUsuarioPorId(int id)
        {
            var usuario = usuarios.FirstOrDefault(u => u.Id == id);
            return usuario;
        }

        
        public async Task<bool> IngresarUsuario(UsuarioDTO usuarioDTO)
        {
            var nuevoUsuario = new Usuario
            {
                Id = usuarios.Max(u => u.Id) + 1,
                Nombre = usuarioDTO.Nombre,
                Email = usuarioDTO.Email,
                Password = usuarioDTO.Password,
                RolId = usuarioDTO.RolId
            };

            usuarios.Add(nuevoUsuario);
            return true; 
        }

        public async Task<bool> ActualizarUsuario(int id, UsuarioDTO usuarioDTO)
        {
            var usuarioExistente = usuarios.FirstOrDefault(u => u.Id == id);
            if (usuarioExistente != null)
            {
                usuarioExistente.Nombre = usuarioDTO.Nombre;
                usuarioExistente.Email = usuarioDTO.Email;
                usuarioExistente.Password = usuarioDTO.Password;
                usuarioExistente.RolId = usuarioDTO.RolId;
                return await Task.FromResult(true);
            }
            return false; 
        }

        public async Task<bool> EliminarUsuario(int id)
        {
            var usuarioExistente = usuarios.FirstOrDefault(u => u.Id == id);
            if (usuarioExistente != null)
            {
                usuarios.Remove(usuarioExistente);
                return true;
            }
            return false; 
        }
    }
}
