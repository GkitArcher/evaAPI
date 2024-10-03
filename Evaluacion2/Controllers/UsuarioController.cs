using Microsoft.AspNetCore.Mvc;
using Evaluacion2.Services;
using Evaluacion2.DTO;

namespace Evaluacion2.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class UsuariosController : ControllerBase
    {
        private readonly UsuariosServices _usuariosServices;

        public UsuariosController(UsuariosServices usuariosServices)
        {
            _usuariosServices = usuariosServices;
        }

        [HttpGet]
        public async Task<IActionResult> GetUsuarios()
        {
            var usuarios = await _usuariosServices.ObtenerUsuarios();
            return Ok(usuarios);
        }

        [HttpGet("{Id}")]
        public async Task<IActionResult> GetUsuario(int id)
        {
            var usuario = await _usuariosServices.ObtenerUsuarioPorId(id);
            return Ok(usuario);
        }

        [HttpPost]
        public async Task<IActionResult> PostUsuario([FromBody] UsuarioDTO usuarioDTO)
        {
            var resultado = await _usuariosServices.IngresarUsuario(usuarioDTO);
            return Ok("Usuario creado exitosamente");
        }

        [HttpPut("{Id}")]
        public async Task<IActionResult> ActualizarUsuario(int id, [FromBody] UsuarioDTO usuarioDTO)
        {
            var resultado = await _usuariosServices.ActualizarUsuario(id, usuarioDTO);
            return Ok("Usuario actualizado exitosamente");
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> EliminarUsuario(int id)
        {
            var resultado = await _usuariosServices.EliminarUsuario(id);
            return Ok("Usuario eliminado exitosamente");
        }
    }
}
