using Evaluacion2.Models;
using Evaluacion2.Services;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace Evaluacion2.Controllers
{
    [ApiController]
    [Route("ApiEvaluacion/[controller]")]
    public class TareaController : Controller
    {
        private readonly TareaServices _tareaServices;

        public TareaController(TareaServices tareaServices)
        {
            _tareaServices = tareaServices;
        }

        [HttpGet]
        public async Task<IActionResult> ObtenerTodasLasTareas()
        {
            var tareas = await _tareaServices.ObtenerTodasLasTareas();
            return Ok(tareas);
        }

        [HttpGet("{Id}")]
        public async Task<IActionResult> ObtenerTareaPorId(int Id)
        {
            var tarea = await _tareaServices.ObtenerTareaPorId(Id);
            if (tarea == null)
            {
                return NotFound();
            }
            return Ok(tarea);
        }

        [HttpPost]
        public async Task<IActionResult> CrearTarea([FromBody] Tarea tarea)
        {
            await _tareaServices.CrearTarea(tarea);
            return Ok("Tarea creada exitosamente.");
        }

        [HttpPut("{Id}")]
        public async Task<IActionResult> ActualizarTarea(int Id, [FromBody] Tarea tarea)
        {
            var resultado = await _tareaServices.ActualizarTarea(Id, tarea);
            if (!resultado)
            {
                return NotFound("Tarea no encontrada.");
            }
            return Ok("Tarea actualizada exitosamente.");
        }

        [HttpDelete("{Id}")]
        public async Task<IActionResult> EliminarTarea(int Id)
        {
            var resultado = await _tareaServices.EliminarTarea(Id);
            if (!resultado)
            {
                return NotFound("Tarea no encontrada.");
            }
            return Ok("Tarea eliminada exitosamente.");
        }
    }
}
