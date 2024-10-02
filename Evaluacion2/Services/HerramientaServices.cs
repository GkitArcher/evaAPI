using Evaluacion2.Data;
using Evaluacion2.Models;
using Microsoft.EntityFrameworkCore;


namespace Evaluacion2.Services
{
    public class HerramientaServices
    {
        private readonly ProyectoDBContext _context;

        public HerramientaServices(ProyectoDBContext context)
        {
            _context = context;
        }

        
        public async Task<List<Herramienta>> ObtenerTodasLasHerramientas()
        {
            return await _context.Herramientas.ToListAsync();
        }

        
        public async Task<Herramienta> ObtenerHerramientaPorId(int id)
        {
            return await _context.Herramientas.FindAsync(id);
        }

        
        public async Task CrearHerramienta(Herramienta herramienta)
        {
            _context.Herramientas.Add(herramienta);
            await _context.SaveChangesAsync();
        }

        
        public async Task<bool> ActualizarHerramienta(int id, Herramienta herramienta)
        {
            var herramientaExistente = await _context.Herramientas.FindAsync(id);
            if (herramientaExistente == null)
            {
                return false;
            }

            
            herramientaExistente.Nombre = herramienta.Nombre;

            await _context.SaveChangesAsync();
            return true;
        }


        
        public async Task<bool> EliminarHerramienta(int id)
        {
            var herramientaExistente = await _context.Herramientas.FindAsync(id);
            if (herramientaExistente == null)
            {
                return false;
            }

            _context.Herramientas.Remove(herramientaExistente);
            await _context.SaveChangesAsync();
            return true;
        }
    }
}
