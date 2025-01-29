using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ThomasSalon.Abstracciones.Modelos.Proveedores;
using ThomasSalon.Abstracciones.Modelos.Sucursales;

namespace ThomasSalon.Abstracciones.LN.Interfaces.Proveedores.ObtenerPorId
{
    public interface IObtenerProveedoresPorIdLN
    {
        ProveedoresDto Obtener(int IdProveedores);
    }
}
