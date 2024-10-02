using Evaluacion2.Models;
using Evaluacion2.Services;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace Evaluacion2.Controllers
{
    [ApiController]
    [Route("ApiEvaluacion/[controller]")]
    public class HerramientaController : Controller
    {
        private readonly HerramientaServices _herramientaServices;

        public HerramientaController(HerramientaServices herramientaServices)
        {
            _herramientaServices = herramientaServices;
        }

        [HttpGet]
        public async Task<IActionResult> ObtenerTodasLasHerramientas()
        {
            var herramientas = await _herramientaServices.ObtenerTodasLasHerramientas();
            return Ok(herramientas);
        }

        [HttpGet("{Id}")]
        public async Task<IActionResult> ObtenerHerramientaPorId(int Id)
        {
            var herramienta = await _herramientaServices.ObtenerHerramientaPorId(Id);
            if (herramienta == null)
            {
                return NotFound();
            }
            return Ok(herramienta);
        }

        [HttpPost]
        public async Task<IActionResult> CrearHerramienta([FromBody] Herramienta herramienta)
        {
            await _herramientaServices.CrearHerramienta(herramienta);
            return Ok("Herramienta creada exitosamente.");
        }

        [HttpPut("{Id}")]
        public async Task<IActionResult> ActualizarHerramienta(int Id, [FromBody] Herramienta herramienta)
        {
            var resultado = await _herramientaServices.ActualizarHerramienta(Id, herramienta);
            if (!resultado)
            {
                return NotFound("Herramienta no encontrada.");
            }
            return Ok("Herramienta actualizada exitosamente.");
        }

        [HttpDelete("{Id}")]
        public async Task<IActionResult> EliminarHerramienta(int Id)
        {
            var resultado = await _herramientaServices.EliminarHerramienta(Id);
            if (!resultado)
            {
                return NotFound("Herramienta no encontrada.");
            }
            return Ok("Herramienta eliminada exitosamente.");
        }
    }
}

