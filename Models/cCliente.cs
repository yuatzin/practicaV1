
using System.ComponentModel.DataAnnotations;

namespace practicaV1.Models
{
    public class cCliente
    {
        [Key]
        public int idCliente { get; set; }
        public string nombre { get; set; }
        public string direccion { get; set; }
        public string  documento { get; set; }
        public string telefono   { get; set; }
        public int fkNacionalidad { get; set; }

    }
}
