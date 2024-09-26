namespace Evaluacion2.Models
{
    public class Proyecto
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
        public string Descripcion { get; set; }
        public string Estado { get; set; }
        public int HorasTrabajadas { get; set; } = 0;
        public int HorasTotales { get; set; }
        public DateTime FechaCreacion { get; set; } = DateTime.Now;


        public static List<Proyecto> CargarProyectos()
        {
            return new List<Proyecto>
            {
                new Proyecto { Id = 1, 
                    Nombre = "Proyecto 1", 
                    Descripcion = "Descripción del primer proyecto", 
                    Estado = "Pendiente", 
                    HorasTrabajadas = 0, 
                    HorasTotales = 100, 
                    FechaCreacion = DateTime.Now },

                new Proyecto { Id = 2, 
                    Nombre = "Proyecto 2", 
                    Descripcion = "Descripción del segundo proyecto", 
                    Estado = "En progreso", 
                    HorasTrabajadas = 50, 
                    HorasTotales = 200, 
                    FechaCreacion = DateTime.Now },

                new Proyecto { Id = 3, 
                    Nombre = "Proyecto 3", 
                    Descripcion = "Descripción del tercer proyecto", 
                    Estado = "Finalizado", 
                    HorasTrabajadas = 200, 
                    HorasTotales = 200, 
                    FechaCreacion = DateTime.Now }
            };
        }

        public static Proyecto CargarProyecto(int id)
        {
            return CargarProyectos().Find(p => p.Id == id);
        }
    }
}
