using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ThomasSalon.Abstracciones.Modelos.Personas;
using ThomasSalon.Abstracciones.Modelos.Sucursales;

namespace ThomasSalon.Abstracciones.Modelos.Pedidos
{
    public class PedidosDto
    {

        public Guid IdPedido { get; set; }
        public Guid? IdAdjuntos { get; set; }
        [Required]
        [Display(Name = "Estado", Description = "Estado")]
        public string EstadoPedido { get; set; }
        [Required]

        public string Sucursal { get; set; }
        [Required]
        public string Usuario { get; set; }
        [Required]
        [Display(Name = "Metodo Pago", Description = "Metodo Pago")]
        public string MetodoPago { get; set; }
        [Required]
        [Display(Name = "Tipo de Entrega", Description = "Tipo de Entrega")]

        public string TipoEntrega { get; set; }
        [Required]
        public string Provincia { get; set; }
        [Required]
        [Display(Name = "Direccion Exacta", Description = "Direccion Exacta")]
        public string DireccionExacta { get; set; }
        [Required]
        public string Comentario { get; set; }
        [Required]
        public DateTime Fecha { get; set; }
        [Required]
        [Display(Name = "Monto Total", Description = "Monto Total")]
        public decimal MontoTotal { get; set; }
        [Display(Name = "Monto IVA", Description = "Monto IVA")]
        public decimal MontoIVA { get; set; }




    }
}
