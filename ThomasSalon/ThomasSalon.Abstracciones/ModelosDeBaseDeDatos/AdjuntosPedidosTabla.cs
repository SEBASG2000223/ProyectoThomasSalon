using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ThomasSalon.Abstracciones.ModelosDeBaseDeDatos
{
    [Table("ADJUNTOS_PEDIDOS")]
    public class AdjuntosPedidosTabla
    {
        [Key]

        public Guid IdAdjuntos {  get; set; }
        public byte[] Adjunto {  get; set; }
    }
}
