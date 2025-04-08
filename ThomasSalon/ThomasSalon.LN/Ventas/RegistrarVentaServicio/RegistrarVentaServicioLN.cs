using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ThomasSalon.Abstracciones.AccesoADatos.Interfaces.Ventas.RegistrarVentaServicio;
using ThomasSalon.Abstracciones.LN.Ventas.RegistrarVentaServicio;
using ThomasSalon.Abstracciones.Modelos.Ventas.RegistrarVentaServicio;
using ThomasSalon.AccesoADatos.Ventas.RegistrarVentaServicio;

namespace ThomasSalon.LN.Ventas.RegistrarVentaServicio
{
    public class RegistrarVentaServicioLN : IRegistrarVentaServicioLN
    {
        IRegistrarVentaServicioAD _ventaServicioAD;

        public RegistrarVentaServicioLN()
        {
            _ventaServicioAD = new RegistrarVentaServicioAD();
        }
        public async Task<int> RegistrarVentaServicio(RegistrarVentaServicioDTO ventaServicio)
        {
            return await _ventaServicioAD.RegistrarVentaServicio(ventaServicio);
        }
    }
}
