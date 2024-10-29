using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace JimenezAndres_Examen_Pgr1.Models
{
    public class Celular
    {
        [Key]
        public int Id { get; set; }

        [MaxLength(50)]
        [Required(ErrorMessage = "El modeloes obligatorio")]
        public string Modelo { get; set; }

        [DataType(DataType.Date)]
        public DateOnly Year { get; set; }

        [Range(0, 1200)]
        public string Precio { get; set; }
        public AJimenez? Cliente {  get; set; }
        
        [ForeignKey("Cliente")]
        public int IdCliente { get; set; }

    }
}
