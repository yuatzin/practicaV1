using System.ComponentModel.DataAnnotations;

namespace practicaV1.Models
{
    public class cAlquiler
    {
        [Key]

        public int idAlquiler { get; set; }
        public DateTime fechaHoraEntrada { get; set; }
        public DateTime fechaHoraSalida { get; set; }
        public decimal costoTotal { get; set; }
        public string observacion { get; set; }
        public int fkHabitacion { get; set; }
        public int fkCliente { get; set; }
        public int fkRegistrador { get; set; }
        public int fkEstado { get; set; }
    }
}
