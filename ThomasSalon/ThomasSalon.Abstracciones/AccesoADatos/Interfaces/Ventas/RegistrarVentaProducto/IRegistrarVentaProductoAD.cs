using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ThomasSalon.Abstracciones.Modelos.Ventas.RegistrarVentaProducto;

namespace ThomasSalon.Abstracciones.AccesoADatos.Interfaces.Ventas.RegistrarVentaProducto
{
    public interface IRegistrarVentaProductoAD
    {
        Task<int> RegistrarVentaProducto(RegistrarVentaProductoDTO ventaProducto);

    }
}
