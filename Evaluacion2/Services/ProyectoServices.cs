using Evaluacion2.DTO;
using Evaluacion2.Models;
using System.Threading;


namespace Evaluacion2.Services
{
    public class ProyectoServices
    {
        
        public async Task<List<Proyecto>> ListaProyectos()
        {
            List<Proyecto> proyectos = Proyecto.CargarProyectos();

            proyectos = Proyecto.CargarProyectos();
            return proyectos; 
        }

        
        public async Task<Proyecto> ObtenerProyecto(int Id)
        {
            Proyecto proyecto = Proyecto.CargarProyecto(Id);

            proyecto = Proyecto.CargarProyecto(Id);

            return proyecto; 
        }

        public async Task<bool> IngresarProyecto(ProyectoDTO proyecto)
        {
            
            return true; 
        }

        public async Task<bool> ActualizarProyecto(int Id, ProyectoDTO proyecto)
        {
            
            return true; 
        }

        public async Task<bool> EliminarProyecto(int Id)
        {
  
            return true; 
        }
    }
}
