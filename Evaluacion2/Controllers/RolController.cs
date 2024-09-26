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

        [HttpGet("{IdRol}/usuarios")]
        public IActionResult ObtenerUsuariosPorRol(int IdRol)
        {
            var usuarios = _rolServices.ObtenerUsuariosPorRol(IdRol);
            if (usuarios == null)
            {
                return NotFound();
            }
            return Ok(usuarios);
        }
    }
}
