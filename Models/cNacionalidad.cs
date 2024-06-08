using System.ComponentModel.DataAnnotations;

namespace practicaV1.Models
{
    public class cNacionalidad
    {
        [Key]
        public int idNacionalidad { get; set; }
        public string pais { get; set; }

        public string nacionalidad { get; set; }
    }
}
