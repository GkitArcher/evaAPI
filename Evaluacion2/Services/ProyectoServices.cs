using Microsoft.EntityFrameworkCore;
using Evaluacion2.Data;
using Evaluacion2.DTO;
using Evaluacion2.Models;

namespace Evaluacion2.Services
{
    public class ProyectoServices
    {
        private readonly ProyectoDBContext _context;

        public ProyectoServices(ProyectoDBContext context)
        {
            _context = context;
        }

        
        public async Task<Proyecto> CrearProyecto(ProyectoDTO proyectoDTO)
        {
            var proyecto = new Proyecto
            {
                Nombre = proyectoDTO.Nombre,
                Descripcion = proyectoDTO.Descripcion,
                HorasTotales = proyectoDTO.HorasTotales,
                Estado = "Pendiente",  
                FechaCreacion = DateTime.UtcNow
            };

            _context.Proyectos.Add(proyecto);
            await _context.SaveChangesAsync();
            return proyecto;
        }

        
        public async Task<List<Proyecto>> ObtenerProyectos()
        {
            return await _context.Proyectos.ToListAsync();
        }

        
        public async Task<Proyecto> ObtenerProyectoPorId(int id)
        {
            return await _context.Proyectos.FirstOrDefaultAsync(p => p.Id == id);
        }

        
        public async Task<bool> ActualizarProyecto(int id, ProyectoDTO proyectoDTO)
        {
            var proyectoIngresado = await _context.Proyectos.FindAsync(id);

            if (proyectoIngresado == null)
            {
                return false; 
            }

            proyectoIngresado.Nombre = proyectoDTO.Nombre;


            proyectoIngresado.Descripcion = proyectoDTO.Descripcion;


            proyectoIngresado.HorasTotales = proyectoDTO.HorasTotales;

            _context.Proyectos.Update(proyectoIngresado);

            return true;
        }

        
        public async Task<bool> EliminarProyecto(int id)
        {
            var proyecto = await _context.Proyectos.FindAsync(id);

            if (proyecto == null)
            {
                return false; 
            }

            _context.Proyectos.Remove(proyecto);
            

            return true;
        }
    }
}


