using System;

public class Class1
{
	public Class1()
	{

    public int Id { get; set; }
    public DateTime FechaInicio { get; set; }
    public string Estado { get; set; } // Valores permitidos: "Pendiente", "En progreso", "Finalizado"
    public int Horas { get; set; }
    public string Area { get; set; } // Valores permitidos: "Hardware", "Redes"
    public int ProyectoId { get; set; } // ForeignKey a Proyecto
    public Proyecto Proyecto { get; set; }
    public int EmpleadoAsignadoId { get; set; } // ForeignKey a Usuario
    public Usuario EmpleadoAsignado { get; set; }
    public string SetHerramientas { get; set; } // IDs de herramientas separados por comas

}
}
