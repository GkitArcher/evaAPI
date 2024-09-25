public class UsuarioController : ControllerBase
{
    [HttpGet("{id}")]
    public ActionResult<UsuarioResponse> ObtenerUsuario(int id)
    {
        var usuario = ;

        if (usuario == null)
        {
            return NotFound(new UsuarioResponse
            {
                Exito = false,
                Mensaje = "Usuario no encontrado."
            });
        }

        return Ok(new UsuarioResponse
        {
            Exito = true,
            Mensaje = "Usuario encontrado.",
            Data = usuario
        });
    }

    [HttpPost]
    public ActionResult<NuevoUsuarioResponse> CrearUsuario(Usuario nuevoUsuario)
    {
        bool exito = ;

        return Ok(new NuevoUsuarioResponse
        {
            Exito = exito,
            Mensaje = exito ? "Usuario creado con éxito." : "Error al crear el usuario.",
            Data = exito
        });
    }

    [HttpDelete("{id}")]
    public ActionResult<EliminarUsuarioResponse> EliminarUsuario(int id)
    {
        bool exito = ;

        return Ok(new EliminarUsuarioResponse
        {
            Exito = exito,
            Mensaje = exito ? "Usuario eliminado con éxito." : "Error al eliminar el usuario.",
            Data = exito
        });
    }

    [HttpPut("{id}")]
    public ActionResult<ActualizarUsuarioResponse> ActualizarUsuario(int id, Usuario usuarioActualizado)
    {
        bool exito = ;

        return Ok(new ActualizarUsuarioResponse
        {
            Exito = exito,
            Mensaje = exito ? "Usuario actualizado con éxito." : "Error al actualizar el usuario.",
            Data = exito
        });
    }
}
