using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Evaluacion2.Models
{
    public class Proyecto
    {
        [Key] 
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]  
        public int Id { get; set; }

        [Required(ErrorMessage = "El nombre es obligatorio.")]
        public string Nombre { get; set; }

        [Required(ErrorMessage = "La descripción es obligatoria.")]
        public string Descripcion { get; set; }

        [Required(ErrorMessage = "El estado es obligatorio.")]
        [RegularExpression(@"^(Pendiente|En progreso|Finalizado)$", ErrorMessage = "Estado no válido. Debe ser 'Pendiente', 'En progreso' o 'Finalizado'.")]
        public string Estado { get; set; }

        [Required]
        [Range(0, int.MaxValue, ErrorMessage = "Las horas trabajadas deben ser al menos 0.")]
        public int HorasTrabajadas { get; set; } = 0;  

        [Required(ErrorMessage = "Las horas totales son obligatorias.")]
        [Range(1, int.MaxValue, ErrorMessage = "Las horas totales deben ser al menos 1.")]
        public int HorasTotales { get; set; }

        [Required(ErrorMessage = "La fecha de creación es obligatoria.")]
        public DateTime FechaCreacion { get; set; } = DateTime.Now;  
    }
}

