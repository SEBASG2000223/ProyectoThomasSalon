using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ThomasSalon.Abstracciones.Modelos.Ventas.RegistrarVentaProducto;

namespace ThomasSalon.Abstracciones.LN.Interfaces.Ventas.RegistrarVentaProducto
{
    public interface IRegistrarVentaProductoLN
    {
        Task<int> RegistrarVentaProducto(RegistrarVentaProductoDTO ventaProducto);
    }
}
