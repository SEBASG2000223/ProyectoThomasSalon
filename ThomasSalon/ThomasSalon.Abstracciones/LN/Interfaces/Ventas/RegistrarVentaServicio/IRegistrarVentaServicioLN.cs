using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ThomasSalon.Abstracciones.Modelos.InventarioSucursal;
using ThomasSalon.Abstracciones.Modelos.Ventas.RegistrarVentaServicio;

namespace ThomasSalon.Abstracciones.LN.Ventas.RegistrarVentaServicio
{
    public interface IRegistrarVentaServicioLN
    {
        Task<int> RegistrarVentaServicio(RegistrarVentaServicioDTO ventaServicio);
    }
}
