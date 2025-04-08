using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ThomasSalon.Abstracciones.Modelos.Ventas.Resumen
{
    public class ResumenVentasDTO
    {
        public Guid IdVenta { get; set; }
        public DateTime Fecha { get; set; }
        public decimal MontoTotal { get; set; }

        public string NombreCliente { get; set; }
        public string Telefono { get; set; }
        public string Identificacion { get; set; }

        public string NombreColaborador { get; set; }
        public string MetodoPago { get; set; }
        public string NombreSucursal { get; set; }

        public decimal MontoTotalDia { get; set; }
        public decimal MontoTotalTransferencias { get; set; }
        public decimal MontoTotalSinpe { get; set; }
        public decimal MontoTotalTarjeta { get; set; }
        public decimal MontoTotalEfectivo { get; set; }
        public decimal MontoTotalGastos { get; set; }
    }
}
