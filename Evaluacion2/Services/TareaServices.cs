using Evaluacion2.Data;
using Evaluacion2.Models;
using Microsoft.EntityFrameworkCore;

namespace Evaluacion2.Services
{
    public class TareaServices
    {
        private readonly ProyectoDBContext _context;

        public TareaServices(ProyectoDBContext context)
        {
            _context = context;
        }

        
        public async Task<List<Tarea>> ObtenerTodasLasTareas()
        {
            return await _context.Tareas.ToListAsync();
        }

        
        public async Task<Tarea> ObtenerTareaPorId(int id)
        {
            return await _context.Tareas.FindAsync(id);
        }

        
        public async Task<bool> CrearTarea(Tarea tarea)
        {
            List<string> errores = new List<string>();

            
            var proyectoIngresado = await _context.Proyectos.FindAsync(tarea.ProyectoId);
            if (proyectoIngresado == null)
            {
                errores.Add("El proyecto no existe.");
            }

            
            var empleadoIngresado = await _context.Usuarios.FindAsync(tarea.EmpleadoId);
            if (empleadoIngresado == null)
            {
                errores.Add("El empleado no existe.");
            }

            if (!await ValidarSetHerramientas(tarea.SetHerramientas))
            {
                errores.Add("Una o más herramientas especificadas no existen.");
            }


            if (errores.Count > 0)
            {
                throw new Exception(string.Join(" ", errores)); // Juntar todos los mensajes en uno solo
            }

            
            _context.Tareas.Add(tarea);
            await _context.SaveChangesAsync();
            return true;
        }


        public async Task<bool> ActualizarTarea(int id, Tarea tarea)
        {
            var tareaIngresada = await _context.Tareas.FindAsync(id);
            if (tareaIngresada == null)
            {
                return false;
            }

            
            if (!await ValidarSetHerramientas(tarea.SetHerramientas))
            {
                return false; 
            }
            tareaIngresada.Estado = tarea.Estado;
            tareaIngresada.FechaInicio = tarea.FechaInicio;
            tareaIngresada.Horas = tarea.Horas;
            tareaIngresada.Area = tarea.Area;
            tareaIngresada.SetHerramientas = tarea.SetHerramientas;

            await _context.SaveChangesAsync();
            return true;
        }

        
        public async Task<bool> EliminarTarea(int id)
        {
            var tareaIngresada = await _context.Tareas.FindAsync(id);
            if (tareaIngresada == null)
            {
                return false;
            }

            _context.Tareas.Remove(tareaIngresada);
            await _context.SaveChangesAsync();
            return true;
        }

        
        public async Task<bool> ValidarSetHerramientas(string setHerramientas)
        {
            
            var idsHerramientas = setHerramientas.Split(',')
                .Select(id => int.TryParse(id, out int validId) ? validId : (int?)null)
                .Where(id => id.HasValue) 
                .Select(id => id.Value)
                .ToList();

            
            var herramientasExistentes = await _context.Herramientas
                .Where(h => idsHerramientas.Contains(h.Id))
                .ToListAsync();

            
            return herramientasExistentes.Count == idsHerramientas.Count;
        }
    }
}
