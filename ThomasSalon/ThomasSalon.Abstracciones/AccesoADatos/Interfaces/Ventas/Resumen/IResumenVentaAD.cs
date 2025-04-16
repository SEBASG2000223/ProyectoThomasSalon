using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ThomasSalon.Abstracciones.Modelos.TiposServicios;
using ThomasSalon.Abstracciones.Modelos.Ventas.Resumen;

namespace ThomasSalon.Abstracciones.AccesoADatos.Interfaces.Ventas.Resumen
{
    public interface IResumenVentaAD
    {
        Task<List<ResumenVentasDTO>> Listar();
    }
}
