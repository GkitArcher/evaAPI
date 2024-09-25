public class HerramientaController : ControllerBase
{
    [HttpGet("{id}")]
    public ActionResult<HerramientaResponse> ObtenerHerramienta(int id)
    {
        var herramienta = ;

        if (herramienta == null)
        {
            return NotFound(new HerramientaResponse
            {
                Exito = false,
                Mensaje = "Herramienta no encontrada."
            });
        }

        return Ok(new HerramientaResponse
        {
            Exito = true,
            Mensaje = "Herramienta encontrada.",
            Data = herramienta
        });
    }

    [HttpPost]
    public ActionResult<NuevoHerramientaResponse> CrearHerramienta(Herramienta nuevaHerramienta)
    {
        bool exito = ;

        return Ok(new NuevoHerramientaResponse
        {
            Exito = exito,
            Mensaje = exito ? "Herramienta creada con éxito." : "Error al crear la herramienta.",
            Data = exito
        });
    }

    [HttpDelete("{id}")]
    public ActionResult<EliminarHerramientaResponse> EliminarHerramienta(int id)
    {
        bool exito = ;

        return Ok(new EliminarHerramientaResponse
        {
            Exito = exito,
            Mensaje = exito ? "Herramienta eliminada con éxito." : "Error al eliminar la herramienta.",
            Data = exito
        });
    }

    [HttpPut("{id}")]
    public ActionResult<ActualizarHerramientaResponse> ActualizarHerramienta(int id, Herramienta herramientaActualizada)
    {
        bool exito = ;

        return Ok(new ActualizarHerramientaResponse
        {
            Exito = exito,
            Mensaje = exito ? "Herramienta actualizada con éxito." : "Error al actualizar la herramienta.",
            Data = exito
        });
    }
}
