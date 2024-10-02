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

        
        public async Task CrearTarea(Tarea tarea)
        {
            _context.Tareas.Add(tarea);
            await _context.SaveChangesAsync();
        }

        
        public async Task<bool> ActualizarTarea(int id, Tarea tarea)
        {
            var tareaExistente = await _context.Tareas.FindAsync(id);
            if (tareaExistente == null)
            {
                return false;
            }

            
            tareaExistente.Estado = tarea.Estado;
            tareaExistente.FechaInicio = tarea.FechaInicio;
            tareaExistente.Horas = tarea.Horas;
            tareaExistente.Area = tarea.Area;
            tareaExistente.SetHerramientas = tarea.SetHerramientas;

            await _context.SaveChangesAsync();
            return true;
        }


        
        public async Task<bool> EliminarTarea(int id)
        {
            var tareaExistente = await _context.Tareas.FindAsync(id);
            if (tareaExistente == null)
            {
                return false;
            }

            _context.Tareas.Remove(tareaExistente);
            await _context.SaveChangesAsync();
            return true;
        }
    }
}
