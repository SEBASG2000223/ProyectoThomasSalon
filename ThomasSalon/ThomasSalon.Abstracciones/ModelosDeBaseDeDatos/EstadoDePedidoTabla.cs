using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ThomasSalon.Abstracciones.ModelosDeBaseDeDatos
{
    [Table("ESTADO_PEDIDO")]
    public class EstadoDePedidoTabla
    {
        [Key]
        public int IdEstadoPedido { get; set; }
        public string Nombre { get; set; }
        public string Descripcion { get; set; }





    }
}
