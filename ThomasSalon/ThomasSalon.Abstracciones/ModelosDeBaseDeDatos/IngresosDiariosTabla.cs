using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ThomasSalon.Abstracciones.ModelosDeBaseDeDatos
{
    [Table("INGRESOS_DIARIOS")]
    public class IngresosDiariosTabla
    {
        [Key]
        public Guid IdIngreso { get; set; }

        [Required]
        public DateTime Fecha { get; set; } = DateTime.Now;

        [Required]
        public int IdSucursal { get; set; }

        [Required]
        public decimal MontoTotalDia { get; set; } = 0;

        [Required]
        public decimal MontoTotalTransferencias { get; set; } = 0;

        [Required]
        public decimal MontoTotalSinpe { get; set; } = 0;

        [Required]
        public decimal MontoTotalTarjeta { get; set; } = 0;

        [Required]
        public decimal MontoTotalEfectivo { get; set; } = 0;

        [Required]
        public decimal MontoTotalGastos { get; set; } = 0;

    }
}
