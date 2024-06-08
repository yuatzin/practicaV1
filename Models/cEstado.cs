using System.ComponentModel.DataAnnotations;

namespace practicaV1.Models
{
    public class cEstado
    {
        [Key]
        public int idEstado { get; set; }
        public string nombre { get; set; }
    }
}
