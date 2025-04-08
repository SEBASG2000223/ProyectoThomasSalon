using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ThomasSalon.Abstracciones.AccesoADatos.Interfaces.Ventas.RegistrarVentaProducto;
using ThomasSalon.Abstracciones.LN.Interfaces.Ventas.RegistrarVentaProducto;
using ThomasSalon.Abstracciones.Modelos.Ventas.RegistrarVentaProducto;
using ThomasSalon.AccesoADatos.Ventas.RegistrarVentaProducto;

namespace ThomasSalon.LN.Ventas.RegistrarVentaProducto
{
    public class RegistrarVentaProductoLN : IRegistrarVentaProductoLN
    {
        IRegistrarVentaProductoAD _ventaProductoAD;

        public RegistrarVentaProductoLN()
        {
            _ventaProductoAD = new RegistrarVentaProductoAD();
        }
        public async Task<int> RegistrarVentaProducto(RegistrarVentaProductoDTO ventaProducto)
        {
            return await _ventaProductoAD.RegistrarVentaProducto(ventaProducto);
        }
    }
}

