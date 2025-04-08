using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ThomasSalon.Abstracciones.ModelosDeBaseDeDatos
{
    [Table("PEDIDOS")]
    public class PedidosTabla
    {
        [Key]
        public Guid IdPedido { get; set; }

        [Required]
        public int IdEstadoPedido { get; set; }

        [Required]
        public int? IdSucursal { get; set; }

        [Required]
        [StringLength(128)]
        public string IdUsuario { get; set; }

        [Required]
        public Guid IdMetodoPago { get; set; }

        [Required]
        public Guid IdTipoEntrega { get; set; }

        public Guid? IdProvincia { get; set; }

        [StringLength(255)]
        public string DireccionExacta { get; set; }

        [StringLength(255)]
        public string Comentario { get; set; }

        [Required]
        public DateTime Fecha { get; set; } = DateTime.Now;

        [Required]
        public decimal MontoTotal { get; set; }
        public decimal MontoIVA { get; set; }

        public Guid? IdAdjuntos { get; set; }






    }
}
