using Microsoft.AspNetCore.Mvc;
using Evaluacion2.DTO;
using Evaluacion2.Models;

namespace Evaluacion2.Services
{
    public class ProyectoServices
    {
        public async Task<List<Proyecto>> ListaProyectos()
        {
            List<Proyecto> pro = new List<Proyecto>();

            pro = Proyecto.CargarProyectos();

            return pro;
        }

        public async Task<Proyecto> ObtenerProyecto(int Id)
        {
            Proyecto proyecto = new Proyecto();

            proyecto = Proyecto.CargarProyecto();

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
            return false;
        }
    }
}
