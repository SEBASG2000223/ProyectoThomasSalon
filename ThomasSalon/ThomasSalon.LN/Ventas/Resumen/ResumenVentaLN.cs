using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ThomasSalon.Abstracciones.AccesoADatos.Interfaces.Sucursales.Listar;
using ThomasSalon.Abstracciones.AccesoADatos.Interfaces.Ventas.Resumen;
using ThomasSalon.Abstracciones.LN.Interfaces.Ventas.Resumen;
using ThomasSalon.Abstracciones.Modelos.Sucursales;
using ThomasSalon.Abstracciones.Modelos.Ventas.Resumen;
using ThomasSalon.AccesoADatos.Sucursales.Listar;
using ThomasSalon.AccesoADatos.Ventas.Resumen;

namespace ThomasSalon.LN.Ventas.Resumen
{
    public class ResumenVentaLN : IResumenVentaLN
    {
        IResumenVentaAD _listarVentasAD;

        public ResumenVentaLN()
        {
            _listarVentasAD = new ResumenVentaAD();
        }

        public async Task<List<ResumenVentasDTO>> Listar()
        {
            List<ResumenVentasDTO> ventas = await _listarVentasAD.Listar();
            return ventas;
        }
    }
}
