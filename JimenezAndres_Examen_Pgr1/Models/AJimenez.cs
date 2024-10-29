using System.ComponentModel.DataAnnotations;
using System.Runtime.CompilerServices;

namespace JimenezAndres_Examen_Pgr1.Models
{
    public class AJimenez
    {
        [Key]
        public int Id { get; set; }

        [MaxLength(50)]
        [Required(ErrorMessage = "El nombre es obligatorio")]
        public string Nombre { get; set; }

        [Range(0, 1000)]
        public float Dinero { get; set; }

        [Required]
        public bool MayorEdad {  get; set; }

        [DataType(DataType.Date)]
        public DateTime Cumpleanos { get; set; }
    }
}
