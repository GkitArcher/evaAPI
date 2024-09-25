public class TareaController : ControllerBase
{
    [HttpGet("{id}")]
    public ActionResult<TareaResponse> ObtenerTarea(int id)
    {
        var tarea = ;

        if (tarea == null)
        {
            return NotFound(new TareaResponse
            {
                Exito = false,
                Mensaje = "Tarea no encontrada."
            });
        }

        return Ok(new TareaResponse
        {
            Exito = true,
            Mensaje = "Tarea encontrada.",
            Data = tarea
        });
    }

    [HttpPost]
    public ActionResult<NuevaTareaResponse> CrearTarea(Tarea nuevaTarea)
    {
        bool exito = ;

        return Ok(new NuevaTareaResponse
        {
            Exito = exito,
            Mensaje = exito ? "Tarea creada con éxito." : "Error al crear la tarea.",
            Data = exito
        });
    }

    [HttpDelete("{id}")]
    public ActionResult<EliminarTareaResponse> EliminarTarea(int id)
    {
        bool exito =;

        return Ok(new EliminarTareaResponse
        {
            Exito = exito,
            Mensaje = exito ? "Tarea eliminada con éxito." : "Error al eliminar la tarea.",
            Data = exito
        });
    }

    [HttpPut("{id}")]
    public ActionResult<ActualizarTareaResponse> ActualizarTarea(int id, Tarea tareaActualizada)
    {
        bool exito = ;

        return Ok(new ActualizarTareaResponse
        {
            Exito = exito,
            Mensaje = exito ? "Tarea actualizada con éxito." : "Error al actualizar la tarea.",
            Data = exito
        });
    }
}
