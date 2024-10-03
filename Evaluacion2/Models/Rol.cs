using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace Evaluacion2.Models
{
    public class Rol
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)] 
        public int Id { get; set; }
        [Required(ErrorMessage = "El nombre del rol es obligatorio.")]
        public string Nombre { get; set; }
        public ICollection<Usuario> Usuarios { get; set; }
    }
}
