using Evaluacion2.Services;
using Microsoft.AspNetCore.Mvc;

namespace Evaluacion2.Controllers
{

    [ApiController]
    [Route("ApiEvaluacion/[controller]")]
    public class RolController : Controller
    {
        private readonly RolServices _rolServices;

        public RolController (RolServices rolServices)
        {
            _rolServices = rolServices;
        }

        [HttpGet]
        public IActionResult ObtenerTodosLosRoles()
        {
            var roles = _rolServices.ObtenerTodosLosRoles();
            return Ok(roles);
        }

        [HttpGet("{rolId}/usuarios")]
        public async Task<IActionResult> ObtenerUsuariosPorRol(int rolId)
        {
            var usuarios = await _rolServices.ObtenerUsuariosPorRol(rolId);

            if (usuarios == null || usuarios.Count == 0)
            {
                return NotFound("No se encontraron usuarios para este rol.");
            }

            return Ok(usuarios);
        }
    }
}
