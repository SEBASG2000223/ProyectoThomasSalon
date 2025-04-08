using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ThomasSalon.Abstracciones.Modelos.TiposServicios;
using ThomasSalon.Abstracciones.Modelos.Ventas.Resumen;

namespace ThomasSalon.Abstracciones.LN.Interfaces.Ventas.Resumen
{
    public interface IResumenVentaLN
    {

        Task<List<ResumenVentasDTO>> Listar();
    }
}
