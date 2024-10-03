using Evaluacion2.Services;
using Evaluacion2.Responses;
using Microsoft.AspNetCore.Mvc;
using Evaluacion2.DTO;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Evaluacion2.Controllers
{
    [ApiController]
    [Route("ApiEvaluacion/[controller]")]
    public class ProyectoController : ControllerBase
    {
        private readonly ProyectoServices _proyectoServices;

        public ProyectoController(ProyectoServices proyectoServices)
        {
            _proyectoServices = proyectoServices;
        }

        [HttpGet]
        public async Task<ActionResult<ProyectosResponses>> GetProyectos()
        {
            var pro = await _proyectoServices.ObtenerProyectos();

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
            var proyecto = await _proyectoServices.ObtenerProyectoPorId(Id); 

            if (proyecto == null)
            {
                return NotFound(); 
            }

            var response = new ProyectoResponses
            {
                Data = proyecto,
                Code = 200,
                Message = "Proyecto obtenido correctamente"
            };

            return Ok(response);
        }

        [HttpPost]
        public async Task<ActionResult<NuevoProyectoResponses>> PostProyecto([FromBody] ProyectoDTO proyecto)
        {
            var nuevoProyecto = await _proyectoServices.CrearProyecto(proyecto); 

            var response = new NuevoProyectoResponses
            {
                Data = true,
                Code = 201, 
                Message = "Proyecto ingresado correctamente"
            };

            return CreatedAtAction(nameof(GetProyecto), new { id = nuevoProyecto.Id }, response); 
        }

        [HttpPut("{Id}")]
        public async Task<ActionResult<ActualizarProyectoResponses>> ActualizarProyecto(int Id, [FromBody] ProyectoDTO proyecto)
        {
            var resultado = await _proyectoServices.ActualizarProyecto(Id, proyecto); 

            if (!resultado)
            {
                return NotFound(); 
            }

            var response = new ActualizarProyectoResponses
            {
                Data = true,
                Code = 200,
                Message = "Proyecto actualizado correctamente"
            };

            return Ok(response);
        }

        [HttpDelete("{Id}")]
        public async Task<ActionResult<ProyectoResponses>> EliminarProyecto(int Id)
        {
            var resultado = await _proyectoServices.EliminarProyecto(Id); 

            if (!resultado)
            {
                return NotFound(); 
            }

            var response = new ProyectoResponses
            {
                Data = null,
                Code = 200,
                Message = "Proyecto eliminado correctamente"
            };

            return Ok(response);
        }
    }
}

