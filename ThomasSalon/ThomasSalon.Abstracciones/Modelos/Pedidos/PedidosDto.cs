using System;
using System.Collections.Generic;
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
        public string EstadoPedido { get; set; }
        public string Sucursal { get; set; }
        public string Usuario { get; set; }
        public string MetodoPago { get; set; }
        public string TipoEntrega { get; set; }
        public string Provincia { get; set; }
        public string DireccionExacta { get; set; }
        public string Comentario { get; set; }
        public DateTime Fecha { get; set; }
        public decimal MontoTotal { get; set; }
        public decimal MontoIVA { get; set; }




    }
}
