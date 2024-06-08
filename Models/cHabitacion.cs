using System.ComponentModel.DataAnnotations;

namespace practicaV1.Models
{
    public class cHabitacion
    {
        [Key]
        public int idHabitacion { get;set; }
        public int numero { get; set; }
        public string estado { get; set; }
        public decimal costo { get; set; }
        public string descripcion { get; set; }
        public int fkTipo { get; set; }
    }
}
