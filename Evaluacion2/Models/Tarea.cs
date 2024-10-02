using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Evaluacion2.Models
{
    public class Tarea
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "La fecha de inicio es obligatoria.")]
        public DateTime FechaInicio { get; set; }

        [Required(ErrorMessage = "El estado de la tarea es obligatorio.")]
        [RegularExpression(@"^(Pendiente|En progreso|Finalizado)$", ErrorMessage = "Estado no válido.")]
        public string Estado { get; set; }

        [Required(ErrorMessage = "Las horas son obligatorias.")]
        [Range(1, int.MaxValue, ErrorMessage = "Las horas deben ser al menos 1.")]
        public int Horas { get; set; }

        [Required(ErrorMessage = "El área es obligatoria.")]
        [RegularExpression(@"^(Hardware|Redes)$", ErrorMessage = "Área no válida.")]
        public string Area { get; set; }

        [Required(ErrorMessage = "El ID del proyecto es obligatorio.")]
        public int ProyectoId { get; set; }

        [Required(ErrorMessage = "El ID del empleado es obligatorio.")]
        public int EmpleadoId { get; set; }

        [Required(ErrorMessage = "El set de herramientas es obligatorio.")]
        public string SetHerramientas { get; set; }

    }
}
