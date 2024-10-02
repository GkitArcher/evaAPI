using Microsoft.EntityFrameworkCore;
using Evaluacion2.Data;
using Evaluacion2.DTO;
using Evaluacion2.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;


namespace Evaluacion2.Services
{
    public class ProyectoServices
    {
        private readonly ProyectoDBContext _dbContext;

        public ProyectoServices(ProyectoDBContext dbContext)
        {
            _dbContext = dbContext;
        }

        
        public async Task<Proyecto> CrearProyectoAsync(ProyectoDTO proyectoDTO)
        {
            var proyecto = new Proyecto
            {
                Nombre = proyectoDTO.Nombre,
                Descripcion = proyectoDTO.Descripcion,
                HorasTotales = proyectoDTO.HorasTotales,
                Estado = "Pendiente",  
                FechaCreacion = DateTime.UtcNow
            };

            _dbContext.Proyectos.Add(proyecto);
            await _dbContext.SaveChangesAsync();

            return proyecto;
        }

        
        public async Task<List<Proyecto>> ObtenerProyectosAsync()
        {
            return await _dbContext.Proyectos.ToListAsync();
        }

        
        public async Task<Proyecto> ObtenerProyectoPorIdAsync(int id)
        {
            return await _dbContext.Proyectos.FirstOrDefaultAsync(p => p.Id == id);
        }

        
        public async Task<bool> ActualizarProyectoAsync(int id, ProyectoDTO proyectoDTO)
        {
            var proyectoExistente = await _dbContext.Proyectos.FindAsync(id);

            if (proyectoExistente == null)
            {
                return false; 
            }

            proyectoExistente.Nombre = proyectoDTO.Nombre;
            proyectoExistente.Descripcion = proyectoDTO.Descripcion;
            proyectoExistente.HorasTotales = proyectoDTO.HorasTotales;

            _dbContext.Proyectos.Update(proyectoExistente);
            await _dbContext.SaveChangesAsync();

            return true;
        }

        
        public async Task<bool> EliminarProyectoAsync(int id)
        {
            var proyecto = await _dbContext.Proyectos.FindAsync(id);

            if (proyecto == null)
            {
                return false; 
            }

            _dbContext.Proyectos.Remove(proyecto);
            await _dbContext.SaveChangesAsync();

            return true;
        }

        
        public async Task<bool> ActualizarEstadoProyectoAsync(int id, string nuevoEstado)
        {
            var proyecto = await _dbContext.Proyectos.FindAsync(id);

            if (proyecto == null || (nuevoEstado != "Pendiente" && nuevoEstado != "En progreso" && nuevoEstado != "Finalizado"))
            {
                return false; 
            }

            proyecto.Estado = nuevoEstado;
            _dbContext.Proyectos.Update(proyecto);
            await _dbContext.SaveChangesAsync();

            return true;
        }

        
        public async Task<bool> AgregarHorasTrabajadasAsync(int id, int horasTrabajadas)
        {
            var proyecto = await _dbContext.Proyectos.FindAsync(id);

            if (proyecto == null || horasTrabajadas < 0)
            {
                return false; 
            }

            proyecto.HorasTrabajadas += horasTrabajadas;

            
            if (proyecto.HorasTrabajadas > proyecto.HorasTotales)
            {
                proyecto.HorasTrabajadas = proyecto.HorasTotales; 
            }

            _dbContext.Proyectos.Update(proyecto);
            await _dbContext.SaveChangesAsync();

            return true;
        }
    }
}


