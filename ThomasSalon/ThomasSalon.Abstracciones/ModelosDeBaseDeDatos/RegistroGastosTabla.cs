using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ThomasSalon.Abstracciones.ModelosDeBaseDeDatos
{
    [Table("REGISTRO_GASTOS")]
    public class RegistroGastosTabla
    {
        [Key]
        public Guid IdGastos { get; set; }

        [Required]
        public DateTime Fecha { get; set; }

        [Required]
        public Guid IdIngreso { get; set; }

        [Required]
        public decimal Monto { get; set; }

        public int? IdColaborador { get; set; }

        [Required]
        [StringLength(100)]
        public string Descripcion { get; set; }


    }
}
