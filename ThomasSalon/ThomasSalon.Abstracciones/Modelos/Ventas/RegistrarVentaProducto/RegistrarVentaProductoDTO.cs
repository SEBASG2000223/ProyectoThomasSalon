using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ThomasSalon.Abstracciones.Modelos.Ventas.RegistrarVentaProducto
{
    public class RegistrarVentaProductoDTO
    {
        public int IdColaborador { get; set; }
        public Guid IdMetodoPago { get; set; }
        public int IdPersona { get; set; }
        public int IdSucursal { get; set; }
        public List<ProductoVentaDTO> Productos { get; set; }
        public string Cedula { get; set; }
        public string NombrePersona { get; set; }
    }

    public class ProductoVentaDTO
    {
        public int IdProducto { get; set; }
        public int Cantidad { get; set; }
        public decimal PrecioUnitario { get; set; }
    }


}
