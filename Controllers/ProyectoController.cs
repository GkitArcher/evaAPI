using Evaluacion2.Services;
using Evaluacion2.Responses;
using Microsoft.AspNetCore.Mvc;
using Evaluacion2.DTO;

namespace Evaluacion2.Controllers
{

    [ApiController]
    [Route("ApiEvaluacion/[controller]")]
    public class ProyectoController : Controller
    {
        private readonly ProyectoServices _proyectoServices;

        public ProyectoController()
        {
            
            _proyectoServices = new ProyectoServices();
        }

        [HttpGet]
        public async Task<ActionResult<ProyectosResponses>> GetProyectos()
        {
            var pro = await _proyectoServices.ListaProyectos();

            var response = new ProyectosResponses
            {
                Data = pro,
                Code = 200,
                Message = "Proyectos obtenidos correctamente"
            };

            return Ok(response);
        }

        [HttpGet("{Id}")]
        public async Task<ActionResult<ProyectoResponses>> GetProyecto(int Id)
        {
            var proyecto = await _proyectoServices.ObtenerProyecto(Id);

            var response = new ProyectoResponses
            {
                Data = proyecto,
                Code = 200,
                Message = "Tarea obtenida correctamente"
            };

            return Ok(response);

        }


        [HttpPost]
        public async Task<ActionResult<NuevoProyectoResponses>> PostProyecto([FromBody] ProyectoDTO proyecto)
        {
            var ingreso = await _proyectoServices.IngresarProyecto(proyecto);

            var response = new NuevoProyectoResponses
            {
                Data = ingreso,
                Code = 200,
                Message = "Proyecto ingresado correctamente"
            };

            return Ok(response);
        }

        [HttpPut("{Id}")]
        public async Task<ActionResult<ActualizarProyectoResponses>> ActualizarProyecto(int Id, [FromBody] ProyectoDTO proyecto)
        {
            var ingreso = await _proyectoServices.ActualizarProyecto(Id, proyecto);

            var response = new ActualizarProyectoResponses
            {
                Data = ingreso,
                Code = 200,
                Message = "Proyecto Actualizado correctamente"
            };

            return Ok(response);
        }


        [HttpDelete("{Id}")]
        public async Task<ActionResult<ProyectoResponses>> EliminarProyecto(int Id, ProyectoDTO proyecto)
        {
            var ingreso = await _proyectoServices.EliminarProyecto(Id);

            var response = new EliminarProyectoResponses
            {
                Data = ingreso,
                Code = 200,
                Message = "Proyecto Eliminado correctamente"
            };

            return Ok(response);

        }
    }
}
