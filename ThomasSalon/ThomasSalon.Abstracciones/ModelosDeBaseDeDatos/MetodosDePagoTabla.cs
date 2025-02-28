using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ThomasSalon.Abstracciones.ModelosDeBaseDeDatos
{
    [Table("METODOS_PAGO")]
    public class MetodosDePagoTabla
    {
        [Key]
        public Guid IdMetodoPago { get; set; }
        public string Nombre { get; set; }


    }
}
